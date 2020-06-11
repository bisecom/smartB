using DAL.Interfaces;
using smart_booking.DAL.EF;
using smart_booking.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public class BusinessRepository : IRepository<Business>
    {
        private SBContext db;

        public BusinessRepository(SBContext context)
        {
            this.db = context;
        }

        public async Task<bool> Create(Business item)
        {
            try
            {
                db.Businesses.Add(item);
                await db.SaveChangesAsync();
                return true;
            }
            catch (Exception ex){ Console.Out.WriteLine(ex.Message); return false; }
        }

        public async Task<bool> Delete(int id)
        {
            try
            {
                Business business = db.Businesses.Find(id);
                if (business != null)
                {
                    db.Businesses.Remove(business);
                    db.SaveChanges();
                    return true;
                }
            }
            catch (Exception ex) { Console.Out.WriteLine(ex.Message); }
            return false;
        }

        public IQueryable<Business> Find(Func<Business, bool> predicate)
        {
            return db.Businesses.AsQueryable();
        }

        public async Task<Business> Get(int id)
        {
            return await db.Businesses.FindAsync(id);
        }

        public IQueryable<Business> GetAll()
        {
            return db.Businesses.AsQueryable();
        }

        public async Task<bool> Update(Business business)
        {
            try
            {
                var initialBusiness = await db.Businesses.FindAsync(business.Id);
                if (initialBusiness != null)
                {
                    initialBusiness.Name = business.Name;
                    initialBusiness.Phone = business.Phone;
                    initialBusiness.Country = business.Country;
                    initialBusiness.Currency = business.Currency;
                    initialBusiness.Time_zone = business.Time_zone;
                    initialBusiness.Logo = business.Logo;
                    initialBusiness.Webpage = business.Webpage;
                    initialBusiness.Address = business.Address;
                    initialBusiness.City = business.City;
                    initialBusiness.State = business.State;
                    initialBusiness.ZipCode = business.ZipCode;
                    initialBusiness.RegistrationNumber = business.RegistrationNumber;

                    await db.SaveChangesAsync();
                    return true;
                }
            }
            catch (Exception ex)
            { Console.Out.WriteLine(ex.Message); }
            return false;
        }


    }
}
