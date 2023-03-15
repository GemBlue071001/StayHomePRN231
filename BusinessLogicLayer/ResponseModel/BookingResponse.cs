using BusinessLogicLayer.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.ResponseModel
{
    public class BookingResponse
    {
        public bool Status { get; set; }
        public double Total { get; set; }
        public Guid UserId { get; set; }
        public Guid HomeStayId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public HomeStayResponse HomeStay { get; set; }

        public UserResponse UserVM { get; set; }
    }
}
