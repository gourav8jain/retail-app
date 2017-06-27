// ***********************************************************************
// Assembly         : RetailApp.Common
// Author           : gjain
// Created          : 06-23-2017
//
// Last Modified By : gjain
// Last Modified On : 06-23-2017
// ***********************************************************************
// <copyright file="IDiscount.cs" company="">
//     Copyright ©  2017
// </copyright>
// <summary></summary>
// ***********************************************************************
using RetailApp.Common.Infrastructure.Common.Enum;

namespace RetailApp.Common.Infrastructure.Common.Interfaces.Discount
{
    /// <summary>
    /// Interface IDiscount
    /// </summary>
    public interface IDiscount
    {
        /// <summary>
        /// Gets or sets the type of the user.
        /// </summary>
        /// <value>The type of the user.</value>
        UserType UserType { get; set; }
        /// <summary>
        /// Gets the discount.
        /// </summary>
        /// <param name="amount">The amount.</param>
        /// <returns>System.Double.</returns>
        double GetDiscount(double amount);
        /// <summary>
        /// Determines whether [is discount applicable] [the specified association years].
        /// </summary>
        /// <param name="associationYears">The association years.</param>
        /// <returns><c>true</c> if [is discount applicable] [the specified association years]; otherwise, <c>false</c>.</returns>
        bool IsDiscountApplicable(int associationYears);
    }
}
