using System;

namespace smart_booking.BLL.DataTransferModels
{
    public class CustomerNotificationDTM
    {
        public int EmployeeId { get; set; }
        public bool? AfterBooked { get; set; } = true;
        public bool? AfterRescheduled { get; set; } = false;
        public bool? AfterCancelled { get; set; } = false;
        public virtual EmployeeDTM Employee { get; set; }
    }
}