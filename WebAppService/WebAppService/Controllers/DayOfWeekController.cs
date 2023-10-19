using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAppService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DayOfWeekController : ControllerBase
    {
        [HttpGet]
        public string Get()
        {
            return DateTime.Now.DayOfWeek.ToString();
        }
    }
}
