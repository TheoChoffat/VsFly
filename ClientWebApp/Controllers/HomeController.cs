using ClientWebApp.Models;
using ClientWebApp.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace ClientWebApp.Controllers
{
    public class HomeController : Controller
    {

        private readonly ILogger<HomeController> _logger;
        private readonly IVSFlyServices _vsFly;

        public HomeController(ILogger<HomeController> logger, IVSFlyServices vsFly)
        {
            _logger = logger;
            _vsFly = vsFly;
        }

        public async Task<IActionResult> Index()
        {
            var listFlights = await _vsFly.GetFlights();
            return View(listFlights);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModels { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}