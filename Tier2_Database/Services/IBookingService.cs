using System.Threading.Tasks;
using Simple_booking_system.Models;

namespace Tier2_Database.Services
{
    public interface IBookingService
    {
        Task<Booking> NewBooking(Booking booking);
    }
}