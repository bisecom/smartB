﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace smart_booking.DAL.Entities
{
    public class Client
    {
        public int Id { get; set; }
        public int? BusinessId { get; set; }
        public virtual Business Business { get; set; }
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public string ClientCompanyName { get; set; }
        public string Email { get; set; }
        public string MobilePhone { get; set; }
        public string OfficePhone { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Zip_Code { get; set; }
        public DateTime? BirthDay { get; set; }
        public byte[] Image { get; set; }
        public bool? IsMale { get; set; }
        public string Note { get; set; }
    }
}