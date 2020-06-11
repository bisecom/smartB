using BLL.Interfaces;
using BLL.Services;
using smart_booking.BLL.DataTransferModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface IUnitOfWorkService : IDisposable
    {
        IUserServiceRepository UsersDTM { get; }
        ISlotServiceRepository SlotesDTM { get; }
        IServiceRepository<CountryDTM> CountriesDTM { get; }
        IServiceRepository<Time_zoneDTM> TimezonesDTM { get; }
        IServiceRepository<CurrencyDTM> CurrenciesDTM { get; }
        IBusinessServiceRepository BusinessesDTM { get; }
        IServiceRepository<BookingDTM> BookingsDTM { get; }
        //IServiceRepository<EmployeeDTM> EmployeesDTM { get; }
        IServiceRepository<PageLanguageDTM> PageLanguagesDTM { get; }
        IServiceRepository<ServiceDTM> ServicesDTM { get; }
        IServiceRepository<ServiceCategoryDTM> ServiceCategoriesDTM { get; }
        IServiceRepository<PermissionDTM> PermissionsDTM { get; }
        IServiceRepository<CalendarSettingDTM> CalendarSettingsDTM { get; }
        IServiceRepository<CustomerNotificationDTM> CustomerNotificationsDTM { get; }
        IServiceRepository<TeamNotificationDTM> TeamNotificationsDTM { get; }
        IServiceRepository<WorkingHourDTM> WorkingHoursDTM { get; }
        IServiceRepository<WorkingBreakDTM> WorkingBreaksDTM { get; }
        IServiceRepository<ClientDTM> ClientsDTM { get; }
        IEmployeeServiceRepository EmployeesDTM { get; }
        //bool SaveChanges();
    }
}
