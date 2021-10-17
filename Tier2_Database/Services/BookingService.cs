using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Simple_booking_system.Models;
using Tier2_Database.DataAccess;

namespace Tier2_Database.Services
{
    public class BookingService : IBookingService
    {
        public async Task<Booking> NewBooking(Booking booking)
        {
            await using (SimpleBookingDBContext SBContext = new SimpleBookingDBContext())
            {
                try
                {
                    await SBContext.Bookings.AddAsync(booking);
                    await SBContext.SaveChangesAsync();

                    // returning created booking for the id
                    var dbSet = SBContext.Bookings;
                    var tempBooking = await dbSet.OrderBy(n => n).LastOrDefaultAsync();


                    Console.WriteLine(tempBooking.Id);
                    return tempBooking;
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                }
            }

            return null;
        }
    }
}