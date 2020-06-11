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
    public class ServiceCategoriesController : BaseApiController
    {
        public ServiceCategoriesController(IUnitOfWorkService repo)
            : base(repo) { }

        // GET: /ServiceCategories/1
        public async Task<HttpResponseMessage> Get(int id)
        {
            try
            {
                var sCategory = await TheRepo.ServiceCategoriesDTM.Get(id);
                if (sCategory != null)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, sCategory);
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

        // POST: /ServiceCategories/sCategoryDtm
        public async Task<HttpResponseMessage> Post([FromBody] ServiceCategoryDTM sCategoryDtm)
        {
            try
            {
                int id = await TheRepo.ServiceCategoriesDTM.Create(sCategoryDtm);
                return Request.CreateResponse(HttpStatusCode.Created, id);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }
        }

        // DELETE: /ServiceCategories/1
        public async Task<HttpResponseMessage> Delete(int id)
        {
            try
            {
                var originalSCategory = TheRepo.ServiceCategoriesDTM.Get(id);
                if (originalSCategory == null)
                {
                    return Request.CreateResponse(HttpStatusCode.NotFound);
                }
                else
                {
                    TheRepo.ServiceCategoriesDTM.Delete(id);
                    return Request.CreateResponse(HttpStatusCode.OK);
                }
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex.Message);
            }


        }

        // GET: /ServiceCategories/
        public async Task<List<ServiceCategoryDTM>> GetCategories([FromBody]SearchParams mSearch)
        {
            return await TheRepo.ServiceCategoriesDTM.GetAll(mSearch);
        }
    }
}