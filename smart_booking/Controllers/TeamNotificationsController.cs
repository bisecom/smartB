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
    public class TeamNotificationsController : BaseApiController
    {
        public TeamNotificationsController(IUnitOfWorkService repo)
            : base(repo) { }

        // GET: api/TeamNotifications/1
        public async Task<HttpResponseMessage> Get(int id)
        {
            try
            {
                var notification = await TheRepo.TeamNotificationsDTM.Get(id);
                if (notification != null)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, notification);
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

        // PUT: api/TeamNotifications/notificationDtm
        [HttpPatch]
        [HttpPut]
        public async Task<HttpResponseMessage> Put([FromBody]TeamNotificationDTM notificationDtm)
        {
            try
            {
                var originalTNotification = TheRepo.TeamNotificationsDTM.Get(notificationDtm.EmployeeId);

                if (originalTNotification == null)
                {
                    return Request.CreateResponse(HttpStatusCode.NotModified, "Item is not found");
                }
                else
                {
                    await TheRepo.TeamNotificationsDTM.Update(notificationDtm);
                    return Request.CreateResponse(HttpStatusCode.OK, notificationDtm);
                }
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }
        }

        // DELETE: api/TeamNotifications/1
        public async Task<HttpResponseMessage> Delete(int id)
        {
            try
            {
                var originalTNotification = TheRepo.TeamNotificationsDTM.Get(id);
                if (originalTNotification == null)
                {
                    return Request.CreateResponse(HttpStatusCode.NotFound);
                }
                else
                {
                    TheRepo.TeamNotificationsDTM.Delete(id);
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
