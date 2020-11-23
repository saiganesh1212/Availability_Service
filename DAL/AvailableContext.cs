using Availability_Service.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Availability_Service.DAL
{
    public class AvailableContext : DbContext
    {
        public AvailableContext(DbContextOptions<AvailableContext> options) : base(options)
        {

        }
        public virtual DbSet<Flight> Flights { get; set; }
    }
}
