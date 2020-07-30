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
using GuildCars.UI.EF;
using GuildCars.Data.Interfaces;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;

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
            builder.RegisterType<BodyStyleRepositoryEF>().As<IBodyStyleRepository>();
            builder.RegisterType<ConditionRepositoryEF>().As<IConditionRepository>();
            builder.RegisterType<ExteriorColorRepositoryEF>().As<IExteriorColorRepository>();
            builder.RegisterType<GuildRepositoryEF>().As<IGuildRepository>();
            builder.RegisterType<InteriorColorRepositoryEF>().As<IInteriorColorRepository>();
            builder.RegisterType<MakeRepositoryEF>().As<IMakeRepository>();
            builder.RegisterType<ModelRepositoryEF>().As<IModelRepository>();
            builder.RegisterType<PurchaseTypeRepositoryEF>().As<IPurchaseTypeRepository>();
            builder.RegisterType<RoleRepositoryEF>().As<IRoleRepository>();
            builder.RegisterType<SpecialsRepositoryEF>().As<ISpecialsRepository>();
            builder.RegisterType<StateRepositoryEF>().As<IStateRepository>();
            builder.RegisterType<TransactionRepositoryEF>().As<ITransactionRepository>();
            builder.RegisterType<TransmissionRepositoryEF>().As<ITransmissionRepository>();
            builder.RegisterType<UserRepositoryEF>().As<IUserRepository>();
            builder.RegisterType<ApplicationDbContext>();
            builder.Register(c => HttpContext.Current.GetOwinContext().Authentication).As<IAuthenticationManager>();


            //builder.RegisterType<ApplicationDbContext>().AsSelf().InstancePerRequest();
            //builder.RegisterType<ApplicationUserStore>().As<IUserStore<ApplicationUser>>().InstancePerRequest();
            //builder.RegisterType<ApplicationUserManager>().AsSelf().InstancePerRequest();
            //builder.RegisterType<ApplicationSignInManager>().AsSelf().InstancePerRequest();
            //builder.Register<IAuthenticationManager>(c => HttpContext.Current.GetOwinContext().Authentication).InstancePerRequest();
            //builder.Register<IDataProtectionProvider>(c => app.GetDataProtectionProvider()).InstancePerRequest();


            // For property injection using Autofac
            // builder.RegisterType<QuoteService>().PropertiesAutowired();

            builder.RegisterControllers(typeof(MvcApplication).Assembly);
            builder.RegisterModelBinders(typeof(MvcApplication).Assembly);
            builder.RegisterModule<AutofacWebTypesModule>();

            var container = builder.Build();

            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
            GlobalConfiguration.Configuration.DependencyResolver =
                 new AutofacWebApiDependencyResolver(container);
        }
    }
}
