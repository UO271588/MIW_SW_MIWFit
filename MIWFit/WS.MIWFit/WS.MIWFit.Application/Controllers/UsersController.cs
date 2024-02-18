using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net.Mime;
using WSClient.DataWS;

namespace WS.MIWFit.Application.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {

        [HttpPost]
        [Consumes(MediaTypeNames.Application.Json)]
        [Produces(MediaTypeNames.Application.Json)]
        public async Task<IActionResult> CreateUser([FromBody] User user)
        {

            /**
            var token = Request.Headers["token"];
            if (String.IsNullOrEmpty(token) || !ValidateToken(token))
                return Unauthorized();
            */

            try
            {
                DataServicesClient dataClient = new DataServicesClient();
                await dataClient.CreateUserAsync(user.Username, user.Password, user.Genre, user.Mail);
                return Ok();

            }
            catch (Exception) { return BadRequest(); }
        }
    }
}
