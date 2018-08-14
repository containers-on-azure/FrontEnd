using System.Threading.Tasks;
using FrontEnd.Shared.V1.Models;
using FrontEnd.Web.Clients;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace FrontEnd.Web.Pages
{
    public class IndexModel : PageModel
    {
        private readonly IFrontEndApiClient frontEndApiClient;

        public HomePageViewModel HomePageContents { get; private set; }
        

        public IndexModel(IFrontEndApiClient frontEndApiClient)
        {
            this.frontEndApiClient = frontEndApiClient;
        }

        public async Task OnGet()
        {
            // get contents from api
            this.HomePageContents = await frontEndApiClient.GetHomePage();
        }
    }
}
