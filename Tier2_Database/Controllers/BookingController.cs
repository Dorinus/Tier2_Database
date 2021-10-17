using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Simple_booking_system.Models;
using Tier2_Database.Services;

namespace Tier2_Database.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BookingController : ControllerBase
    {
        private IBookingService BookingService;

        public BookingController(IBookingService bookingService)
        {
            BookingService = bookingService;
        }

        [HttpPost]
        public async Task<ActionResult<Booking>> NewBooking([FromBody] Booking booking)
        {
            try
            {
                Booking newBooking = await BookingService.NewBooking(booking);
                return Created($"/{newBooking.Id}", newBooking);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return StatusCode(500, e.Message);
            }
        }
    }
}