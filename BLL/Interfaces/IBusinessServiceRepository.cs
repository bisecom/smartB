using BLL.Utils;
using smart_booking.BLL.DataTransferModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface IBusinessServiceRepository
    {
        Task<List<BusinessDTM>> GetAll(SearchParams search);
        Task<BusinessDTM> Get(int id);
        IQueryable<BusinessDTM> Find(Func<BusinessDTM, Boolean> predicate);
        Task<int> Create(BusinessDTM item);
        Task<bool> Update(BusinessDTM item);
        Task<bool> Delete(int id);
    }
}
