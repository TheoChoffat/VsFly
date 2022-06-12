using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ClientWebApp_MVC_.Models
{
        public class FlightModels
        {
            [Key]
            public int FlightNo { get; set; }
            public string Departure { get; set; }
            public string Destination { get; set; }
            public double Price { get; set; }
            public int Seats { get; set; }
            public int SeatsAvailable { get; set; }
            public DateTime Date { get; set; }
            public double TotalSalePrice { get; set; }
    }
    }

