using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VSFlyWebApi.Models
{
    public class BuyTicketModel
    {
        public string FullName { get; set; }
        public string Destination { get; set; }
        public DateTime Date { get; set; }
        public int FlightNo { get; set; }
    }
}
