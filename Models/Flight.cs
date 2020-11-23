using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Availability_Service.Models
{
    public class Flight
    {
        public int FlightId { get; set; }
        [Required]
        public string Company_Name { get; set; }
        [Required]
        public string Starting_Location { get; set; }
        [Required]
        public string Destination { get; set; }
        [Required]
        public int Available_Seats { get; set; }
    }
}
