using BLL.Utils;
using smart_booking.BLL.DataTransferModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface ISlotServiceRepository
    {
        Task<List<SlotDTM>> GetAll(SearchParams search);
        Task<SlotDTM> Get(int id);
        IQueryable<SlotDTM> Find(Func<SlotDTM, Boolean> predicate);
        Task<int> Create(SlotDTM item);
        Task<bool> Update(SlotDTM item);
        Task<bool> Delete(int id);
    }
}
