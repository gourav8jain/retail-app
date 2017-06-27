// ***********************************************************************
// Assembly         : RetailApp.WebApi
// Author           : gjain
// Created          : 06-22-2017
//
// Last Modified By : gjain
// Last Modified On : 06-27-2017
// ***********************************************************************
// <copyright file="UnityConfig.cs" company="">
//     Copyright ©  2017
// </copyright>
// <summary></summary>
// ***********************************************************************
using Microsoft.Practices.Unity;
using RetailApp.BusinessLogic.Implementation.Discount;
using RetailApp.BusinessLogic.Implementation.Factory;
using RetailApp.BusinessLogic.Implementation.Logging;
using RetailApp.BusinessLogic.Implementation.Order;
using RetailApp.BusinessLogic.Implementation.Product;
using RetailApp.BusinessLogic.Implementation.User;
using RetailApp.Common.Infrastructure.Common.Interfaces.Discount;
using RetailApp.Common.Infrastructure.Common.Interfaces.Factory;
using RetailApp.Common.Infrastructure.Common.Interfaces.Order;
using RetailApp.Common.Infrastructure.Common.Interfaces.Product;
using RetailApp.Common.Infrastructure.Common.Interfaces.User;
using RetailApp.Common.Infrastructure.Common.Logging;
using System.Web.Http;
using Unity.WebApi;

namespace RetailApp.WebApi
{
    /// <summary>
    /// Class UnityConfig.
    /// </summary>
    public static class UnityConfig
    {
        /// <summary>
        /// Registers the components.
        /// </summary>
        public static void RegisterComponents()
        {
            var container = new UnityContainer();
            container.RegisterType<IProduct, ProductProcessor>();
            container.RegisterType<IUser, UserProcesser>();
            container.RegisterType<IOrder, OrderProcesser>();
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