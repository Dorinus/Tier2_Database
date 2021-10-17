using System;
using System.Collections.Generic;
using System.IO;
using Microsoft.EntityFrameworkCore;
using Simple_booking_system.Models;

namespace Tier2_Database.DataAccess
{
    public class SimpleBookingDBContext : DbContext
    {
        public DbSet<Resource> Resources { get; set; }
        public DbSet<Booking> Bookings { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // name of database
            optionsBuilder.UseSqlite("Data Source = SimpleBooking.db");
        }
    }
}