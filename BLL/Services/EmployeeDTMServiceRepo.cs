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
    class EmployeeDTMServiceRepo : IEmployeeServiceRepository
    {
        IUnitOfWork Database { get; set; }

        public EmployeeDTMServiceRepo(IUnitOfWork uow)
        {
            Database = uow;
        }

        public async Task<List<EmployeeDTM>> GetAll(SearchParams search)
        {
            IQueryable<Employee> employeeQuery = Database.Employees.GetAll();
            List<Employee> temp = employeeQuery
            .Where(t => t.BusinessId == search.BusinessId)
            .ToList();
            List<EmployeeDTM> tempList = new List<EmployeeDTM>();

            if (temp != null)
                foreach (var e in temp)
                {
                    tempList.Add(ModelFactory.changeToDTM(e));
                }

            return tempList;
        }

        public async Task<EmployeeDTM> Get(int id)
        {
            int firstEmployeeId = 1;
            if (id < firstEmployeeId)
                throw new ValidationException("Employee id is not specified correctly", "");
            var employee = await Database.Employees.Get(id);
            if (employee == null)
                throw new ValidationException("Employee is not found", "");

            EmployeeDTM employeeDTM = ModelFactory.changeToDTM(employee);
            return employeeDTM;
        }

        public IQueryable<EmployeeDTM> Find(Func<EmployeeDTM, bool> predicate)
        {
            throw new NotImplementedException();
        }

        public async Task<int> Create(EmployeeDTM item)
        {
            try
            {
                Employee employee = new Employee();
                employee.Business = await Database.Businesses.Get(item.Business.Id);
                employee.BusinessId = item.Business.Id;
                employee.User = await Database.Users.Get(item.User.Id);
                employee.UserId = item.User.Id;
                employee.IsOwner = item.IsOwner;

                await Database.Employees.Create(employee);

                if (employee.IsOwner == false)
                {
                    WorkingHour wHourDtm = new WorkingHour();
                    wHourDtm.Employee = employee;
                    wHourDtm.EmployeeId = employee.Id;
                    await Database.WorkingHours.Create(wHourDtm);

                    Permission perm = new Permission();
                    perm.Employee = employee;
                    perm.EmployeeId = employee.Id;
                    await Database.Permissions.Create(perm);

                    CalendarSetting cSetting = new CalendarSetting();
                    cSetting.Employee = employee;
                    cSetting.EmployeeId = employee.Id;
                    await Database.CalendarSettings.Create(cSetting);

                    CustomerNotification cNotif = new CustomerNotification();
                    cNotif.Employee = employee;
                    cNotif.EmployeeId = employee.Id;
                    await Database.CustomerNotifications.Create(cNotif);

                    TeamNotification tNotif = new TeamNotification();
                    tNotif.Employee = employee;
                    tNotif.EmployeeId = employee.Id;
                    await Database.TeamNotifications.Create(tNotif);
                }

                return employee.Id;
            }
            catch { return 0; }
        }

        public async Task<bool> Update(EmployeeDTM employeeDtm)
        {
            try
            {
                Employee employee = new Employee();
                employee.Id = employeeDtm.Id;

                if (employeeDtm.CalendarSetting != null)
                {
                    employee.CalendarSetting = ModelFactory.changeFromDTM(employeeDtm.CalendarSetting);
                }
                if (employeeDtm.CustomerNotification != null)
                {
                    employee.CustomerNotification = ModelFactory.changeFromDTM(employeeDtm.CustomerNotification);
                }
                if (employeeDtm.TeamNotification != null)
                {
                    employee.TeamNotification = ModelFactory.changeFromDTM(employeeDtm.TeamNotification);
                }
                if (employeeDtm.Permission != null)
                {
                    employee.Permission = ModelFactory.changeFromDTM(employeeDtm.Permission);
                }
                if (employeeDtm.WorkingHour != null)
                {
                    employee.WorkingHour = ModelFactory.changeFromDTM(employeeDtm.WorkingHour);
                }
                return await Database.Employees.Update(employee) ? true : false;
            }
            catch (Exception ex) { Console.Out.WriteLine(ex.Message); return false; }
        }

        public async Task<bool> Delete(int id)
        {
            try
            {
                await Database.CalendarSettings.Delete(id);
                await Database.CustomerNotifications.Delete(id);
                await Database.TeamNotifications.Delete(id);
                await Database.Permissions.Delete(id);
                await Database.WorkingHours.Delete(id);

                await Database.Employees.Delete(id);
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
