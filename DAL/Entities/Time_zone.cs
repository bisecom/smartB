using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace smart_booking.DAL.Entities
{
    public class Time_zone
    {
        public int Id { get; set; }
        public string Zone { get; set; }
        public string CountryCode { get; set; }
        public string UTC_Jan_1_2020 { get; set; }
        public string DST_Jul_1_2020 { get; set; }

        public virtual ICollection<Business> Businesses { get; set; }
        public virtual ICollection<User> Users { get; set; }
        public virtual ICollection<Country> Countries { get; set; }
        public Time_zone() {
            Businesses = new List<Business>();
            Users = new List<User>();
            Countries = new List<Country>();
        }

    }
}