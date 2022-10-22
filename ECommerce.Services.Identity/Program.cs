using Duende.IdentityServer.Services;
using ECommerce.Services.Identity;
using ECommerce.Services.Identity.Services;
using ECommerce.Services.Identity.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlServer("name=DefaultConnection"));

builder.Services.AddIdentity<ApplicationUser, IdentityRole>().
    AddEntityFrameworkStores<AppDbContext>().AddDefaultTokenProviders();

builder.Services.AddIdentityServer(options =>
{
    options.Events.RaiseErrorEvents = true;
    options.Events.RaiseInformationEvents = true;
    options.Events.RaiseFailureEvents = true;
    options.Events.RaiseSuccessEvents = true;
    options.EmitStaticAudienceClaim = true;
}).AddInMemoryIdentityResources(StaticData.IdentityResources)
.AddInMemoryApiScopes(StaticData.APIScopes)
.AddInMemoryClients(StaticData.Clients)
.AddAspNetIdentity<ApplicationUser>()
.AddDeveloperSigningCredential();

builder.Services.AddScoped<IDBInitializer, DBInitializer>();
builder.Services.AddScoped<IProfileService, ProfileService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

//var scope = app.Services.CreateScope();
//var initializer = scope.ServiceProvider.GetService<IDBInitializer>();
//await initializer.InitializeAsync();

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

//app.Use(async(context,next) =>
//{
//    await next();
//});

app.UseIdentityServer();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
