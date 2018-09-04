using FrontEnd.Shared.V1.Models;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace FrontEnd.Api.Services
{
    public class StockApiClient : IStockApiClient
    {
        private readonly HttpClient httpClient;
        private readonly ILogger logger;

        public StockApiClient(HttpClient httpClient, ILogger<StockApiClient> logger)
        {
            this.httpClient = httpClient;
            this.logger = logger;
        }

        public async Task<StockViewModel> GetStock(string symbol)
        {
            string apiPath = $"/api/v1/stocks/{symbol}";
            var sourceUrl = new Uri(httpClient.BaseAddress, apiPath).ToString();
            try
            {
                logger.LogInformation("Loading {symbol} from {url}", symbol, sourceUrl);

                using (var stream = await httpClient.GetStreamAsync(apiPath))
                {
                    using (var reader = new StreamReader(stream))
                    {
                        using (var jsonReader = new JsonTextReader(reader))
                        {
                            var result = new JsonSerializer().Deserialize<StockViewModel>(jsonReader);
                            return result;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                logger.LogError(ex, $"Error loading stock symbol from {sourceUrl}");
            }

            return null;
        }
    }
}
