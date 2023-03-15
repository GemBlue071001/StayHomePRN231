using AutoMapper;
using BusinessLogicLayer.ResponseModel;
using BusinessLogicLayer.ViewModel;
using Domain.Model;

namespace StayHome.AutoMapper
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Booking, BookingResponse>().ForMember
                (dest => dest.Status, opt => opt.MapFrom(src => src.Status))
                .ForMember(dest => dest.Total, opt => opt.MapFrom(src => src.BookingDetail.Total));


            CreateMap<HomeStay, HomeStayResponse>();
            CreateMap<User, UserResponse>();

            CreateMap<Booking, BookingResponse>()
                .ForMember(dest => dest.HomeStay, opt => opt.MapFrom(src => new HomeStayResponse() { Id = src.HomeStay.Id, Name = src.HomeStay.Name }))
                .ForMember(dest => dest.UserVM, opt => opt.MapFrom(src => new UserResponse() { FullName = src.User.FullName, Name = src.User.Name }))
                .ForMember(dest => dest.Status, opt => opt.MapFrom(src => src.Status))
                .ForMember(dest => dest.Total, opt => opt.MapFrom(src => src.BookingDetail.Total)); 
        }
    }
}
