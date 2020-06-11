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
    public class DalUnitOfWork : IUnitOfWork
    {
        private SBContext db;
        private UserRepository userRepository;
        private BllServiceRepository bllServiceRepository;
        private BusinessRepository businessRepository;
        private EmployeeRepository employeeRepository;
        private CountryRepository countryRepository;
        private Time_ZoneRepository time_zoneRepository;
        private BookingRepository bookingRepository;
        private CurrencyRepository currencyRepository;
        private PageLangRepository pageLangRepository;
        private SlotRepository slotRepository;
        private ServiceRepository serviceRepository;
        private ServiceCategoryRepository serviceCategoryRepository;
        private PermissionRepository permissionRepository;
        private CalendarSettingRepository pcalendarSettingRepository;
        private CustomerNotificationRepository cNotificationRepository;
        private TeamNotificationRepository tNotificationRepository;
        private WorkingHourRepository wHourRepository;
        private WorkingBreakRepository wBreakRepository;
        private ClientRepository clientRepository;
        public DalUnitOfWork()
        { 
            db = new SBContext("SBContext");
        }

        public IUserRepository Users  {
            get
            {
                if (userRepository == null)
                    userRepository = new UserRepository(db);
                return userRepository;
            }
        }
        public IBllServicesUtils BllServices
        {
            get
            {
                if (bllServiceRepository == null)
                    bllServiceRepository = new BllServiceRepository(db);
                return bllServiceRepository;
            }
        }
        
        public IRepository<Client> Clients
        {
            get
            {
                if (clientRepository == null)
                    clientRepository = new ClientRepository(db);
                return clientRepository;
            }
        }

        public IRepository<WorkingBreak> WorkingBreaks
        {
            get
            {
                if (wBreakRepository == null)
                    wBreakRepository = new WorkingBreakRepository(db);
                return wBreakRepository;
            }
        }
        public IRepository<WorkingHour> WorkingHours
        {
            get
            {
                if (wHourRepository == null)
                    wHourRepository = new WorkingHourRepository(db);
                return wHourRepository;
            }
        }

        public IRepository<CalendarSetting> CalendarSettings
        {
            get
            {
                if (pcalendarSettingRepository == null)
                    pcalendarSettingRepository = new CalendarSettingRepository(db);
                return pcalendarSettingRepository;
            }
        }

        public IRepository<CustomerNotification> CustomerNotifications
        {
            get
            {
                if (cNotificationRepository == null)
                    cNotificationRepository = new CustomerNotificationRepository(db);
                return cNotificationRepository;
            }
        }

        public IRepository<TeamNotification> TeamNotifications
        {
            get
            {
                if (tNotificationRepository == null)
                    tNotificationRepository = new TeamNotificationRepository(db);
                return tNotificationRepository;
            }
        }

        public IRepository<Permission> Permissions
        {
            get
            {
                if (permissionRepository == null)
                    permissionRepository = new PermissionRepository(db);
                return permissionRepository;
            }
        }

        public IRepository<ServiceCategory> ServiceCategories
        {
            get
            {
                if (serviceCategoryRepository == null)
                    serviceCategoryRepository = new ServiceCategoryRepository(db);
                return serviceCategoryRepository;
            }
        }

        public IRepository<Service> Services
        {
            get
            {
                if (serviceRepository == null)
                    serviceRepository = new ServiceRepository(db);
                return serviceRepository;
            }
        }

        public IRepository<Slot> Slotes
        {
            get
            {
                if (slotRepository == null)
                    slotRepository = new SlotRepository(db);
                return slotRepository;
            }
        }

        public IRepository<Employee> Employees
        {
            get
            {
                if (employeeRepository == null)
                    employeeRepository = new EmployeeRepository(db);
                return employeeRepository;
            }
        }

        public IRepository<PageLanguage> PageLanguages
        {
            get
            {
                if (pageLangRepository == null)
                    pageLangRepository = new PageLangRepository(db);
                return pageLangRepository;
            }
        }

        public IRepository<Currency> Currencies
        {
            get
            {
                if (currencyRepository == null)
                    currencyRepository = new CurrencyRepository(db);
                return currencyRepository;
            }
        }

        public IRepository<Booking> Bookings
        {
            get
            {
                if (bookingRepository == null)
                    bookingRepository = new BookingRepository(db);
                return bookingRepository;
            }
        }

        public IRepository<Business> Businesses
        {
            get
            {
                if (businessRepository == null)
                    businessRepository = new BusinessRepository(db);
                return businessRepository;
            }
        }


        public IRepository<Country> Countries {
            get
            {
                if (countryRepository == null)
                    countryRepository = new CountryRepository(db);
                return countryRepository;
            }
        }

        public IRepository<Time_zone> Time_zones {
            get
            {
                if (time_zoneRepository == null)
                    time_zoneRepository = new Time_ZoneRepository(db);
                return time_zoneRepository;
            }
        }

        private bool disposed = false;

        public virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    db.Dispose();
                }
                this.disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public async void Save()
        {
            await db.SaveChangesAsync();
        }
    }
}
