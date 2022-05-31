﻿using ClientMVC.Models;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace ClientMVC.Services
{
    public class VSFlyServices : IVSFlyServices
    {
        private readonly HttpClient _client;
        private readonly string _baseuri;

        public VSFlyServices(HttpClient client)
        {
            _client = client;
            _baseuri = "https://localhost:44336/api/"; //44381

        }
        public async Task<IEnumerable<FlightModel>> GetFlights()
        {
            var uri = _baseuri + "Flights";

            var responseString = await _client.GetStringAsync(uri);
            var fligthList = JsonConvert.DeserializeObject<IEnumerable<FlightModel>>(responseString);
            return fligthList;
        }
    }
}
