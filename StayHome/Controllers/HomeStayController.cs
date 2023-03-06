using AutoMapper;
using BusinessLogicLayer.ResponseModel;
using BusinessLogicLayer.Service;
using BusinessLogicLayer.ViewModel;
using Domain.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace StayHome.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HomeStayController : ControllerBase
    {
        private HomeStayService _homeStayService;
        private IMapper _mapper;
        public HomeStayController(HomeStayService homeStayService, IMapper mapper)
        {
            _homeStayService = homeStayService;
            _mapper = mapper;
        }

        [HttpGet("GetAllHomeStay")]
        public IActionResult GetAll()
        {
            var list = _homeStayService.GetHomeStays().ToList();
            List<HomeStayResponse> res = _mapper.Map<List<HomeStayResponse>>(list);
            return Ok(res);
        }

        [HttpPost("AddNewHomeStay")]
        public IActionResult AddHomeStay ( HomeStayVM homeStay)
        {
            _homeStayService.AddHomeStay(homeStay);
            return Ok();
        }
    }
}
