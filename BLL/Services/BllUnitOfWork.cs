using BLL.Interfaces;
using DAL.Interfaces;
using smart_booking.BLL.DataTransferModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class BllUnitOfWork : IUnitOfWorkService
    {
        IUnitOfWork Database { get; set; }
        private UserDTMServiceRepo UsersDtmRepo;
        private BusinessDTMServiceRepo BusinessesDtmRepo;
        private CountryDTMServiceRepo CountriesDtmRepo;
        private Time_ZoneDTMServiceRepo Time_ZoneDtmRepo;
        private BookingDTMServiceRepo BookingDtmRepo;
        private CurrencyDTMServiceRepo CurrencyDtmRepo;
        private EmployeeDTMServiceRepo EmployeeDtmRepo;
        private PageLangDTMServiceRepo PageLangDtmRepo;
        private SlotDTMServiceRepo SlotDtmRepo;
        private ServiceDTMServiceRepo ServiceDtmRepo;
        private ServiceCategoryDTMServiceRepo ServiceCategoryDtmRepo;
        private PermissionDTMServiceRepo PermissionDtmRepo;
        private CalendarSettingDTMServiceRepo CalendarSettingDtmRepo;
        private CustomerNotificationDTMServiceRepo CustomerNotificationDtmRepo;
        private TeamNotificationDTMServiceRepo TeamNotificationDtmRepo;
        private WorkingHourDTMServiceRepo WorkingHourDtmRepo;
        private WorkingBreakDTMServiceRepo WorkingBreakDtmRepo;
        private ClientDTMServiceRepo ClientDtmRepo;
        public BllUnitOfWork(IUnitOfWork db)
        {
            Database = db;
        }

        public IUserServiceRepository UsersDTM
        {
            get
            {
                if (UsersDtmRepo == null)
                    UsersDtmRepo = new UserDTMServiceRepo(Database);
                return UsersDtmRepo;
            }
        }

        public IServiceRepository<ClientDTM> ClientsDTM
        {
            get
            {
                if (ClientDtmRepo == null)
                    ClientDtmRepo = new ClientDTMServiceRepo(Database);
                return ClientDtmRepo;
            }
        }

        public IServiceRepository<TeamNotificationDTM> TeamNotificationsDTM
        {
            get
            {
                if (TeamNotificationDtmRepo == null)
                    TeamNotificationDtmRepo = new TeamNotificationDTMServiceRepo(Database);
                return TeamNotificationDtmRepo;
            }
        }

        public IServiceRepository<WorkingHourDTM> WorkingHoursDTM
        {
            get
            {
                if (WorkingHourDtmRepo == null)
                    WorkingHourDtmRepo = new WorkingHourDTMServiceRepo(Database);
                return WorkingHourDtmRepo;
            }
        }
        public IServiceRepository<WorkingBreakDTM> WorkingBreaksDTM
        {
            get
            {
                if (WorkingBreakDtmRepo == null)
                    WorkingBreakDtmRepo = new WorkingBreakDTMServiceRepo(Database);
                return WorkingBreakDtmRepo;
            }
        }

        public IServiceRepository<CustomerNotificationDTM> CustomerNotificationsDTM
        {
            get
            {
                if (CustomerNotificationDtmRepo == null)
                    CustomerNotificationDtmRepo = new CustomerNotificationDTMServiceRepo(Database);
                return CustomerNotificationDtmRepo;
            }
        }

        public IServiceRepository<CalendarSettingDTM> CalendarSettingsDTM
        {
            get
            {
                if (CalendarSettingDtmRepo == null)
                    CalendarSettingDtmRepo = new CalendarSettingDTMServiceRepo(Database);
                return CalendarSettingDtmRepo;
            }
        }

        public IServiceRepository<PermissionDTM> PermissionsDTM
        {
            get
            {
                if (PermissionDtmRepo == null)
                    PermissionDtmRepo = new PermissionDTMServiceRepo(Database);
                return PermissionDtmRepo;
            }
        }

        public IServiceRepository<ServiceCategoryDTM> ServiceCategoriesDTM
        {
            get
            {
                if (ServiceCategoryDtmRepo == null)
                    ServiceCategoryDtmRepo = new ServiceCategoryDTMServiceRepo(Database);
                return ServiceCategoryDtmRepo;
            }
        }

        public IServiceRepository<ServiceDTM> ServicesDTM
        {
            get
            {
                if (ServiceDtmRepo == null)
                    ServiceDtmRepo = new ServiceDTMServiceRepo(Database);
                return ServiceDtmRepo;
            }
        }

        public IServiceRepository<PageLanguageDTM> PageLanguagesDTM
        {
            get
            {
                if (PageLangDtmRepo == null)
                    PageLangDtmRepo = new PageLangDTMServiceRepo(Database);
                return PageLangDtmRepo;
            }
        }

        public ISlotServiceRepository SlotesDTM
        {
            get
            {
                if (SlotDtmRepo == null)
                    SlotDtmRepo = new SlotDTMServiceRepo(Database);
                return SlotDtmRepo;
            }
        }

        public IEmployeeServiceRepository EmployeesDTM
        {
            get
            {
                if (EmployeeDtmRepo == null)
                    EmployeeDtmRepo = new EmployeeDTMServiceRepo(Database);
                return EmployeeDtmRepo;
            }
        }

        public IServiceRepository<CurrencyDTM> CurrenciesDTM
        {
            get
            {
                if (CurrencyDtmRepo == null)
                    CurrencyDtmRepo = new CurrencyDTMServiceRepo(Database);
                return CurrencyDtmRepo;
            }
        }

        public IServiceRepository<BookingDTM> BookingsDTM
        {
            get
            {
                if (BookingDtmRepo == null)
                    BookingDtmRepo = new BookingDTMServiceRepo(Database);
                return BookingDtmRepo;
            }
        }
        public IBusinessServiceRepository BusinessesDTM
        {
            get
            {
                if (BusinessesDtmRepo == null)
                    BusinessesDtmRepo = new BusinessDTMServiceRepo(Database);
                return BusinessesDtmRepo;
            }
        }

        public IServiceRepository<CountryDTM> CountriesDTM
        {
            get
            {
                if (CountriesDtmRepo == null)
                    CountriesDtmRepo = new CountryDTMServiceRepo(Database);
                return CountriesDtmRepo;
            }
        }
        
        public IServiceRepository<Time_zoneDTM> TimezonesDTM
        {
            get
            {
                if (Time_ZoneDtmRepo == null)
                    Time_ZoneDtmRepo = new Time_ZoneDTMServiceRepo(Database);
                return Time_ZoneDtmRepo;
            }
        }

        public void Dispose()
        {
            Database.Dispose();
        }

        //private bool disposed = false;

        //public virtual void Dispose(bool disposing)
        //{
        //    if (!this.disposed)
        //    {
        //        if (disposing)
        //        {
        //            Database.Dispose();
        //        }
        //        this.disposed = true;
        //    }
        //}

        //public void Dispose()
        //{
        //    Dispose(true);
        //    GC.SuppressFinalize(this);
        //}

        //public bool SaveChanges()
        //{
        //    try
        //    {
        //        Database.Save();
        //        return true;
        //    }
        //    catch { return false; }
        //}
    }
}
