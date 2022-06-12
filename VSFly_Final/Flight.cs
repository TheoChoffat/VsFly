using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VSFly
{
    [Table("Flight")]
    public partial class Flight
    {

        [Key]
        public int FlightNo { get; set; }
        public string Departure { get; set; }
        public string Destination { get; set; }
        public double Price { get; set; }
        public int Seats { get; set; }
        public int SeatsAvailable { get; set; }
        public DateTime Date { get; set; }

        [ForeignKey("PilotId")]
        public virtual Pilot pilot { get; set; }

        public virtual ICollection<Booking> BookingSet { get; set; }

    }
}
