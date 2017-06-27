// ***********************************************************************
// Assembly         : RetailApp.Common
// Author           : gjain
// Created          : 06-23-2017
//
// Last Modified By : gjain
// Last Modified On : 06-23-2017
// ***********************************************************************
// <copyright file="IDiscountInvoker.cs" company="">
//     Copyright ©  2017
// </copyright>
// <summary></summary>
// ***********************************************************************
using RetailApp.Common.Infrastructure.Common.Enum;
using RetailApp.Common.Infrastructure.Common.Interfaces.Discount;

namespace RetailApp.Common.Infrastructure.Common.Interfaces.Factory
{
    /// <summary>
    /// Interface IDiscountInvoker
    /// </summary>
    public interface IDiscountInvoker
    {
        /// <summary>
        /// Gets the type of the discount.
        /// </summary>
        /// <param name="userType">Type of the user.</param>
        /// <returns>IDiscount.</returns>
        IDiscount GetDiscountType(UserType userType);
    }
}
