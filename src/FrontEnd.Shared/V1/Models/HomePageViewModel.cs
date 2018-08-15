using System;
using System.Collections.Generic;
using System.Text;

namespace FrontEnd.Shared.V1.Models
{
    public class HomePageViewModel
    {
        public string Source { get; set; }

        public IEnumerable<StockViewModel> TopStocks { get; set; }

        public MarketOverviewViewModel[] Markets { get; set; }
    }
}
