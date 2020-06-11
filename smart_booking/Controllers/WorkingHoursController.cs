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
    public class WorkingHoursController : BaseApiController
    {
        public WorkingHoursController(IUnitOfWorkService repo)
            : base(repo) { }

        // GET: api/WorkingHours/1
        public async Task<HttpResponseMessage> Get(int id)
        {
            try
            {
                var wHours = await TheRepo.WorkingHoursDTM.Get(id);
                if (wHours != null)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, wHours);
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

        // PUT: api/WorkingHours/workingHoursDTM
        [HttpPatch]
        [HttpPut]
        public async Task<HttpResponseMessage> Put([FromBody]WorkingHourDTM wHoursDtm)
        {
            try
            {
                var originalWHours = TheRepo.WorkingHoursDTM.Get(wHoursDtm.EmployeeId);

                if (originalWHours == null)
                {
                    return Request.CreateResponse(HttpStatusCode.NotModified, "Item is not found");
                }
                else
                {
                    await TheRepo.WorkingHoursDTM.Update(wHoursDtm);
                    return Request.CreateResponse(HttpStatusCode.OK, wHoursDtm);
                }
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }
        }

    }

}
