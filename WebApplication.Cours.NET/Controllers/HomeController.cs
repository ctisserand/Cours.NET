using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using WebApplication.Cours.NET.Models;

namespace WebApplication.Cours.NET.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private ITestService _test;
        private readonly UserManager<IdentityUser> userManager;

        public HomeController(ILogger<HomeController> logger, ITestService test, UserManager<IdentityUser> userManager)
        {
            _test = test;
            this.userManager = userManager;
            _logger = logger;
        }

        public IActionResult Index()
        {
            _test.DoSomething();
            ViewData["Something"] = "Anythings";
            return View(new IndexViewModel { Text = "Test" });
        }

        [Authorize(Roles = "basic")]
        public IActionResult basic()
        {
            _test.DoSomething();
            return View("Index", new IndexViewModel { Text = "Authenticated Test" });
        }
        [Authorize(Roles = "admin")]
        public IActionResult admin()
        {
            _test.DoSomething();
            return View("Index", new IndexViewModel { Text = "Authenticated as Admin Test" });
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
    }
}
