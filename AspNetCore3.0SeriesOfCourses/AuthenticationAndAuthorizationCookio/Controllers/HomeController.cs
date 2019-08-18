using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using AuthenticationAndAuthorizationCookio.Models;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;

namespace AuthenticationAndAuthorizationCookio.Controllers
{
    //固定角色
    //[Authorize(Roles = "admin")]
    [Authorize(Policy = "Permission")]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        [AllowAnonymous]
        [HttpGet("/login")]
        public IActionResult Login()
        {
            return View();
        }

        [AllowAnonymous]
        [HttpPost("/login")]
        public async Task<IActionResult> Login(string username, string password)
        {
            if (username == "gsw" && password == "111111")
            {
                var identity = new ClaimsIdentity(CookieAuthenticationDefaults.AuthenticationScheme);
                identity.AddClaim(new Claim(ClaimTypes.Role, "admin"));
                identity.AddClaim(new Claim(ClaimTypes.Name, "桂素伟"));
                identity.AddClaim(new Claim(ClaimTypes.Sid, username));

                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(identity));



                return Redirect("/");
            }
            else
            {
                return BadRequest("username or password is error");
            }
        }

        public IActionResult Index()
        {
            ViewBag.Name = User.Identity.Name + User.Claims.SingleOrDefault(s => s.Type == ClaimTypes.Sid).Value;
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        [HttpGet("/denied")]
        public IActionResult Denied()
        {
            return View();

        }
    }
}
