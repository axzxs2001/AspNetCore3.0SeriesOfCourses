using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Log009.LogTest;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Log009.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private readonly ILogger<WeatherForecastController> _logger;
        private readonly ILogTestService _logTestService;
        public WeatherForecastController(ILogger<WeatherForecastController> logger, ILogTestService logTestService)
        {
            _logTestService = logTestService;
            _logger = logger;
        }

        [HttpGet]
        public string Get()
        {
            _logTestService.Log();
            using(_logger.BeginScope("===批量输出"))
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
