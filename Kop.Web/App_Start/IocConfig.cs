using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;
using Autofac;
using Autofac.Integration.Mvc;
using Kop.Core;
using Kop.Core.Data;
using Kop.Data;
using Kop.Services.Bibles;
using Kop.Services.Countries;
using Kop.Services.PrayerTemplates;
using Kop.Services.Prayers;
using Kop.Services.Users;

namespace Kop.Web
{
    public class IocConfig
    {
        public static void Build()
        {
            var builder = new ContainerBuilder();
            builder.RegisterControllers(typeof(MvcApplication).Assembly);
            builder.RegisterControllers(Assembly.GetExecutingAssembly());

            builder.RegisterType<KopDataContext>().As<KopDataContext>().InstancePerHttpRequest();

            //Repository
            builder.RegisterType<EfRepository<Prayer>>().As<IRepository<Prayer>>().InstancePerLifetimeScope();
            builder.RegisterType<EfRepository<User>>().As<IRepository<User>>().InstancePerLifetimeScope();
            builder.RegisterType<EfRepository<Country>>().As<IRepository<Country>>().InstancePerLifetimeScope();
            builder.RegisterType<EfRepository<Bible>>().As<IRepository<Bible>>().InstancePerLifetimeScope();
            builder.RegisterType<EfRepository<BibleBook>>().As<IRepository<BibleBook>>().InstancePerLifetimeScope();
            builder.RegisterType<EfRepository<PrayerTemplate>>().As<IRepository<PrayerTemplate>>().InstancePerLifetimeScope();
            builder.RegisterType<EfRepository<PrayerTemplateCategory>>().As<IRepository<PrayerTemplateCategory>>().InstancePerLifetimeScope();

            //Service
            builder.RegisterType<PrayerService>().As<IPrayerService>().InstancePerLifetimeScope();
            builder.RegisterType<UserService>().As<IUserService>().InstancePerLifetimeScope();            
            builder.RegisterType<CountryService>().As<ICountryService>().InstancePerLifetimeScope();
            builder.RegisterType<BibleService>().As<IBibleService>().InstancePerLifetimeScope();
            builder.RegisterType<PrayerTemplateService>().As<IPrayerTemplateService>().InstancePerLifetimeScope();            

            //web helper
            builder.Register(c => new HttpContextWrapper(HttpContext.Current)).As<HttpContextBase>().InstancePerHttpRequest();
            builder.RegisterType<WebHelper>().As<IWebHelper>().InstancePerHttpRequest();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(builder.Build()));
        }
    }
}