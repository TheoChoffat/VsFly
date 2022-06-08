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
        public virtual Flight Flight { get; set; }
        public virtual Passenger Passenger { get; set; }
        public int PassengerId { get; set; }

    }
}
