using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VSFly
{
    [Table("Passenger")]
    public partial class Passenger
    {
        public string Surname { get; set; }
        public string Firstname { get; set; }
        public DateTime CustomerSince { get; set; }
        public string Status { get; set; }
        [Key]
        public int PassengerId { get; set; }

        public virtual ICollection<Booking> BookingSet { get; set; }
    }
}
