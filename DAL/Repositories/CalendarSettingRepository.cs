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
    public class CalendarSettingRepository : IRepository<CalendarSetting>
    {
        private SBContext db;

        public CalendarSettingRepository(SBContext context)
        {
            this.db = context;
        }

        public async Task<bool> Create(CalendarSetting item)
        {
            try
            {
                db.CalendarSettings.Add(item);
                await db.SaveChangesAsync();
                return true;
            }
            catch (Exception ex) { Console.Out.WriteLine(ex.Message); return false; }
        }

        public async Task<bool> Delete(int id)
        {
            try
            {
                CalendarSetting cSetting = await db.CalendarSettings.FindAsync(id);
                //CalendarSetting cSetting = db.CalendarSettings.Where(c => c.EmployeeId == id).ToList()[0];
                
                if (cSetting != null)
                {
                    db.CalendarSettings.Remove(cSetting);
                    await db.SaveChangesAsync();
                    return true;
                }
            }
            catch (Exception ex) { Console.Out.WriteLine(ex.Message); }
            return false;
        }

        public IQueryable<CalendarSetting> Find(Func<CalendarSetting, bool> predicate)
        {
            throw new NotImplementedException();
        }

        public async Task<CalendarSetting> Get(int id)
        {
            return await db.CalendarSettings
                .Include("Employee")
                .SingleOrDefaultAsync(p => p.EmployeeId == id);
        }

        public IQueryable<CalendarSetting> GetAll()
        {
            throw new NotImplementedException();
        }

        public async Task<bool> Update(CalendarSetting setting)
        {
            try
            {
                var initialSetting = await db.CalendarSettings.FindAsync(setting.EmployeeId);
                if (initialSetting != null)
                {
                    initialSetting.View = setting.View;
                    initialSetting.FirstHour = setting.FirstHour;
                    initialSetting.WorkingDayDuration = setting.WorkingDayDuration;
                    initialSetting.SlotDuration = setting.SlotDuration;

                    await db.SaveChangesAsync();
                    return true;
                }
            }
            catch (Exception ex) { Console.Out.WriteLine(ex.Message); }
            return false;
        }
    }
}
