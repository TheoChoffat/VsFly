using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ClientWebApp_MVC_.Models
{
    public class PassengerModel
    {
        public string Surname { get; set; }
        public string Firstname { get; set; }
        public int FK_Flight_No { get; set; }
        public double Price { get; set; }
        [Key]
        public int PassengerId { get; set; }
    }
}
