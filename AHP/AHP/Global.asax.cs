using Autofac;
using AHP.AutoMapper;
using Autofac.Integration.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using AutoMapper;
using System.Reflection;
using Autofac.Integration.WebApi;

namespace AHP
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            var builder = new ContainerBuilder();

            builder.RegisterModule(new DAL.DIModule());
            builder.RegisterModule(new Repository.DIModule());
            builder.RegisterModule(new Service.DIModule());
            //builder.RegisterModule(new AutoMapper.DIModule());

            builder.RegisterAssemblyTypes().AssignableTo(typeof(Profile));

            builder.Register(c => new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new MVCMapper());
                cfg.AddProfile(new RepositoryMapper());
                cfg.AddProfile(new ApiMapper());
            })).AsSelf().SingleInstance();

            builder.Register(c => c.Resolve<MapperConfiguration>().CreateMapper(c.Resolve)).As<IMapper>().InstancePerLifetimeScope();

            builder.RegisterControllers(typeof(MvcApplication).Assembly);
            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());

            var container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
            GlobalConfiguration.Configuration.DependencyResolver = new AutofacWebApiDependencyResolver((IContainer)container);

            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            
        }
    }
}
