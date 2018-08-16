using FrontEnd.Shared.V1.Models;
using Microsoft.Extensions.Logging;
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
        private readonly ILogger<FrontEndApiClient> logger;

        public FrontEndApiClient(HttpClient httpClient, ILogger<FrontEndApiClient> logger)
        {
            this.httpClient = httpClient;
            this.logger = logger;
        }

        public async Task<HomePageViewModel> GetHomePage()
        {
            const string apiPath = "/api/v1/contents";
            var sourceUrl = new Uri(httpClient.BaseAddress, apiPath).ToString();
            try
            {
                
                using (var stream = await httpClient.GetStreamAsync(apiPath))
                {
                    using (var reader = new StreamReader(stream))
                    {
                        using (var jsonReader = new JsonTextReader(reader))
                        {
                            var result = new JsonSerializer().Deserialize<HomePageViewModel>(jsonReader);
                            result.Source = sourceUrl;
                            return result;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                logger.LogError(ex, $"Error loading home page contents from {sourceUrl}");
            }

            return new HomePageViewModel
            {
                TopStocks = new StockViewModel[0],
                Markets = new MarketOverviewViewModel[0],
                Source = sourceUrl
            };
        }
    }
}
