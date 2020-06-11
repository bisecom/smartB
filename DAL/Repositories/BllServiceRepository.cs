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
    public class BllServiceRepository : IBllServicesUtils
    {
        private SBContext db;

        public BllServiceRepository(SBContext context)
        {
            this.db = context;
        }
        public async Task<Booking> GetBooking(int id)
        {
            return await db.Bookings.FindAsync(id);
        }

        public async Task<Business> GetBusiness(int id)
        {
            return await db.Businesses.FindAsync(id);
        }

        public async Task<CalendarSetting> GetCalendarSetting(int id)
        {
            return await db.CalendarSettings.FindAsync(id);
        }

        public async Task<Client> GetClient(int id)
        {
            return await db.Clients.FindAsync(id);
        }

        public async Task<Country> GetCountry(int id)
        {
            return db.Countries.Where(c=>c.Id == id).FirstOrDefault();
        }

        public async Task<Currency> GetCurrency(int id)
        {
            //return await db.Currencies.FindAsync(id);
            return db.Currencies.Where(c => c.Id == id).FirstOrDefault();
        }

        public async Task<CustomerNotification> GetCustomerNotification(int id)
        {
            return await db.CustomerNotifications.FindAsync(id);
        }

        public async Task<Employee> GetEmployee(int id)
        {
            try
            {
                return await db.Employees.FindAsync(id);
            }
            catch (Exception ex) { Console.Out.WriteLine(ex.Message); return null; }
        }

        public async Task<PageLanguage> GetPageLanguage(int id)
        {
            return await db.PageLanguages.FindAsync(id);
        }

        public async Task<Permission> GetPermission(int id)
        {
            return await db.Permissions.FindAsync(id);
        }

        public async Task<Service> GetService(int id)
        {
            return await db.Services.FindAsync(id);
        }

        public async Task<Slot> GetSlot(int id)
        {
            return await db.Slots.FindAsync(id);
        }

        public async Task<TeamNotification> GetTeamNotification(int id)
        {
            return await db.TeamNotifications.FindAsync(id);
        }

        public async Task<Time_zone> GetTime_zone(int id)
        {
            //return await db.Time_zones.FindAsync(id);
            return db.Time_zones.Where(t => t.Id == id).FirstOrDefault();
        }

        public async Task<User> GetUser(string id)
        {
            return await db.Users.FindAsync(id);
        }

        public async Task<WorkingBreak> GetWorkingBreak(int id)
        {
            return await db.WorkingBreaks.FindAsync(id);
        }

        public async Task<WorkingHour> GetWorkingHour(int id)
        {
            return await db.WorkingHours.FindAsync(id);
        }

        public async Task<ServiceCategory> ServiceCategory(int id)
        {
            return await db.ServiceCategories.FindAsync(id);
        }


    }
}
