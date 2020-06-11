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
    public class EmployeeRepository : IRepository<Employee>
    {
        private SBContext db;

        public EmployeeRepository(SBContext context)
        {
            this.db = context;
        }

        public async Task<bool> Create(Employee item)
        {
            try
            {
                db.Employees.Add(item);
                await db.SaveChangesAsync();
                return true;
            }
            catch { return false; }
        }

        public async Task<bool> Delete(int id)
        {
            try
            {
                Employee empl = await db.Employees.FindAsync(id);

                if (empl != null)
                    db.Employees.Remove(empl);
                await db.SaveChangesAsync();
                return true;
            }
            catch (Exception ex){ Console.Out.WriteLine(ex.Message); return false; }
        }

        public IQueryable<Employee> Find(Func<Employee, bool> predicate)
        {
            return db.Employees.AsQueryable();
        }

        public async Task<Employee> Get(int id)
        {
            try
            {
                Employee empl = await db.Employees
                    //.Include("User")
                    //.Include("Business")
                    .Include(c => c.CalendarSetting)
                    .Include(c => c.CustomerNotification)
                    .Include(t => t.TeamNotification)
                    .Include(p => p.Permission)
                    .Include(w => w.WorkingHour)
                    .FirstOrDefaultAsync(e => e.Id == id);


                //var empl = await (from e in db.Employees
                //                  where e.Id == id
                //                  select e).FirstOrDefaultAsync();

                return empl;
            }
            catch(Exception ex) { Console.Out.WriteLine(ex.Message); return null; }
        }

        public IQueryable<Employee> GetAll()
        {
            return db.Employees.Include("User").AsQueryable();
        }

        public async Task<bool> Update(Employee employee)
        {
            //try
            //{
            //    var initialEmployee = await db.Employees.FindAsync(employee.Id);
            //    if (initialEmployee != null)
            //    {
            //        if (employee.CalendarSetting != null)
            //        {
            //            initialEmployee.CalendarSetting = employee.CalendarSetting;
            //        }
            //        if (employee.CustomerNotification != null)
            //        {
            //            initialEmployee.CustomerNotification = employee.CustomerNotification;
            //        }
            //        if (employee.TeamNotification != null)
            //        {
            //            initialEmployee.TeamNotification = employee.TeamNotification;
            //        }
            //        if (employee.Permission != null)
            //        {
            //            initialEmployee.Permission = employee.Permission;
            //        }
            //        if (employee.WorkingHour != null)
            //        {
            //            initialEmployee.WorkingHour = employee.WorkingHour;
            //        }

            //        await db.SaveChangesAsync();
            //        return true;
            //    }
            //}
            //catch (Exception ex)
            //{ Console.Out.WriteLine(ex.Message); }
            return false;
        }
    }
}