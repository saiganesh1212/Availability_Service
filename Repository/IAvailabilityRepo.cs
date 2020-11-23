using Availability_Service.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Availability_Service.Repository
{
    public interface IAvailabilityRepo
    {
        public IEnumerable<Flight> GetFlights();
        public int AvailableCount(int Flightid);

        public bool Reduce(int Flightid);
    }
}
