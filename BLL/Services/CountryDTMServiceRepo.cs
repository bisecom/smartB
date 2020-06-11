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
    class CountryDTMServiceRepo : IServiceRepository<CountryDTM>
    {
        IUnitOfWork Database { get; set; }

        public CountryDTMServiceRepo(IUnitOfWork uow)
        {
            Database = uow;
        }

        public async Task<int> Create(CountryDTM item)
        {
            try
            {
                Country country = new Country
                {
                    Code = item.Code,
                    Name = item.Name,
                    Native = item.Native,
                    PhonePrefix = item.PhonePrefix,
                    Capital = item.Capital,
                    Currency_ = item.Currency_,
                    Emoji  = item.Emoji,
                    EmojiU = item.EmojiU
                    };

                await Database.Countries.Create(country);
                return country.Id;
            }
            catch { return 0; }
        }

        public async Task<bool> Delete(int id)
        {
            try
            {
                await Database.Countries.Delete(id);
                return true;
            }
            catch { return false; }
        }

        public IQueryable<CountryDTM> Find(Func<CountryDTM, bool> predicate)
        {
            throw new NotImplementedException();
        }

        public async Task<CountryDTM> Get(int id)
        {
            int firstCountryId = 1; int lastCountryId = 999;
            if (id < firstCountryId || id > lastCountryId)
                throw new ValidationException("Country id is not specified correctly", "");
            var country = await Database.Countries.Get(id);
            if (country == null)
                throw new ValidationException("Country is not found", "");

            var config = new MapperConfiguration(cfg => cfg.CreateMap<Country, CountryDTM>());
            var mapper = new Mapper(config);
            return mapper.Map<CountryDTM>(country);
        }

        public async Task<List<CountryDTM>> GetAll(SearchParams search)
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<Country, CountryDTM>());
            var mapper = new Mapper(config);
            return await Task.Run(() => (mapper.Map<List<CountryDTM>>(
                Database.Countries.GetAll()
               .OrderBy(u => u.Name)
               .Skip(search.PageSize * search.Page)
               .Take(search.PageSize))));
        }

        public async Task<bool> Update(CountryDTM item)
        {
            try
            {
                var config = new MapperConfiguration(cfg => cfg.CreateMap<CountryDTM, Country>());
                var mapper = new Mapper(config);
                Country country = mapper.Map<Country>(item);

                await Database.Countries.Update(country);
                return true;
            }
            catch (Exception ex) { return false; }
        }

        //public async Task<Country> GetToUpdateParent(int id)
        //{
        //    return await Database.Countries.Get(id);
        //}
        public void Dispose()
        {
            Database.Dispose();
        }

    }
}
