using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RestSharp;
using System.Xml.Linq;
using WS.MIWFit.Application.Models;

namespace WS.MIWFit.Application.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {

        private IConfiguration _configuration;
        public LoginController(IConfiguration configuration)
        {
            this._configuration = configuration;
        }

        [HttpPost]

        public async Task<ActionResult<dynamic>> Login([FromBody] TokenRequest tokenRequest)
        {
            var options = new RestClientOptions(
              _configuration.GetValue<string>("ApplicationSettings:SecurityEndpoint"));
            options.RemoteCertificateValidationCallback =
                                 (sender, certificate, chain, sslPolicyErrors) => true;
            var restClient = new RestClient(options);
            var request = new RestRequest("", Method.Post);
            request.RequestFormat = DataFormat.Json;
            request.AddJsonBody(new { Username = tokenRequest.Username, Password = tokenRequest.Password });
            var response = await restClient.ExecuteAsync(request);
            if (!(response).IsSuccessful)
                return BadRequest();
            var token = JsonConvert.DeserializeAnonymousType(
                response.Content,
                new { Token = "" });
            return Ok(token);
        
        }
    }
}
