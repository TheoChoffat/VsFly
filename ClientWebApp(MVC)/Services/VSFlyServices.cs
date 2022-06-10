using ClientWebApp_MVC_.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
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
            var uri = _baseuri + "Flights/All";

            var responseString = await _client.GetStringAsync(uri);
            var fligthList = JsonConvert.DeserializeObject<IEnumerable<FlightModels>>(responseString);
            return fligthList;
        }

        public async Task<IEnumerable<BookingModel>> GetBookings()
        {
            var uri = _baseuri + "Booking/All";

            var responseString = await _client.GetStringAsync(uri);
            var bookingList = JsonConvert.DeserializeObject<IEnumerable<BookingModel>>(responseString);
            return bookingList;
        }

        public async Task<FlightModels> GetFlight(int id)
        {
            var uri = _baseuri + "Flights/" + id;
            var responseString = await _client.GetStringAsync(uri);
            var flight = JsonConvert.DeserializeObject<FlightModels>(responseString);

            return flight;
        }

        public async Task<PassengerModel> GetPassenger(int id)
        {
            var uri = _baseuri + "Passenger/" + id;
            var responseString = await _client.GetStringAsync(uri);
            var passenger = JsonConvert.DeserializeObject<PassengerModel>(responseString);

            return passenger;
        }

        public async Task<IEnumerable<PassengerModel>> GetPassengers()
        {
            var uri = _baseuri + "Passenger/All";

            var responseString = await _client.GetStringAsync(uri);
            var passengerList = JsonConvert.DeserializeObject<IEnumerable<PassengerModel>>(responseString);
            return passengerList;
        }

        [HttpPost]
        public Boolean CreatePassenger(PassengerModel passengerModels)
        {
            var uri = _baseuri + "Passenger/";

            var postTask = _client.PostAsJsonAsync<PassengerModel>(uri, passengerModels);
            postTask.Wait();

            var result = postTask.Result;
            if (result.IsSuccessStatusCode)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        //[HttpPut]
        //public Boolean UpdateFlight(FlightModels flightModels)
        //{
        //    var uri = _baseuri + "Flights/UpdateFlight" + flightModels;

        //    var postTask = _client.PutAsJsonAsync<FlightModels>(uri, flightModels);
        //    postTask.Wait();

        //    var result = postTask.Result;
        //    if (result.IsSuccessStatusCode)
        //    {
        //        return true;
        //    }
        //    else
        //    {
        //        return false;
        //    }

        //}

        [HttpPost]
        public Boolean CreateFlight(FlightModels flightModels)
        {
            var uri = _baseuri + "Flights/";

            var postTask = _client.PostAsJsonAsync<FlightModels>(uri, flightModels);
            postTask.Wait();

            var result = postTask.Result;
            if (result.IsSuccessStatusCode)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

    }
}
