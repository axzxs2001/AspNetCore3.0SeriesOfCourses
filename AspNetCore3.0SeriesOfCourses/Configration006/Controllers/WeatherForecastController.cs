using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace Configration006.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {

        private readonly Appsetting _appsetting;
        public WeatherForecastController(IConfiguration configuration, ILogger<WeatherForecastController> logger, IOptionsSnapshot<Appsetting> options)
        {
            _appsetting = options.Value;
            var key = configuration.GetSection("Appsetting:key");
        
        }

        [HttpGet]
        public string Get()
        {
            return _appsetting.Key;
        }
    }
}
