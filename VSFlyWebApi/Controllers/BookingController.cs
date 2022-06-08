using ClientWebApp_MVC_.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VSFly;
using VSFlyWebApi.Extensions;

namespace VSFlyWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingController : ControllerBase
    {
        private readonly WWWContext _context;

        public BookingController(WWWContext context)
        {
            _context = context;
        }

        [HttpGet("All")]
        public async Task<ActionResult<IEnumerable<BookingModel>>> GetBookings()
        {

            var bookingList = await _context.Booking.ToListAsync();
            List<BookingModel> bookingMList = new List<BookingModel>();
            foreach (Booking f in bookingList)
            {
                //    //Check if flight have free seats
                //    if (f.SeatsAvailable != 0)
                //    {
                //        var FM = f.ConvertToFlightM();
                //        FM.Price = getFlightPrice(f.Seats, f.SeatsAvailable, f.Date, f.Price);

                //        flightMList.Add(FM);
                //    }
                //}
            }

            return bookingMList;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<BookingModel>> GetBooking(int id)
        {
            var booking = await _context.Flight.FindAsync(id);

            if (booking == null)
            {
                return NotFound();
            }

            FlightModels model = booking.ConvertToFlightM();
            model.Price = getFlightPrice(flight.Seats, flight.SeatsAvailable, flight.Date, flight.Price);
            return model;
        }
    }
}
