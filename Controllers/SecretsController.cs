using System.Net;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace AspNetCoreConfigExample.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SecretsController : ControllerBase
    {

        // 1. inject IOptions
        public SecretsController() {  }
        
        // 2. make the configuration values available as a property

        [HttpGet]
        public IActionResult GetSecret()
        {
            // 3. return the secret to inspect it
            return Ok("nothing implemented yet");
        }
    }
}