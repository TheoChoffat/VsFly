using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using VSFly;

namespace ClientWebApp_MVC_.Models
{
    public class BookingModel
    {
        [Key]
        public int FlightNo { get; set; }
        public int PassengerId { get; set; }
        public double BuyPrice { get; set; }
        public string Destination { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
