using Availability_Service.DAL;
using Availability_Service.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Availability_Service.Repository
{
    public class AvailabilityRepo : IAvailabilityRepo
    {
        private readonly AvailableContext _context;
        public AvailabilityRepo(AvailableContext context)
        {
            _context = context;
        }
        public int AvailableCount(int Flightid)
        {

            var res =  _context.Flights.Where(x => x.FlightId == Flightid).FirstOrDefault();
            if (res == null)
            {
                return -1;
            }

            return res.Available_Seats;


        }

        public IEnumerable<Flight> GetFlights()
        {

            var result =  _context.Flights.ToList();
            return result;

        }

        public bool Reduce(int flightId)
        {
            var flight =  _context.Flights.Where(x => x.FlightId == flightId).FirstOrDefault();
            if (flight == null || flight.Available_Seats == 0)
            {
                return false;
            }

            flight.Available_Seats -= 1;
             _context.SaveChanges();
            return true;

        }
    }
}
