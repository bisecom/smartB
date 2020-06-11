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
    public class BookingDTMServiceRepo : IServiceRepository<BookingDTM>
    {
        IUnitOfWork Database { get; set; }

        public BookingDTMServiceRepo(IUnitOfWork uow)
        {
            Database = uow;
        }

        public Task<List<BookingDTM>> GetAll(SearchParams search)
        {
            throw new NotImplementedException();
        }

        public async Task<BookingDTM> Get(int id)
        {
            int firstBookingId = 1;
            if (id < firstBookingId)
                throw new ValidationException("Booking id is not specified correctly", "");
            var booking = await Database.Bookings.Get(id);
            if (booking == null)
                throw new ValidationException("Booking is not found", "");

            BookingDTM bDtm = ModelFactory.changeToDTM(booking);
            return bDtm;
        }

        public IQueryable<BookingDTM> Find(Func<BookingDTM, bool> predicate)
        {
            throw new NotImplementedException();
        }

        public async Task<int>Create(BookingDTM item)
        {
            try
            {
                var booking = ModelFactory.changeFromDTM(item);
                await Database.Bookings.Create(booking);
                return booking.BusinessId;
            }
            catch { return 0; }
        }

        public async Task<bool> Update(BookingDTM item)
        {
            try
            {
                var booking = ModelFactory.changeFromDTM(item);
                return await Database.Bookings.Update(booking) ? true : false;
            }
            catch (Exception ex) { Console.Out.WriteLine(ex.Message); return false; }
        }

        public async Task<bool> Delete(int id)
        {
            try
            {
                await Database.Bookings.Delete(id);
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
