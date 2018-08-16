using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace FrontEnd.Web.Pages
{
    public class HttpTesterModel : PageModel
    {
        static HttpClient httpClient = new HttpClient();
        private readonly Microsoft.AspNetCore.Antiforgery.IAntiforgery xsrf;

        public HttpTesterModel(Microsoft.AspNetCore.Antiforgery.IAntiforgery xsrf)
        {
            this.xsrf = xsrf;
        }

        public string XsrfToken => xsrf.GetAndStoreTokens(HttpContext).RequestToken;

        

        public void OnGet()
        {

        }

        public class RetrieveContentRequest
        {
            public string url { get; set; }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> OnPostRetrieveContent([FromBody] RetrieveContentRequest url)
        {
            try
            {
                var response = await httpClient.GetAsync(url.url);
                if (!response.IsSuccessStatusCode)
                {
                    var errorContent = await response.Content.ReadAsStringAsync();
                    return new JsonResult(new
                    {
                        status = response.StatusCode.ToString(),
                        errorContent
                    });
                }

                return new ContentResult()
                {
                    Content = await response.Content.ReadAsStringAsync(),
                    ContentType = response.Content.Headers.ContentType.ToString()
                };
            }
            catch (Exception ex)
            {
                return new BadRequestObjectResult(new { url = url.url, errorMessage = ex.Message });
            }
        }
    }
}