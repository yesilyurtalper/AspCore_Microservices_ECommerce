namespace ECommerce.Web
{
    public static class StaticData
    {
        public enum APIClient
        {
            ItemAPI,
            IdentityServer,
            SoppingCartAPI,
            CouponAPI,
        }
        public static string ItemAPIBaseUrl { get; set; }
        public static string IdentityServerBaseUrl { get; set; }

        public static string KeycloakRealm { get; set; }
        public static string ShoppingCartAPIBaseUrl { get; set; }
        public static string CouponAPIBaseUrl { get; set; }

        public enum APIMethod
        {
            GET,
            POST,
            PUT,
            DELETE 
        }
    }
}
