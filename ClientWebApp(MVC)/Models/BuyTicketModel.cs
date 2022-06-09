using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ClientWebApp_MVC_.Models
{
    public class BuyTicketModel
    {
        [Required]
        public string FullName { get; set; }
        public string Destination { get; set; }
        public DateTime Date { get; set; }
        public int FlightNo { get; set; }
    }
}
