using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClientWebApp_MVC_.Models
{
    public class FlightAndPassengerModel 
    {
        public List<FlightModels> Flights { get; set; }
        public List<PassengerModel> Passengers { get; set; }
    }
}
