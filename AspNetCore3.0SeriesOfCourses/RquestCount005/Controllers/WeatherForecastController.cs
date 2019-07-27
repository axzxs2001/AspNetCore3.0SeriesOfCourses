using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace RquestCount005.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {


        private readonly IRequestCountService _requestCountServic;
        public WeatherForecastController(IRequestCountService requestCountService)
        {
            _requestCountServic = requestCountService;
        }

        [HttpGet("/count")]
        public string GetRequestCount()
        {
            return $"总请求数：{  _requestCountServic.RequestList.Count},当前请求总数：{_requestCountServic.RequestList.Count(d=>d.Value)-1}";
        }
        [HttpGet("/ok")]
        public bool GetOK()
        {
            System.Threading.Thread.Sleep(10000);
            return true;
        }
    }
}
