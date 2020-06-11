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
    public class UserDTMServiceRepo : IUserServiceRepository
    {
        IUnitOfWork Database { get; set; }

        public UserDTMServiceRepo(IUnitOfWork uow)
        {
            Database = uow;
        }
       
        public async void Update(UserDTM userDtm)
        {
            try
            {
                var config = new MapperConfiguration(cfg => cfg.CreateMap<UserDTM, User>());
                var mapper = new Mapper(config);
                User user = mapper.Map<User>(userDtm);

                await Database.Users.Update(user);
            }
            catch (Exception ex){ Console.Out.WriteLine(ex.Message); }

        }

        public async Task<bool> Delete(string id)
        {
            try
            {
                await Database.Users.Delete(id);
                return true;
            }
            catch { return false; }
        }

        public async Task<List<UserDTM>> GetAll(SearchParams search)
        {
            List<UserDTM> userListDtm = new List<UserDTM>();
            List<User> userList = 
                 Database.Users.GetAll()
                .OrderBy(u => u.SecondName)
                .Skip(search.PageSize * search.Page)
                .Take(search.PageSize).ToList();

            if (userList == null)
                return null;

            foreach(var u in userList)
            {
                userListDtm.Add(ModelFactory.changeToDTM(u));
            }
            return userListDtm;
        }

        public async Task <UserDTM> Get(string id)
        {
            if (id == null)
                throw new ValidationException("User id is not specified", "");
            var user = await Database.Users.Get(id);
            if (user == null)
                throw new ValidationException("User is not found", "");

            var userDtm = ModelFactory.changeToDTM(user);
            return userDtm;
        }

        public IQueryable<UserDTM> Find(Func<UserDTM, bool> predicate)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> Create(UserDTM userDtm)
        {
            try
            {
                User user = new User
                {
                    Id = userDtm.Id,
                    Email = userDtm.Email,
                    FirstName = userDtm.FirstName,
                    SecondName = userDtm.SecondName,
                    CountryId = userDtm.CountryId,
                    Time_ZoneId = userDtm.Time_ZoneId,
                    Birthdate = userDtm.Birthdate,
                    PlanId = userDtm.PlanId,
                    City = userDtm.City

                };
                await Database.Users.Create(user);
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
