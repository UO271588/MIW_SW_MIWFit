using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using WS.MIWFit.DataWS;
using WS.Unit10.Task2.Security.Utils;

namespace WS.Unit10.Task2.Security.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TokensController : ControllerBase
    {
        [HttpGet("{token}")]
        public ActionResult<String> Get([FromRoute] string token)
        {
            try
            {
                var securityToken = JsonConvert.DeserializeObject<dynamic>(
                                                             AESManager.Decrypt(token));
                if (securityToken == null)
                {
                    return NotFound();
                }
                else if (DateTime.Parse(
                    securityToken.ExpirationDate.ToString()) > DateTime.Now)
                {
                    return Ok();
                }
                else
                {
                    return Unauthorized();
                }
            }
            catch (Exception) { return BadRequest(); }
        }

        // POST: api/Tokens
        [HttpPost]
        public IActionResult Post([FromBody] dynamic tokenRequest)
        {
            try
            {
                var username = JsonConvert.DeserializeObject<dynamic>(
                                          tokenRequest.ToString()).Username.ToString();
                var password = JsonConvert.DeserializeObject<dynamic>(
                                          tokenRequest.ToString()).Password.ToString();
                var data = new DataServicesClient();
                User user = data.GetUserAsync(username).Result;
                if(user.Username.Length <= 0) 
                {
                    return BadRequest();
                }
                else 
                {
                    if(!user.Username.Equals(username) || !user.Password.Equals(password)) 
                    {
                        return BadRequest();
                    }
                }
                var token = AESManager.Encrypt(JsonConvert.SerializeObject(
                        new { UserName = username, ExpirationDate = DateTime.Now.AddDays(30) }));
                return CreatedAtAction(
                                       "Get", new { token = token }, new { Token = token });
            }
            catch (Exception) { return BadRequest(); }
        }
    }
}
