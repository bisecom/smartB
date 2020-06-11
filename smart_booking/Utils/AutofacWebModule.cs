using Autofac;
using BLL.Interfaces;
using BLL.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace smart_booking.Utils
{
    public class AutofacWebModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<BllUnitOfWork>().As<IUnitOfWorkService>().InstancePerRequest();
        }
    }

}
