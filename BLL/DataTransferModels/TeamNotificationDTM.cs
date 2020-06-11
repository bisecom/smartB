using System;

namespace smart_booking.BLL.DataTransferModels
{
    public class TeamNotificationDTM
    {
        public int EmployeeId { get; set; }
        public bool? AfterBooked { get; set; } = true;
        public bool? AfterRescheduled { get; set; } = false;
        public bool? Collegue { get; set; } = false;
        public bool? CollegueAndOwner { get; set; } = false;
        public bool? Owner { get; set; } = true;
        public virtual EmployeeDTM Employee { get; set; }
    }
}