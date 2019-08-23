using Ninject;
using Ninject.Modules;
using Ninject.Web.WebApi;
using Store.BLL.Infrastructure;
using Store.BLL.Interfaces;
using Store.BLL.Services;
using Store.Identity;
using Store.Models;
using Store.Util;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Routing;

namespace Store
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            NinjectModule productModule = new ProductModule();
            NinjectModule serviceModule = new ServiceModule("Default");
            var kernel = new StandardKernel(productModule,serviceModule);
            DependencyResolver.SetResolver(new NinjectDependencyResolver(kernel));
            Database.SetInitializer<ApplicationDbContext>(new UserDbInitializer());
        }
       
    }
}
