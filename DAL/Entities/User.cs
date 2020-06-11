using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace smart_booking.DAL.Entities
{
    public class User
    {
        public string Id { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string SecondName { get; set; }
      
        public string PhoneMobile { get; set; }
        public string PhoneOffice { get; set; }
        public int? CountryId { get; set; }
        public virtual Country Country { get; set; }
        public int? Time_ZoneId { get; set; }
        public virtual Time_zone Time_zone { get; set; }
        public byte[] UserPicture { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string ZipCode { get; set; }
        public int? PlanId { get; set; }
        public bool? IsPaymentOverdue { get; set; }
        public bool? IsMale { get; set; }
        public DateTime? Birthdate { get; set; }

        public virtual ICollection<Employee> Employees { get; set; }
        public User()
        {
            Employees = new List<Employee>();
        }

    }
}