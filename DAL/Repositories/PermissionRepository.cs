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
    class PermissionRepository : IRepository<Permission>
    {
        private SBContext db;

        public PermissionRepository(SBContext context)
        {
            this.db = context;
        }

        public async Task<bool> Create(Permission item)
        {
            try
            {
                db.Permissions.Add(item);
                await db.SaveChangesAsync();
                return true;
            }
            catch (Exception ex) { Console.Out.WriteLine(ex.Message); return false; }
        }

        public async Task<bool> Delete(int id)
        {
            try
            {
                Permission permission = await db.Permissions.FindAsync(id);
                //var permission = db.Permissions.Where(p => p.EmployeeId == id).ToList()[0];
                if (permission != null)
                {
                    db.Permissions.Remove(permission);
                    await db.SaveChangesAsync();
                    return true;
                }
            }
            catch (Exception ex) { Console.Out.WriteLine(ex.Message); }
            return false;
        }

        public IQueryable<Permission> Find(Func<Permission, bool> predicate)
        {
            throw new NotImplementedException();
        }

        public async Task<Permission> Get(int id)
        {
            return await db.Permissions
                .Include("Employee")
                .SingleOrDefaultAsync(p => p.EmployeeId == id);
        }

        public IQueryable<Permission> GetAll()
        {
            throw new NotImplementedException();
        }

        public async Task<bool> Update(Permission permission)
        {
            try
            {
                var initialPermission = await db.Permissions.FindAsync(permission.EmployeeId);
                if (initialPermission != null)
                {
                    initialPermission.IsSummary = permission.IsSummary;
                    initialPermission.IsOthersCalendar = permission.IsOthersCalendar;
                    initialPermission.IsClients = permission.IsClients;
                    initialPermission.IsServices = permission.IsServices;
                    initialPermission.IsReports = permission.IsReports;
                    await db.SaveChangesAsync();
                    return true;
                }
            }
            catch (Exception ex) { Console.Out.WriteLine(ex.Message); }
            return false;
        }
    }
}
