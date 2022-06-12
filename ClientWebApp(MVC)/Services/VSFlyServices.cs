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

        // FLIGHTS SECTION
        public async Task<IEnumerable<FlightModels>> GetFlights()
        {
            var uri = _baseuri + "Flights/All";

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

        [HttpPost]
        public Boolean CreateFlight(FlightModels flightModels)
        {
            var uri = _baseuri + "Flights/Create";

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

        [HttpPut]
        public Boolean ModifyFlight(FlightModels flightModels)
        {
            var uri = _baseuri + "Flights/Modify";

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


        //BOOKING SECTION
        public async Task<IEnumerable<BookingModel>> GetBookings()
        {
            var uri = _baseuri + "Booking/All";

            var responseString = await _client.GetStringAsync(uri);
            var bookingList = JsonConvert.DeserializeObject<IEnumerable<BookingModel>>(responseString);
            return bookingList;
        }

        public async Task<IEnumerable<BookingModel>> GetBookingsWithPlaneId(int id)
        {
            var uri = _baseuri + "Booking/PlaneID" + id;

            var responseString = await _client.GetStringAsync(uri);
            var bookingList = JsonConvert.DeserializeObject<IEnumerable<BookingModel>>(responseString);
            return bookingList;
        }

        public async Task<IEnumerable<BookingModel>> GetBookingsWithPassengerId(int id)
        {
            var uri = _baseuri + "Booking/PassengerID" + id;

            var responseString = await _client.GetStringAsync(uri);
            var bookingList = JsonConvert.DeserializeObject<IEnumerable<BookingModel>>(responseString);
            return bookingList;
        }

        [HttpPost]
        public Boolean CreateBooking(BookingModel bookingModel)
        {
            var uri = _baseuri + "Booking/Create";

            var postTask = _client.PostAsJsonAsync<BookingModel>(uri, bookingModel);
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


        //PASSENGER SECTION
        public async Task<PassengerModel> GetPassenger(int id)
        {
            var uri = "https://localhost:44381/" + "Passenger/" + id;
            var responseString = await _client.GetStringAsync(uri);
            var passenger = JsonConvert.DeserializeObject<PassengerModel>(responseString);

            return passenger;
        }

        public async Task<IEnumerable<PassengerModel>> GetPassengers()
        {
            var uri = "https://localhost:44381/" + "Passenger/All";

            var responseString = await _client.GetStringAsync(uri);
            var passengerList = JsonConvert.DeserializeObject<IEnumerable<PassengerModel>>(responseString);
            return passengerList;
        }

        public async Task<IEnumerable<PassengerModel>> GetPassengerByName(string firstname, string surname)
        {

            var uri = "https://localhost:44381/" + "Passenger/Name/" + firstname + "" + surname;

            var responseString = await _client.GetStringAsync(uri);
            var passengerFirstname = JsonConvert.DeserializeObject<IEnumerable<PassengerModel>>(responseString);
            return passengerFirstname;
        }


        [HttpPost]
        public Boolean CreatePassenger(PassengerModel passengerModels)
        {
            var uri = "https://localhost:44381/" + "Create";

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

        [HttpDelete]
        public Boolean DeletePassenger(int id)
        {
            var uri = "https://localhost:44381/" + "Delete" + id;

            var postTask = _client.PostAsJsonAsync(uri, id);
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
