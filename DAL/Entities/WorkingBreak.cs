using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace smart_booking.DAL.Entities
{
    public class WorkingBreak
    {
        public int Id { get; set; }
        public int? WorkingHourId { get; set; }
        public virtual WorkingHour WorkingHour { get; set; }
        public int? WeekDay { get; set; } //Starting from Sunday; Sunday == 1;
        public DateTime? BreakStart { get; set; }
        public DateTime? BreakStop { get; set; }



    }
}