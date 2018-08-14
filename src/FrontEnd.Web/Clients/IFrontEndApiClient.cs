using FrontEnd.Shared.V1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FrontEnd.Web.Clients
{
    public interface IFrontEndApiClient
    {
        Task<HomePageViewModel> GetHomePage();
    }
}
