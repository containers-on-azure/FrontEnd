using FrontEnd.Shared.V1.Models;
using Newtonsoft.Json;
using System;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;

namespace FrontEnd.Web.Clients
{
    public class FrontEndApiClient : IFrontEndApiClient
    {
        private readonly HttpClient httpClient;

        public FrontEndApiClient(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        public async Task<HomePageViewModel> GetHomePage()
        {
            const string apiPath = "/api/v1/contents";
            using (var stream = await httpClient.GetStreamAsync(apiPath))
            {
                using (var reader = new StreamReader(stream))
                {
                    using (var jsonReader = new JsonTextReader(reader))
                    {
                        var result = new JsonSerializer().Deserialize<HomePageViewModel>(jsonReader);
                        result.Source = new Uri(httpClient.BaseAddress, apiPath).ToString();
                        return result;
                    }
                }
            }
        }
    }
}
