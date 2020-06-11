using smart_booking.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace smart_booking.BLL.DataTransferModels
{
    public class BookingDTM
    {
        public int BusinessId { get; set; }
        public string WebpageLink { get; set; }
        public bool? IsEntityLogoRemoved { get; set; } = false;
        public bool? IsMemberSelecting { get; set; } = false;
        public int? SlotDuration { get; set; }// Delete property
        public int? PageLanguageId { get; set; }
        public byte[] BannerPicture { get; set; }
        public string SklypeLink { get; set; }
        public string FacebookLink { get; set; }
        public string TwitterLink { get; set; }
        public string InstagramkLink { get; set; }
        public string YoutubeLink { get; set; }
        public string PageOverview { get; set; }
        public bool? IsContactsAvailable { get; set; } = false;
        public bool? IsServicesAvailable { get; set; } = true;
        public bool? IsPriceAvailable { get; set; } = false;
        public bool? IsDurationAvailable { get; set; } = false;
        public bool? IsDescriptionAvailable { get; set; } = true;
        public virtual BusinessDTM Business { get; set; }
    }
}