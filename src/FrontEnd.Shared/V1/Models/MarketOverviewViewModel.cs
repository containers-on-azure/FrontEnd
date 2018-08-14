using System;
using System.Collections.Generic;
using System.Text;

namespace FrontEnd.Shared.V1.Models
{
    public class MarketOverviewViewModel
    {
        public string Name { get; set; }
        public double Value { get; set; }
        public double ChangeValue { get; set; }
        public double ChangePercentage { get; set; }
    }
}
