using AutoMapper;
using Microsoft.EntityFrameworkCore;
using ECommerce.APIs.ItemAPI.Services;
using ECommerce.APIs.ItemAPI.Models;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;

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

builder.Services.AddDbContext<ItemAPIDbContext>(options => options.UseSqlServer("name=DefaultConnection"));

IMapper mapper = MappingConfig.RegisterMaps().CreateMapper();
builder.Services.AddSingleton(mapper);
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddScoped<ICategoryRepository, DBCategoryRepository>();
builder.Services.AddScoped<IBrandRepository, DBBrandRepository>();
builder.Services.AddScoped<IProductRepository, DBProductRepository>();

builder.Services.AddAuthentication("Bearer").AddJwtBearer("Bearer", options =>
{
    options.Authority = "https://localhost:7103/";
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateAudience = false,
    };
});

builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("ItemAPIAllPolicy", policy =>
    {
        policy.RequireClaim("scope", "ItemAPIAllScope");
    });
});


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers().RequireAuthorization("ItemAPIAllPolicy");

app.Run();
