using GuildCars.UI.App_Start;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Autofac;
using System.Reflection;
using Autofac.Integration.Mvc;
using GuildCars.UI.Models;
using Autofac.Integration.WebApi;

namespace GuildCars.UI
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            RegisterAutofac();
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }

        private void RegisterAutofac()
        {
            var builder = new ContainerBuilder();
            builder.RegisterControllers(Assembly.GetExecutingAssembly());
            builder.RegisterSource(new ViewRegistrationSource());

            // manual registration of types;
            builder.RegisterType<ApplicationDbContext>();

            // For property injection using Autofac
            // builder.RegisterType<QuoteService>().PropertiesAutowired();

            var container = builder.Build();

            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
            GlobalConfiguration.Configuration.DependencyResolver =
                 new AutofacWebApiDependencyResolver(container);
        }
    }
}
