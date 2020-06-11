using BLL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace smart_booking.Controllers
{
    public class BaseApiController : ApiController
    {
        private IUnitOfWorkService repo;
        public BaseApiController(IUnitOfWorkService repo)
        {
            this.repo = repo;
        }

        protected IUnitOfWorkService TheRepo
        {
            get
            {
                return repo;
            }
        }
    }
}

