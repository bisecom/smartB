using System;
using System.Collections.Generic;

namespace smart_booking.BLL.DataTransferModels
{
    public class WorkingHourDTM
    {
        public int EmployeeId { get; set; }
        public virtual EmployeeDTM Employee { get; set; }
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
        public virtual ICollection<WorkingBreakDTM> WorkingBreaks { get; set; }
        public WorkingHourDTM()
        {
            WorkingBreaks = new List<WorkingBreakDTM>();

        }
    }
}