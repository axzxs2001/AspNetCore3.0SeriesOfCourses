using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace NLog010.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
    
        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public string Get()
        {
            using (_logger.BeginScope("===批量输出"))
            {
                _logger.LogTrace("    Trace");
                _logger.LogCritical("    Critical");
                _logger.LogDebug("    Debug");
                _logger.LogWarning("    Warning");
                _logger.LogInformation("    Information");
                _logger.LogError("    Error");
            }

            return "Ok";
        }
    }
}
