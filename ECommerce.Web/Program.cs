using System.Globalization;
using ECommerce.Web;
using ECommerce.Web.Services;
using Microsoft.AspNetCore.Authentication.OAuth.Claims;
using Microsoft.IdentityModel.Tokens;

var builder = WebApplication.CreateBuilder(args);
var services = builder.Services;

// Add services to the container.
services.AddControllersWithViews();
services.AddControllers();

//Add product service
StaticData.ItemAPIBaseUrl = builder.Configuration["ServiceUrls:ItemAPIBase"];
StaticData.IdentityServerBaseUrl = builder.Configuration["ServiceUrls:IdentityServerBase"];

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
    options.Authority = StaticData.IdentityServerBaseUrl;
    options.GetClaimsFromUserInfoEndpoint = true;
    options.ClientId = "ECommerceWeb";
    options.ClientSecret = "secret";
    options.ResponseType = "code";

    options.ClaimActions.Add(new JsonKeyClaimAction("phone", null, "phone_number"));
    options.ClaimActions.Add(new JsonKeyClaimAction("website", null, "website"));
    options.ClaimActions.Add(new JsonKeyClaimAction("CustomClaim", null, "CustomClaim"));
    options.ClaimActions.Add(new JsonKeyClaimAction("role", null, "role"));
    options.TokenValidationParameters = new TokenValidationParameters
    {
        NameClaimType = "name",
        RoleClaimType = "role"
    };

    options.Scope.Add("email");
    options.Scope.Add("ItemAPIAllScope");
    options.Scope.Add("OrderAPIAllScope");
    options.Scope.Add("CouponAPIAllScope");
    options.SaveTokens = true;
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
