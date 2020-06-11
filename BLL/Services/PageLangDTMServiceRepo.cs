using BLL.Interfaces;
using BLL.Utils;
using DAL.Interfaces;
using smart_booking.BLL.DataTransferModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    class PageLangDTMServiceRepo : IServiceRepository<PageLanguageDTM>
    {
        IUnitOfWork Database { get; set; }

        public PageLangDTMServiceRepo(IUnitOfWork uow)
        {
            Database = uow;
        }

        public Task<List<PageLanguageDTM>> GetAll(SearchParams search)
        {
            throw new NotImplementedException();
        }

        public async Task<PageLanguageDTM> Get(int id)
        {
            int firstLangId = 1;
            if (id < firstLangId)
                throw new ValidationException("Language id is not specified correctly", "");
            var language = await Database.PageLanguages.Get(id);
            if (language == null)
                throw new ValidationException("Language is not found", "");

            PageLanguageDTM langDtm = new PageLanguageDTM();
            langDtm.Id = language.Id;
            langDtm.Name = language.Name;

            return langDtm;
        }

        public IQueryable<PageLanguageDTM> Find(Func<PageLanguageDTM, bool> predicate)
        {
            throw new NotImplementedException();
        }

        public Task<int> Create(PageLanguageDTM item)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Update(PageLanguageDTM item)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> Delete(int id)
        {
            try
            {
                await Database.PageLanguages.Delete(id);
                return true;
            }
            catch { return false; }
        }

        public void Dispose()
        {
            Database.Dispose();
        }
    }
}
