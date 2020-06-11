using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace smart_booking.DAL.Entities
{
    public class WorkingHour
    {
        [Key]
        [ForeignKey("Employee")]
        public int EmployeeId { get; set; }
        public virtual Employee Employee { get; set; }

        public DateTime? MondayStart { get; set; }
        public DateTime? MondayStop { get; set; }
        public DateTime? TuesdayStart { get; set; }
        public DateTime? TuesdayStop { get; set; }
        public DateTime? WednesdayStart { get; set; }
        public DateTime? WednesdayStop { get; set; }
        public DateTime? ThursdayStart { get; set; }
        public DateTime? ThursdayStop { get; set; }
        public DateTime? FridayStart { get; set; }
        public DateTime? FridayStop { get; set; }
        public DateTime? SaturdayStart { get; set; }
        public DateTime? SaturdayStop { get; set; }
        public DateTime? SundayStart { get; set; }
        public DateTime? SundayStop { get; set; }

        public virtual ICollection<WorkingBreak> WorkingBreaks { get; set; }
        public WorkingHour()
        {
            WorkingBreaks = new List<WorkingBreak>();

        }
    }
}