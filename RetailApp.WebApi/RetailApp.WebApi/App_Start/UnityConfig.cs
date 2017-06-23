using Microsoft.Practices.Unity;
using RetailApp.Common;
using RetailApp.Common.Implementation;
using RetailApp.Common.Interfaces;
using RetailApp.WebApi.Implementation;
using System.Web.Http;
using Unity.WebApi;

namespace RetailApp.WebApi
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
            var container = new UnityContainer();
            container.RegisterType<IProduct, Product>();
            container.RegisterType<IUser, User>();
            container.RegisterType<IOrder, Order>();
            container.RegisterType<IDiscount, CustomerDiscount>();
            container.RegisterType<IDiscount, AffilateDiscount>();
            container.RegisterType<IDiscount, EmployeeDiscount>();
            container.RegisterType<IDiscount, FinalDiscount>();
            container.RegisterType<IDiscountInvoker, DiscountInvoker>();
            // register all your components with the container here
            // it is NOT necessary to register your controllers

            // e.g. container.RegisterType<ITestService, TestService>();

            GlobalConfiguration.Configuration.DependencyResolver = new UnityDependencyResolver(container);
        }
    }
}