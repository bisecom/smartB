using BLL.Interfaces;
using BLL.Utils;
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
    public class BusinessesController : BaseApiController
    {
        public BusinessesController(IUnitOfWorkService repo)
            : base(repo) {  }

        // POST: Businesses/businessDTM
        public async Task<HttpResponseMessage> Post([FromBody] BusinessDTM businessDtm)
        {
            try
            {
                int id = await TheRepo.BusinessesDTM.Create(businessDtm);
                return Request.CreateResponse(HttpStatusCode.Created, id);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }
        }

        // GET: Businesses/1
        public async Task<HttpResponseMessage> Get(int id)
        {
            try
            {
                var business = await TheRepo.BusinessesDTM.Get(id);
                if (business != null)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, business);
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
        // GET: Businesses
        public async Task<List<BusinessDTM>> Get(SearchParams mSearch)
        {
            List<BusinessDTM> query = await TheRepo.BusinessesDTM.GetAll(mSearch);
            return query;
        }

        // PUT: Businesses/businessDTM
        [HttpPatch]
        [HttpPut]
        public async Task<HttpResponseMessage> Put([FromBody]BusinessDTM businessDtm)
        {
            try
            {
                var originalBusiness = TheRepo.BusinessesDTM.Get(businessDtm.Id);

                if (originalBusiness == null)
                {
                    return Request.CreateResponse(HttpStatusCode.NotModified, "Item is not found");
                }
                else
                {
                    await TheRepo.BusinessesDTM.Update(businessDtm);
                    return Request.CreateResponse(HttpStatusCode.OK, businessDtm);
                }
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }
        }

        // DELETE: Businesses/1
        public async Task<HttpResponseMessage> Delete(int id)
        {
            try
            {
                var business = TheRepo.BusinessesDTM.Get(id);
                if (business == null)
                {
                    return Request.CreateResponse(HttpStatusCode.NotFound);
                }
                else
                {
                    TheRepo.BusinessesDTM.Delete(id);
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
