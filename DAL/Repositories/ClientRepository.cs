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
    public class ClientRepository : IRepository<Client>
    {
        private SBContext db;

        public ClientRepository(SBContext context)
        {
            this.db = context;
        }

        public async Task<bool> Create(Client item)
        {
            try
            {
                db.Clients.Add(item);
                await db.SaveChangesAsync();
                return true;
            }
            catch (Exception ex) { Console.Out.WriteLine(ex.Message); return false; }
        }

        public async Task<bool> Delete(int id)
        {
            try
            {
                Client client = await db.Clients.FindAsync(id);
                if (client != null)
                {
                    db.Clients.Remove(client);
                    await db.SaveChangesAsync();
                    return true;
                }
            }
            catch (Exception ex) { Console.Out.WriteLine(ex.Message); }
            return false;
        }

        public IQueryable<Client> Find(Func<Client, bool> predicate)
        {
            throw new NotImplementedException();
        }

        public async Task<Client> Get(int id)
        {
            return await db.Clients
                .Include("Business")
                .SingleOrDefaultAsync(p => p.Id == id);
        }

        public IQueryable<Client> GetAll()
        {
            return db.Clients.AsQueryable();
        }

        public async Task<bool> Update(Client client)
        {
            try
            {
                var initialClient = await db.Clients.FindAsync(client.Id);
                if (initialClient != null)
                {
                    initialClient.FirstName = client.FirstName;
                    initialClient.SecondName = client.SecondName;
                    initialClient.ClientCompanyName = client.ClientCompanyName;
                    initialClient.Email = client.Email;
                    initialClient.MobilePhone = client.MobilePhone;
                    initialClient.OfficePhone = client.OfficePhone;
                    initialClient.Address = client.Address;
                    initialClient.City = client.City;
                    initialClient.State = client.State;
                    initialClient.Zip_Code = client.Zip_Code;
                    initialClient.BirthDay = client.BirthDay;
                    initialClient.Image = client.Image;
                    initialClient.IsMale = client.IsMale;
                    initialClient.Note = client.Note;

                    await db.SaveChangesAsync();
                    return true;
                }
            }
            catch (Exception ex) { Console.Out.WriteLine(ex.Message); }
            return false;
        }
    }
}
