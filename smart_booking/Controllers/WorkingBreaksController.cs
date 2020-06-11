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
    public class WorkingBreaksController : BaseApiController
    {
        public WorkingBreaksController(IUnitOfWorkService repo)
            : base(repo) { }

        // POST: api/WorkingBreaks/workingBreaksDTM
        public async Task<HttpResponseMessage> Post([FromBody] WorkingBreakDTM workingBreakDtm)
        {
            try
            {
                int id = await TheRepo.WorkingBreaksDTM.Create(workingBreakDtm);
                return Request.CreateResponse(HttpStatusCode.Created, id);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }
        }

        // GET: api/WorkingBreaks/1
        public async Task<HttpResponseMessage> Get(int id)
        {
            try
            {
                var wBreaks = await TheRepo.WorkingBreaksDTM.Get(id);
                if (wBreaks != null)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, wBreaks);
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

        // GET: api/WorkingBreaks
        public async Task<List<WorkingBreakDTM>> Get(SearchParams mSearch)
        {
            List<WorkingBreakDTM> query = await TheRepo.WorkingBreaksDTM.GetAll(mSearch);
            return query;
        }

        // PUT: api/WorkingBreaks/workingBreaksDTM
        [HttpPatch]
        [HttpPut]
        public async Task<HttpResponseMessage> Put([FromBody]WorkingBreakDTM workingBreakDtm)
        {
            try
            {
                var originalWBreak = TheRepo.BusinessesDTM.Get(workingBreakDtm.Id);

                if (originalWBreak == null)
                {
                    return Request.CreateResponse(HttpStatusCode.NotModified, "Item is not found");
                }
                else
                {
                    await TheRepo.WorkingBreaksDTM.Update(workingBreakDtm);
                    return Request.CreateResponse(HttpStatusCode.OK, workingBreakDtm);
                }
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }
        }

        // DELETE: api/WorkingBreaks/1
        public async Task<HttpResponseMessage> Delete(int id)
        {
            try
            {
                var wBreak = TheRepo.WorkingBreaksDTM.Get(id);
                if (wBreak == null)
                {
                    return Request.CreateResponse(HttpStatusCode.NotFound);
                }
                else
                {
                    TheRepo.WorkingBreaksDTM.Delete(id);
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
