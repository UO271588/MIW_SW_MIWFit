using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using NuGet.Common;
using RestSharp;
using WS.MIWFit.Web.Models;

namespace WS.MIWFit.Web.Controllers
{
    public class UsersController : Controller
    {

        private IConfiguration _configuration;
        public UsersController(IConfiguration configuration)
        {
            this._configuration = configuration;
        }

        public IActionResult LoginView()
        {
            if (HttpContext.Session.GetString("token") != null && HttpContext.Session.GetString("token") != String.Empty) {
                return RedirectToAction("Index", "Home");
            }
            return View();
        }

        public IActionResult RegisterView()
        {
            if (HttpContext.Session.GetString("token") != null && HttpContext.Session.GetString("token") != String.Empty)
            {
                return RedirectToAction("Index", "Home");
            }
            return View();
        }

        public async Task<IActionResult> LoginAction() {
            if (HttpContext.Session.GetString("token") != null && HttpContext.Session.GetString("token") != String.Empty)
            {
                return RedirectToAction("Index", "Home");
            }

            User user = new User();
            user.Username = Request.Form["Username"].ToString();
            user.Password = Request.Form["Password"].ToString();

            var options = new RestClientOptions(_configuration.GetValue<string>("WebSettings:AppEndPoint"));
            options.RemoteCertificateValidationCallback =
                                 (sender, certificate, chain, sslPolicyErrors) => true;
            var client = new RestClient(options);
            var request = new RestRequest("/login", Method.Post);

            request.RequestFormat = DataFormat.Json;
            request.AddJsonBody(new { Username = user.Username, Password = user.Password });
            var response = await client.ExecuteAsync(request);
            if (!(response).IsSuccessful)
                return RedirectToAction("LoginView");
            var token = JsonConvert.DeserializeAnonymousType(
                response.Content,
                new { Token = "" });
            Console.Out.WriteLine(token);
            HttpContext.Session.SetString("token",token.Token);
            HttpContext.Session.SetString("username", user.Username);

            return RedirectToAction("Index", "Home");
        }

        public async Task<IActionResult> RegisterAction()
        {
            if (HttpContext.Session.GetString("token") != null && HttpContext.Session.GetString("token") != String.Empty)
            {
                return RedirectToAction("Index", "Home");
            }

            User user = new User();

            user.Username = Request.Form["Username"].ToString();
            user.Password = Request.Form["Password"].ToString();
            user.Mail = Request.Form["Mail"].ToString();
            user.Genre = Request.Form["Genre"].ToString();

            Console.Out.WriteLine(user.Username);
            Console.Out.WriteLine(user.Password);

            var options = new RestClientOptions(_configuration.GetValue<string>("WebSettings:AppEndPoint"));
            options.RemoteCertificateValidationCallback =
                                 (sender, certificate, chain, sslPolicyErrors) => true;
            var client = new RestClient(options);
            var request = new RestRequest("/users", Method.Post);

            request.RequestFormat = DataFormat.Json;
            request.AddJsonBody(user);
            var response = await client.ExecuteAsync(request);
            if (!(response).IsSuccessful)
                return RedirectToAction("RegisterView");
            return RedirectToAction("LoginView");
        }

        public IActionResult LogoutAction() {
            HttpContext.Session.SetString("token", String.Empty);
            HttpContext.Session.SetString("username", String.Empty);
            return View("LoginView");
        }
    }
}
