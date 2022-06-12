using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VSFly
{
    public class Booking

    {
        [Key]
        public int FlightNo { get; set; }
        public int PassengerId { get; set; }

    }
}
