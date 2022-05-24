using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VSFly
{
    [Table("Pilot")]
    public partial class Pilot:Employee
    {
        public DateTime FlightHours { get; set; }
        public string FlightSchool { get; set; }
        public DateTime LicenseDate { get; set; }
       
        public virtual ICollection<Flight> FlightAsPilotSet { get; set; }
    }
}
