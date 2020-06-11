using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace smart_booking.DAL.Entities
{
    public class Booking
    {
        [Key]
        [ForeignKey("Business")]
        public int BusinessId { get; set; }
        public string WebpageLink { get; set; }
        public bool? IsEntityLogoRemoved { get; set; }
        public bool? IsMemberSelecting { get; set; }
        public int? SlotDuration { get; set; }
        public int? PageLanguageId { get; set; }
        public byte[] BannerPicture { get; set; }
        public string SklypeLink { get; set; }
        public string FacebookLink { get; set; }
        public string TwitterLink { get; set; }
        public string InstagramkLink { get; set; }
        public string YoutubeLink { get; set; }
        public string PageOverview { get; set; }
        public bool? IsContactsAvailable { get; set; }
        public bool? IsServicesAvailable { get; set; }
        public bool? IsPriceAvailable { get; set; }
        public bool? IsDurationAvailable { get; set; }
        public bool? IsDescriptionAvailable { get; set; }

        public virtual Business Business { get; set; }
    }
}