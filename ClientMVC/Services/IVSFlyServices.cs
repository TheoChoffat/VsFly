using ClientMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClientMVC.Services
{
    public interface IVSFlyServices
    {
        public Task<IEnumerable<FlightModel>> GetFlights();
    }
}
