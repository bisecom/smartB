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
    public class WorkingHourDTMServiceRepo : IServiceRepository<WorkingHourDTM>
    {
        IUnitOfWork Database { get; set; }

        public WorkingHourDTMServiceRepo(IUnitOfWork uow)
        {
            Database = uow;
        }

        public async Task<List<WorkingHourDTM>> GetAll(SearchParams search)
        {
            throw new NotImplementedException();
        }

        public async Task<WorkingHourDTM> Get(int id)
        {
            int firstwHourId = 1;
            if (id < firstwHourId)
                throw new ValidationException("WorkingHour id is not specified correctly", "");
            var wHour = await Database.WorkingHours.Get(id);
            if (wHour == null)
                throw new ValidationException("WorkingHour is not found", "");

            WorkingHourDTM wHourDtm = WorkingHourToWorkingHourDtmMap(wHour);
            return wHourDtm;
        }

        public IQueryable<WorkingHourDTM> Find(Func<WorkingHourDTM, bool> predicate)
        {
            throw new NotImplementedException();
        }

        public async Task<int> Create(WorkingHourDTM workingHour)
        {
            try
            {
                WorkingHour iworkingHour = new WorkingHour();
                iworkingHour.MondayStart = workingHour.MondayStart;
                iworkingHour.MondayStop = workingHour.MondayStop;
                iworkingHour.TuesdayStart = workingHour.TuesdayStart;
                iworkingHour.TuesdayStop = workingHour.TuesdayStop;
                iworkingHour.WednesdayStart = workingHour.WednesdayStart;
                iworkingHour.WednesdayStop = workingHour.WednesdayStop;
                iworkingHour.ThursdayStart = workingHour.ThursdayStart;
                iworkingHour.ThursdayStop = workingHour.ThursdayStop;
                iworkingHour.FridayStart = workingHour.FridayStart;
                iworkingHour.FridayStop = workingHour.FridayStop;
                iworkingHour.SaturdayStart = workingHour.SaturdayStart;
                iworkingHour.SaturdayStop = workingHour.SaturdayStop;
                iworkingHour.SundayStart = workingHour.SundayStart;
                iworkingHour.SundayStop = workingHour.SundayStop;

                iworkingHour.Employee = await Database.Employees.Get(workingHour.EmployeeId);

                await Database.WorkingHours.Create(iworkingHour);
                return iworkingHour.EmployeeId;
            }
            catch { return 0; }
        }

        public async Task<bool> Update(WorkingHourDTM workingHour)
        {
            try
            {
                WorkingHour iworkingHour = new WorkingHour();
                iworkingHour.EmployeeId = workingHour.EmployeeId;
                iworkingHour.MondayStart = workingHour.MondayStart;
                iworkingHour.MondayStop = workingHour.MondayStop;
                iworkingHour.TuesdayStart = workingHour.TuesdayStart;
                iworkingHour.TuesdayStop = workingHour.TuesdayStop;
                iworkingHour.WednesdayStart = workingHour.WednesdayStart;
                iworkingHour.WednesdayStop = workingHour.WednesdayStop;
                iworkingHour.ThursdayStart = workingHour.ThursdayStart;
                iworkingHour.ThursdayStop = workingHour.ThursdayStop;
                iworkingHour.FridayStart = workingHour.FridayStart;
                iworkingHour.FridayStop = workingHour.FridayStop;
                iworkingHour.SaturdayStart = workingHour.SaturdayStart;
                iworkingHour.SaturdayStop = workingHour.SaturdayStop;
                iworkingHour.SundayStart = workingHour.SundayStart;
                iworkingHour.SundayStop = workingHour.SundayStop;

                return await Database.WorkingHours.Update(iworkingHour) ? true : false;
            }
            catch (Exception ex) { Console.Out.WriteLine(ex.Message); return false; }
        }

        public async Task<bool> Delete(int id)
        {
            try
            {
                await Database.WorkingHours.Delete(id);
                return true;
            }
            catch { return false; }
        }

        public WorkingHourDTM WorkingHourToWorkingHourDtmMap(WorkingHour workingHour)
        {
            WorkingHourDTM workingHourDTM = new WorkingHourDTM();
            workingHourDTM.EmployeeId = workingHour.EmployeeId;
            workingHourDTM.MondayStart = workingHour.MondayStart;
            workingHourDTM.MondayStop = workingHour.MondayStop;
            workingHourDTM.TuesdayStart = workingHour.TuesdayStart;
            workingHourDTM.TuesdayStop = workingHour.TuesdayStop;
            workingHourDTM.WednesdayStart = workingHour.WednesdayStart;
            workingHourDTM.WednesdayStop = workingHour.WednesdayStop;
            workingHourDTM.ThursdayStart = workingHour.ThursdayStart;
            workingHourDTM.ThursdayStop = workingHour.ThursdayStop;
            workingHourDTM.FridayStart = workingHour.FridayStart;
            workingHourDTM.FridayStop = workingHour.FridayStop;
            workingHourDTM.SaturdayStart = workingHour.SaturdayStart;
            workingHourDTM.SaturdayStop = workingHour.SaturdayStop;
            workingHourDTM.SundayStart = workingHour.SundayStart;
            workingHourDTM.SundayStop = workingHour.SundayStop;

            return workingHourDTM;
        }

        public void Dispose()
        {
            Database.Dispose();
        }
    }
}
