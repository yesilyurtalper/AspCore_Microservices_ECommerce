﻿using static ECommer.ItemUI.StaticData;

namespace ECommer.ItemUI.Services
{
    public class ApiRequest
    {
        public APIMethod ApiMethod { get; set; } = APIMethod.GET;
        public string BaseUrl { get; set; } = "";
        public string RelativeUrl { get; set; } = "";
        public object Data { get; set; }
        public string AccessToken { get; set; }
        public string ApiUrl { get; internal set; }
    }
}
