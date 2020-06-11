using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace smart_booking.DAL.Entities
{
    public class Business
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public int? CountryId { get; set; }
        public virtual Country Country { get; set; }
        public int? CurrencyId { get; set; }
        public virtual Currency Currency { get; set; }
        public int? Time_zoneId { get; set; }
        public virtual Time_zone Time_zone { get; set; }
        public byte[] Logo { get; set; }
        public string Webpage { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string ZipCode { get; set; }
        public string RegistrationNumber { get; set; }

        public virtual Booking Booking { get; set; }
        public virtual ICollection<ServiceCategory> CategoryServices { get; set; }
        public virtual ICollection<Client> Clients { get; set; }
        public virtual ICollection<Employee> Employees { get; set; }
        public Business()
        {
            CategoryServices = new List<ServiceCategory>();
            Clients = new List<Client>();
            Employees = new List<Employee>();
        }

    }
}