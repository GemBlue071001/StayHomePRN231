using BusinessLogicLayer.ResponseModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.ViewModel
{
    public class BookingVM
    {
        public bool Status { get; set; }
        public double Total { get; set; }
        public Guid UserId { get; set; }
        public Guid HomeStayId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        //public HomeStayResponse HomeStay { get; set; }

        //public UserVM UserVM { get; set; }

    }
}
