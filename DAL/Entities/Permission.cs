using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace smart_booking.DAL.Entities
{
    public class Permission
    {
        [Key]
        [ForeignKey("Employee")]
        public int EmployeeId { get; set; }
        public bool? IsSummary { get; set; }
        public bool? IsOthersCalendar { get; set; }
        public bool? IsClients { get; set; }
        public bool? IsServices { get; set; }
        public bool? IsReports { get; set; }
        public virtual Employee Employee { get; set; }
    }
}