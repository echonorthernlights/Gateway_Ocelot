using Microsoft.AspNetCore.Mvc;

namespace MicroService1.Controllers
{
    [ApiController]
    [Route("api")]
    public class MicroService1Controller : ControllerBase
    {
        [HttpGet]
        [Route("m1")]
        public IActionResult Get()
        {
            return Ok("Microservice 1");
        }


    }
}
