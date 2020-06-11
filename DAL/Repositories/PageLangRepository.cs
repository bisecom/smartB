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
    class PageLangRepository : IRepository<PageLanguage>
    {
        private SBContext db;

        public PageLangRepository(SBContext context)
        {
            this.db = context;
        }

        public Task<bool> Create(PageLanguage item)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IQueryable<PageLanguage> Find(Func<PageLanguage, bool> predicate)
        {
            throw new NotImplementedException();
        }

        public Task<PageLanguage> Get(int id)
        {
            throw new NotImplementedException();
        }

        public IQueryable<PageLanguage> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<bool> Update(PageLanguage item)
        {
            throw new NotImplementedException();
        }
    }
}
