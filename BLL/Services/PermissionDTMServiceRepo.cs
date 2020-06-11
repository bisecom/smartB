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
    public class PermissionDTMServiceRepo : IServiceRepository<PermissionDTM>
    {
        IUnitOfWork Database { get; set; }

        public PermissionDTMServiceRepo(IUnitOfWork uow)
        {
            Database = uow;
        }

        public Task<List<PermissionDTM>> GetAll(SearchParams search)
        {
            throw new NotImplementedException();
        }

        public async Task<PermissionDTM> Get(int id)
        {
            int firstPermissionId = 1;
            if (id < firstPermissionId)
                throw new ValidationException("Permission id is not specified correctly", "");
            var permission = await Database.Permissions.Get(id);
            if (permission == null)
                throw new ValidationException("Permission is not found", "");

            PermissionDTM permissionDtm = PermissionToPermissionDtmMap(permission);
            return permissionDtm;
        }

        public IQueryable<PermissionDTM> Find(Func<PermissionDTM, bool> predicate)
        {
            throw new NotImplementedException();
        }

        public async Task<int> Create(PermissionDTM permissionDtm)
        {
            try
            {
                Permission permission = new Permission();
                permission.IsSummary = permissionDtm.IsSummary;
                permission.IsOthersCalendar = permissionDtm.IsOthersCalendar;
                permission.IsClients = permissionDtm.IsClients;
                permission.IsServices = permissionDtm.IsServices;
                permission.IsReports = permissionDtm.IsReports;
                permission.EmployeeId = permissionDtm.EmployeeId;

                permission.Employee = await Database.Employees.Get(permissionDtm.EmployeeId);
                await Database.Permissions.Create(permission);
                return permission.EmployeeId;
            }
            catch { return 0; }
        }

        public async Task<bool> Update(PermissionDTM permissionDtm)
        {
            try
            {
                Permission permission = new Permission();
                permission.EmployeeId = permissionDtm.EmployeeId;
                permission.IsSummary = permissionDtm.IsSummary;
                permission.IsOthersCalendar = permissionDtm.IsOthersCalendar;
                permission.IsClients = permissionDtm.IsClients;
                permission.IsServices = permissionDtm.IsServices;
                permission.IsReports = permissionDtm.IsReports;
                if(permissionDtm.Employee != null)
                permission.Employee = await Database.Employees.Get(permissionDtm.Employee.Id);

                await Database.Permissions.Update(permission);
                return true;
            }
            catch (Exception ex) { Console.Out.WriteLine(ex.Message); return false; }
        }

        public async Task<bool> Delete(int id)
        {
            try
            {
                await Database.Permissions.Delete(id);
                return true;
            }
            catch { return false; }
        }

        public PermissionDTM PermissionToPermissionDtmMap(Permission permission)
        {
            PermissionDTM permissionDtm = new PermissionDTM();
            permissionDtm.EmployeeId = permission.EmployeeId;
            permissionDtm.IsSummary = permission.IsSummary;
            permissionDtm.IsOthersCalendar = permission.IsOthersCalendar;
            permissionDtm.IsClients = permission.IsClients;
            permissionDtm.IsServices = permission.IsServices;
            permissionDtm.IsReports = permission.IsReports;
            return permissionDtm;
        }
        public void Dispose()
        {
            Database.Dispose();
        }
    }
}
