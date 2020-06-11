using System;
using System.Collections.Generic;

namespace smart_booking.BLL.DataTransferModels
{
    public class ServiceDTM
    {
        public int Id { get; set; }
        //public int BusinessId { get; set; }
        //public virtual BusinessDTM Business { get; set; }
        public int ServiceCategoryId { get; set; }
        public virtual ServiceCategoryDTM ServiceCategory { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public float? Price { get; set; }
        public int? Duration { get; set; }
        public int? PaddingAfter { get; set; }
        public byte[] Picture { get; set; }

        public virtual ICollection<SlotDTM> Slots { get; set; }
        public ServiceDTM()
        {
            Slots = new List<SlotDTM>();
        }
    }
}