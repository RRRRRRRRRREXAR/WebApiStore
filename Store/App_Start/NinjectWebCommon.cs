using Ninject;
using Store.BLL.Interfaces;
using Store.BLL.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Store.App_Start
{
    public static class NinjectWebCommon
    {
        public static IKernel CreateKernel()
        {
            var kernel = new StandardKernel();
            RegisterServices(kernel);
            GlobalConfiguration.Configuration.DependencyResolver = new NinjectDependencyResolver(kernel);
            return kernel;
        }
        private static void RegisterServices(IKernel kernel)
        {
            kernel.Bind<IProductService>().To<ProductService>();
            kernel.Bind<IAdminService>().To<AdminService>();
        }
    }
}