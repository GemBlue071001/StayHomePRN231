using DataAccessLayer.Interface;
using Domain;
using Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repository
{
    public class BookingDetailRepository : GenericRepository<BookingDetail>, IBookingDetailRepository
    {
        private readonly AppDbContext context;

        public BookingDetailRepository(AppDbContext context) : base(context)
        {
            this.context = context;
        }
    }
}
