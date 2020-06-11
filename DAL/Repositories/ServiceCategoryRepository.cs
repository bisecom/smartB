using DAL.Interfaces;
using smart_booking.DAL.EF;
using smart_booking.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    class ServiceCategoryRepository : IRepository<ServiceCategory>
    {
        private SBContext db;

        public ServiceCategoryRepository(SBContext context)
        {
            this.db = context;
        }

        public async Task<bool> Create(ServiceCategory item)
        {
            try
            {
                db.ServiceCategories.Add(item);
                await db.SaveChangesAsync();
                return true;
            }
            catch (Exception ex) { Console.Out.WriteLine(ex.Message); return false; }
        }

        public async Task<bool> Delete(int id)
        {
            try
            {
                ServiceCategory sCategory = await db.ServiceCategories.FindAsync(id);
                if (sCategory != null)
                {
                    db.ServiceCategories.Remove(sCategory);
                    await db.SaveChangesAsync();
                    return true;
                }
            }
            catch (Exception ex) { Console.Out.WriteLine(ex.Message); }
            return false;
        }

        public IQueryable<ServiceCategory> Find(Func<ServiceCategory, bool> predicate)
        {
            return db.ServiceCategories.AsQueryable();
        }

        public async Task<ServiceCategory> Get(int id)
        {
            return await db.ServiceCategories.FindAsync(id);
        }

        public IQueryable<ServiceCategory> GetAll()
        {
            return db.ServiceCategories.AsQueryable();
        }

        public Task<bool> Update(ServiceCategory item)
        {
            throw new NotImplementedException();
        }
    }
}
