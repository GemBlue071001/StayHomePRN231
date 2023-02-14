using BusinessLogicLayer.Service;
using BusinessLogicLayer.ViewModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace StayHome.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingController : ControllerBase
    {
        private BookingService _bookingService;
        
        public BookingController(BookingService bookingService)
        {
            _bookingService = bookingService;
        }
        [HttpGet(Name = "GetBookingById")]
        public IActionResult GetBookingById(Guid id)
        {
            var _booking = _bookingService.GetBooking(id);
            return Ok(_booking);
        }
        [HttpPost(Name = "Book")]
        public IActionResult Book([FromBody] BookingVM booking)
        {
            _bookingService.AddBooking(booking);
            return Ok();
        }
    }
}
