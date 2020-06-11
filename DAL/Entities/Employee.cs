using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace smart_booking.DAL.Entities
{
    public class Employee
    {
        public int Id { get; set; }
        public int? BusinessId { get; set; }
        public virtual Business Business { get; set; }
        public string UserId { get; set; }
        public virtual User User { get; set; }
        public bool? IsOwner { get; set; }
        
        public virtual CalendarSetting CalendarSetting { get; set; }
        public virtual CustomerNotification CustomerNotification { get; set; }
        public virtual TeamNotification TeamNotification { get; set; }
        public virtual Permission Permission { get; set; }
        public virtual WorkingHour WorkingHour { get; set; }
        public virtual ICollection<Slot> SlotsOwners { get; set; }
        public virtual ICollection<Slot> Responsibles { get; set; }

        public Employee()
        {
            SlotsOwners = new List<Slot>();
            Responsibles = new List<Slot>();

        }

    }
}