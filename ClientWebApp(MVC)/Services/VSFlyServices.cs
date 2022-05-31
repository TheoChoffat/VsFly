using ClientWebApp_MVC_.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace ClientWebApp_MVC_.Services
{
        public class VSFlyServices : IVSFlyServices
        {
            private readonly HttpClient _client;
            private readonly string _baseuri;

            public VSFlyServices(HttpClient client)
            {
                _client = client;
                _baseuri = "https://localhost:44381/api/";

            }
            public async Task<IEnumerable<FlightModels>> GetFlights()
            {
                var uri = _baseuri + "Flights";

                var responseString = await _client.GetStringAsync(uri);
                var fligthList = JsonConvert.DeserializeObject<IEnumerable<FlightModels>>(responseString);
                return fligthList;
            }

            public async Task<FlightModels> GetFlight(int id)
             {
            var uri = _baseuri + "Flights/" + id;
            var responseString = await _client.GetStringAsync(uri);
            var flight = JsonConvert.DeserializeObject<FlightModels>(responseString);

            return flight;
             }


        }
    }
