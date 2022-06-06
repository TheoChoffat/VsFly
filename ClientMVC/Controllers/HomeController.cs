using ClientMVC.Models;
using ClientMVC.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace ClientMVC.Controllers
{
    public class HomeController : Controller
    {

        private readonly ILogger<HomeController> _logger;

        private readonly IVSFlyServices _vsFly;

        private readonly IOptions<UtilityModel> appSettings;

        public HomeController(ILogger<HomeController> logger, IVSFlyServices vsFly, IOptions<UtilityModel> app)
        {
            _logger = logger;
            appSettings = app;
            _vsFly = vsFly;
            ApplicationSettings.WebApiUrl = appSettings.Value.WebApiUrl;
        }

        public async Task <IActionResult> Index()
        {
            var listFlights = await _vsFly.GetFlights();
            return View(listFlights);
        }

        public async Task<IActionResult> Details(int id)
        {
            var flight = await _vsFly.GetFlight(id);
            return View(flight);
        }

            [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public async Task<IActionResult> GetFlight(int id)
        {
            var flight = await _vsFly.GetFlight(id);
            return View(flight);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult Buy()
        {
            return View();
        }

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Buy([Bind("PassengerId, Surnname, Firstname, FK_FlightNo, Price")]PassengerModel passenger, double price, int id, string surname, string firstname)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        passenger.Price = price;
        //        passenger.FK_Flight_No = id;
        //        passenger.Firstname = firstname;
        //        passenger.Surname = surname;

        //        var data = await APIClientClient.Instance.SavePassenger(passenger);
        //    }


        //}
    }

            return View(passenger);
        }
    }
}
