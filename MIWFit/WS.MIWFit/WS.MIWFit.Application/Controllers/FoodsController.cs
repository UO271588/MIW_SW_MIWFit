using Microsoft.AspNetCore.Mvc;
using RestSharp;
using System.Net.Mime;
using System.Xml.Serialization;
using WS.MIWFit.Application.Models;
using WSClient.FoodWS;

namespace WS.MIWFit.Application.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FoodsController : ControllerBase
    {

        private IConfiguration _configuration;
        public FoodsController(IConfiguration configuration)
        {
            this._configuration = configuration;
        }

        [XmlRoot(ElementName = "photo")]
        public class Photo
        {
            [XmlAttribute(AttributeName = "id")]
            public string Id { get; set; }
            [XmlAttribute(AttributeName = "owner")]
            public string Owner { get; set; }
            [XmlAttribute(AttributeName = "secret")]
            public string Secret { get; set; }
            [XmlAttribute(AttributeName = "server")]
            public string Server { get; set; }
            [XmlAttribute(AttributeName = "farm")]
            public string Farm { get; set; }
            [XmlAttribute(AttributeName = "title")]
            public string Title { get; set; }
            [XmlAttribute(AttributeName = "ispublic")]
            public string Ispublic { get; set; }
            [XmlAttribute(AttributeName = "isfriend")]
            public string Isfriend { get; set; }
            [XmlAttribute(AttributeName = "isfamily")]
            public string Isfamily { get; set; }
        }

        [XmlRoot(ElementName = "photos")]
        public class Photos
        {
            [XmlElement(ElementName = "photo")]
            public List<Photo> Photo { get; set; }
            [XmlAttribute(AttributeName = "page")]
            public string Page { get; set; }
            [XmlAttribute(AttributeName = "pages")]
            public string Pages { get; set; }
            [XmlAttribute(AttributeName = "perpage")]
            public string Perpage { get; set; }
            [XmlAttribute(AttributeName = "total")]
            public string Total { get; set; }
        }

        [XmlRoot(ElementName = "rsp")]
        public class Rsp
        {
            [XmlElement(ElementName = "photos")]
            public Photos Photos { get; set; }
            [XmlAttribute(AttributeName = "stat")]
            public string Stat { get; set; }
        }

        [HttpGet]
        public async Task<ActionResult<Food>> GetFoods([FromQuery] double calories) {
            var token = Request.Headers["token"];
            if (String.IsNullOrEmpty(token) || !ValidateToken(token))
                return Unauthorized();

            FoodProviderClient client = new FoodProviderClient();

            var foods = await client.getFoodAsync(calories);

            if (foods == null)
            {
                return BadRequest();
            }

            List<Food> comidas = new List<Food>();

            foreach (food f in foods.@return) {

                Food fd = new Food();
                fd.Name = f.name;
                fd.Calories = f.calories;
                fd.Azucares = f.azucares;
                fd.Comida = f.comida;
                fd.Proteina = f.proteina;
                fd.Grasas = f.grasas;
                fd.GramosPorRacion = f.gramosPorRacion;
                fd.Gramos = f.gramos;
                fd.Url = await GetPhotoUrl(f.flickrname);
                comidas.Add(fd);
            }

            return Ok(comidas);
        }


        private async Task<string> GetPhotoUrl(String name) {

            //Llamada a la app de flicker para sacar las imagenes
            var options = new RestClientOptions(
              _configuration.GetValue<string>("ApplicationSettings:FlickerEndPoint"));
            var restClient = new RestClient(options);
            var request = new RestRequest("/", Method.Get);
            request.RequestFormat = DataFormat.Json;
            request.AddParameter("method", "flickr.photos.search", ParameterType.QueryString);
            request.AddParameter("api_key", "3b5c444101072c0d887ab2b19957bcb2", ParameterType.QueryString);
            request.AddParameter("text", name, ParameterType.QueryString);
            request.AddParameter("format", "rest", ParameterType.QueryString);
            var response = await restClient.ExecuteAsync(request);
            if (!response.IsSuccessful)
            {
                return null;
            }

            XmlSerializer serializer = new XmlSerializer(typeof(Rsp));
            using (TextReader reader = new StringReader(response.Content.ToString()))
            {
                Rsp result = (Rsp)serializer.Deserialize(reader);

                Photo p = result.Photos.Photo[0];
                Console.Out.WriteLine(name);
                Console.Out.WriteLine("https://farm" + p.Farm + ".staticflickr.com/" + p.Server + "/" + p.Id + "_" + p.Secret + ".jpg");
                return "https://farm" + p.Farm + ".staticflickr.com/" + p.Server + "/" + p.Id + "_" + p.Secret + ".jpg";
            }
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
