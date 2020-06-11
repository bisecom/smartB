using BLL.Utils;
using smart_booking.BLL.DataTransferModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface IEmployeeServiceRepository
    {
        Task<List<EmployeeDTM>> GetAll(SearchParams search);
        Task<EmployeeDTM> Get(int id);
        IQueryable<EmployeeDTM> Find(Func<EmployeeDTM, Boolean> predicate);
        Task<int> Create(EmployeeDTM item);
        Task<bool> Update(EmployeeDTM item);
        Task<bool> Delete(int id);
    }
}
