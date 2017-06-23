using Microsoft.Practices.Unity;
using RetailApp.Common;
using System.Web.Http;
using RetailApp.BusinessLogic.Implementation.Discount;
using RetailApp.BusinessLogic.Implementation.Factory;
using RetailApp.BusinessLogic.Implementation.Order;
using RetailApp.BusinessLogic.Implementation.Product;
using RetailApp.BusinessLogic.Implementation.User;
using RetailApp.Common.Infrastructure.Common.Interfaces.Discount;
using RetailApp.Common.Infrastructure.Common.Interfaces.Factory;
using RetailApp.Common.Infrastructure.Common.Interfaces.Order;
using RetailApp.Common.Infrastructure.Common.Interfaces.Product;
using RetailApp.Common.Infrastructure.Common.Interfaces.User;
using RetailApp.Common.Infrastructure.Common.Logging;
using Unity.WebApi;
using log4net.Repository.Hierarchy;
using RetailApp.BusinessLogic.Implementation.Logging;

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
            container.RegisterType<ILogger, RetailLogger>();
            // register all your components with the container here
            // it is NOT necessary to register your controllers

            // e.g. container.RegisterType<ITestService, TestService>();

            GlobalConfiguration.Configuration.DependencyResolver = new UnityDependencyResolver(container);
        }
    }
}