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
        public async Task<ActionResult<IEnumerable<WSClient.DataWS.FitStats>>> GetFitStats([FromRoute] String user)
        {
            DataServicesClient dataClient = new DataServicesClient();

            var fitStats = await dataClient.GetUserFitStatsAsync(user);
            if (fitStats == null)
                return NotFound();
            return Ok(fitStats);
        }

        [HttpPost]
        [Consumes(MediaTypeNames.Application.Json)]
        public async Task<ActionResult<WSClient.CalculadoraIMCWS.resultadoIMC>> CreateFitStats([FromBody] BasicInfo basicInfo  )
        { 
            CalculatorIMCClient calculatorClient = new CalculatorIMCClient();

            var imcResult = await calculatorClient.calcularIMCAsync(basicInfo.peso, basicInfo.altura, basicInfo.sexo, basicInfo.actividad);

            if (imcResult == null) {
                return BadRequest();
            }
            return Ok(imcResult.@return);
        }
    }
}
