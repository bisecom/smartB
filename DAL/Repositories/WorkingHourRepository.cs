using DAL.Interfaces;
using smart_booking.DAL.EF;
using smart_booking.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public class WorkingHourRepository : IRepository<WorkingHour>
    {
        private SBContext db;

        public WorkingHourRepository(SBContext context)
        {
            this.db = context;
        }

        public async Task<bool> Create(WorkingHour item)
        {
            try
            {
                db.WorkingHours.Add(item);
                await db.SaveChangesAsync();
                return true;
            }
            catch (Exception ex) { Console.Out.WriteLine(ex.Message); return false; }
        }

        public async Task<bool> Delete(int id)
        {
            try
            {
                //WorkingHour wHour = await db.WorkingHours.FindAsync(id);
                // WorkingHour wHour = await db.WorkingHours.Where(w => w.EmployeeId == id).FirstOrDefaultAsync();
                var wHour = db.WorkingHours.Where(w => w.EmployeeId == id).ToList()[0];
                //WorkingHour wHour = await db.WorkingHours.Where(w => w.EmployeeId == id).FirstOrDefaultAsync();
                
                if (wHour != null)
                {
                    db.WorkingHours.Remove(wHour);
                    await db.SaveChangesAsync();
                    return true;
                }
            }
            catch (Exception ex) { Console.Out.WriteLine(ex.Message); }
            return false;
        }

        public IQueryable<WorkingHour> Find(Func<WorkingHour, bool> predicate)
        {
            return db.WorkingHours.AsQueryable();
        }

        public async Task<WorkingHour> Get(int id)
        {
            return await db.WorkingHours
               .Include("Employee")
               .SingleOrDefaultAsync(p => p.EmployeeId == id);
        }

        public IQueryable<WorkingHour> GetAll()
        {
            return db.WorkingHours.AsQueryable();
        }

        public async Task<bool> Update(WorkingHour workingHour)
        {
            try
            {
                var initialWorkingHour = await db.WorkingHours.FindAsync(workingHour.EmployeeId);
                if (initialWorkingHour != null)
                {
                    initialWorkingHour.MondayStart = workingHour.MondayStart;
                    initialWorkingHour.MondayStop = workingHour.MondayStop;
                    initialWorkingHour.TuesdayStart = workingHour.TuesdayStart;
                    initialWorkingHour.TuesdayStop = workingHour.TuesdayStop;
                    initialWorkingHour.WednesdayStart = workingHour.WednesdayStart;
                    initialWorkingHour.WednesdayStop = workingHour.WednesdayStop;
                    initialWorkingHour.ThursdayStart = workingHour.ThursdayStart;
                    initialWorkingHour.ThursdayStop = workingHour.ThursdayStop;
                    initialWorkingHour.FridayStart = workingHour.FridayStart;
                    initialWorkingHour.FridayStop = workingHour.FridayStop;
                    initialWorkingHour.SaturdayStart = workingHour.SaturdayStart;
                    initialWorkingHour.SaturdayStop = workingHour.SaturdayStop;
                    initialWorkingHour.SundayStart = workingHour.SundayStart;
                    initialWorkingHour.SundayStop = workingHour.SundayStop;

                    await db.SaveChangesAsync();
                    return true;
                }
            }
            catch (Exception ex)
            { Console.Out.WriteLine(ex.Message); }
            return false;
        }
    }
}
