using Autofac;
using Autofac.Integration.WebApi;
using BLL.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Http;

namespace smart_booking.Utils
{
    public class AutofacConfig
    {
        public static void Configure()
        {
            // получаем экземпляр контейнера
            var builder = new ContainerBuilder();

            // регистрируем контроллер в текущей сборке
            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());

            // регистрируем споставление типов
            //builder.RegisterType<BookRepository>().As<IRepository>();
            builder.RegisterModule<AutofacBllModule>();
            builder.RegisterModule<AutofacWebModule>();
            // создаем новый контейнер с теми зависимостями, которые определены выше
            var container = builder.Build();

            // установка сопоставителя зависимостей
            // DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
            GlobalConfiguration.Configuration.DependencyResolver = new AutofacWebApiDependencyResolver(container);
        }
    }
}