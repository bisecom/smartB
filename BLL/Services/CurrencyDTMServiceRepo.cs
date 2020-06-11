using AutoMapper;
using BLL.Interfaces;
using BLL.Utils;
using DAL.Interfaces;
using smart_booking.BLL.DataTransferModels;
using smart_booking.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    class CurrencyDTMServiceRepo : IServiceRepository<CurrencyDTM>
    {
        IUnitOfWork Database { get; set; }

        public CurrencyDTMServiceRepo(IUnitOfWork uow)
        {
            Database = uow;
        }

        public Task<List<CurrencyDTM>> GetAll(SearchParams search)
        {
            throw new NotImplementedException();
        }

        public async Task<CurrencyDTM> Get(int id)
        {
            int firstCurrencyId = 1; int lastCurrencyId = 999;
            if (id < firstCurrencyId || id > lastCurrencyId)
                throw new ValidationException("Currency id is not specified correctly", "");
            var currency = await Database.Currencies.Get(id);
            if (currency == null)
                throw new ValidationException("Currency is not found", "");

            var config = new MapperConfiguration(cfg => cfg.CreateMap<Currency, CurrencyDTM>());
            var mapper = new Mapper(config);
            return mapper.Map<CurrencyDTM>(currency);
        }

        public IQueryable<CurrencyDTM> Find(Func<CurrencyDTM, bool> predicate)
        {
            throw new NotImplementedException();
        }

        public async Task<int> Create(CurrencyDTM item)
        {
            try
            {
                Currency currency = new Currency { Name = item.Name };
                await Database.Currencies.Create(currency);
                return currency.Id;
            }
            catch { return 0; }
        }

        public Task<bool> Update(CurrencyDTM item)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> Delete(int id)
        {
            throw new NotImplementedException();
        }
    }
}
