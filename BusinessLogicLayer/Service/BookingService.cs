using AutoMapper;
using BusinessLogicLayer.ResponseModel;
using BusinessLogicLayer.ViewModel;
using DataAccessLayer.Interface;
using Domain.Model;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Service
{
    public class BookingService
    {
        private IBookingRepository _bookingRepository;
        private IBookingDetailRepository _bookingDetailRepository;
        private IMapper _mapper;

        public BookingService(IBookingDetailRepository bookingDetailRepository, IBookingRepository bookingRepository, IMapper mapper)
        {
            _bookingDetailRepository = bookingDetailRepository;
            _bookingRepository = bookingRepository;
            _mapper = mapper;
        }
        public bool AddBooking(BookingVM bookingVM)
        {
            // insert booking 
            try
            {
                if (bookingVM.StartDate > bookingVM.EndDate)
                {
                    throw new ArgumentException("Invalid Date");
                }
                var list = _bookingRepository.GetAll();

                foreach (var item in list)
                {
                    if (bookingVM.StartDate > item.StartDate && item.HomeStayId == bookingVM.HomeStayId
                        || bookingVM.EndDate < item.EndDate && item.HomeStayId == bookingVM.HomeStayId)
                    {
                        throw new ArgumentException("Not availible ");
                    }
                }

                var _booking = new Booking()
                {
                    Id = Guid.NewGuid(),
                    Status = bookingVM.Status,
                    HomeStayId = bookingVM.HomeStayId,
                    UserId = bookingVM.UserId,
                };

                _bookingRepository.Insert(_booking);
                _bookingRepository.Save();

                // insert booking detail
                var _bookingDetail = new BookingDetail()
                {
                    Id = Guid.NewGuid(),
                    Total = bookingVM.Total,
                };
                _booking.BookingDetail = _bookingDetail;
                _bookingDetail.Booking = _booking;
                _bookingDetail.BookingId = _booking.Id;


                _bookingDetailRepository.Insert(_bookingDetail);
                _bookingRepository.Save();
                return true;
            }
            catch (ArgumentException)
            {
                Console.WriteLine("Error");
                return false;
            }


        }

        public BookingResponse GetBooking(Guid bookingId)
        {
            var _booking = _bookingRepository.GetBookingById(bookingId);
            Console.WriteLine(_booking.HomeStay.Name);
            var _bookingResponse = _mapper.Map<BookingResponse>(_booking);
            return _bookingResponse;
        }

        public List<Booking> GetAllBooking()
        {
            var list = _bookingRepository.GetAll();
            return list;
        }



    }
}
