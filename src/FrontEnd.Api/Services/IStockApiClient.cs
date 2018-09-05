using FrontEnd.Shared.V1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FrontEnd.Api.Services
{
    public interface IStockApiClient
    {
        Task<StockViewModel> GetStock(string symbol);
        string GetSourceName();
    }
}
