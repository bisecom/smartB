using BLL.Interfaces;
using smart_booking.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace smart_booking.Controllers
{
    public class Time_zonesController : BaseApiController
    {
        public Time_zonesController(IUnitOfWorkService repo)
            : base(repo) { }

        public HttpResponseMessage Get(int id)
        {
            try
            {
                var zone = TheRepo.TimezonesDTM.Get(id);
                if (zone != null)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, zone);
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
    }
}
