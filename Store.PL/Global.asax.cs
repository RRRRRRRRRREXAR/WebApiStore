using Ninject;
using Ninject.Modules;
using Ninject.Web.WebApi;
using Store.BLL.Infrastructure;
using Store.PL.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace Store.PL
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            //NinjectModule productModule = new ProductModule();
            //NinjectModule adminModule = new AdminModule();
            //NinjectModule serviceModule = new ServiceModule("IdentityDB");
            //var kernel = new StandardKernel(productModule, serviceModule);
            //DependencyResolver.SetResolver(new NinjectDependencyResolver(kernel));
        }
    }
}
