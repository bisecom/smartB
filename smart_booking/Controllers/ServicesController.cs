using BLL.Interfaces;
using smart_booking.BLL.DataTransferModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace smart_booking.Controllers
{
    public class ServicesController : BaseApiController
    {
        public ServicesController(IUnitOfWorkService repo)
            : base(repo) { }

        // GET: api/Services/1
        public async Task<HttpResponseMessage> Get(int id)
        {
            try
            {
                var service = await TheRepo.ServicesDTM.Get(id);
                if (service != null)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, service);
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.NotFound);
                }
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }
        }

        // POST: api/Services/serviceDtm
        public async Task<HttpResponseMessage> Post([FromBody] ServiceDTM serviceDtm)
        {
            try
            {
                int id = await TheRepo.ServicesDTM.Create(serviceDtm);
                return Request.CreateResponse(HttpStatusCode.Created, id);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }
        }

        // PUT: api/Services/serviceDtm
        [HttpPatch]
        [HttpPut]
        public async Task<HttpResponseMessage> Put([FromBody]ServiceDTM serviceDtm)
        {
            try
            {
                var originalService = TheRepo.ServicesDTM.Get(serviceDtm.Id);

                if (originalService == null)
                {
                    return Request.CreateResponse(HttpStatusCode.NotModified, "Item is not found");
                }
                else
                {
                    await TheRepo.ServicesDTM.Update(serviceDtm);
                    return Request.CreateResponse(HttpStatusCode.OK, serviceDtm);
                }
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }
        }

        // DELETE: api/Services/1
        public async Task<HttpResponseMessage> Delete(int id)
        {
            try
            {
                var originalService = TheRepo.ServicesDTM.Get(id);
                if (originalService == null)
                {
                    return Request.CreateResponse(HttpStatusCode.NotFound);
                }
                else
                {
                    await TheRepo.ServicesDTM.Delete(id);
                    return Request.CreateResponse(HttpStatusCode.OK);
                }
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }
    }
}
