// ***********************************************************************
// Assembly         : RetailApp.BusinessLogic
// Author           : gjain
// Created          : 06-23-2017
//
// Last Modified By : gjain
// Last Modified On : 06-27-2017
// ***********************************************************************
// <copyright file="FinalDiscount.cs" company="">
//     Copyright ©  2017
// </copyright>
// <summary></summary>
// ***********************************************************************
using RetailApp.BusinessLogic.Implementation.Filters.Exception;
using RetailApp.Common.Infrastructure.Common.Enum;
using RetailApp.Common.Infrastructure.Common.Interfaces.Discount;
using System;

namespace RetailApp.BusinessLogic.Implementation.Discount
{
    /// <summary>
    /// Class FinalDiscount.
    /// </summary>
    /// <seealso cref="RetailApp.Common.Infrastructure.Common.Interfaces.Discount.IDiscount" />
    [RetailExceptionFilter]
    public class FinalDiscount : IDiscount
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="FinalDiscount"/> class.
        /// </summary>
        public FinalDiscount()
        {
            this.UserType = UserType.Other;
        }
        /// <summary>
        /// Gets or sets the type of the user.
        /// </summary>
        /// <value>The type of the user.</value>
        public UserType UserType { get; set; }

        /// <summary>
        /// Gets the discount.
        /// </summary>
        /// <param name="totalAmount">The total amount.</param>
        /// <returns>System.Double.</returns>
        public double GetDiscount(double totalAmount)
        {
            return (Math.Floor(totalAmount / 100)) * 5;
        }

        /// <summary>
        /// Determines whether [is discount applicable] [the specified association years].
        /// </summary>
        /// <param name="associationYears">The association years.</param>
        /// <returns><c>true</c> if [is discount applicable] [the specified association years]; otherwise, <c>false</c>.</returns>
        public bool IsDiscountApplicable(int associationYears)
        {
            return true;
        }
    }
}