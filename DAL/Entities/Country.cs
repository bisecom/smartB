using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace smart_booking.DAL.Entities
{
    public class Country
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string Native { get; set; }
        public string PhonePrefix { get; set; }
        public string Capital { get; set; }
        public string Currency_ { get; set; }
        public string Emoji { get; set; }
        public string EmojiU { get; set; }

        public virtual ICollection<Business> Businesses { get; set; }
        public virtual ICollection<User> Users { get; set; }
        public virtual ICollection<Time_zone> Time_zones { get; set; }
        //public virtual ICollection<Slot> Slots { get; set; }
        public Country()
        {
            Businesses = new List<Business>();
            Users = new List<User>();
            Time_zones = new List<Time_zone>();
            //Slots = new List<Slot>();
        }
    }
}