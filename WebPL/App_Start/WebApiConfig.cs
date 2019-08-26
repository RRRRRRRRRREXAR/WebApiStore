using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web.Http;
using Microsoft.Owin.Security.OAuth;
using Newtonsoft.Json.Serialization;
using Store.BLL.Interfaces;
using Store.BLL.Services;
using Store.DAL.Context;
using Store.DAL.Interfaces;
using Unity;
using Unity.Injection;
using Unity.Lifetime;
using WebPL.Dependencies;

namespace WebPL
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            var container = new UnityContainer();
            container.RegisterType<IUnitOfWork,UnitOfWork>(new HierarchicalLifetimeManager());
            container.RegisterType<IProductService, ProductService>(new HierarchicalLifetimeManager());
            container.RegisterType<IAdminService, AdminService>(new HierarchicalLifetimeManager());
            config.DependencyResolver = new UnityResolver(container);
            // Конфигурация и службы Web API
            // Настройка Web API для использования только проверки подлинности посредством маркера-носителя.
            config.SuppressDefaultHostAuthentication();
            config.Filters.Add(new HostAuthenticationFilter(OAuthDefaults.AuthenticationType));

            // Маршруты Web API
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
