using Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Interface
{
    public interface IBookingRepository :IGenericRepository<Booking>
    {
        public Booking GetBookingById(Guid bookingId);
    }
}
