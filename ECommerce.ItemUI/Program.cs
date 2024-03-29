﻿using System.Globalization; 
using System.IdentityModel.Tokens.Jwt;
using ECommer.ItemUI;
using ECommer.ItemUI.Services;
using Microsoft.IdentityModel.Logging;
using Microsoft.IdentityModel.Protocols.OpenIdConnect;

var builder = WebApplication.CreateBuilder(args);
var services = builder.Services;

//test after renaming

// Add services to the container.
services.AddControllersWithViews();
services.AddControllers();

StaticData.ItemAPIBaseUrl = Environment.GetEnvironmentVariable("ITEM_API_BASE_URL");
StaticData.OIDCClient = Environment.GetEnvironmentVariable("OIDC_CLIENT");
StaticData.OIDCPassword = Environment.GetEnvironmentVariable("OIDC_PASSWORD");
StaticData.OIDCAuthority = Environment.GetEnvironmentVariable("OIDC_AUTHORITY");
//builder.Configuration["ServiceUrls:KeycloakRealm"];

//services.AddHttpClient<IItemService, ItemService>();
services.AddHttpClient(StaticData.APIClient.ItemAPI.ToString(), 
    client => client.BaseAddress = new Uri(StaticData.ItemAPIBaseUrl)
);

services.AddScoped<IItemService, ItemService>();

//services.AddSession(options =>
//{
//    options.Cookie.HttpOnly = true;
//    options.IdleTimeout = TimeSpan.FromHours(8);
//    options.Cookie.IsEssential = true;
//    options.Cookie.Expiration = TimeSpan.FromMinutes(1);
//});

var cultureInfo = new CultureInfo("en-US");
cultureInfo.NumberFormat.CurrencySymbol = "$";
CultureInfo.DefaultThreadCurrentCulture = cultureInfo;
CultureInfo.DefaultThreadCurrentUICulture = cultureInfo;

IdentityModelEventSource.ShowPII = true;
JwtSecurityTokenHandler.DefaultInboundClaimTypeMap.Clear();

services.AddAuthentication(options =>
{
    options.DefaultScheme = "AuthCookies";
    options.DefaultChallengeScheme = "oidc";
}).AddCookie("AuthCookies", options =>
{
    options.ExpireTimeSpan = TimeSpan.FromMinutes(10);
    options.AccessDeniedPath = "/Home/AccessDenied";
    
    options.Events.OnSigningIn = ctx =>
    {
        ctx.Properties.IsPersistent = true;
        return Task.CompletedTask;
    };
}).AddOpenIdConnect("oidc", options =>
{
    options.Authority = StaticData.OIDCAuthority;
    options.GetClaimsFromUserInfoEndpoint = true;
    options.ClientId = StaticData.OIDCClient;
    options.ClientSecret = StaticData.OIDCPassword;
    options.ResponseType = OpenIdConnectResponseType.Code;
    options.RequireHttpsMetadata = false;
    options.Scope.Add("openid");
    options.Scope.Add("profile");
    options.CallbackPath = "/signin-oidc"; // The same as the Redirect URI configured in Keycloak
    options.SaveTokens = true;
    options.Scope.Add("email");
    options.Scope.Add("roles");

    //options.ClaimActions.Add(new JsonKeyClaimAction("azp", null, "azp"));
    //options.ClaimActions.Add(new JsonKeyClaimAction("website", null, "website"));
    //options.ClaimActions.Add(new JsonKeyClaimAction("CustomClaim", null, "CustomClaim"));
    //options.ClaimActions.Add(new JsonKeyClaimAction("role", null, "role"));
    //options.TokenValidationParameters = new TokenValidationParameters
    //{
    //    NameClaimType = "name",
    //    RoleClaimType = "role"
    //};


    //options.Scope.Add("ItemAPIAllScope");
    //options.Scope.Add("OrderAPIAllScope");
    //options.Scope.Add("CouponAPIAllScope");
    //options.SaveTokens = true;
});

services.AddAuthorization(options =>
{
    options.AddPolicy("ECommerceAdmin", policy =>
    {
        policy.RequireClaim("RealmRole", "ECommerceAdmin");
    });
});



var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

//app.UseSession();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers().RequireAuthorization();
    endpoints.MapControllerRoute(
            name: "default",
            pattern: "{controller=Home}/{action=Index}/{id?}").RequireAuthorization();

});

app.Run();
