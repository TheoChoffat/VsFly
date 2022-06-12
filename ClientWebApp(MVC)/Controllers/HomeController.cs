﻿
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

        /*public async Task<IActionResult> BookingList(BuyTicketModel buyTicketModel)
        {
           if (ModelState.IsValid)
            {
                ViewBag.FullName = buyTicketModel.FullName;
                ViewBag.Destination = buyTicketModel.Destination;
                ViewBag.Date = buyTicketModel.Date;
                ViewBag.Price = buyTicketModel.Price;
                ViewBag.Seats = buyTicketModel.Seats;
                ViewBag.SeatsAvailable = buyTicketModel.SeatsAvailable;

                List<BuyTicketModel> buyTicketM = new List<BuyTicketModel>();
                var passenger = await _vsFly.GetPassengers();
                Boolean Exists = false;
                
                for(int i=0; i < passenger.Count(); i++)
                {
                    if (buyTicketModel.FullName == passenger.ElementAt(i).Firstname)
                    {
                        Exists = true;

                        buyTicketModel.FullName = passenger.ElementAt(i).Firstname;
                        ViewBag.Exists = true;
                    }
                }

                //Creation of the passenger
                if (!Exists)
                {
                    var status = _vsFly.CreatePassenger(buyTicketModel.Passenger);
                    if (status)
                    {
                        buyTicketModel.Passenger = passenger;
                        ViewBag.Exists = false;
                    }
                }
            }
        }*/

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
              

                passengerModel.Firstname = collection["Name"];
                passengerModel.Surname = collection["Surname"];
            }
            
            var passenger = await _vsFly.GetPassengerByName(passengerModel.Firstname, passengerModel.Surname);
            
            if(passenger == null)
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
            bool BookCreation = _vsFly.CreateBooking(newBooking);
            return View(flightModel);
        }
    }

}