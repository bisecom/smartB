using System;

namespace smart_booking.BLL.DataTransferModels
{
    public class CalendarSettingDTM
    {
        public int EmployeeId { get; set; }
        public int? View { get; set; }
        public DateTime? FirstHour { get; set; } 
            = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 9, 0, 0);
        public int? WorkingDayDuration { get; set; } = 8;
        public int? SlotDuration { get; set; } = 30;
        public virtual EmployeeDTM Employee { get; set; }
    }
}