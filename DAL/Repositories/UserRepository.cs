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
    public class UserRepository : IUserRepository
    {
        private SBContext db;

        public UserRepository(SBContext context)
        {
            this.db = context;
        }
        public async Task<bool> Create(User item)
        {
            try
            {
                db.Users.Add(item);
                await db.SaveChangesAsync();
                return true;
            }
            catch { return false; }
        }

        public async Task<bool> Delete(string id)
        {
            try
            {
                User user = await db.Users.FindAsync(id);
                if (user != null)
                {
                    db.Users.Remove(user);
                    db.SaveChanges();
                    return true;
                }
            }
            catch(Exception ex) {  }
            return false;
        }

        public IQueryable<User> Find(Func<User, bool> predicate)//should be deleted
        {
            return db.Users.AsQueryable();
        }

        public async Task<User> Get(string id)
        {
            return await db.Users.FindAsync(id);
        }

        public IQueryable<User> GetAll()
        {
            return db.Users.AsQueryable();
        }
        
        public async Task<bool> Update(User user)
        {
            try
            {
                //var initialUser = await Get(user.Id);
                //db.Entry(initialUser).CurrentValues.SetValues(user);
                //db.Users.Add(user);
                //db.Entry(user).State = EntityState.Modified;
                //return true;
                var initialUser = await Get(user.Id);
                if (initialUser != null)
                {
                    initialUser.FirstName = user.FirstName;
                    initialUser.SecondName = user.SecondName;
                    initialUser.PhoneMobile = user.PhoneMobile;
                    initialUser.PhoneOffice = user.PhoneOffice;
                    initialUser.Country = db.Countries.Find(user.CountryId);
                    initialUser.Time_zone = db.Time_zones.Find(user.Time_ZoneId);
                    initialUser.UserPicture = user.UserPicture;
                    initialUser.Address = user.Address;
                    initialUser.City = user.City;
                    initialUser.State = user.State;
                    initialUser.ZipCode = user.ZipCode;
                    initialUser.PlanId = user.PlanId;
                    initialUser.IsPaymentOverdue = user.IsPaymentOverdue;
                    initialUser.IsMale = user.IsMale;
                    initialUser.Birthdate = user.Birthdate;
                    db.SaveChanges();
                    return true;
                }
            }
            catch(Exception ex)
            { }
            return false;
        }
    }
}
