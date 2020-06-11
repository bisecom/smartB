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
    public class CustomerNotificationRepository : IRepository<CustomerNotification>
    {
        private SBContext db;

        public CustomerNotificationRepository(SBContext context)
        {
            this.db = context;
        }

        public async Task<bool> Create(CustomerNotification item)
        {
            try
            {
                db.CustomerNotifications.Add(item);
                await db.SaveChangesAsync();
                return true;
            }
            catch (Exception ex) { Console.Out.WriteLine(ex.Message); return false; }
        }

        public async Task<bool> Delete(int id)
        {
            try
            {
                //CustomerNotification notification = await db.CustomerNotifications.FindAsync(id);
                CustomerNotification notification = db.CustomerNotifications.Where(c => c.EmployeeId == id).ToList()[0];
                
                if (notification != null)
                {
                    db.CustomerNotifications.Remove(notification);
                    await db.SaveChangesAsync();
                    return true;
                }
            }
            catch (Exception ex) { Console.Out.WriteLine(ex.Message); }
            return false;
        }

        public IQueryable<CustomerNotification> Find(Func<CustomerNotification, bool> predicate)
        {
            throw new NotImplementedException();
        }

        public async Task<CustomerNotification> Get(int id)
        {
            return await db.CustomerNotifications
                .Include("Employee")
                .SingleOrDefaultAsync(p => p.EmployeeId == id);
        }

        public IQueryable<CustomerNotification> GetAll()
        {
            throw new NotImplementedException();
        }

        public async Task<bool> Update(CustomerNotification notification)
        {
            try
            {
                var initialNotification = await db.CustomerNotifications.FindAsync(notification.EmployeeId);
                if (initialNotification != null)
                {
                    initialNotification.AfterBooked = notification.AfterBooked;
                    initialNotification.AfterRescheduled = notification.AfterRescheduled;
                    initialNotification.AfterCancelled = notification.AfterCancelled;

                    await db.SaveChangesAsync();
                    return true;
                }
            }
            catch (Exception ex) { Console.Out.WriteLine(ex.Message); }
            return false;
        }
    }
}
