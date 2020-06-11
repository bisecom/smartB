using System;

namespace smart_booking.BLL.DataTransferModels
{
    public class WorkingBreakDTM
    {
        public int Id { get; set; }
        public int? WorkingHourId { get; set; }
        public virtual WorkingHourDTM WorkingHour { get; set; }
        public int? WeekDay { get; set; } //Starting from Sunday; Sunday == 1;
        public DateTime? BreakStart { get; set; }
        public DateTime? BreakStop { get; set; }



    }
}