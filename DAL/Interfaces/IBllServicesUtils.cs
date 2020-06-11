using smart_booking.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface IBllServicesUtils
    {
        Task<User> GetUser(string id);
        Task<Business> GetBusiness(int id);
        Task<Booking> GetBooking(int id);
        Task<Slot> GetSlot(int id);
        Task<Service> GetService(int id);
        Task<ServiceCategory> ServiceCategory(int id);
        Task<Employee> GetEmployee(int id);
        Task<Permission> GetPermission(int id);
        Task<Client> GetClient(int id);
        Task<Country> GetCountry(int id);
        Task<Currency> GetCurrency(int id);
        Task<Time_zone> GetTime_zone(int id);
        Task<PageLanguage> GetPageLanguage(int id);
        Task<WorkingHour> GetWorkingHour(int id);
        Task<WorkingBreak> GetWorkingBreak(int id);
        Task<CalendarSetting> GetCalendarSetting(int id);
        Task<CustomerNotification> GetCustomerNotification(int id);
        Task<TeamNotification> GetTeamNotification(int id);

    }
}
