using Microsoft.AspNetCore.Mvc;

namespace MicroService2.Controllers
{
    [ApiController]
    [Route("api/m2")]
    public class MicroService2Controller : ControllerBase
    {
        [HttpGet]

        public IActionResult Get()
        {
            return Ok("Microservice 2");
        }
        [HttpPost]

        public IActionResult Save(UserModel user)
        {
            return Ok(new { message = $"Microservice 2 received data {user.Username} / {user.Password}" });
        }

        [HttpGet("{fileId}")]
        public IActionResult GetFile(string fileId)
        {
            var filePath = Path.Combine("C:\\Users\\elhas\\Desktop\\Resources", fileId);
            if (System.IO.File.Exists(filePath))
            {
                var fileStream = new FileStream(filePath, FileMode.Open);
                return File(fileStream, "application/octet-stream", fileId);
            }
            return NotFound();
        }
    

    public class UserModel
        {
            public string Username { get; set; } = string.Empty;
            public string Password { get; set; } = string.Empty;
        }


    }
}