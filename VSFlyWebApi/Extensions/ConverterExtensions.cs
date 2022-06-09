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

        public static VSFlyWebApi.Models.BookingModel ConvertToBookingM(this VSFly.Booking bk)
        {
            Models.BookingModel bm = new Models.BookingModel();
            bm.FlightNo = bk.FlightNo;
            bm.Flight = bk.Flight;
            bm.Passenger = bk.Passenger;
            bm.PassengerId = bk.PassengerId;
           
            return bm;
        }

        public static VSFly.Booking ConvertToBooking(this Models.BookingModel bm)
        {
            VSFly.Booking b = new VSFly.Booking();
            b.FlightNo = bm.FlightNo;
            b.Flight = bm.Flight;
            b.Flight.Destination = bm.Flight.Destination;
            b.Passenger = bm.Passenger;
            b.Passenger.Surname = bm.Passenger.Surname;
            b.PassengerId = bm.PassengerId;
          
            return b;
        }

        public static VSFlyWebApi.Models.PilotModel ConvertToPilotM(this VSFly.Pilot pk)
        {
            Models.PilotModel pm = new Models.PilotModel();
            pm.PilotId = pk.PilotId;
            pm.FullName = pk.FullName;
            pm.LicenseDate = pk.LicenseDate; 

            return pm;
        }

        public static VSFly.Pilot ConvertToPilot(this Models.PilotModel pm)
        {
            VSFly.Pilot p = new VSFly.Pilot();
            p.PilotId = pm.PilotId;
            p.FullName = pm.FullName;
            p.LicenseDate = pm.LicenseDate;
          
            return p;
        }
    }
}
