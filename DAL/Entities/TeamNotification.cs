using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace smart_booking.DAL.Entities
{
    public class TeamNotification
    {
        [Key]
        [ForeignKey("Employee")]
        public int EmployeeId { get; set; }
        public bool? AfterBooked { get; set; }
        public bool? AfterRescheduled { get; set; }
        public bool? Collegue { get; set; }
        public bool? CollegueAndOwner { get; set; }
        public bool? Owner { get; set; }
        public virtual Employee Employee { get; set; }
    }
}