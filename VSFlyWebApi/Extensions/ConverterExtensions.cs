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
            fm.TotalSalePrice = f.TotalSalePrice;
            return fm;
        }

        //Du model à la DB
        public static VSFly.Flight ConvertToFlight(this Models.FlightModels fm)
        {
            VSFly.Flight f = new VSFly.Flight();
            f.FlightNo = fm.FlightNo;
            f.Departure = fm.Departure;
            f.Destination = fm.Destination;
            f.Seats = fm.Seats;
            f.SeatsAvailable = fm.SeatsAvailable;
            f.Date = fm.Date;
            f.Price = fm.Price;
            f.TotalSalePrice = fm.TotalSalePrice;
            return f;
        }

        public static VSFlyWebApi.Models.BookingModel ConvertToBookingM(this VSFly.Booking bk)
        {
            Models.BookingModel bm = new Models.BookingModel();
            bm.FlightNo = bk.FlightNo;
            bm.PassengerId = bk.PassengerId;
            bm.BuyPrice = bk.BuyPrice;

            return bm;
        }

        public static VSFly.Booking ConvertToBooking(this Models.BookingModel bm)
        {
            VSFly.Booking b = new VSFly.Booking();
            b.FlightNo = bm.FlightNo;
            b.PassengerId = bm.PassengerId;
            b.BuyPrice = bm.BuyPrice;
          
            return b;
        }

        public static VSFlyWebApi.Models.PassengerModel ConvertToPassengerM(this VSFly.Passenger pk)
        {
            Models.PassengerModel pm = new Models.PassengerModel();
            pm.PassengerId = pk.PassengerId;
            pm.Surname = pk.Surname;
            pm.Firstname = pk.Firstname;

            return pm;
        }

        public static VSFly.Passenger ConvertToPassenger(this Models.PassengerModel pm)
        {
            VSFly.Passenger p = new VSFly.Passenger();
            p.PassengerId = pm.PassengerId;
            p.Surname = pm.Surname;
            p.Firstname = pm.Firstname;

            return p;
        }
    }
}
