using System;
using System.Collections.Generic;

namespace smart_booking.BLL.DataTransferModels
{
    public class Time_zoneDTM
    {
        public int Id { get; set; }
        public string Zone { get; set; }
        public string CountryCode { get; set; }
        public string UTC_Jan_1_2020 { get; set; }
        public string DST_Jul_1_2020 { get; set; }
        public virtual ICollection<BusinessDTM> Businesses { get; set; }
        public virtual ICollection<UserDTM> Users { get; set; }
        public virtual ICollection<CountryDTM> Countries { get; set; }
        public Time_zoneDTM()
        {
            Businesses = new List<BusinessDTM>();
            Users = new List<UserDTM>();
            Countries = new List<CountryDTM>();
        }
    }
}