// ***********************************************************************
// Assembly         : RetailApp.BusinessLogic
// Author           : gjain
// Created          : 06-23-2017
//
// Last Modified By : gjain
// Last Modified On : 06-27-2017
// ***********************************************************************
// <copyright file="OrderProcesser.cs" company="">
//     Copyright ©  2017
// </copyright>
// <summary></summary>
// ***********************************************************************
using RetailApp.BusinessLogic.Implementation.Filters.Exception;
using RetailApp.Common.Infrastructure.Common.Enum;
using RetailApp.Common.Infrastructure.Common.Interfaces.Order;
using RetailApp.Common.Infrastructure.Common.Interfaces.Product;
using RetailApp.Common.Infrastructure.Common.Models;
using System.Linq;

namespace RetailApp.BusinessLogic.Implementation.Order
{
    /// <summary>
    /// Class OrderProcesser.
    /// </summary>
    /// <seealso cref="RetailApp.Common.Infrastructure.Common.Interfaces.Order.IOrder" />
    [RetailExceptionFilter]
    public class OrderProcesser : IOrder
    {
        /// <summary>
        /// The product
        /// </summary>
        private readonly IProduct _product;
        /// <summary>
        /// Initializes a new instance of the <see cref="OrderProcesser"/> class.
        /// </summary>
        /// <param name="product">The product.</param>
        public OrderProcesser(IProduct product)
        {
            this._product = product;
        }

        /// <summary>
        /// Gets the discounted order price.
        /// </summary>
        /// <param name="order">The order.</param>
        /// <param name="userType">Type of the user.</param>
        /// <param name="associationYears">The association years.</param>
        /// <returns>System.Double.</returns>
        public double GetDiscountedOrderPrice(OrderModel order, UserType userType, int associationYears)
        {
            foreach (var product in order.Products)
            {
                product.Cost = this._product.GetDiscountedProductPrice(product, userType, associationYears);
            }

            return GetTotalPrice(order);

        }

        /// <summary>
        /// Gets the total price.
        /// </summary>
        /// <param name="order">The order.</param>
        /// <returns>System.Double.</returns>
        private static double GetTotalPrice(OrderModel order)
        {
            double totalPrice = 0;
            foreach (var item in order.Products.Where(x => x.Quantity > 0))
            {
                totalPrice += item.Quantity * item.Cost;
            }

            return totalPrice;
        }
    }
}
