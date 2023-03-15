using DataAccessLayer.Interface;
using Domain;
using Domain.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repository
{
    public class BookingRepository : GenericRepository<Booking> , IBookingRepository
    {
        public BookingRepository(AppDbContext context) : base(context)
        {

        }

        public Booking GetBookingById (Guid bookingId)
        {
            var _booking = Context.Bookings.Where(b=> b.Id ==bookingId )//LINQ
                .Include(b=>b.BookingDetail).Include(b=>b.HomeStay).Include(b => b.User).FirstOrDefault();
            return _booking;
        }

        public override List<Booking> GetAll()
        {
            var list = Context.Bookings.Include(b => b.HomeStay).Include(b => b.User).Include(b => b.BookingDetail).ToList();
            return list;
        }

    }
}
