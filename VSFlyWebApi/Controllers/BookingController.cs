using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VSFly;
using VSFlyWebApi.Extensions;
using VSFlyWebApi.Models;

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
                var BM = f.ConvertToBookingM();
                bookingMList.Add(BM);
            }



            return bookingMList;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<BookingModel>> GetBooking(int id)
        {
            var booking = await _context.Booking.FindAsync(id);

            if (booking == null)
            {
                return NotFound();
            }

            BookingModel model = booking.ConvertToBookingM();
            return model;
        }

        [HttpPost]
        public async Task<ActionResult<BookingModel>> PostBooking(BookingModel booking)
        {
            Booking booking1 = booking.ConvertToBooking();
            _context.Booking.Add(booking1);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetBooking), new { id = booking.FlightNo }, booking);
        }



    }
}
