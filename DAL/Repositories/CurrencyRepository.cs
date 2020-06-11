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
    public class CurrencyRepository : IRepository<Currency>
    {
        private SBContext db;

        public CurrencyRepository(SBContext context)
        {
            this.db = context;
        }

        public async Task<bool> Create(Currency item)
        {
            try
            {
                db.Currencies.Add(item);
                db.SaveChanges();
                return true;
            }
            catch { return false; }
        }

        public Task<bool> Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IQueryable<Currency> Find(Func<Currency, bool> predicate)
        {
            throw new NotImplementedException();
        }

        public async Task<Currency> Get(int id)
        {
            return await db.Currencies.FindAsync(id);
        }

        public IQueryable<Currency> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<bool> Update(Currency item)
        {
            throw new NotImplementedException();
        }

    }
}
