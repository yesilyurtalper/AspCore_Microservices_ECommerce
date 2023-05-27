using AutoMapper;
using Microsoft.EntityFrameworkCore;
using ECommerce.APIs.ItemAPI.Services;
using ECommerce.APIs.ItemAPI.Models;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System;
using System.Configuration;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers().AddNewtonsoftJson(options =>
    options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);

builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
if (builder.Environment.IsDevelopment())
{
    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddSwaggerGen(c => {

        //c.OperationFilter<SwaggerRequestHeader>();

        c.AddSecurityDefinition("bearer", new OpenApiSecurityScheme
        {
            Type = SecuritySchemeType.Http,
            BearerFormat = "JWT",
            In = ParameterLocation.Header,
            Scheme = "bearer"
        });
        c.OperationFilter<AuthenticationRequirementsOperationFilter>();
    });
}


//string conStr = "server=localhost;port=3306;database=ECommerceItemAPI;user=root;password=mysecretpassword;";
//string conStr = builder.Configuration.GetConnectionString("DefaultConnection");
string conStr = Environment.GetEnvironmentVariable("DB_CON_STR");
builder.Services.AddDbContext<ItemAPIDbContext>(options => options.UseMySQL(conStr));

IMapper mapper = MappingConfig.RegisterMaps().CreateMapper();
builder.Services.AddSingleton(mapper);
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddScoped<ICategoryRepository, DBCategoryRepository>();
builder.Services.AddScoped<IBrandRepository, DBBrandRepository>();
builder.Services.AddScoped<IProductRepository, DBProductRepository>();

builder.Services.AddAuthentication("Bearer").AddJwtBearer("Bearer", options =>
{
    options.Authority = Environment.GetEnvironmentVariable("OIDC_AUTHORITY");
    options.RequireHttpsMetadata = false;
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateAudience = false,
    };
});

builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("ItemAPIPolicy", policy =>
    {
        policy.RequireClaim("ItemAPIClaim", "ItemAPIClaim");
    });
});

builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("ECommerceAdmin", policy =>
    {
        policy.RequireClaim("RealmRole", "ECommerceAdmin");
    });
});


var app = builder.Build();

//Migrate latest database changes during startup
//using (var scope = app.Services.CreateScope())
//{
//    var dbContext = scope.ServiceProvider
//        .GetRequiredService<ItemAPIDbContext>();

//    // Here is the migration executed
//    dbContext.Database.Migrate();
//}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers().RequireAuthorization("ItemAPIPolicy");

app.Run();
