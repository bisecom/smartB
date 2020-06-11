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
    public class CustomerNotificationsController : BaseApiController
    {
        public CustomerNotificationsController(IUnitOfWorkService repo)
            : base(repo) { }

        // GET: api/CustomerNotifications/1
        public async Task<HttpResponseMessage> Get(int id)
        {
            try
            {
                var cNotifications = await TheRepo.CustomerNotificationsDTM.Get(id);
                if (cNotifications != null)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, cNotifications);
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

        // PUT: api/CustomerNotifications/cNotifications
        [HttpPatch]
        [HttpPut]
        public async Task<HttpResponseMessage> Put([FromBody]CustomerNotificationDTM cNotificationDtm)
        {
            try
            {
                var originalCNotification = TheRepo.CustomerNotificationsDTM.Get(cNotificationDtm.EmployeeId);

                if (originalCNotification == null)
                {
                    return Request.CreateResponse(HttpStatusCode.NotModified, "Item is not found");
                }
                else
                {
                    await TheRepo.CustomerNotificationsDTM.Update(cNotificationDtm);
                    return Request.CreateResponse(HttpStatusCode.OK, cNotificationDtm);
                }
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }
        }

        // DELETE: api/CustomerNotifications/1
        public async Task<HttpResponseMessage> Delete(int id)
        {
            try
            {
                var originalNotification = TheRepo.CustomerNotificationsDTM.Get(id);
                if (originalNotification == null)
                {
                    return Request.CreateResponse(HttpStatusCode.NotFound);
                }
                else
                {
                    TheRepo.CustomerNotificationsDTM.Delete(id);
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
