using ClientWebApp_MVC_.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClientWebApp_MVC_.Services
{
    public interface IVSFlyServices
    {
        //FLIGHTS
        public Task<IEnumerable<FlightModels>> GetFlights();
        public Task<FlightModels> GetFlight(int id);
        public Boolean CreateFlight(FlightModels flightModels);
        public Boolean ModifyFlight(FlightModels flightModels);

        //BOOKINGS
        public Task<IEnumerable<BookingModel>> GetBookings();
        public Task<IEnumerable<BookingModel>> GetBookingsWithPassengerId(int id);
        public Task<IEnumerable<BookingModel>> GetBookingsWithPlaneId(int id);
        public Boolean CreateBooking(BookingModel bookingModel);

        //PASSENGERS
        public Task<PassengerModel> GetPassenger(int id);
        public Task<IEnumerable<PassengerModel>> GetPassengers();
        public Boolean CreatePassenger(PassengerModel passengerModels);
        public Task<IEnumerable<PassengerModel>> GetPassengerByName(string firstname, string surname);
        public Boolean DeletePassenger(int id);






    }
}

    
