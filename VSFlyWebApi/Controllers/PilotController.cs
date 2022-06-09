using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VSFly;
using VSFlyWebApi.Models;

namespace VSFlyWebApi.Controllers
{
    public class PilotController : ControllerBase
    {
        private readonly WWWContext _context;

        public PilotController(WWWContext context)
        {
            _context = context;
        }


        //[HttpGet("All")]
        //public async Task<ActionResult<IEnumerable<PilotModel>>> GetFlights()
        //{

        //    var pilotList = await _context.Pilot.ToListAsync();
        //    List<FlightModels> flightMList = new List<FlightModels>();
        //    foreach (Flight f in flightList)
        //    {
        //        //Check if flight have free seats
        //        if (f.SeatsAvailable != 0)
        //        {
        //            var FM = f.ConvertToFlightM();
        //            FM.Price = getFlightPrice(f.Seats, f.SeatsAvailable, f.Date, f.Price);

        //            flightMList.Add(FM);
        //        }
        //    }
        //    return flightMList;
        //}

    }
}
