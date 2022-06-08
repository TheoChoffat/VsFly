using ClientWebApp_MVC_.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClientWebApp_MVC_.Services
{
        public interface IVSFlyServices
        {
            public Task<IEnumerable<FlightModels>> GetFlights();
            public Task<IEnumerable<BookingModel>> GetBookings();
            public Task<FlightModels> GetFlight(int id);
    }
    }
