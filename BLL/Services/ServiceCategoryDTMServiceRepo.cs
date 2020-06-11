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
    public class ServiceCategoryDTMServiceRepo : IServiceRepository<ServiceCategoryDTM>
    {
        IUnitOfWork Database { get; set; }

        public ServiceCategoryDTMServiceRepo(IUnitOfWork uow)
        {
            Database = uow;
        }

        public async Task<List<ServiceCategoryDTM>> GetAll(SearchParams search)
        {
            //IQueryable<ServiceCategory> sCategoriesQuery = Database.ServiceCategories.GetAll()
            //    .Where(s => s.;
            //List<ServiceCategory> temp = sCategoriesQuery
            //.ToList();
            //List<ServiceCategoryDTM> tempList = new List<ServiceCategoryDTM>();

            //if (temp != null)
            //    foreach (var s in temp)
            //    {
            //        tempList.Add(new ServiceCategoryDTM { Id = s.Id, Name = s.Name});
            //    }

            //return tempList;
            return null;
        }

        public async Task<ServiceCategoryDTM> Get(int id)
        {
            int firstSCategoryId = 1;
            if (id < firstSCategoryId)
                throw new ValidationException("ServiceCategory id is not specified correctly", "");
            var sCategory = await Database.ServiceCategories.Get(id);
            if (sCategory == null)
                throw new ValidationException("ServiceCategory is not found", "");

            ServiceCategoryDTM sCategoryDtm = new ServiceCategoryDTM();
            sCategoryDtm.Id = sCategory.Id;
            sCategoryDtm.Name = sCategory.Name;
            sCategoryDtm.BusinessId = sCategory.BusinessId;
            sCategoryDtm.Business = ModelFactory.changeToDTM(sCategory.Business);

            return sCategoryDtm;
        }

        public IQueryable<ServiceCategoryDTM> Find(Func<ServiceCategoryDTM, bool> predicate)
        {
            throw new NotImplementedException();
        }

        public async Task<int> Create(ServiceCategoryDTM sCategoryDtm)
        {
            try
            {
                ServiceCategory sCategory = new ServiceCategory();
                sCategory.Name = sCategoryDtm.Name;
                sCategory.BusinessId = sCategoryDtm.BusinessId;
                sCategory.Business = ModelFactory.changeFromDTM(sCategoryDtm.Business);
                await Database.ServiceCategories.Create(sCategory);
                return sCategory.Id;
            }
            catch { return 0; }
        }

        public Task<bool> Update(ServiceCategoryDTM item)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> Delete(int id)
        {
            try
            {
                await Database.ServiceCategories.Delete(id);
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
