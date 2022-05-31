using ClientWebApp.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace ClientWebApp.Services
{
    public class VSFlyServices
    {
        private readonly HttpClient _client;
        private readonly string _baseuri;

        public VSFlyServices(HttpClient client)
        {
            _client = client;
            _baseuri = "https://localhost:44336/api/";

        }
        public async Task<IEnumerable<FlightsModel>> GetFlights()
        {
            var uri = _baseuri + "Flights";

            var responseString = await _client.GetStringAsync(uri);
            var fligthList = JsonConvert.DeserializeObject<IEnumerable<FlightsModel>>(responseString);
            return fligthList;
        }
    }
}
