
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
            var bookings = await _vsFly.GetBookings();
            var flights = await _vsFly.GetFlights();
            var passengers = await _vsFly.GetPassengers();

            var listFlights = flights.ToList();
            var listBookings = bookings.ToList();
            var listPassengers = passengers.ToList();

            foreach(var li in listBookings)
            {
                int id = li.FlightNo -1;
                if(id < listFlights.Count)
                {
                    li.Destination = listFlights[id].Destination;
                }
                else
                {
                    li.Destination = listFlights.Last<FlightModels>().Destination;
                }
                
                int idp = li.PassengerId -1;
                if(idp < listPassengers.Count)
                {
                    li.FirstName = listPassengers[idp].Firstname;
                    li.LastName = listPassengers[idp].Surname;
                }
                else
                {
                    li.FirstName = listPassengers.Last<PassengerModel>().Firstname;
                    li.LastName = listPassengers.Last<PassengerModel>().Surname;
                }
            }
            return View(listBookings);
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

                var myBook = new FlightModels();
                myBook.FlightNo = data.FlightNo;
                myBook.Destination = data.Destination;
                myBook.Date = data.Date;
                myBook.Price = data.Price;
                myBook.Seats = data.Seats;
                myBook.SeatsAvailable = data.SeatsAvailable;
                myBook.TotalSalePrice = data.TotalSalePrice;
                ViewBag.Message = myBook.TotalSalePrice / (myBook.Seats - myBook.SeatsAvailable);
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

        public async Task<IActionResult> GetPassenger(int id)
        {
            var flight = await _vsFly.GetPassenger(id);
            return View(flight);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Buy(IFormCollection collection)
        {
            FlightModels flightModel = new();
            PassengerModel passengerModel = new();

            if (ModelState.IsValid)
            {
                flightModel.Date = Convert.ToDateTime(collection["Date"]);
                flightModel.Departure = collection["Departure"];
                flightModel.Destination = collection["Destination"];
                flightModel.FlightNo = Int32.Parse(collection["FlightNo"]);
                flightModel.Price = Double.Parse(collection["Price"]);
                flightModel.Seats = Int32.Parse(collection["Seats"]);
                flightModel.SeatsAvailable = Int32.Parse(collection["SeatsAvailable"]);
                flightModel.TotalSalePrice = Double.Parse(collection["TotalSalePrice"]);
                passengerModel.Firstname = collection["Name"];
                passengerModel.Surname = collection["Surname"];

                if (flightModel.SeatsAvailable <= 0)
                {
                    return View("~/Views/SpecificView.cshtml");
                }

                var passenger = await _vsFly.GetPassengerByName(passengerModel.Firstname, passengerModel.Surname);

                if (passenger == null)
                {
                    passengerModel.CustomerSince = DateTime.Now;
                    bool PassengerCreation = _vsFly.CreatePassenger(passengerModel);
                    if (PassengerCreation)
                    {
                        passenger = await _vsFly.GetPassengerByName(passengerModel.Firstname, passengerModel.Surname);
                    }
                }

                BookingModel newBooking = new BookingModel();
                newBooking.FlightNo = flightModel.FlightNo;
                newBooking.PassengerId = passenger.PassengerId;
                newBooking.BuyPrice = flightModel.Price;
                bool BookCreation = _vsFly.CreateBooking(newBooking);

                flightModel.SeatsAvailable -= 1;
                flightModel.TotalSalePrice += flightModel.Price;
                bool ModifyFlight = _vsFly.ModifyFlight(flightModel);

                ViewBag.Message = flightModel.TotalSalePrice / (flightModel.Seats - flightModel.SeatsAvailable);
            }

            
            
            return View(flightModel);
        }
    }

}