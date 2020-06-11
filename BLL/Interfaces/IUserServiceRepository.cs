using BLL.Utils;
using smart_booking.BLL.DataTransferModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface IUserServiceRepository
    {
        Task<List<UserDTM>> GetAll(SearchParams search);
        Task <UserDTM> Get(string id);
        IQueryable<UserDTM> Find(Func<UserDTM, Boolean> predicate);
        Task<bool> Create(UserDTM item);
        void Update(UserDTM item);
        Task<bool> Delete(string id);
    }
}
