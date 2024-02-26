using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using RestSharp;
using System.Xml.Linq;
using WS.MIWFit.Web.Models;

namespace WS.MIWFit.Web.Controllers
{
    public class FitStatsController : Controller
    {

        private IConfiguration _configuration;
        public FitStatsController(IConfiguration configuration)
        {
            this._configuration = configuration;
        }

        public async Task<IActionResult> FitStatsList()
        {
            if (HttpContext.Session.GetString("token") == null || HttpContext.Session.GetString("token") == String.Empty)
            {
                return RedirectToAction("LoginView", "Users");
            }

            var user = HttpContext.Session.GetString("username");
            var options = new RestClientOptions(_configuration.GetValue<string>("WebSettings:AppEndPoint"));
            options.RemoteCertificateValidationCallback =
                                 (sender, certificate, chain, sslPolicyErrors) => true;
            var client = new RestClient(options);
            var request = new RestRequest("/fitStats/{user}", Method.Get);
            request.RequestFormat = DataFormat.Json;
            request.AddHeader("token", HttpContext.Session.GetString("token")!);
            request.AddParameter("user", user, ParameterType.UrlSegment);
            var response = await client.ExecuteAsync<List<FitStats>>(request);
            if (!response.IsSuccessful) return BadRequest();
            return View(response.Data.ToArray<FitStats>());
        }
    }
}
