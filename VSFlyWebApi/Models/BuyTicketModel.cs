using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VSFly;

namespace VSFlyWebApi.Models
{
    public class BuyTicketModel
    {
        public string FullName { get; set; }
        public string Destination { get; set; }
        public DateTime Date { get; set; }
        public int FlightNo { get; set; }

        //Maybe ??
        public Passenger Passenger { get; set; }
        public int Seats { get; set; }
        public int SeatsAvailable { get; set; }
        public double Price { get; set; }
    }
}
