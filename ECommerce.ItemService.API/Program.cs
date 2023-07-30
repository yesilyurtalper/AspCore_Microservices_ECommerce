
using ECommerce.ItemService.Application;
using ECommerce.ItemService.Infra;
using System.Text.Json.Serialization;
using ECommerce.ItemService.Infra.DBContext;
using Microsoft.EntityFrameworkCore;
using ECommerce.ItemService.API.Filters;
using Microsoft.AspNetCore.Mvc;
using ECommerce.ItemService.API.Extentions;
using ECommerce.ItemService.API.Extensions;

var builder = WebApplication.CreateBuilder(args); 
var services = builder.Services;

services.AddControllers(options => {
    options.Filters.Add<ValidationFilter>();
    }).
    ConfigureApiBehaviorOptions(options =>
    {
        options.SuppressModelStateInvalidFilter = true;
    }).
    AddJsonOptions(options =>
        options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);

services.AddScoped<ResultLoggerAttribute>();

//services.AddLogging(loggingBuilder =>
//{
//    loggingBuilder.ClearProviders();
//    loggingBuilder.AddSerilog();
//});

builder.Host.AddCustomSerilog();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
if (builder.Environment.IsDevelopment())
    services.AddSwaggerServices();

services.AddInfraServices(builder.Configuration);
services.AddApplicationServices();

services.AddAuthServices();

var app = builder.Build();

//Migrate latest database changes during startup
using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<ItemAPIDbContext>();
    dbContext.Database.Migrate();
}

//custom global exception handling middleware
app.UseExceptionMiddleware();
app.UseErrorMiddleware();

//app.UseSerilogRequestLogging();

app.UseHttpsRedirection();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//var elasticAPMSettings = new Dictionary<string, string>();
//elasticAPMSettings.Add("ElasticApm:SecretToken","");
//elasticAPMSettings.Add("ElasticApm:ServerUrl", Environment.GetEnvironmentVariable("ELK_APMURL"));
//elasticAPMSettings.Add("ElasticApm:ServiceName", "ECommerce.ItemService");
//app.UseAllElasticApm(new ConfigurationBuilder().AddInMemoryCollection(elasticAPMSettings).Build());

app.UseCors("all");
//app.UseCors(builder =>
//    builder.WithOrigins(Environment.GetEnvironmentVariable("ALLOWED_ORIGINS").Split(","))
//    .AllowAnyMethod().
//    AllowAnyHeader());

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers().RequireAuthorization("ECommerceWebClient");

app.Run();
