using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using NuGet.Common;
using RestSharp;
using WS.MIWFit.Web.Models;

namespace WS.MIWFit.Web.Controllers
{
    public class FoodsController : Controller
    {

        private IConfiguration _configuration;
        public FoodsController(IConfiguration configuration)
        {
            this._configuration = configuration;
        }
        public async Task<IActionResult> FoodExamples([FromQuery] double calories)
        {

            if (HttpContext.Session.GetString("token") == null || HttpContext.Session.GetString("token") == String.Empty)
            {
                return RedirectToAction("LoginView", "Users");
            }

            var client = new RestClient(_configuration.GetValue<string>("WebSettings:AppEndPoint"));
            var request = new RestRequest("/foods", Method.Get);

            request.RequestFormat = DataFormat.Json;
            request.AddHeader("token", HttpContext.Session.GetString("token")!);
            request.AddQueryParameter("calories", calories);
            var response = await client.ExecuteAsync(request);
            if (!(response).IsSuccessful)
                return RedirectToAction("/");
            var foods = JsonConvert.DeserializeAnonymousType(
                response.Content, new[] { new Food() });
            Console.Out.WriteLine(foods);
            return View(foods);
        }
    }
}
