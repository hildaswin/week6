using Microsoft.AspNetCore.Mvc;
using System.Dynamic;
using Newtonsoft.Json;

namespace API_1.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        [HttpGet]
        public ActionResult<List<Activity>> Get()
        {
            HttpClient client = new HttpClient();
            dynamic? obj = new ExpandoObject();
            string result;

            try
            {
                HttpResponseMessage response = client.GetAsync("https://www.boredapi.com/api/activity").Result;
                response.EnsureSuccessStatusCode();
                result = response.Content.ReadAsStringAsync().Result;
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

            var list = (result);
            return Ok(list);
        }
    }

    public class Activity
    {
        public string activity { get; set; }
        public string type { get; set; }
        public int participants { get; set; }
        public double price { get; set; }
        public string link { get; set; }
        public string key { get; set; }
        public string accessibility { get; set; }
    }
}