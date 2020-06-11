using smart_booking.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IUserRepository Users { get; }
        IBllServicesUtils BllServices { get; }
        IRepository<Employee> Employees { get; }
        IRepository<Business> Businesses { get; }
        IRepository<Country> Countries { get; }
        IRepository<Time_zone> Time_zones { get; }
        IRepository<Currency> Currencies { get; }
        IRepository<Booking> Bookings { get; }
        IRepository<PageLanguage> PageLanguages { get; }
        IRepository<Slot> Slotes { get; }
        IRepository<Service> Services { get; }
        IRepository<ServiceCategory> ServiceCategories { get; }
        IRepository<Permission> Permissions { get; }
        IRepository<CalendarSetting> CalendarSettings { get; }
        IRepository<CustomerNotification> CustomerNotifications { get; }
        IRepository<TeamNotification> TeamNotifications { get; }
        IRepository<WorkingHour> WorkingHours { get; }
        IRepository<WorkingBreak> WorkingBreaks { get; }
        IRepository<Client> Clients { get; }
    }
}
