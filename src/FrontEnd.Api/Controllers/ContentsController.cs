using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FrontEnd.Api.Services;
using FrontEnd.Shared.V1.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FrontEnd.Api.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class ContentsController : ControllerBase
    {
        private readonly IStockApiClient stockApiClient;

        public ContentsController(IStockApiClient stockApiClient)
        {
            this.stockApiClient = stockApiClient;
        }

        [HttpGet]
        [Route("")]
        public async Task<ActionResult<HomePageViewModel>> GetHomePage()
        {
            // Based on data from https://www.nasdaq.com/ on 2018-08-14
            var content = new HomePageViewModel
            {
                Markets = new MarketOverviewViewModel[]
                {
                    new MarketOverviewViewModel{ Name = "NASDAQ", Value = 7819.71, ChangeValue = -19.4, ChangePercentage = -0.25 },
                    new MarketOverviewViewModel{ Name = "S&P 500", Value = 2821.93, ChangeValue = -11.35, ChangePercentage = -0.40 },
                },                
            };

            var tasks = new Task<StockViewModel>[]
            {
                LoadStockSymbol("aapl"),
                LoadStockSymbol("qqq"),
                LoadStockSymbol("mu"),
                LoadStockSymbol("msft"),
                LoadStockSymbol("csco"),
            };

            await Task.WhenAll(tasks);
            content.TopStocks = tasks
                .Where(t => t.Result != null)
                .Select(t => t.Result)
                .ToList();

            return content;
        }

        private async Task<StockViewModel> LoadStockSymbol(string symbol) => await this.stockApiClient.GetStock(symbol);
    }
}