using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VSFly;
using VSFlyWebApi.Extensions;
using VSFlyWebApi.Models;

namespace VSFlyWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FlightsController : ControllerBase
    {
        private readonly WWWContext _context;

        public FlightsController(WWWContext context)
        {
            _context = context;
        }

        [HttpPost("Create")]
        public async Task<ActionResult<FlightModels>> CreateFlight(FlightModels newFlight)
        {
            if (!ModelState.IsValid)
                return BadRequest("Invalid data.");

            Flight flight1 = newFlight.ConvertToFlight();

            _context.Flight.Add(flight1);

            return newFlight;

        }



        [HttpGet("All")]
        public async Task<ActionResult<IEnumerable<FlightModels>>> GetFlights()
        {

            var flightList = await _context.Flight.ToListAsync();
            List<FlightModels> flightMList = new List<FlightModels>();
            foreach (Flight f in flightList)
            {
                //Check if flight have free seats
                if (f.SeatsAvailable != 0)
                {
                    var FM = f.ConvertToFlightM();
                    FM.Price = getFlightPrice(f.Seats, f.SeatsAvailable, f.Date, f.Price);

                    flightMList.Add(FM);
                }
            }
            return flightMList;
        }


        // GET: api/Flights/5
        [HttpGet("{id}")]
        public async Task<ActionResult<FlightModels>> GetFlight(int id)
        {
            var flight = await _context.Flight.FindAsync(id);

            if (flight == null)
            {
                return NotFound();
            }

            FlightModels model = flight.ConvertToFlightM();
            model.Price = getFlightPrice(flight.Seats, flight.SeatsAvailable, flight.Date, flight.Price);
            return model;
        }

        private double getFlightPrice(int Seats, int SeatsAvailable, DateTime Date, double Price)
        {

            //If the airplane is more than 80% full regardless of the date:
            if (Seats / 100 * 20 > SeatsAvailable)
                Price = Price / 100 * 150;

            else
            {
                //If the plane is filled less than 20 % less than 2 months before departure:
                if (Seats / 100 * 80 < SeatsAvailable && (Date - DateTime.Now).TotalDays < 60.0)
                    Price = Price / 100 * 80;

                else
                {
                    //If the plane is filled less than 50 % less than 1 month before departure:
                    if (Seats / 100 * 50 < SeatsAvailable && (Date - DateTime.Now).TotalDays < 30.0)
                        Price = Price / 100 * 70;

                    else
                    {
                        //In all other cases:
                        Price = Price;
                    }

                }
            }


            return Price;
        }

        



        ////POST: api/Flights
        ////To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        //[HttpPost]
        //public async Task<ActionResult<FlightModels>> PostFlight(FlightModels flight)
        //{
        //    Flight flight1 = flight.ConvertToFlight();
        //    _context.Flight.Add(flight1);
        //    await _context.SaveChangesAsync();

        //    return CreatedAtAction(nameof(GetFlight), new { id = flight.FlightNo }, flight);

        //}

    }
}
