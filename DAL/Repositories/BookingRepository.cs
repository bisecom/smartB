using DAL.Interfaces;
using smart_booking.DAL.EF;
using smart_booking.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public class BookingRepository : IRepository<Booking>
    {
        private SBContext db;

        public BookingRepository(SBContext context)
        {
            this.db = context;
        }

        public async Task<bool> Create(Booking item)
        {
            try
            {
                db.Bookings.Add(item);
                await db.SaveChangesAsync();
                return true;
            }
            catch (Exception ex) { Console.Out.WriteLine(ex.Message); return false; }
        }

        public async Task<bool> Delete(int id)
        {
            try
            {
                Booking booking = await db.Bookings.FindAsync(id);
                if (booking != null)
                {
                    db.Bookings.Remove(booking);
                    await db.SaveChangesAsync();
                    return true;
                }
            }
            catch (Exception ex) { Console.Out.WriteLine(ex.Message); }
            return false;
        }

        public IQueryable<Booking> Find(Func<Booking, bool> predicate)
        {
            return db.Bookings.AsQueryable();
        }

        public async Task<Booking> Get(int id)
        {
            return await db.Bookings.FindAsync(id);
        }

        public IQueryable<Booking> GetAll()
        {
            return db.Bookings.AsQueryable();
        }

        public async Task<bool> Update(Booking booking)
        {
            try
            {
                var initialBooking = await db.Bookings.FindAsync(booking.BusinessId);
                if (initialBooking != null)
                {
                    initialBooking.WebpageLink = booking.WebpageLink;
                    initialBooking.IsEntityLogoRemoved = booking.IsEntityLogoRemoved;
                    initialBooking.IsMemberSelecting = booking.IsMemberSelecting;
                    initialBooking.SlotDuration = booking.SlotDuration;
                    initialBooking.PageLanguageId = booking.PageLanguageId;
                    initialBooking.BannerPicture = booking.BannerPicture;
                    initialBooking.SklypeLink = booking.SklypeLink;
                    initialBooking.FacebookLink = booking.FacebookLink;
                    initialBooking.TwitterLink = booking.TwitterLink;
                    initialBooking.InstagramkLink = booking.InstagramkLink;
                    initialBooking.YoutubeLink = booking.YoutubeLink;
                    initialBooking.PageOverview = booking.PageOverview;
                    initialBooking.IsContactsAvailable = booking.IsContactsAvailable;
                    initialBooking.IsServicesAvailable = booking.IsServicesAvailable;
                    initialBooking.IsPriceAvailable = booking.IsPriceAvailable;
                    initialBooking.IsDurationAvailable = booking.IsDurationAvailable;
                    initialBooking.IsDescriptionAvailable = booking.IsDescriptionAvailable;
                    if(booking.Business != null)
                    initialBooking.Business = booking.Business;

                    await db.SaveChangesAsync();
                    return true;
                }
            }
            catch (Exception ex)
            { Console.Out.WriteLine(ex.Message); }
            return false;
        }
    }
}
