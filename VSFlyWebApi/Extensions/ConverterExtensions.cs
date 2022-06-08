using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VSFlyWebApi.Extensions
{
    public static class ConverterExtensions
    {
        //Depuis la DB jusqu'au Model
        public static VSFlyWebApi.Models.FlightModels ConvertToFlightM(this VSFly.Flight f)
        {
            Models.FlightModels fm = new Models.FlightModels();
            fm.FlightNo = f.FlightNo;
            fm.Departure = f.Departure;
            fm.Destination = f.Destination;
            fm.Seats = f.Seats;
            fm.SeatsAvailable = f.SeatsAvailable;
            fm.Date = f.Date;
            fm.Price = f.Price;
            return fm;
        }

        //Du model à la DB
        public static VSFly.Flight ConvertToFlight(this Models.FlightModels fm)
        {
            VSFly.Flight f = new VSFly.Flight();
            f.FlightNo = fm.FlightNo;
            f.Departure = fm.Departure;
            f.Destination = fm.Destination;
            fm.Seats = f.Seats;
            fm.SeatsAvailable = f.SeatsAvailable;
            f.Date = fm.Date;
            f.Price = fm.Price;
            return f;
        }

    }
}
