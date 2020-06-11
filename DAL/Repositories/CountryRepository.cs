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
    public class CountryRepository : IRepository<Country>
    {
        private SBContext db;

        public CountryRepository(SBContext context)
        {
            this.db = context;
        }

        public async Task<bool> Create(Country item)
        {
            try
            {
                db.Countries.Add(item);
                db.SaveChanges();
                return true;
            }
            catch (Exception ex){ Console.Out.WriteLine(ex.Message); return false; }
        }

        public async Task<bool> Delete(int id)
        {
            try
            {
                Country country = await db.Countries.FindAsync(id);
                if (country != null)
                    db.Countries.Remove(country);
                    db.SaveChanges();
                return true;
            }
            catch { return false; }
        }

        public IQueryable<Country> Find(Func<Country, bool> predicate)
        {
            return db.Countries.AsQueryable();
        }

        public async Task<Country> Get(int id)
        {
            return await db.Countries.FindAsync(id);
        }

        public IQueryable<Country> GetAll()
        {
            return db.Countries.AsQueryable();
        }

        public async Task<bool> Update(Country item)
        {
            try
            {
                var initialCountry = await Get(item.Id);
                db.Entry(initialCountry).CurrentValues.SetValues(item);
                db.SaveChanges();
                return true;
            }
            catch { return false; }
        }
    }
}
