using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace smart_booking.DAL.Entities
{
    public class Slot
    {
        public int Id { get; set; }
        public int EmployeeId { get; set; }
        //[ForeignKey("Employee")]
        public virtual Employee Employee { get; set; }
        public int CountryId { get; set; }
        //[ForeignKey("Country")]
        //public virtual Country Country { get; set; }
        public DateTime? SlotDateTime { get; set; }
        public int? Duration { get; set; }
        public bool? IsPadding { get; set; }
        public int? PaddingAfter { get; set; }
        public int? Reiteration { get; set; }
        public float? Price { get; set; }
        public int? ResponsibleId { get; set; }
        //[ForeignKey("Employee")]
        public virtual Employee Responsible { get; set; }
        public string Note { get; set; }
        public string Status { get; set; }
        public bool? IsTimeBlock { get; set; }
        public bool? IsReminderNeeded { get; set; }
        public int? ReminderInterval { get; set; }
       
        public int ServiceId { get; set; }
        //[ForeignKey("Service")]
        //public virtual Service Service { get; set; }
    }
}