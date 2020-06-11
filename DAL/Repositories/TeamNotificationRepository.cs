using DAL.Interfaces;
using smart_booking.DAL.EF;
using smart_booking.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public class TeamNotificationRepository : IRepository<TeamNotification>
    {
        private SBContext db;

        public TeamNotificationRepository(SBContext context)
        {
            this.db = context;
        }

        public async Task<bool> Create(TeamNotification item)
        {
            try
            {
                db.TeamNotifications.Add(item);
                await db.SaveChangesAsync();
                return true;
            }
            catch (Exception ex) { Console.Out.WriteLine(ex.Message); return false; }
        }

        public async Task<bool> Delete(int id)
        {
            try
            {
                //TeamNotification notification = await db.TeamNotifications.FindAsync(id);
                var notification = db.TeamNotifications.Where(t => t.EmployeeId == id).ToList()[0];

                if (notification != null)
                {
                    db.TeamNotifications.Remove(notification);
                    await db.SaveChangesAsync();
                    return true;
                }
            }
            catch (Exception ex) { Console.Out.WriteLine(ex.Message); }
            return false;
        }

        public IQueryable<TeamNotification> Find(Func<TeamNotification, bool> predicate)
        {
            throw new NotImplementedException();
        }

        public async Task<TeamNotification> Get(int id)
        {
            return await db.TeamNotifications
                .Include("Employee")
                .SingleOrDefaultAsync(p => p.EmployeeId == id);
        }

        public IQueryable<TeamNotification> GetAll()
        {
            throw new NotImplementedException();
        }

        public async Task<bool> Update(TeamNotification notification)
        {
            try
            {
                var initialNotification = await db.TeamNotifications.FindAsync(notification.EmployeeId);
                if (initialNotification != null)
                {
                    initialNotification.AfterBooked = notification.AfterBooked;
                    initialNotification.AfterRescheduled = notification.AfterRescheduled;
                    initialNotification.Collegue = notification.Collegue;
                    initialNotification.CollegueAndOwner = notification.CollegueAndOwner;
                    initialNotification.Owner = notification.Owner;

                    await db.SaveChangesAsync();
                    return true;
                }
            }
            catch (Exception ex) { Console.Out.WriteLine(ex.Message); }
            return false;
        }
    }
}
