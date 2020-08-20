using System.Net;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace AspNetCoreConfigExample.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SecretsController : ControllerBase
    {
        private Secret _secret;

        public SecretsController(IOptions<Secret> opts)
        {
            _secret = opts.Value;
        }
        
        [HttpGet]
        public IActionResult GetSecret()
        {
            return Ok(new { Result = "Secret: \n", _secret });
        }
    }
}