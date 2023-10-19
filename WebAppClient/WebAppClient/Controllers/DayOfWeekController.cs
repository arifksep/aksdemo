using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAppClient.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DayOfWeekController : ControllerBase
    {
        [HttpGet("{id}")]
        public string Get(int id)
        {
            string responseContent = CallWebApi().Result;

            return responseContent;
        }

        private async Task<string> CallWebApi()
        {
            using (HttpClient client = new HttpClient())
            {
                string responseContent = "";

                // Replace 'your_api_url' with the actual URL of your Web API GET endpoint
                string apiUrl = "";
                apiUrl = @"http://lnxappservice.default.svc.cluster.local/api/dayofweek";

                // Invoke the GET method and get the response
                HttpResponseMessage response = await client.GetAsync(apiUrl);

                // Ensure the response is successful
                response.EnsureSuccessStatusCode();

                // Read the response content as a string
                responseContent = await response.Content.ReadAsStringAsync();

                return responseContent;
            }

        }
    }
}
