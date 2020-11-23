using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Availability_Service.Repository;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Server.HttpSys;

namespace Availability_Service.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class AvailabilityController : ControllerBase
    {
        // GET: api/Availability
        private readonly IAvailabilityRepo _availabilityRepo;
        static readonly log4net.ILog _log4net = log4net.LogManager.GetLogger(typeof(AvailabilityController));

        public AvailabilityController(IAvailabilityRepo availabilityRepo)
        {
            _availabilityRepo = availabilityRepo;
        }
        [Microsoft.AspNetCore.Mvc.HttpGet]
        public IActionResult Get_AllFlights()
        {
            try
            {
                _log4net.Info("Getting all flights");
                var allFlights = _availabilityRepo.GetFlights();
                return Ok(allFlights);
            }
            catch
            {
                _log4net.Info("Error in getting all flights");
                return new NoContentResult();
            }

        }

        [Microsoft.AspNetCore.Mvc.HttpGet("{id}")]
        public IActionResult Get_Availability_For_Flight(int id)
        {
            try
            {
                _log4net.Info("Getting availability of flight with id " + id.ToString());
                int total_availability = _availabilityRepo.AvailableCount(id);
                if (total_availability == -1)
                {
                    return NotFound();
                }
                return Ok(total_availability);
            }
            catch
            {
                _log4net.Info("Error in getting details of flight id " + id.ToString());
                return new NoContentResult();
            }
        }

        [Microsoft.AspNetCore.Mvc.HttpDelete("reduce/{id}")]
        public IActionResult Reduce_Availability(int id)
        {
            try
            {
                _log4net.Info("Reducing the capacity of Flight with id " + id.ToString());
                bool res = _availabilityRepo.Reduce(id);
                if (res)
                {
                    _log4net.Info("Successfully reduced capacity of id " + id.ToString());
                    return Ok();
                }
                else
                {
                    return NotFound();
                }
            }
            catch
            {
                _log4net.Info("Error in reducing availability of flight id " + id.ToString());
                return new NoContentResult();
            }

        }

    }
}
