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
    public class SlotsController : BaseApiController
    {
        public SlotsController(IUnitOfWorkService repo)
            : base(repo) { }

        // POST: /Slots/slotDTM
        public async Task<HttpResponseMessage> Post([FromBody] SlotDTM slotDtm)
        {
            try
            {
                int id = await TheRepo.SlotesDTM.Create(slotDtm);
                return Request.CreateResponse(HttpStatusCode.Created, id);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }
        }

        // PUT: /Slots/slotDTM
        [HttpPatch]
        [HttpPut]
        public HttpResponseMessage Put([FromBody]SlotDTM slotDtm)
        {
            try
            {
                var originalSlot = TheRepo.SlotesDTM.Get(slotDtm.Id);
                if (originalSlot == null)
                {
                    return Request.CreateResponse(HttpStatusCode.NotModified, "Slot is not found");
                }
                else
                {
                    TheRepo.SlotesDTM.Update(slotDtm);
                    return Request.CreateResponse(HttpStatusCode.OK, slotDtm);
                }
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }
        }

        // DELETE: /Slots/1
        public async Task<HttpResponseMessage> Delete(int id)
        {
            try
            {
                var slot = TheRepo.SlotesDTM.Get(id);
                if (slot == null)
                {
                    return Request.CreateResponse(HttpStatusCode.NotFound);
                }
                else
                {
                    TheRepo.SlotesDTM.Delete(id);
                    return Request.CreateResponse(HttpStatusCode.OK);
                }
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }

        // GET: /Slots/1
        public async Task<HttpResponseMessage> Get(int id)
        {
            try
            {
                var slot = await TheRepo.SlotesDTM.Get(id);
                if (slot != null)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, slot);
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

        // GET: /Slots/mSearch
        public async Task<List<SlotDTM>> Get([FromBody]SearchParams mSearch)
        {
            List<SlotDTM> query = await TheRepo.SlotesDTM.GetAll(mSearch);
            return query;
        }

    }
}
