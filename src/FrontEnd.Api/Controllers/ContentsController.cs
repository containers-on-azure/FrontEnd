using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FrontEnd.Shared.V1.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FrontEnd.Api.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class ContentsController : ControllerBase
    {
        [HttpGet]
        [Route("")]
        public ActionResult<HomePageViewModel> GetHomePage()
        {
            // Based on data from https://www.nasdaq.com/ on 2018-08-14
            var content = new HomePageViewModel
            {
                Markets = new MarketOverviewViewModel[]
                {
                    new MarketOverviewViewModel{ Name = "NASDAQ", Value = 7819.71, ChangeValue = -19.4, ChangePercentage = -0.25 },
                    new MarketOverviewViewModel{ Name = "S&P 500", Value = 2821.93, ChangeValue = -11.35, ChangePercentage = -0.40 },
                },

                TopStocks = new StockViewModel[]
                {
                    new StockViewModel { Symbol = "aapl", Name = "Apple Inc.", LastSale = 208.87m, ChangeValue = 1.34m, ChangePercentage = .65, ShareVolume = 25180005 },
                    new StockViewModel { Symbol = "qqq", Name = "Invesco QQQ Trust", LastSale = 180.32m, ChangeValue = -.20m, ChangePercentage = -.11, ShareVolume = 23852259},
                    new StockViewModel { Symbol = "mu", Name = "Micron Technology", LastSale = 51.34m, ChangeValue = -.03m, ChangePercentage = -.06, ShareVolume = 23030109 },
                    new StockViewModel { Symbol = "msft", Name = "Microsoft Corporation", LastSale = 108.21m, ChangeValue = -.79m, ChangePercentage = -.72, ShareVolume = 17892142 },
                    new StockViewModel { Symbol = "csco", Name = "Cisco Systems", LastSale = 43.75m, ChangeValue = -.03m, ChangePercentage = -.07, ShareVolume = 17546299 },
                }
            };

            return content;
        }
    }
}