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
    class ServiceDTMServiceRepo : IServiceRepository<ServiceDTM>
    {
        IUnitOfWork Database { get; set; }

        public ServiceDTMServiceRepo(IUnitOfWork uow)
        {
            Database = uow;
        }

        public async Task<List<ServiceDTM>> GetAll(SearchParams search)
        {
            IQueryable<Service> servicesQuery = Database.Services.GetAll();
            var sCategoriesList = Database.ServiceCategories.GetAll()
                .Where(c => c.BusinessId == search.BusinessId).ToList();

            List<Service> tempServiceList = new List<Service>();
            List<ServiceDTM> tempServiceDtmList = new List<ServiceDTM>();
            foreach (var c in sCategoriesList)
            {
                tempServiceList.AddRange(servicesQuery
               .Where(t => t.ServiceCategoryId == c.Id)
               .ToList());
            }

            if (tempServiceList != null)
            foreach (var s in tempServiceList)
            {
                    tempServiceDtmList.Add(ModelFactory.changeToDTM(s));
            }

            return tempServiceDtmList;
        }

        public async Task<ServiceDTM> Get(int id)
        {
            int firstServiceId = 1;
            if (id < firstServiceId)
                throw new ValidationException("Service id is not specified correctly", "");
            var service = await Database.Services.Get(id);
            if (service == null)
                throw new ValidationException("Service is not found", "");

            ServiceDTM serviceDtm = ModelFactory.changeToDTM(service);
            return serviceDtm;
        }

        public IQueryable<ServiceDTM> Find(Func<ServiceDTM, bool> predicate)
        {
            throw new NotImplementedException();
        }

        public async Task<int> Create(ServiceDTM serviceDtm)
        {
            try
            {
                Service service = new Service();
                service.Name = serviceDtm.Name;
                service.Description = serviceDtm.Description;
                service.Price = serviceDtm.Price;
                service.Duration = serviceDtm.Duration;
                service.PaddingAfter = serviceDtm.PaddingAfter;
                service.Picture = serviceDtm.Picture;

                service.ServiceCategory = await Database.BllServices.ServiceCategory(serviceDtm.ServiceCategoryId);

                await Database.Services.Create(service);
                return service.Id;
            }
            catch { return 0; }
        }

        public async Task<bool> Update(ServiceDTM serviceDtm)
        {
            try
            {
                Service service = new Service();
                service.Id = serviceDtm.Id;
                service.Name = serviceDtm.Name;
                service.Description = serviceDtm.Description;
                service.Price = serviceDtm.Price;
                service.Duration = serviceDtm.Duration;
                service.PaddingAfter = serviceDtm.PaddingAfter;
                service.Picture = serviceDtm.Picture;
                
                if (serviceDtm.ServiceCategory != null)
                    service.ServiceCategory = ModelFactory.changeFromDTM(serviceDtm.ServiceCategory);

                bool isUpdated = await Database.Services.Update(service);

                if (isUpdated)  return true;
            }
            catch (Exception ex) { Console.Out.WriteLine(ex.Message);  }
            return false;
        }

        public async Task<bool> Delete(int id)
        {
            try
            {
                await Database.Services.Delete(id);
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
