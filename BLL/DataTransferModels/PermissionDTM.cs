using System;

namespace smart_booking.BLL.DataTransferModels
{
    public class PermissionDTM
    {
        public int EmployeeId { get; set; }
        public bool? IsSummary { get; set; } = true;
        public bool? IsOthersCalendar { get; set; } = false;
        public bool? IsClients { get; set; } = true;
        public bool? IsServices { get; set; } = true;
        public bool? IsReports { get; set; } = false;
        public virtual EmployeeDTM Employee { get; set; }
    }
}