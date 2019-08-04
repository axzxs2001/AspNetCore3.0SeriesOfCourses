using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using GlobalizationLocaliztion011.Models;
using Microsoft.Extensions.Localization;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Http;


namespace GlobalizationLocaliztion011.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IStringLocalizer<HomeController> _stringLocalizer;
        private readonly IStringLocalizer<SharedResource> _sharedResource;

        public HomeController(IStringLocalizer<HomeController> stringLocalizer, IStringLocalizer<SharedResource>  sharedResource, ILogger<HomeController> logger)
        {
            _stringLocalizer = stringLocalizer;
            _sharedResource = sharedResource;
            _logger = logger;
        }

        public IActionResult Index()
        {
            ViewData["ok"] = _stringLocalizer["ok"].Value;
            ViewData["no"] = _stringLocalizer["no"].Value;
            ViewData["cancel"] = _sharedResource["cancel"].Value;
       
            return View();
        }
        [HttpPost]
        public IActionResult Index(string culture,string returnurl="/")
        {
            Response.Cookies.Append(
                CookieRequestCultureProvider.DefaultCookieName,
                CookieRequestCultureProvider.MakeCookieValue(new RequestCulture(culture)),
                new CookieOptions { Expires = DateTimeOffset.UtcNow.AddYears(1) });
       
            return LocalRedirect("/");
        }
        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult Add()
        {
            return View();
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
