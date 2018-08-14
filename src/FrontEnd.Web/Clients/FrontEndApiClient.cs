using FrontEnd.Shared.V1.Models;
using Newtonsoft.Json;
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
            using (var stream = await httpClient.GetStreamAsync("/api/v1/contents"))
            {
                using (var reader = new StreamReader(stream))
                {
                    using (var jsonReader = new JsonTextReader(reader))
                    {
                        return new JsonSerializer().Deserialize<HomePageViewModel>(jsonReader);
                    }
                }
            }
        }
    }
}
