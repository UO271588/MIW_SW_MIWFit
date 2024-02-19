using Microsoft.AspNetCore.Mvc;
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

        public async Task<IActionResult> FitStatsList(string user)
        {
            var client = new RestClient(_configuration.GetValue<string>("WebSettings:AppEndPoint"));
            var request = new RestRequest("/login", Method.Post);
            request.RequestFormat = DataFormat.Json;
            request.AddParameter("user", user, ParameterType.UrlSegment);
            var response = await client.ExecuteAsync<List<FitStats>>(request);
            if (!response.IsSuccessful) return BadRequest();
            return View(response.Data.ToArray<FitStats>());
        }
    }
}
