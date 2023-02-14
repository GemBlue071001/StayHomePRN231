using AutoMapper;
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
        public void AddBooking(BookingVM bookingVM)
        {

            var _booking = new Booking()
            {
                Id = Guid.NewGuid(),
                Status = bookingVM.Status,
            };

            _bookingRepository.Insert(_booking);
            _bookingRepository.Save();


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


        }

        public BookingVM GetBooking(Guid bookingId)
        {
            var _booking = _bookingRepository.GetBookingById(bookingId);
            var _bookingVM = _mapper.Map<BookingVM>(_booking);
            return _bookingVM;


            /*return new BookingVM()
            {
                Status= _booking.Status,
                Total= _booking.BookingDetail.Total
            };*/
        }



    }
}
