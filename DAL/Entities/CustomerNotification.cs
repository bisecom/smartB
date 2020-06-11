using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace smart_booking.DAL.Entities
{
    public class CustomerNotification
    {
        [Key]
        [ForeignKey("Employee")]
        public int EmployeeId { get; set; }
        public bool? AfterBooked { get; set; }
        public bool? AfterRescheduled { get; set; }
        public bool? AfterCancelled { get; set; }
        public virtual Employee Employee { get; set; }

    }
}