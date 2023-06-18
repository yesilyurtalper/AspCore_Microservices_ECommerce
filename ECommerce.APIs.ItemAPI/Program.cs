
using ECommerce.ItemService.API.Models;
using ECommerce.ItemService.Application;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using ECommerce.ItemService.Infra;
using System.Text.Json.Serialization;
using ECommerce.ItemService.Infra.DBContext;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

//builder.Services.AddControllers().AddNewtonsoftJson(options =>
//    options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);

builder.Services.AddControllers().AddJsonOptions(options =>
    options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);

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

builder.Services.AddApplicationServices();
builder.Services.AddInfraServices(builder.Configuration);

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
    options.AddPolicy("ECommerceWebClient", policy =>
    {
        policy.RequireClaim("ECommerceWebClient", "ECommerceWebClient");
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
using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider
        .GetRequiredService<ItemAPIDbContext>();

    // Here is the migration executed
    dbContext.Database.Migrate();
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers().RequireAuthorization("ECommerceWebClient");

app.Run();
