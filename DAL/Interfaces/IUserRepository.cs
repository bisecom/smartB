using smart_booking.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface IUserRepository
    {
        IQueryable<User> GetAll();
        Task<User> Get(string id);
        IQueryable<User> Find(Func<User, Boolean> predicate);
        Task<bool> Create(User item);
        Task<bool> Update(User item);
        Task<bool> Delete(string id);
    }
}
