using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Model
{
    public class Booking
    {
        public Guid Id { get; set; }
        public bool Status { get; set; }

        public DateTime OrderDate { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        // Navigation property

        public virtual BookingDetail BookingDetail { get; set; }

        public User User { get; set; }
        public Guid UserId { get; set; }

        public HomeStay HomeStay { get; set; }
        public Guid HomeStayId { get; set; }


    }
}
