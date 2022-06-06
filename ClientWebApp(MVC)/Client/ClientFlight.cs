using ClientWebApp_MVC_.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VSFly;

namespace ClientWebApp_MVC_.Client
{
    public partial class APIClient
    {
        readonly string uriFlight = "https://localhost:44381/api/Flights/";

        public async Task<List<Models.FlightModels>> GetFlights()
        {
       

            var requestUrl = CreateRequestUri(uriFlight);
            return await GetAsync<List<Models.FlightModels>>(requestUrl);
        }



        public async Task<VSFly.FlightModels> GetFlight(int id)
        {
            var requestUrl = CreateRequestUri(uriFlight + id);
            return await GetAsync<VSFly.FlightModels>(requestUrl);
        }

    }
}
