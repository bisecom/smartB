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
    public class BookingsController : BaseApiController
    {
        public BookingsController(IUnitOfWorkService repo)
            : base(repo) { }


        // GET: Bookings/1
        public async Task<HttpResponseMessage> Get(int id)
        {
            try
            {
                var booking = await TheRepo.BookingsDTM.Get(id);
                if (booking != null)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, booking);
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

        // POST: Bookings/bookingDtm
        public async Task<HttpResponseMessage> Post([FromBody] BookingDTM bookingDtm)
        {
            try
            {
                int id = await TheRepo.BookingsDTM.Create(bookingDtm);
                return Request.CreateResponse(HttpStatusCode.Created, id);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }
        }

        // PUT: Bookings/bookingDtm
        [HttpPatch]
        [HttpPut]
        public async Task<HttpResponseMessage> Put([FromBody]BookingDTM bookingDtm)
        {
            try
            {
                var originalBooking = TheRepo.BookingsDTM.Get(bookingDtm.BusinessId);

                if (originalBooking == null)
                {
                    return Request.CreateResponse(HttpStatusCode.NotModified, "Item is not found");
                }
                else
                {
                    await TheRepo.BookingsDTM.Update(bookingDtm);
                    return Request.CreateResponse(HttpStatusCode.OK, bookingDtm);
                }
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }
        }

        // DELETE: Bookings/1
        public async Task<HttpResponseMessage> Delete(int id)
        {
            try
            {
                var originalBooking = TheRepo.BookingsDTM.Get(id);
                if (originalBooking == null)
                {
                    return Request.CreateResponse(HttpStatusCode.NotFound);
                }
                else
                {
                    TheRepo.BookingsDTM.Delete(id);
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
