using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
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
            return View();
        }

        public IActionResult RegisterView()
        {
            return View();
        }

        public async Task<IActionResult> LoginAction() {

            User user = new User();
            user.Username = Request.Form["Username"].ToString();
            user.Password = Request.Form["Password"].ToString();

            var client = new RestClient(_configuration.GetValue<string>("WebSettings:AppEndPoint"));
            var request = new RestRequest("/login", Method.Post);

            request.RequestFormat = DataFormat.Json;
            request.AddJsonBody(new { Username = user.Username, Password = user.Password });
            var response = await client.ExecuteAsync(request);
            if (!(response).IsSuccessful)
                return BadRequest();
            var token = JsonConvert.DeserializeAnonymousType(
                response.Content,
                new { Token = "" });
            Console.Out.WriteLine(token);
            return RedirectToAction("LoginView");
        }

        public IActionResult RegisterAction()
        {

            User user = new User();

            user.Username = Request.Form["Username"].ToString();
            user.Password = Request.Form["Password"].ToString();
            user.Email = Request.Form["Email"].ToString();
            user.Genre = Request.Form["Genre"].ToString();

            Console.Out.WriteLine(user.Username);
            Console.Out.WriteLine(user.Password);

            var client = new RestClient(_configuration.GetValue<string>("WebSettings:AppEndPoint"));
            var request = new RestRequest("/users/register", Method.Post);

            return RedirectToAction("LoginView");
        }
    }
}
