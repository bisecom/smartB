using AutoMapper;
using BLL.Interfaces;
using BLL.Utils;
using DAL.Interfaces;
using smart_booking.BLL.DataTransferModels;
using smart_booking.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class BusinessDTMServiceRepo : IBusinessServiceRepository
    {
        IUnitOfWork Database { get; set; }

        public BusinessDTMServiceRepo(IUnitOfWork uow)
        {
            Database = uow;
        }

        public async Task<List<BusinessDTM>> GetAll(SearchParams search)
        {
            //var config = new MapperConfiguration(cfg => {
            //    cfg.CreateMap<Business, BusinessDTM>();
            //    cfg.CreateMap<Country, CountryDTM>();
            //    cfg.CreateMap<Currency, CurrencyDTM>();
            //    cfg.CreateMap<Time_zone, Time_zoneDTM>();
            //    cfg.CreateMap<Booking, BookingDTM>();
            //});
            //var mapper = new Mapper(config);
            //return await Task.Run(() => (mapper.Map<List<BusinessDTM>>(
            //    Database.Businesses.GetAll()
            //   .OrderBy(u => u.Name)
            //   .Skip(search.PageSize * search.Page)
            //   .Take(search.PageSize))));
            //return mapper.Map<List<BusinessDTM>>(
            //       Database.Businesses.GetAll()
            //      .OrderBy(u => u.Name)
            //      .Skip(search.PageSize * search.Page)
            //      .Take(search.PageSize));
            List<BusinessDTM> bListDtm = new List<BusinessDTM>();
            List<Business>bList = Database.Businesses.GetAll()
                  .OrderBy(u => u.Name)
                  .Skip(search.PageSize * search.Page)
                  .Take(search.PageSize).ToList();
            foreach(Business b in bList)
            {
                BusinessDTM bDtm = new BusinessDTM();
                bDtm.Id = b.Id;
                bDtm.Name = b.Name;
                bDtm.Phone = b.Phone;
                bDtm.Logo = b.Logo;
                bDtm.Webpage = b.Webpage;
                bDtm.Address = b.Address;
                bDtm.City = b.City;
                bDtm.State = b.State;
                bDtm.ZipCode = b.ZipCode;
                bDtm.RegistrationNumber = b.RegistrationNumber;

                bDtm.CountryId = b.Country.Id;
                bDtm.CurrencyId = b.Currency.Id;
                bDtm.Time_zoneId = b.Time_zone.Id;

                CountryDTM country = new CountryDTM();
                country.Id = b.Country.Id;
                country.Code = b.Country.Code;
                country.Name = b.Country.Name;
                country.Native = b.Country.Native;
                country.PhonePrefix = b.Country.PhonePrefix;
                country.Capital = b.Country.Capital;
                country.Currency_ = b.Country.Currency_;
                country.Emoji = b.Country.Emoji;
                country.EmojiU = b.Country.EmojiU;
                bDtm.Country = country;

                CurrencyDTM currency = new CurrencyDTM();
                currency.Id = b.Currency.Id;
                currency.Name = b.Currency.Name;
                bDtm.Currency = currency;

                Time_zoneDTM tz = new Time_zoneDTM();
                tz.Id = b.Time_zone.Id;
                tz.Zone = b.Time_zone.Zone;
                tz.CountryCode = b.Time_zone.CountryCode;
                tz.UTC_Jan_1_2020 = b.Time_zone.UTC_Jan_1_2020;
                tz.DST_Jul_1_2020 = b.Time_zone.DST_Jul_1_2020;
                bDtm.Time_zone = tz;

                bListDtm.Add(bDtm);
            }

            return bListDtm;
        }

        public async Task<BusinessDTM> Get(int id)
        {
            int firstBusinessId = 1; 
            if (id < firstBusinessId)
                throw new ValidationException("Business id is not specified correctly", "");
            var business = await Database.Businesses.Get(id);
            if (business == null)
                throw new ValidationException("Business is not found", "");

            BusinessDTM bDtm = new BusinessDTM();
            bDtm.Id = business.Id;
            bDtm.Name = business.Name;
            bDtm.Phone = business.Phone;
            bDtm.Logo = business.Logo;
            bDtm.Webpage = business.Webpage;
            bDtm.Address = business.Address;
            bDtm.City = business.City;
            bDtm.State = business.State;
            bDtm.ZipCode = business.ZipCode;
            bDtm.RegistrationNumber = business.RegistrationNumber;

            if (business.Country != null)
            {
                CountryDTM country = new CountryDTM();
                country.Id = business.Country.Id;
                country.Code = business.Country.Code;
                country.Name = business.Country.Name;
                country.Native = business.Country.Native;
                country.PhonePrefix = business.Country.PhonePrefix;
                country.Capital = business.Country.Capital;
                country.Currency_ = business.Country.Currency_;
                country.Emoji = business.Country.Emoji;
                country.EmojiU = business.Country.EmojiU;
                bDtm.Country = country;
                bDtm.CountryId = business.Country.Id;
            }
            if (business.Currency != null)
            {
                CurrencyDTM currency = new CurrencyDTM();
                currency.Id = business.Currency.Id;
                currency.Name = business.Currency.Name;
                bDtm.Currency = currency;
                bDtm.CurrencyId = business.Currency.Id;
            }
            if (business.Time_zone != null)
            {
                Time_zoneDTM tz = new Time_zoneDTM();
                tz.Id = business.Time_zone.Id;
                tz.Zone = business.Time_zone.Zone;
                tz.CountryCode = business.Time_zone.CountryCode;
                tz.UTC_Jan_1_2020 = business.Time_zone.UTC_Jan_1_2020;
                tz.DST_Jul_1_2020 = business.Time_zone.DST_Jul_1_2020;
                bDtm.Time_zone = tz;
                bDtm.Time_zoneId = business.Time_zone.Id;
            }
            //var config = new MapperConfiguration(cfg => cfg.CreateMap<Business, BusinessDTM>());
            //var mapper = new Mapper(config);
            //return mapper.Map<BusinessDTM>(business);
            return bDtm;
        }

        public IQueryable<BusinessDTM> Find(Func<BusinessDTM, bool> predicate)
        {
            throw new NotImplementedException();
        }

        public async Task<int> Create(BusinessDTM businessDtm)
        {
            try
            {
                Business business = new Business();
                business.Name = businessDtm.Name;
                if (businessDtm.Country != null)
                { 
                    business.Phone = businessDtm.Phone;
                    business.Logo = businessDtm.Logo;
                    business.Webpage = businessDtm.Webpage;
                    business.Address = businessDtm.Address;
                    business.City = businessDtm.City;
                    business.State = businessDtm.State;
                    business.ZipCode = businessDtm.ZipCode;
                    business.RegistrationNumber = businessDtm.RegistrationNumber;
                    business.Country = await Database.Countries.Get(businessDtm.Country.Id);
                    business.Currency = await Database.Currencies.Get(businessDtm.Currency.Id);
                    business.Time_zone = await Database.Time_zones.Get(businessDtm.Time_zone.Id);
                    business.Booking = businessDtm.Booking == null ? null : await Database.Bookings.Get(businessDtm.Booking.BusinessId);
                    business.CategoryServices = null;
                    business.Clients = null;
                    business.Employees = null;
                }
                await Database.Businesses.Create(business);
                User user = await Database.BllServices.GetUser(businessDtm.UserId);

                Booking booking = new Booking();
                booking.BusinessId = business.Id;
                await Database.Bookings.Create(booking);

                Employee employeeBoss = new Employee();
                employeeBoss.IsOwner = true;
                employeeBoss.Business = business;
                employeeBoss.User = user;
                await Database.Employees.Create(employeeBoss);

                WorkingHour wHourDtm = new WorkingHour();
                wHourDtm.Employee = employeeBoss;
                wHourDtm.EmployeeId = employeeBoss.Id;
                await Database.WorkingHours.Create(wHourDtm);

                Permission perm = new Permission();
                perm.Employee = employeeBoss;
                perm.EmployeeId = employeeBoss.Id;
                await Database.Permissions.Create(perm);

                CalendarSetting cSetting = new CalendarSetting();
                cSetting.Employee = employeeBoss;
                cSetting.EmployeeId = employeeBoss.Id;
                await Database.CalendarSettings.Create(cSetting);

                CustomerNotification cNotif = new CustomerNotification();
                cNotif.Employee = employeeBoss;
                cNotif.EmployeeId = employeeBoss.Id;
                await Database.CustomerNotifications.Create(cNotif);

                TeamNotification tNotif = new TeamNotification();
                tNotif.Employee = employeeBoss;
                tNotif.EmployeeId = employeeBoss.Id;
                await Database.TeamNotifications.Create(tNotif);

                return business.Id;
            }
            catch { return 0; }
        }

        public async Task<bool> Update(BusinessDTM item)
        {
            try
            {
                Business business = new Business();
                business.Id = item.Id;
                business.Name = item.Name;
                business.Phone = item.Phone;
                business.Logo = item.Logo;
                business.Webpage = item.Webpage;
                business.Address = item.Address;
                business.City = item.City;
                business.State = item.State;
                business.ZipCode = item.ZipCode;
                business.RegistrationNumber = item.RegistrationNumber;
                business.Country = await Database.BllServices.GetCountry(item.Country.Id);
                business.Currency = await Database.BllServices.GetCurrency(item.Currency.Id);
                business.Time_zone = await Database.BllServices.GetTime_zone(item.Time_zone.Id);
                //business.Booking.BusinessId = item.Booking.BusinessId;
                //business.Services = item.Services;
                //business.Clients = item.Clients;
                //business.Employees = item.Employees;
                await Database.Businesses.Update(business);
                return true;
            }
            catch (Exception ex) { Console.Out.WriteLine(ex.Message); return false; }
        }

        public async Task<bool> Delete(int id)
        {
            try
            {
                //var  employeesList = Database.Employees.GetAll()
                //    .Where(e => e.BusinessId == id);

                var employeesList = Database.Employees.GetAll()
                    .Where(e => e.BusinessId == id).ToList();

                if (employeesList == null)
                    return false;

                foreach (var e in employeesList)
                {
                    await Database.WorkingHours.Delete(e.Id);
                    await Database.Permissions.Delete(e.Id);
                    await Database.CalendarSettings.Delete(e.Id);
                    await Database.CustomerNotifications.Delete(e.Id);
                    await Database.TeamNotifications.Delete(e.Id);
                }

                await Database.Bookings.Delete(id);

                foreach (var e in employeesList)
                {
                    await Database.Employees.Delete(e.Id);
                }
                
                await Database.Businesses.Delete(id);
                return true;
            }
            catch { return false; }
        }

        public void Dispose()
        {
            Database.Dispose();
        }
    }
}
