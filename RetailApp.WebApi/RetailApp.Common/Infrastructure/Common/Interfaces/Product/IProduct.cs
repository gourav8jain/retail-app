// ***********************************************************************
// Assembly         : RetailApp.Common
// Author           : gjain
// Created          : 06-23-2017
//
// Last Modified By : gjain
// Last Modified On : 06-23-2017
// ***********************************************************************
// <copyright file="IProduct.cs" company="">
//     Copyright ©  2017
// </copyright>
// <summary></summary>
// ***********************************************************************
using RetailApp.Common.Infrastructure.Common.Enum;
using RetailApp.Common.Infrastructure.Common.Models;

namespace RetailApp.Common.Infrastructure.Common.Interfaces.Product
{
    /// <summary>
    /// Interface IProduct
    /// </summary>
    public interface IProduct
    {
        /// <summary>
        /// Gets the discounted product price.
        /// </summary>
        /// <param name="product">The product.</param>
        /// <param name="userType">Type of the user.</param>
        /// <param name="associationYears">The association years.</param>
        /// <returns>System.Double.</returns>
        double GetDiscountedProductPrice(ProductOrderMappingModel product, UserType userType, int associationYears);
    }
}