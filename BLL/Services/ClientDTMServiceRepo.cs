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
    public class ClientDTMServiceRepo : IServiceRepository<ClientDTM>
    {
        IUnitOfWork Database { get; set; }

        public ClientDTMServiceRepo(IUnitOfWork uow)
        {
            Database = uow;
        }

        public async Task<List<ClientDTM>> GetAll(SearchParams search)
        {
            IQueryable<Client> clientQuery = Database.Clients.GetAll();
            List<Client> temp = clientQuery
            .Where(t => t.BusinessId == search.BusinessId)
            .ToList();
            List<ClientDTM> tempList = new List<ClientDTM>();

            if (temp != null)
                foreach (var c in temp)
                {
                    tempList.Add(ModelFactory.changeToDTM(c));
                }

            return tempList;
        }

        public async Task<ClientDTM> Get(int id)
        {
            int firstClientId = 1;
            if (id < firstClientId)
                throw new ValidationException("Client id is not specified correctly", "");
            var client = await Database.Clients.Get(id);
            if (client == null)
                throw new ValidationException("Client is not found", "");

            ClientDTM clientDTM = ModelFactory.changeToDTM(client);
            return clientDTM;
        }

        public IQueryable<ClientDTM> Find(Func<ClientDTM, bool> predicate)
        {
            throw new NotImplementedException();
        }

        public async Task<int> Create(ClientDTM clientDtm)
        {
            try
            {
                Client client = ModelFactory.changeFromDTM(clientDtm);

                await Database.Clients.Create(client);
                return client.Id;
            }
            catch { return 0; }
        }

        public async Task<bool> Update(ClientDTM clientDtm)
        {
            try
            {
                Client client = ModelFactory.changeFromDTM(clientDtm);

                return await Database.Clients.Update(client) ? true : false;
            }
            catch (Exception ex) { Console.Out.WriteLine(ex.Message); return false; }
        }

        public async Task<bool> Delete(int id)
        {
            try
            {
                await Database.Clients.Delete(id);
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
