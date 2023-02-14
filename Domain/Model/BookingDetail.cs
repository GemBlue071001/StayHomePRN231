using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Model
{
    public class BookingDetail
    {
        
        public Guid Id { get; set; }
        public double Total { get; set; }


       
        // Navigation property
        public virtual Booking Booking { get; set; }
        [ForeignKey("BookingId")]
        public  Guid BookingId { get; set; }

    }
}
