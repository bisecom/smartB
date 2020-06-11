using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace smart_booking.DAL.Entities
{
    public class Currency
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Business> Businesses { get; set; }
        public Currency()
        {
            Businesses = new List<Business>();
        }
    }
}