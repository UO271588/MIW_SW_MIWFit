using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WSClient.DataWS;
using Newtonsoft.Json;
using RestSharp;
using WS.MIWFit.Application.Models;
using WSClient.CalculadoraIMCWS;
using System.Reflection.PortableExecutable;
using System.Net.Mime;


namespace WS.MIWFit.Application.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class FitStatsController : ControllerBase
    {
        private IConfiguration _configuration;
        public FitStatsController(IConfiguration configuration)
        {
            this._configuration = configuration;
        }

        //GET: api/FitStats
        [HttpGet("{user}")]
        public async Task<ActionResult<IEnumerable<Models.FitStats>>> GetFitStats([FromRoute] String user)
        {
            
            var token = Request.Headers["token"];
            if (String.IsNullOrEmpty(token) || !ValidateToken(token))
                return Unauthorized();

            DataServicesClient dataClient = new DataServicesClient();

            var fitStats = await dataClient.GetUserFitStatsAsync(user);
            if (fitStats == null)
                return NotFound();
            return Ok(fitStats);
        }

        [HttpPost]
        [Consumes(MediaTypeNames.Application.Json)]
        [Produces(MediaTypeNames.Application.Json)]
        public async Task<ActionResult<WSClient.CalculadoraIMCWS.resultadoIMC>> CreateFitStats([FromBody] BasicInfo basicInfo  )
        {
            
            var token = Request.Headers["token"];
            if (String.IsNullOrEmpty(token) || !ValidateToken(token))
                return Unauthorized();
            
            DataServicesClient dataClient = new DataServicesClient();

            var user = await dataClient.GetUserAsync(basicInfo.username);

            if (user == null) {
                return BadRequest();
            }

            CalculatorIMCClient calculatorClient = new CalculatorIMCClient();

            var imcResult = await calculatorClient.calcularIMCAsync(basicInfo.peso, basicInfo.altura, user.Genre, basicInfo.actividad);

            if (imcResult == null) {
                return BadRequest();
            }

            WSClient.DataWS.FitStats fitStats = new WSClient.DataWS.FitStats();

            fitStats.Date = DateTime.Now;
            fitStats.Deficit = imcResult.@return.deficit;
            fitStats.Activity = imcResult.@return.actividad;
            fitStats.Superavit = imcResult.@return.superavit;
            fitStats.Imc = imcResult.@return.imc;
            fitStats.Height = imcResult.@return.altura;
            fitStats.Weight = imcResult.@return.peso;
            fitStats.User = user;
            fitStats.Calories = imcResult.@return.calorias;

            try
            {
                await dataClient.CreateUserFitStatsAsync(fitStats);
            }catch (Exception ex)
            {
                return BadRequest();
            }
            

            return Ok(imcResult.@return);
        }

        private bool ValidateToken(string token)
        {
            var options = new RestClientOptions(
              _configuration.GetValue<string>("ApplicationSettings:SecurityEndpoint"));
            options.RemoteCertificateValidationCallback =
                                 (sender, certificate, chain, sslPolicyErrors) => true;
            var restClient = new RestClient(options);
            var request = new RestRequest("/{token}", Method.Get);
            request.AddParameter("token", token, ParameterType.UrlSegment);
            var response = restClient.ExecuteAsync(request).Result;
            return response.IsSuccessful;
        }
    }
}
