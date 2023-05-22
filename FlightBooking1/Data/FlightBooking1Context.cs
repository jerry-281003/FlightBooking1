using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using FlightBooking1.Models;

namespace FlightBooking1.Data
{
    public class FlightBooking1Context : DbContext
    {
        public FlightBooking1Context (DbContextOptions<FlightBooking1Context> options)
            : base(options)
        {
        }

        public DbSet<FlightBooking1.Models.Customer> Customer { get; set; } = default!;

        public DbSet<FlightBooking1.Models.Flight>? Flight { get; set; }

        public DbSet<FlightBooking1.Models.FlightSchedules>? FlightSchedules { get; set; }

        public DbSet<FlightBooking1.Models.Plane>? Plane { get; set; }

        public DbSet<FlightBooking1.Models.Reservations>? Reservations { get; set; }
    }
}
