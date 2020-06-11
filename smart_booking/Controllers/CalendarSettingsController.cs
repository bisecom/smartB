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
    public class CalendarSettingsController : BaseApiController
    {
        public CalendarSettingsController(IUnitOfWorkService repo)
            : base(repo) { }

        // GET: CalendarSettings/1
        public async Task<HttpResponseMessage> Get(int id)
        {
            try
            {
                var cSetting = await TheRepo.CalendarSettingsDTM.Get(id);
                if (cSetting != null)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, cSetting);
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

        // PUT: CalendarSettings/cSettingsDtm
        [HttpPatch]
        [HttpPut]
        public async Task<HttpResponseMessage> Put([FromBody]CalendarSettingDTM cSettingsDtm)
        {
            try
            {
                var originalSetting = TheRepo.CalendarSettingsDTM.Get(cSettingsDtm.EmployeeId);

                if (originalSetting == null)
                {
                    return Request.CreateResponse(HttpStatusCode.NotModified, "Item is not found");
                }
                else
                {
                    await TheRepo.CalendarSettingsDTM.Update(cSettingsDtm);
                    return Request.CreateResponse(HttpStatusCode.OK, cSettingsDtm);
                }
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }
        }

        // DELETE: CalendarSettings/1
        public async Task<HttpResponseMessage> Delete(int id)
        {
            try
            {
                var originalSetting = TheRepo.CalendarSettingsDTM.Get(id);
                if (originalSetting == null)
                {
                    return Request.CreateResponse(HttpStatusCode.NotFound);
                }
                else
                {
                    TheRepo.CalendarSettingsDTM.Delete(id);
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
