using System.Net;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace AspNetCoreConfigExample.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ConfigController : ControllerBase
    {

        // 1. inject IOptions
        public ConfigController() {  }
        
        // 2. make the configuration values available as a property

        [HttpGet]
        public IActionResult GetConfig()
        {
            // 3. return the secret to inspect it
            return Ok("nothing implemented yet");
        }
    }
}