using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using VSFly;

namespace ClientWebApp_MVC_.Models
{
    public class BuyTicketModel
    {
        [Required]
        public string FullName { get; set; }
        public string Destination { get; set; }
        public DateTime Date { get; set; }
        public int FlightNo { get; set; }

        //Maybe 
        public int Seats { get; set; }
        public int SeatsAvailable { get; set; }
        public double Price { get; set; }
        public Passenger Passenger { get; set; }
    }
}

