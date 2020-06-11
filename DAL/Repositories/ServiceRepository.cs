using DAL.Interfaces;
using smart_booking.DAL.EF;
using smart_booking.DAL.Entities;
using System;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    class ServiceRepository : IRepository<Service>
    {
        private SBContext db;

        public ServiceRepository(SBContext context)
        {
            this.db = context;
        }

        public async Task<bool> Create(Service item)
        {
            try
            {
                db.Services.Add(item);
                await db.SaveChangesAsync();
                return true;
            }
            catch (Exception ex) { Console.Out.WriteLine(ex.Message); return false; }
        }

        public async Task<bool> Delete(int id)
        {
            try
            {
                Service service = await db.Services.FindAsync(id);
                if (service != null)
                {
                    db.Services.Remove(service);
                    await db.SaveChangesAsync();
                    return true;
                }
            }
            catch (Exception ex) { Console.Out.WriteLine(ex.Message); }
            return false;
        }

        public IQueryable<Service> Find(Func<Service, bool> predicate)
        {
            return db.Services.AsQueryable();
        }

        public async Task<Service> Get(int id)
        {
            return await db.Services
                //.Include("Business")
                .Include("ServiceCategory")
                .SingleOrDefaultAsync(e => e.Id == id);
        }

        public IQueryable<Service> GetAll()
        {
            return db.Services.AsQueryable();
        }

        public async Task<bool> Update(Service service)
        {
            try
            {
                //Option No1
                //var initialService = await db.Services.FindAsync(service.Id);
                var initialService = await db.Services.Where(x => x.Id == service.Id).FirstOrDefaultAsync();
                //Option No2
                //var initialService = db.Services
                //    .Include(c => c.ServiceCategory)
                //    .FirstOrDefault(s => s.Id == service.Id);
                //Option No3
                //var context = ((IObjectContextAdapter)db).ObjectContext;

                if (initialService != null)
                {
                    initialService.Name = service.Name;
                    initialService.Description = service.Description;
                    initialService.Price = service.Price;
                    initialService.Duration = service.Duration;
                    initialService.PaddingAfter = service.PaddingAfter;
                    initialService.Picture = service.Picture;
                    //    db.Entry(initialService).CurrentValues.SetValues(service);
                    //    db.Entry(initialService.ServiceCategory).CurrentValues.SetValues(service.ServiceCategory);
                    //    initialService.ServiceCategory = service.ServiceCategory;
                    //    db.Services.AddOrUpdate(initialService);

                    //Option No2
                    //db.Entry(initialService).State = EntityState.Modified;
                    //Option No3
                    //context.Refresh(RefreshMode.StoreWins, initialService);

                    await db.SaveChangesAsync();
                    return true;
                }
            }
            catch (Exception ex) { Console.Out.WriteLine(ex.Message); }//To Check exception
            return false;
        }
    }
}
