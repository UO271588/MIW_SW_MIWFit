 using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RestSharp;
using WS.MIWFit.Web.Models;

namespace WS.MIWFit.Web.Controllers
{
    public class CalculadoraIMCController : Controller
    {

        private IConfiguration _configuration;
        public CalculadoraIMCController(IConfiguration configuration)
        {
            this._configuration = configuration;
        }

        // GET: CalculadoraIMCView
        public IActionResult CalculadoraIMCView()
        {

            if (HttpContext.Session.GetString("token") == null || HttpContext.Session.GetString("token") == String.Empty)
            {
                return RedirectToAction("LoginView", "Users");
            }
            return View();
        }

        //POST: CalculadoraIMCAction.
        [HttpPost]
        public async Task<IActionResult> CalculadoraIMCAction()
        {
            if (HttpContext.Session.GetString("token") == String.Empty)
            {
                return RedirectToAction("LoginView", "Users");
            }

            BasicInfo basicInfo = new BasicInfo();
            basicInfo.actividad = Request.Form["actividad"].ToString();
            basicInfo.peso = double.Parse(Request.Form["peso"].ToString());
            basicInfo.altura = double.Parse(Request.Form["altura"].ToString());
            basicInfo.username = HttpContext.Session.GetString("username")!;

            var client = new RestClient(_configuration.GetValue<string>("WebSettings:AppEndPoint"));
            var request = new RestRequest("/fitStats", Method.Post);

            request.RequestFormat = DataFormat.Json;
            request.AddHeader("token", HttpContext.Session.GetString("token")!);
            request.AddJsonBody(basicInfo);
            var response = await client.ExecuteAsync(request);
            if (!(response).IsSuccessful)
                return RedirectToAction("CalculadoraIMCView");
            var resultado = JsonConvert.DeserializeAnonymousType<ResultadoIMC>(response.Content, new ResultadoIMC());
            Console.Out.WriteLine(resultado);
            return View("ResultadoIMCView", resultado);
        }
    }
}
