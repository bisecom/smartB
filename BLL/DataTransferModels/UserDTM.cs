using System;
using System.Collections.Generic;

namespace smart_booking.BLL.DataTransferModels
{
    public class UserDTM
    {
        public string Id { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public string PhoneMobile { get; set; }
        public string PhoneOffice { get; set; }
        public int? CountryId { get; set; }
        public virtual CountryDTM Country { get; set; }
        public int? Time_ZoneId { get; set; }
        public virtual Time_zoneDTM Time_zone { get; set; }
        public byte[] UserPicture { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string ZipCode { get; set; }
        public int? PlanId { get; set; }
        public bool? IsPaymentOverdue { get; set; } = false;
        public bool? IsMale { get; set; }
        public DateTime? Birthdate { get; set; }
        public virtual ICollection<EmployeeDTM> Employees { get; set; }
        public UserDTM()
        {
            Employees = new List<EmployeeDTM>();
        }
    }
}