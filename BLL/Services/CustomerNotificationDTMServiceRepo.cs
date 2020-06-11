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
    public class CustomerNotificationDTMServiceRepo : IServiceRepository<CustomerNotificationDTM>
    {
        IUnitOfWork Database { get; set; }

        public CustomerNotificationDTMServiceRepo(IUnitOfWork uow)
        {
            Database = uow;
        }

        public Task<List<CustomerNotificationDTM>> GetAll(SearchParams search)
        {
            throw new NotImplementedException();
        }

        public async Task<CustomerNotificationDTM> Get(int id)
        {
            int firstNotificationId = 1;
            if (id < firstNotificationId)
                throw new ValidationException("firstNotificationId id is not specified correctly", "");
            var notification = await Database.CustomerNotifications.Get(id);
            if (notification == null)
                throw new ValidationException("firstNotificationId is not found", "");

            CustomerNotificationDTM notificationDtm = CNotificationToCNotificationDtmMap(notification);
            return notificationDtm;
        }

        public IQueryable<CustomerNotificationDTM> Find(Func<CustomerNotificationDTM, bool> predicate)
        {
            throw new NotImplementedException();
        }

        public async Task<int> Create(CustomerNotificationDTM cNotificationDtm)
        {
            try
            {
                CustomerNotification customerNotification = new CustomerNotification();
                customerNotification.AfterBooked = cNotificationDtm.AfterBooked;
                customerNotification.AfterRescheduled = cNotificationDtm.AfterRescheduled;
                customerNotification.AfterCancelled = cNotificationDtm.AfterCancelled;

                customerNotification.Employee = await Database.Employees.Get(cNotificationDtm.EmployeeId);
                await Database.CustomerNotifications.Create(customerNotification);
                return customerNotification.EmployeeId;
            }
            catch { return 0; }
        }

        public async Task<bool> Update(CustomerNotificationDTM cNotificationDtm)
        {
            try
            {
                CustomerNotification customerNotification = new CustomerNotification();
                customerNotification.EmployeeId = cNotificationDtm.EmployeeId;
                customerNotification.AfterBooked = cNotificationDtm.AfterBooked;
                customerNotification.AfterRescheduled = cNotificationDtm.AfterRescheduled;
                customerNotification.AfterCancelled = cNotificationDtm.AfterCancelled;
                if(cNotificationDtm.Employee != null)
                customerNotification.Employee = ModelFactory.changeFromDTM(cNotificationDtm.Employee);

                return await Database.CustomerNotifications.Update(customerNotification) ? true : false;
            }
            catch (Exception ex) { Console.Out.WriteLine(ex.Message); return false; }
        }

        public async Task<bool> Delete(int id)
        {
            try
            {
                await Database.CustomerNotifications.Delete(id);
                return true;
            }
            catch { return false; }
        }

        public CustomerNotificationDTM CNotificationToCNotificationDtmMap(CustomerNotification cNotification)
        {
            CustomerNotificationDTM customerNotificationDTM = new CustomerNotificationDTM();
            customerNotificationDTM.EmployeeId = cNotification.EmployeeId;
            customerNotificationDTM.AfterBooked = cNotification.AfterBooked;
            customerNotificationDTM.AfterRescheduled = cNotification.AfterRescheduled;
            customerNotificationDTM.AfterCancelled = cNotification.AfterCancelled;
            return customerNotificationDTM;
        }
        public void Dispose()
        {
            Database.Dispose();
        }
    }
}
