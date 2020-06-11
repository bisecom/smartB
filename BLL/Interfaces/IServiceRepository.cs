using BLL.Utils;
using smart_booking.BLL.DataTransferModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface IServiceRepository<T> where T : class
    {
        Task<List<T>> GetAll(SearchParams search);
        Task <T> Get(int id);
        IQueryable<T> Find(Func<T, Boolean> predicate);
        Task<int> Create(T item);
        Task<bool> Update(T item);
        Task<bool> Delete(int id);
    }
}
