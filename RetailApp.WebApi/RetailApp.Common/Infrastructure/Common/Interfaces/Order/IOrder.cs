// ***********************************************************************
// Assembly         : RetailApp.Common
// Author           : gjain
// Created          : 06-23-2017
//
// Last Modified By : gjain
// Last Modified On : 06-23-2017
// ***********************************************************************
// <copyright file="IOrder.cs" company="">
//     Copyright ©  2017
// </copyright>
// <summary></summary>
// ***********************************************************************
using RetailApp.Common.Infrastructure.Common.Enum;
using RetailApp.Common.Infrastructure.Common.Models;

namespace RetailApp.Common.Infrastructure.Common.Interfaces.Order
{
    /// <summary>
    /// Interface IOrder
    /// </summary>
    public interface IOrder
    {
        /// <summary>
        /// Gets the discounted order price.
        /// </summary>
        /// <param name="order">The order.</param>
        /// <param name="userType">Type of the user.</param>
        /// <param name="associationYears">The association years.</param>
        /// <returns>System.Double.</returns>
        double GetDiscountedOrderPrice(OrderModel order, UserType userType, int associationYears);
    }
}