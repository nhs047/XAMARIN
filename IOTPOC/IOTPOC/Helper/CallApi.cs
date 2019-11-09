using System;
using System.Net.Http;
using System.Net.Http.Headers;

namespace IOTPOC.Helper
{
    public class CallApi
    {
        public CallApi()
        {
            BaseUrlSet();
        }
        public HttpClient client = new HttpClient();
        public void BaseUrlSet()
        {
            client.BaseAddress = new Uri("http://iotpocapi.azurewebsites.net/api/");
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            client.DefaultRequestHeaders.Add("ApiKey", "IOTPOC_Version_1");
        }
    }
}
