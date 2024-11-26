using Microsoft.AspNetCore.Mvc;
using TFB_BackEnd_Margaux.DTOs;

namespace TFB_BackEnd_Margaux.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HelloWorldController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            var response = new HelloWorldDto
            {
                Message = "Hello, World!"
            };
            return Ok(response);
        }
    }
}
