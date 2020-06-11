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
    public class TeamNotificationDTMServiceRepo : IServiceRepository<TeamNotificationDTM>
    {
        IUnitOfWork Database { get; set; }

        public TeamNotificationDTMServiceRepo(IUnitOfWork uow)
        {
            Database = uow;
        }

        public async Task<List<TeamNotificationDTM>> GetAll(SearchParams search)
        {
            throw new NotImplementedException();
        }

        public async Task<TeamNotificationDTM> Get(int id)
        {
            int firstNotificationId = 1;
            if (id < firstNotificationId)
                throw new ValidationException("Notification id is not specified correctly", "");
            var notification = await Database.TeamNotifications.Get(id);
            if (notification == null)
                throw new ValidationException("Notification is not found", "");

            TeamNotificationDTM notificationDtm = TeamNotificationToTeamNotificationDtmMap(notification);
            return notificationDtm;
        }

        public IQueryable<TeamNotificationDTM> Find(Func<TeamNotificationDTM, bool> predicate)
        {
            throw new NotImplementedException();
        }

        public async Task<int> Create(TeamNotificationDTM tNotificationDtm)
        {
            try
            {
                TeamNotification tNotification = new TeamNotification();
                tNotification.AfterBooked = tNotificationDtm.AfterBooked;
                tNotification.AfterRescheduled = tNotificationDtm.AfterRescheduled;
                tNotification.Collegue = tNotificationDtm.Collegue;
                tNotification.CollegueAndOwner = tNotificationDtm.CollegueAndOwner;
                tNotification.Owner = tNotificationDtm.Owner;
                if(tNotificationDtm.Employee != null)
                tNotification.Employee = ModelFactory.changeFromDTM(tNotificationDtm.Employee);
                await Database.TeamNotifications.Create(tNotification);
                return tNotification.EmployeeId;
            }
            catch { return 0; }
        }

        public async Task<bool> Update(TeamNotificationDTM tNotificationDtm)
        {
            try
            {
                TeamNotification tNotification = new TeamNotification();
                tNotification.EmployeeId = tNotificationDtm.EmployeeId;
                tNotification.AfterBooked = tNotificationDtm.AfterBooked;
                tNotification.AfterRescheduled = tNotificationDtm.AfterRescheduled;
                tNotification.Collegue = tNotificationDtm.Collegue;
                tNotification.CollegueAndOwner = tNotificationDtm.CollegueAndOwner;
                tNotification.Owner = tNotificationDtm.Owner;

                tNotification.Employee = await Database.Employees.Get(tNotificationDtm.Employee.Id);

                return await Database.TeamNotifications.Update(tNotification) ? true : false;
            }
            catch (Exception ex) { Console.Out.WriteLine(ex.Message); return false; }
        }

        public async Task<bool> Delete(int id)
        {
            try
            {
                await Database.TeamNotifications.Delete(id);
                return true;
            }
            catch { return false; }
        }
        public TeamNotificationDTM TeamNotificationToTeamNotificationDtmMap(TeamNotification tNotification)
        {
            TeamNotificationDTM tNotificationDTM = new TeamNotificationDTM();
            tNotificationDTM.EmployeeId = tNotification.EmployeeId;
            tNotificationDTM.AfterBooked = tNotification.AfterBooked;
            tNotificationDTM.AfterRescheduled = tNotification.AfterRescheduled;
            tNotificationDTM.Collegue = tNotification.Collegue;
            tNotificationDTM.CollegueAndOwner = tNotification.CollegueAndOwner;
            tNotificationDTM.Owner = tNotification.Owner;
            return tNotificationDTM;
        }
        public void Dispose()
        {
            Database.Dispose();
        }
    }
}
