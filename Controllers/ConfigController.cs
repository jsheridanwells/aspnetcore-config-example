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
        // 2. make the configuration values available as a property
        private MyConfig _configs;
        public ConfigController(IOptions<MyConfig> opts)
        {
            _configs = opts.Value;
        }
        
        

        [HttpGet]
        public IActionResult GetConfig()
        {
            // 3. return the secret to inspect it
            var configs = _configs;
            return Ok(new { Result = "config values: ", configs });
        }
    }
}