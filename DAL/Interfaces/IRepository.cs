using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface IRepository<T> where T : class
    {
        IQueryable<T> GetAll();
        Task<T> Get(int id);
        IQueryable<T> Find(Func<T, Boolean> predicate);
        Task<bool> Create(T item);
        Task<bool> Update(T item);
        Task<bool> Delete(int id);
    }
}
