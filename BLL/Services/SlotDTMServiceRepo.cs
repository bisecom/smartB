using BLL.Interfaces;
using BLL.Utils;
using AutoMapper;
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
    public class SlotDTMServiceRepo : ISlotServiceRepository
    {
        IUnitOfWork Database { get; set; }

        public SlotDTMServiceRepo(IUnitOfWork uow)
        {
            Database = uow;
        }

        public async Task<SlotDTM> Get(int id)
        {
            int firstSlotId = 1;
            if (id < firstSlotId)
                throw new ValidationException("Slot id is not specified correctly", "");
            var slot = await Database.Slotes.Get(id);
            if (slot == null)
                throw new ValidationException("Slot is not found", "");

            SlotDTM slotDtm = new SlotDTM();
            slotDtm.Id = slot.Id;

            slotDtm.SlotDateTime = slot.SlotDateTime;
            slotDtm.Duration = slot.Duration;
            slotDtm.IsPadding = slot.IsPadding;
            slotDtm.PaddingAfter = slot.PaddingAfter;
            slotDtm.Reiteration = slot.Reiteration;
            slotDtm.Price = slot.Price;
            slotDtm.Note = slot.Note;
            slotDtm.Status = slot.Status;
            slotDtm.IsTimeBlock = slot.IsTimeBlock;
            slotDtm.IsReminderNeeded = slot.IsReminderNeeded;
            slotDtm.ReminderInterval = slot.ReminderInterval;

            slotDtm.EmployeeId = slot.EmployeeId;
            slotDtm.ResponsibleId = slot.ResponsibleId;
            slotDtm.CountryId = slot.CountryId;
            slotDtm.ServiceId = slot.ServiceId;

            //slotDtm.Employee = await Database.BllServices.GetEmployee(slot.Employee.Id);
            //slotDtm.EmployeeId = slot.Employee.Id;
            //slotDtm.Responsible = await Database.BllServices.GetEmployee(slot.Responsible.Id);
            //slotDtm.ResponsibleId = slot.Responsible.Id;
            //slotDtm.Country = await Database.BllServices.GetCountry(slot.Country.Id);
            //slotDtm.CountryId = slot.Country.Id;
            //slotDtm.Service = await Database.BllServices.GetService(slot.Service.Id);
            
            return slotDtm;
        }

        public async Task<List<SlotDTM>> GetAll(SearchParams search)
        {
            //int calendarViewType = 2; //dayly - 1; weekly - 2; monthly - 3
            IQueryable<Slot> slotsQuery = Database.Slotes.GetAll();
            List<Slot> sList = new List<Slot>();
            List<SlotDTM> sDtmList = new List<SlotDTM>();
            int indexId = 0;
            try
            {
                if (search.lastDateToShowSlots == null)
                {
                    if (search.employeesIdsArray.Length > 1)
                    {
                        for (int i = 0; i < search.employeesIdsArray.Length; i++)
                        {
                            indexId = search.employeesIdsArray[i];
                            List<Slot> temp = slotsQuery
                            .Where(t => t.EmployeeId == indexId
                            && t.SlotDateTime == search.firstDateToShowSlots)
                            //.Where(d => d.SlotDateTime == search.dateToShowSlots)
                            .ToList();
                            sList.AddRange(temp);
                        }

                    }
                    else
                    {
                        indexId = search.employeesIdsArray[0];
                        sList = slotsQuery
                            .Where(t => t.EmployeeId == indexId
                             && t.SlotDateTime == search.firstDateToShowSlots)
                            .ToList();
                    }
                }
                else
                {
                    indexId = search.employeesIdsArray[0];
                    sList = slotsQuery
                            .Where(t => t.EmployeeId == indexId
                             && t.SlotDateTime >= search.firstDateToShowSlots
                             && t.SlotDateTime <= search.lastDateToShowSlots)
                            .ToList();
                }

                foreach (var slot in sList)
                {
                    sDtmList.Add(SlotToSlotDtmMap(slot));
                }

                return sDtmList;
            }catch(Exception ex)
            { Console.Out.WriteLine(ex.Message); }
            return null;
        }
            public IQueryable<SlotDTM> Find(Func<SlotDTM, bool> predicate)
        {
            throw new NotImplementedException();
        }

        public async Task<int> Create(SlotDTM slotDtm)
        {
            try
            {
                //Slot slot = new Slot();
                //slot.SlotDateTime = DateTime.Now;
                //slot.Duration = 15;
                //slot.IsPadding = true;
                //slot.PaddingAfter = 20;
                //slot.Reiteration = 30;
                //slot.Price = 15f;
                //slot.Note = "sdfsf";
                //slot.Status = "sdfsd sdf ";
                //slot.IsTimeBlock = false;
                //slot.IsReminderNeeded = true;
                //slot.ReminderInterval = 15;
                //slot.Employee = await Database.BllServices.GetEmployee(1);
                //slot.Responsible = await Database.BllServices.GetEmployee(1);
                //slot.Country = await Database.BllServices.GetCountry(5);
                //slot.Service = await Database.BllServices.GetService(1);


                Slot slot = new Slot();
                slot.SlotDateTime = slotDtm.SlotDateTime /*?? DateTime.Now*/;
                slot.Duration = slotDtm.Duration;
                slot.IsPadding = slotDtm.IsPadding;
                slot.PaddingAfter = slotDtm.PaddingAfter;
                slot.Reiteration = slotDtm.Reiteration;
                slot.Price = slotDtm.Price;
                slot.Note = slotDtm.Note;
                slot.Status = slotDtm.Status;
                slot.IsTimeBlock = slotDtm.IsTimeBlock;
                slot.IsReminderNeeded = slotDtm.IsReminderNeeded;
                slot.ReminderInterval = slotDtm.ReminderInterval;

                slot.Employee = await Database.BllServices.GetEmployee(slotDtm.Employee.Id);
                //slot.EmployeeId = slotDtm.Employee.Id;
                slot.Responsible = await Database.BllServices.GetEmployee(slotDtm.Responsible.Id);
                //slot.ResponsibleId = slotDtm.Responsible.Id;
                //slot.Country = await Database.BllServices.GetCountry(slotDtm.Country.Id);
                slot.CountryId = slotDtm.CountryId;
                //slot.Service = await Database.BllServices.GetService(slotDtm.Service.Id);
                slot.ServiceId = slotDtm.ServiceId;
                await Database.Slotes.Create(slot);
                return slot.Id;
            }
            catch { return 0; }
        }

        public async Task<bool> Update(SlotDTM slotDtm)
        {
            try
            {
                Slot slot = new Slot();
                slot.Id = slotDtm.Id;
                slot.SlotDateTime = slotDtm.SlotDateTime /*?? DateTime.Now*/;
                slot.Duration = slotDtm.Duration;
                slot.IsPadding = slotDtm.IsPadding;
                slot.PaddingAfter = slotDtm.PaddingAfter;
                slot.Reiteration = slotDtm.Reiteration;
                slot.Price = slotDtm.Price;
                slot.Note = slotDtm.Note;
                slot.Status = slotDtm.Status;
                slot.IsTimeBlock = slotDtm.IsTimeBlock;
                slot.IsReminderNeeded = slotDtm.IsReminderNeeded;
                slot.ReminderInterval = slotDtm.ReminderInterval;

                slot.Employee = await Database.BllServices.GetEmployee(slotDtm.Employee.Id);// check here
                slot.Responsible = await Database.BllServices.GetEmployee(slotDtm.Responsible.Id);
                //slot.Country = await Database.BllServices.GetCountry(slotDtm.Country.Id);
                //slot.Service = await Database.BllServices.GetService(slotDtm.Service.Id);
                slot.CountryId = slotDtm.CountryId;
                slot.ServiceId = slotDtm.ServiceId;

                return await Database.Slotes.Update(slot) ? true : false;
            }
            catch (Exception ex) { Console.Out.WriteLine(ex.Message); return false; }
        }

        public async Task<bool> Delete(int id)
        {
            try
            {
                await Database.Slotes.Delete(id);
                return true;
            }
            catch { return false; }
        }
        public void Dispose()
        {
            Database.Dispose();
        }

        public SlotDTM SlotToSlotDtmMap(Slot slot)
        {
            SlotDTM slotDtm = new SlotDTM();
            slotDtm.Id = slot.Id;
            slotDtm.SlotDateTime = slot.SlotDateTime;
            slotDtm.Duration = slot.Duration;
            slotDtm.IsPadding = slot.IsPadding;
            slotDtm.PaddingAfter = slot.PaddingAfter;
            slotDtm.Reiteration = slot.Reiteration;
            slotDtm.Price = slot.Price;
            slotDtm.Note = slot.Note;
            slotDtm.Status = slot.Status;
            slotDtm.IsTimeBlock = slot.IsTimeBlock;
            slotDtm.IsReminderNeeded = slot.IsReminderNeeded;
            slotDtm.ReminderInterval = slot.ReminderInterval;

            slotDtm.EmployeeId = slot.EmployeeId;
            slotDtm.ResponsibleId = slot.ResponsibleId;
            slotDtm.CountryId = slot.CountryId;
            slotDtm.ServiceId = slot.ServiceId;
            return slotDtm;
        }


    }
}
