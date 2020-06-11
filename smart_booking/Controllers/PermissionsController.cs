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
    public class PermissionsController : BaseApiController
    {
        public PermissionsController(IUnitOfWorkService repo)
            : base(repo) { }

        // GET: Permissions/1
        public async Task<HttpResponseMessage> Get(int id)
        {
            try
            {
                var permission = await TheRepo.PermissionsDTM.Get(id);
                if (permission != null)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, permission);
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


        // PUT: Permissions/permissionDtm
        [HttpPatch]
        [HttpPut]
        public async Task<HttpResponseMessage> Put([FromBody]PermissionDTM permissionDtm)
        {
            try
            {
                var originalPermission = TheRepo.PermissionsDTM.Get(permissionDtm.EmployeeId);

                if (originalPermission == null)
                {
                    return Request.CreateResponse(HttpStatusCode.NotModified, "Item is not found");
                }
                else
                {
                    await TheRepo.PermissionsDTM.Update(permissionDtm);
                    return Request.CreateResponse(HttpStatusCode.OK, permissionDtm);
                }
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }
        }

        // DELETE: Permissions/1
        public async Task<HttpResponseMessage> Delete(int id)
        {
            try
            {
                var originalPermission = TheRepo.PermissionsDTM.Get(id);
                if (originalPermission == null)
                {
                    return Request.CreateResponse(HttpStatusCode.NotFound);
                }
                else
                {
                    TheRepo.PermissionsDTM.Delete(id);
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
