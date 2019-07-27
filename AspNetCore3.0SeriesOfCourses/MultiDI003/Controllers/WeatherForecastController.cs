using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace MultiDI003.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;

        private readonly IMyService _myService1;
        private readonly IMyService _myService2;
        private readonly IDataBase _dep1DB;
        private readonly IDataBase _dep2DB;
        public WeatherForecastController(IEnumerable<IMyService> myServices, IEnumerable<IDataBase> dataBases, ILogger<WeatherForecastController> logger)
        {
            foreach (var myService in myServices)
            {
                switch (myService)
                {
                    case MyService1 ms1:
                        _myService1 = ms1;
                        break;
                    case MyService2 ms2:
                        _myService2 = ms2;
                        break;
                }
            }
            foreach (var dataBase in dataBases)
            {
                switch (dataBase.DataBaseType)
                {
                    case "Dep1":
                        _dep1DB = dataBase;
                        break;
                    case "Dep2":
                        _dep2DB = dataBase;
                        break;
                }
            }
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<WeatherForecast> Get()
        {
            _myService1.Print();
            _myService2.Print();

            _dep1DB.Print();
            _dep2DB.Print();

            var rng = new Random();
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = rng.Next(-20, 55),
                Summary = Summaries[rng.Next(Summaries.Length)]
            })
            .ToArray();
        }
    }
}
