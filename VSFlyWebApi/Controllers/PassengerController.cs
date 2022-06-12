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
    public class PassengerController : ControllerBase
    {
        private readonly WWWContext _context;

        public PassengerController(WWWContext context)
        {
            _context = context;
        }


        [HttpPost("Create")]
        public async Task<ActionResult<PassengerModel>> CreatePassenger(PassengerModel newPassenger)
        {
            if (!ModelState.IsValid)
                return BadRequest("Invalid data.");

            Passenger passenger1 = newPassenger.ConvertToPassenger();
            _context.Passenger.Add(passenger1);

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                return null;
            }

            return CreatedAtAction("GetPassenger", new { id = newPassenger.PassengerId }, newPassenger);
        }
       

        [HttpDelete("Delete{id}")]
        public async Task<ActionResult<PassengerModel>> DeletePassenger(int id)
        {
            if (id <= 0)
                return BadRequest("The ID is not valid.");

            var passenger = _context.Passenger.Where(p => p.PassengerId == id).FirstOrDefault();
            _context.Entry(passenger).State = EntityState.Deleted;
            _context.SaveChanges();

            return Ok();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<PassengerModel>> GetPassenger(int id)
        {
            var passenger = await _context.Passenger.FindAsync(id);

            if (passenger == null)
            {
                return NotFound();
            }

            PassengerModel model = passenger.ConvertToPassengerM();
           
            return model;
        }

        [HttpGet("All")]
        public async Task<ActionResult<IEnumerable<PassengerModel>>> GetPassengers()
        {

            var passengerList = await _context.Passenger.ToListAsync();
            List<PassengerModel> passengerMList = new List<PassengerModel>();
            foreach (Passenger f in passengerList)
            {
                var BM = f.ConvertToPassengerM();
                passengerMList.Add(BM);
            }
            return passengerMList;
        }


        [HttpGet("Name/{firstname}/{surname}")]
        public async Task<ActionResult<PassengerModel>> GetPassengerByName(string firstname, string surname)
        {
            var passenger = await _context.Passenger.Where(p=>p.Firstname == firstname && p.Surname == surname).FirstOrDefaultAsync();

            if (passenger == null)
            {
                return null;
            }


            PassengerModel model = passenger.ConvertToPassengerM();

            return model;
        }

        [HttpPost]
        public async Task<ActionResult<PassengerModel>> PostPassenger(PassengerModel passenger)
        {
            Passenger passenger1 = passenger.ConvertToPassenger();
            _context.Passenger.Add(passenger1);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetPassenger), new { id = passenger.PassengerId }, passenger);
        }



    }
}
