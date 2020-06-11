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
    public class EmployeesController : BaseApiController
    {
        public EmployeesController(IUnitOfWorkService repo)
            : base(repo) { }

        // POST: Employees/employeesDTM
        public async Task<HttpResponseMessage> Post([FromBody] EmployeeDTM employeeDTM)
        {
            try
            {
                int id = await TheRepo.EmployeesDTM.Create(employeeDTM);
                return Request.CreateResponse(HttpStatusCode.Created, id);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }
        }

        // GET: Employees/1
        public async Task<HttpResponseMessage> Get(int id)
        {
            try
            {
                var employee = await TheRepo.EmployeesDTM.Get(id);
                if (employee != null)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, employee);
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

        // GET: Employees
        public async Task<List<EmployeeDTM>> Get(SearchParams mSearch)
        {
            List<EmployeeDTM> query = await TheRepo.EmployeesDTM.GetAll(mSearch);
            return query;
        }

        // PUT: Employees/businessDTM
        [HttpPatch]
        [HttpPut]
        public async Task<HttpResponseMessage> Put([FromBody]EmployeeDTM employeeDTM)
        {
            try
            {
                var originalEmployee = TheRepo.EmployeesDTM.Get(employeeDTM.Id);

                if (originalEmployee == null)
                {
                    return Request.CreateResponse(HttpStatusCode.NotModified, "Item is not found");
                }
                else
                {
                    await TheRepo.EmployeesDTM.Update(employeeDTM);
                    return Request.CreateResponse(HttpStatusCode.OK, employeeDTM);
                }
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }
        }

        // DELETE: Employees/1
        public async Task<HttpResponseMessage> Delete(int id)
        {
            try
            {
                var employee = TheRepo.EmployeesDTM.Get(id);
                if (employee == null)
                {
                    return Request.CreateResponse(HttpStatusCode.NotFound);
                }
                else
                {
                    await TheRepo.EmployeesDTM.Delete(id);
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
