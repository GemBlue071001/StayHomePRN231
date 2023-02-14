using AutoMapper;
using BusinessLogicLayer.ViewModel;
using Domain.Model;

namespace StayHome.AutoMapper
{
    public class AutoMapperProfile :Profile 
    {
        public AutoMapperProfile()
        {
            CreateMap<Booking, BookingVM>().ForMember
                (dest => dest.Status, opt => opt.MapFrom(src => src.Status))
                .ForMember(dest => dest.Total, opt => opt.MapFrom(src => src.BookingDetail.Total));
        }
    }
}
