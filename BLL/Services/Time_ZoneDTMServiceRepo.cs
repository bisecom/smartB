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
    public class Time_ZoneDTMServiceRepo : IServiceRepository<Time_zoneDTM>
    {
        IUnitOfWork Database { get; set; }

        public Time_ZoneDTMServiceRepo(IUnitOfWork uow)
        {
            Database = uow;
        }
        public async Task<int> Create(Time_zoneDTM item)
        {
            try
            {
                Time_zone zone = new Time_zone
                {
                    Zone = item.Zone,
                    CountryCode = item.CountryCode,
                    UTC_Jan_1_2020 = item.UTC_Jan_1_2020,
                    DST_Jul_1_2020 = item.DST_Jul_1_2020
                };
                await Database.Time_zones.Create(zone);

                return zone.Id;
            }
            catch { return 0; }
        }

        public async Task<bool> Delete(int id)
        {
            try
            {
                await Database.Time_zones.Delete(id);
                return true;
            }
            catch { return false; }
        }

        public IQueryable<Time_zoneDTM> Find(Func<Time_zoneDTM, bool> predicate)
        {
            throw new NotImplementedException();
        }

        public async Task<Time_zoneDTM> Get(int id)
        {
            int firstTzId = 2; int lastTzId = 426;
            if (id < firstTzId || id > lastTzId)
                throw new ValidationException("TZ id is not specified correctly", "");
            var tz = await Database.Time_zones.Get(id);
            if (tz == null)
                throw new ValidationException("TZ is not found", "");

            var config = new MapperConfiguration(cfg => cfg.CreateMap<Time_zone, Time_zoneDTM>());
            var mapper = new Mapper(config);
            return mapper.Map<Time_zoneDTM>(tz);
        }

        public async Task<List<Time_zoneDTM>> GetAll(SearchParams search)
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<Time_zone, Time_zoneDTM>());
            var mapper = new Mapper(config);
            return await Task.Run(() => (mapper.Map<List<Time_zoneDTM>>(
                Database.Time_zones.GetAll()
               .OrderBy(u => u.CountryCode)
               .Skip(search.PageSize * search.Page)
               .Take(search.PageSize))));
        }

        public async Task<bool> Update(Time_zoneDTM item)
        {
            try
            {
                var config = new MapperConfiguration(cfg => cfg.CreateMap<Time_zoneDTM, Time_zone>());
                var mapper = new Mapper(config);
                Time_zone tz = mapper.Map<Time_zone>(item);
                await Database.Time_zones.Update(tz);
                return true;
            }
            catch (Exception ex) { return false; }
        }
        public void Dispose()
        {
            Database.Dispose();
        }
    }
}
