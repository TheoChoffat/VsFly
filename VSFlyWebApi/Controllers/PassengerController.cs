﻿using Microsoft.AspNetCore.Mvc;
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
    public class PassengerController : ControllerBase
    {
        private readonly WWWContext _context;

        public PassengerController(WWWContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<ActionResult<PassengerModel>> CreatePassenger(PassengerModel newPassenger)
        {
            if (!ModelState.IsValid)
                return BadRequest("Invalid data.");

            Passenger passenger1 = newPassenger.ConvertToPassenger();
            _context.Passenger.Add(passenger1);


            passenger1.Surname = newPassenger.Surname;
            passenger1.Firstname = newPassenger.Firstname;
            passenger1.CustomerSince = newPassenger.CustomerSince;
            passenger1.Status = newPassenger.Status;


            return newPassenger;
          
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
