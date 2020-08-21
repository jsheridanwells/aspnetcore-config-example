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

        public SecretsController(IOptions<Secret> opts) => _secret = opts.Value;

        [HttpGet]
        public IActionResult GetSecret()
        {
            var secret = _secret;
            return Ok(new { Result = "Here's the secret: ", secret });
        }
    }
}