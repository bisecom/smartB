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
    public class WorkingBreakRepository : IRepository<WorkingBreak>
    {
        private SBContext db;

        public WorkingBreakRepository(SBContext context)
        {
            this.db = context;
        }

        public async Task<bool> Create(WorkingBreak item)
        {
            try
            {
                db.WorkingBreaks.Add(item);
                await db.SaveChangesAsync();
                return true;
            }
            catch (Exception ex) { Console.Out.WriteLine(ex.Message); return false; }
        }

        public async Task<bool> Delete(int id)
        {
            try
            {
                WorkingBreak wBreak = db.WorkingBreaks.Find(id);
                if (wBreak != null)
                {
                    db.WorkingBreaks.Remove(wBreak);
                    await db.SaveChangesAsync();
                    return true;
                }
            }
            catch (Exception ex) { Console.Out.WriteLine(ex.Message); }
            return false;
        }

        public IQueryable<WorkingBreak> Find(Func<WorkingBreak, bool> predicate)
        {
            return db.WorkingBreaks.AsQueryable();
        }

        public async Task<WorkingBreak> Get(int id)
        {
            return await db.WorkingBreaks
               .Include("WorkingHour")
               .SingleOrDefaultAsync(p => p.Id == id);
        }

        public IQueryable<WorkingBreak> GetAll()
        {
            return db.WorkingBreaks.AsQueryable();
        }

        public async Task<bool> Update(WorkingBreak wBreak)
        {
            try
            {
                var initialBreak = await db.WorkingBreaks.FindAsync(wBreak.Id);
                if (initialBreak != null)
                {
                    initialBreak.WeekDay = initialBreak.WeekDay;
                    initialBreak.BreakStart = initialBreak.BreakStart;
                    initialBreak.BreakStop = initialBreak.BreakStop;

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
