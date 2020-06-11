using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace smart_booking.DAL.Entities
{
    public class ServiceCategory
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int? BusinessId { get; set; }
        public virtual Business Business { get; set; }

        public virtual ICollection<Service> Services { get; set; }
        public ServiceCategory()
        {
            Services = new List<Service>();
        }
    }
}