using BLL.Interfaces;
using smart_booking.BLL.DataTransferModels;
using smart_booking.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace smart_booking.Controllers
{
    public class CountriesController : BaseApiController
    {
        public CountriesController(IUnitOfWorkService repo)
            : base(repo) { }

        // GET: api/Countries/1
        public HttpResponseMessage Get(int id)
        {
            //try
            //{
            //    var country = TheRepo.CountriesDTM.Get(id);
            //    if (country != null)
            //    {
            //        return Request.CreateResponse(HttpStatusCode.OK, country);
            //    }
            //    else
            //    {
            //        return Request.CreateResponse(HttpStatusCode.NotFound);
            //    }

            //}
            //catch (Exception ex)
            //{
            //    return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            //}

            

            return Request.CreateResponse(HttpStatusCode.OK, 1);
        }
        // POST: api/Countries/countryDtm
        public async Task<HttpResponseMessage> Post([FromBody] CountryDTM countryDtm)
        {
            try
            {
                int id = await TheRepo.CountriesDTM.Create(countryDtm);
                return Request.CreateResponse(HttpStatusCode.Created, id);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }
        }

        [AllowAnonymous]
        public IHttpActionResult Get()
        {
            SeedDbUponRequest seed = new SeedDbUponRequest();
            try
            {

                foreach (var country in seed.CountriesListDtm)
                {
                    TheRepo.CountriesDTM.Create(country);
                }

                foreach (var zone in seed.ZonesListDtm)
                {
                    TheRepo.TimezonesDTM.Create(zone);
                }

                foreach (var currency in seed.CurrenciesLidtDtm)
                {
                    TheRepo.CurrenciesDTM.Create(currency);
                }
                TheRepo.PageLanguagesDTM.Create(seed.PageLanguage);
                TheRepo.ServiceCategoriesDTM.Create(seed.ServCategory);
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }
            return Ok();
        }

    }
}
