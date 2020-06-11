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
    class SlotRepository : IRepository<Slot>
    {
        private SBContext db;

        public SlotRepository(SBContext context)
        {
            this.db = context;
        }

        public async Task<bool> Create(Slot item)
        {
            try
            {
                db.Slots.Add(item);
                await db.SaveChangesAsync();
                return true;
            }
            catch (Exception ex) { Console.Out.WriteLine(ex.Message); return false; }
        }

        public async Task<bool> Delete(int id)
        {
            try
            {
                Slot slot = db.Slots.Find(id);
                if (slot != null)
                {
                    db.Slots.Remove(slot);
                    await db.SaveChangesAsync();
                    return true;
                }
            }
            catch (Exception ex) { Console.Out.WriteLine(ex.Message); }
            return false;
        }

        public IQueryable<Slot> Find(Func<Slot, bool> predicate)
        {
            return db.Slots.AsQueryable();
        }

        public async Task<Slot> Get(int id)
        {
            return await db.Slots
               .Include("Employee")
               .Include("Country")
               .Include("Responsible")
               .Include("Service")
               .SingleOrDefaultAsync(e => e.Id == id);
        }

        public IQueryable<Slot> GetAll()
        {
            return db.Slots.AsQueryable();
        }

        public async Task<bool> Update(Slot slot)
        {
            try
            {
                var initialSlot = await db.Slots.FindAsync(slot.Id);
                if (initialSlot != null)
                {
                    initialSlot.SlotDateTime = slot.SlotDateTime;
                    initialSlot.Duration = slot.Duration;
                    initialSlot.IsPadding = slot.IsPadding;
                    initialSlot.PaddingAfter = slot.PaddingAfter;
                    initialSlot.Reiteration = slot.Reiteration;
                    initialSlot.Price = slot.Price;
                    initialSlot.Note = slot.Note;
                    initialSlot.Status = slot.Status;
                    initialSlot.IsTimeBlock = slot.IsTimeBlock;
                    initialSlot.IsReminderNeeded = slot.IsReminderNeeded;
                    initialSlot.ReminderInterval = slot.ReminderInterval;

                    if (initialSlot.Employee.Id != slot.Employee.Id)
                    {
                        var employee = db.Employees.Include("SlotsOwners").Single(s => s.Id == initialSlot.Employee.Id);
                        var slotToDelete = employee.SlotsOwners.FirstOrDefault(ol => ol.Id == initialSlot.Id);
                        if (slotToDelete != null)
                            employee.SlotsOwners.Remove(slotToDelete);
                        initialSlot.Employee = slot.Employee;

                    }

                    //if (initialSlot.CountryId != slot.CountryId)
                    //{
                    //    var country = db.Countries.Include("Slots").Single(s => s.Id == initialSlot.Country.Id);
                    //    var slotToDelete = country.Slots.FirstOrDefault(ol => ol.Id == initialSlot.Id);
                    //    if (slotToDelete != null)
                    //        country.Slots.Remove(slotToDelete);
                    //    initialSlot.Country = slot.Country;
                    //}
                    
                    if (initialSlot.Responsible.Id != slot.Responsible.Id)
                    {
                        var employeeR = db.Employees.Include("Responsibles").Single(s => s.Id == initialSlot.Responsible.Id);
                        var slotToDelete = employeeR.Responsibles.FirstOrDefault(ol => ol.Id == initialSlot.Id);
                        if (slotToDelete != null)
                            employeeR.Responsibles.Remove(slotToDelete);
                        initialSlot.Responsible = slot.Responsible;
                    }

                    //if (initialSlot.Service.Id != slot.Service.Id)
                    //{
                    //    var service = db.Services.Include("Slots").Single(s => s.Id == initialSlot.Service.Id);
                    //    var slotToDelete = service.Slots.FirstOrDefault(ol => ol.Id == initialSlot.Id);
                    //    if (slotToDelete != null)
                    //        service.Slots.Remove(slotToDelete);
                    //    initialSlot.Service = slot.Service;
                    //}

                    db.SaveChanges();
                    return true;
                }
            }
            catch (Exception ex) { Console.Out.WriteLine(ex.Message); }
            return false;
        }
    }
}
