using BLL.Interfaces;
using BLL.Utils;
using DAL.Interfaces;
using smart_booking.BLL.DataTransferModels;
using smart_booking.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class CalendarSettingDTMServiceRepo : IServiceRepository<CalendarSettingDTM>
    {
        IUnitOfWork Database { get; set; }

        public CalendarSettingDTMServiceRepo(IUnitOfWork uow)
        {
            Database = uow;
        }

        public Task<List<CalendarSettingDTM>> GetAll(SearchParams search)
        {
            throw new NotImplementedException();
        }

        public async Task<CalendarSettingDTM> Get(int id)
        {
            int firstSettingId = 1;
            if (id < firstSettingId)
                throw new ValidationException("Setting id is not specified correctly", "");
            var permission = await Database.CalendarSettings.Get(id);
            if (permission == null)
                throw new ValidationException("Setting is not found", "");

            CalendarSettingDTM cSettingDtm = CalendarSettingToCalendarSettingDTMMap(permission);
            return cSettingDtm;
        }

        public IQueryable<CalendarSettingDTM> Find(Func<CalendarSettingDTM, bool> predicate)
        {
            throw new NotImplementedException();
        }

        public async Task<int> Create(CalendarSettingDTM cSettingDtm)
        {
            try
            {
                CalendarSetting cSetting = new CalendarSetting();
                cSetting.View = cSettingDtm.View;
                cSetting.FirstHour = cSettingDtm.FirstHour;
                cSetting.WorkingDayDuration = cSettingDtm.WorkingDayDuration;
                cSetting.SlotDuration = cSettingDtm.SlotDuration;

                cSetting.Employee = await Database.Employees.Get(cSettingDtm.EmployeeId);
                await Database.CalendarSettings.Create(cSetting);
                return cSetting.EmployeeId;
            }
            catch { return 0; }
        }

        public async Task<bool> Update(CalendarSettingDTM setting)
        {
            try
            {
                CalendarSetting cSetting = new CalendarSetting();
                cSetting.EmployeeId = setting.EmployeeId;
                cSetting.View = setting.View;
                cSetting.FirstHour = setting.FirstHour;
                cSetting.WorkingDayDuration = setting.WorkingDayDuration;
                cSetting.SlotDuration = setting.SlotDuration;
                if(setting.Employee != null)
                cSetting.Employee = await Database.Employees.Get(setting.Employee.Id);

                return await Database.CalendarSettings.Update(cSetting) ? true : false;
            }
            catch (Exception ex) { Console.Out.WriteLine(ex.Message); return false; }
        }

        public async Task<bool> Delete(int id)
        {
            try
            {
                await Database.CalendarSettings.Delete(id);
                return true;
            }
            catch { return false; }
        }

        public CalendarSettingDTM CalendarSettingToCalendarSettingDTMMap(CalendarSetting setting)
        {
            CalendarSettingDTM cSetting = new CalendarSettingDTM();
            cSetting.EmployeeId = setting.EmployeeId;
            cSetting.View = setting.View;
            cSetting.FirstHour = setting.FirstHour;
            cSetting.WorkingDayDuration = setting.WorkingDayDuration;
            cSetting.SlotDuration = setting.SlotDuration;
            return cSetting;
        }
        public void Dispose()
        {
            Database.Dispose();
        }
    }
}
