using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace smart_booking.DAL.Entities
{
    public class Service
    {
        public int Id { get; set; }
       
        public int? ServiceCategoryId { get; set; }
        //[ForeignKey("ServiceCategory")]
        public virtual ServiceCategory ServiceCategory { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public float? Price { get; set; }
        public int? Duration { get; set; }
        public int? PaddingAfter { get; set; }
        public byte[] Picture { get; set; }

        //public virtual ICollection<Slot> Slots { get; set; }
        //public Service()
        //{
        //    Slots = new List<Slot>();
        //}

    }
}