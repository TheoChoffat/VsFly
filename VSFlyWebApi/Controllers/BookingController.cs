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

        [HttpPost("Create")]
        public async Task<ActionResult<BookingModel>> PostBooking(BookingModel newBooking)
        {
            if (!ModelState.IsValid)
                return BadRequest("Invalid data.");

            Booking book1 = newBooking.ConvertToBooking();

            _context.Booking.Add(book1);

            return newBooking;
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

        [HttpGet("PlaneID/{planeID}")]
        public async Task<ActionResult<IEnumerable<BookingModel>>> GetBookingWithPlaneId(int planeID)
        {
            var bookingList = await _context.Booking.Where(p => p.FlightNo == planeID).ToListAsync();
            List<BookingModel> bookingMList = new List<BookingModel>();
            foreach (Booking f in bookingList)
            {
                var BM = f.ConvertToBookingM();
                bookingMList.Add(BM);
            }
            
            return bookingMList;
        }

        [HttpGet("PassengerID/{passengerID}")]
        public async Task<ActionResult<IEnumerable<BookingModel>>> GetBookingWithPassengerId(int passengerID)
        {
            var bookingList = await _context.Booking.Where(p => p.PassengerId == passengerID).ToListAsync();
            List<BookingModel> bookingMList = new List<BookingModel>();
            foreach (Booking f in bookingList)
            {
                var BM = f.ConvertToBookingM();
                bookingMList.Add(BM);
            }

            return bookingMList;
        }





    }
}
