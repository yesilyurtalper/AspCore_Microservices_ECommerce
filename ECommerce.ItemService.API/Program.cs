
using ECommerce.ItemService.API.Models;
using ECommerce.ItemService.Application;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using ECommerce.ItemService.Infra;
using System.Text.Json.Serialization;
using ECommerce.ItemService.Infra.DBContext;
using Microsoft.EntityFrameworkCore;
using ECommerce.ItemService.API.Middleware;
using Autofac;
using ECommerce.ItemService.API.Filters;
using Autofac.Core;
using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args); 
var Services = builder.Services;

Services.AddControllers(options => { 
    options.Filters.Add(new ValidationFilter()); }).
    AddJsonOptions(options =>
        options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);

Services.Configure<ApiBehaviorOptions>(options =>
{
    options.SuppressModelStateInvalidFilter = true;
});

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
if (builder.Environment.IsDevelopment())
{
    Services.AddEndpointsApiExplorer();
    Services.AddSwaggerGen(c => {

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

Services.AddInfraServices(builder.Configuration);
Services.AddApplicationServices();

Services.AddAuthentication("Bearer").AddJwtBearer("Bearer", options =>
{
    options.Authority = Environment.GetEnvironmentVariable("OIDC_AUTHORITY");
    options.RequireHttpsMetadata = false;
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateAudience = false
    };
});

Services.AddAuthorization(options =>
{
    options.AddPolicy("ECommerceWebClient", policy =>
    {
        policy.RequireClaim("ECommerceWebClient", "ECommerceWebClient");
    });
});

Services.AddAuthorization(options =>
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
    var dbContext = scope.ServiceProvider.GetRequiredService<ItemAPIDbContext>();
    dbContext.Database.Migrate();
}

//custom global exception handling middleware
app.UseExceptionMiddleware();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//app.UseSerilogRequestLogging();

app.UseHttpsRedirection();
app.UseCors("all");

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers().RequireAuthorization("ECommerceWebClient");

app.Run();
