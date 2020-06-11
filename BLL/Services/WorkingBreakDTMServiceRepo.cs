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
    public class WorkingBreakDTMServiceRepo : IServiceRepository<WorkingBreakDTM>
    {
        IUnitOfWork Database { get; set; }

        public WorkingBreakDTMServiceRepo(IUnitOfWork uow)
        {
            Database = uow;
        }

        public async Task<List<WorkingBreakDTM>> GetAll(SearchParams search)
        {
            IQueryable<WorkingBreak> servicesQuery = Database.WorkingBreaks.GetAll();
            List<WorkingBreak> temp = servicesQuery
            .Where(t => t.WorkingHourId == search.WorkingHourId)
            .ToList();
            List<WorkingBreakDTM> tempList = new List<WorkingBreakDTM>();

            if (temp != null)
                foreach (var s in temp)
                {
                    tempList.Add(WorkingBreakToWorkingBreakDtmMap(s));
                }

            return tempList;
        }

        public async Task<WorkingBreakDTM> Get(int id)
        {
            int firstwBreakId = 1;
            if (id < firstwBreakId)
                throw new ValidationException("WorkingBreak id is not specified correctly", "");
            var wBreak = await Database.WorkingBreaks.Get(id);
            if (wBreak == null)
                throw new ValidationException("WorkingBreak is not found", "");

            WorkingBreakDTM workingBreakDTM = WorkingBreakToWorkingBreakDtmMap(wBreak);
            return workingBreakDTM;
        }

        public IQueryable<WorkingBreakDTM> Find(Func<WorkingBreakDTM, bool> predicate)
        {
            throw new NotImplementedException();
        }

        public async Task<int> Create(WorkingBreakDTM workingBreakDTM)
        {
            try
            {
                WorkingBreak workingBreak = new WorkingBreak();
                workingBreak.WeekDay = workingBreakDTM.WeekDay;
                workingBreak.BreakStart = workingBreakDTM.BreakStart;
                workingBreak.BreakStop = workingBreakDTM.BreakStop;

                await Database.WorkingBreaks.Create(workingBreak);
                return workingBreak.Id;
            }
            catch { return 0; }
        }

        public async Task<bool> Update(WorkingBreakDTM workingBreakDTM)
        {
            try
            {
                WorkingBreak workingBreak = new WorkingBreak();
                workingBreak.Id = workingBreakDTM.Id;
                workingBreak.WeekDay = workingBreakDTM.WeekDay;
                workingBreak.BreakStart = workingBreakDTM.BreakStart;
                workingBreak.BreakStop = workingBreakDTM.BreakStop;

                return await Database.WorkingBreaks.Update(workingBreak) ? true : false;
            }
            catch (Exception ex) { Console.Out.WriteLine(ex.Message); return false; }
        }

        public async Task<bool> Delete(int id)
        {
            try
            {
                await Database.WorkingBreaks.Delete(id);
                return true;
            }
            catch { return false; }
        }

        public WorkingBreakDTM WorkingBreakToWorkingBreakDtmMap(WorkingBreak workingBreak)
        {
            WorkingBreakDTM workingBreakDTM = new WorkingBreakDTM();
            workingBreakDTM.Id = workingBreak.Id;
            workingBreakDTM.WeekDay = workingBreak.WeekDay;
            workingBreakDTM.BreakStart = workingBreak.BreakStart;
            workingBreakDTM.BreakStop = workingBreak.BreakStop;

            return workingBreakDTM;
        }

        public void Dispose()
        {
            Database.Dispose();
        }
    }
}
