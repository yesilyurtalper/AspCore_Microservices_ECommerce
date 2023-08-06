namespace ECommerce.ItemService.API.Constants
{
    public class APIConstants
    {
        public static int[] KnownCodes = { 200, 400, 404 };
        public static Dictionary<int, string> StatusDescriptions = new () {
            { 401,"Kullanıcı doğrulanamadı"},
            { 403,"Yetkiniz yetersiz" }
        };
        public static string OrderAPIClient = "OrderAPIClient";
        public static string OrderAPIBaseUrl = "OrderAPIClient";
    }
}
