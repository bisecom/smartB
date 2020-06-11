using System;
using System.Collections.Generic;

namespace smart_booking.BLL.DataTransferModels
{
    public class CurrencyDTM
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<BusinessDTM> Businesses { get; set; }
        public CurrencyDTM()
        {
            Businesses = new List<BusinessDTM>();
        }
    }
}