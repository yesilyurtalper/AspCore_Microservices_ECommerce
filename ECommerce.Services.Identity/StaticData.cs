using Duende.IdentityServer;
using Duende.IdentityServer.Models;

namespace ECommerce.Services.Identity
{
    public static class StaticData
    {
        public const string Admin = "Admin";
        public const string Customer = "Customer";

        public static IEnumerable<IdentityResource> IdentityResources =>
            new List<IdentityResource>
            {
                new IdentityResources.OpenId(),
                new IdentityResources.Email(),
                new IdentityResources.Profile()
            };

        public static IEnumerable<ApiScope> APIScopes =>
            new List<ApiScope>
            {
                new ApiScope("ItemAPIAllScope", "ItemAPIAllScope"),
                new ApiScope("ItemAPIReadScope", "ItemAPIReadScope"),
                new ApiScope("ItemAPIUpdateScope", "ItemAPIUpdateScope"),
                new ApiScope("OrderAPIAllScope", "OrderAPIAllScope"),
                new ApiScope("CouponAPIAllScope", "CouponAPIAllScope"),
                new ApiScope(name:"ECommerceWrite", displayName:"Can write ECommerce items")
            };

        public static IEnumerable<Client> Clients =>
            new List<Client>
            {
                new Client
                {
                    ClientId = "Client",
                    ClientSecrets = { new Secret("secret".Sha256()) },
                    AllowedGrantTypes = GrantTypes.ClientCredentials,
                    AllowedScopes = {"read","write","profile"}
                },
                
                new Client
                {
                    ClientId = "ECommerceWeb",
                    ClientSecrets = { new Secret("secret".Sha256()) },
                    AllowedGrantTypes = GrantTypes.Code,
                    AllowedScopes = new List<string>
                    {
                        IdentityServerConstants.StandardScopes.OpenId,
                        IdentityServerConstants.StandardScopes.Profile,
                        IdentityServerConstants.StandardScopes.Email,
                        "ItemAPIAllScope",
                        "OrderAPIAllScope",
                        "CouponAPIAllScope"
                    },
                    RedirectUris = {"https://localhost:7187/signin-oidc"},
                    PostLogoutRedirectUris = { "https://localhost:7187/signout-callback-oidc" }
                }
            };
    }
}
