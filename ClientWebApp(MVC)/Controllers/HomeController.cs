
using ClientWebApp_MVC_.Models;
using ClientWebApp_MVC_.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace ClientWebApp_MVC_.Controllers
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


        public async Task<IActionResult> IndexAsync()
        {
            var data = await _vsFly.GetFlights();
            return View(data);
        }

        public async Task<IActionResult> BookingList()
        {
            var data = await _vsFly.GetBookings();
            return View(data);
        }

        public async Task<IActionResult> Details(int id)
        {  

            {
                if (id == -1)
                {
                    return NotFound();
                }


                var data = await _vsFly.GetFlight(id);

                ViewBag.price = data.Price;

                if (data == null)
                {
                    return NotFound();
                }

                var myBook = new BuyTicketModel();
                myBook.FlightNo = data.FlightNo;
                myBook.Destination = data.Destination;
                myBook.Date = data.Date;


                return View(myBook);
            }

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


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Buy(IFormCollection collection)
        {
            BuyTicketModel ticketModel = new();

            if (ModelState.IsValid)
            {
               
                ticketModel.FullName = collection["FullName"];
                ticketModel.Destination = collection["Destination"];
                ticketModel.Date = Convert.ToDateTime(collection["Date"]);
                ticketModel.FlightNo = Int32.Parse(collection["FlightNo"]);

              
            }

            return View(ticketModel);
        }
    }

}