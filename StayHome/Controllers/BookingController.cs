using AutoMapper;
using BusinessLogicLayer.ResponseModel;
using BusinessLogicLayer.Service;
using BusinessLogicLayer.ViewModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace StayHome.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingController : ControllerBase
    {
        private BookingService _bookingService;
        private IMapper _mapper;

        public BookingController(BookingService bookingService, IMapper mapper)
        {
            _bookingService = bookingService;
            _mapper = mapper;
        }
        [HttpGet("GetBookingById")]
        public IActionResult GetBookingById(Guid id)
        {
            var _booking = _bookingService.GetBooking(id);
            return Ok(_booking);
        }
        [HttpPost("Book")]
        public IActionResult Book([FromBody] BookingVM booking)
        {
            var res = _bookingService.AddBooking(booking);
            if (res)
            {
                return Ok(res);
            }
            else
            {
                return BadRequest();
            }

        }

        [HttpGet("GetAllBooking")]
        public IActionResult GetAll()
        {
            var list = _bookingService.GetAllBooking();
            List<BookingResponse> res = _mapper.Map<List<BookingResponse>>(list);
            if (list != null)
                return Ok(res);
            else
                return BadRequest();
        }

    }
}
