// ***********************************************************************
// Assembly         : RetailApp.BusinessLogic
// Author           : gjain
// Created          : 06-23-2017
//
// Last Modified By : gjain
// Last Modified On : 06-23-2017
// ***********************************************************************
// <copyright file="AffilateDiscount.cs" company="">
//     Copyright ©  2017
// </copyright>
// <summary></summary>
// ***********************************************************************
using RetailApp.BusinessLogic.Implementation.Filters.Exception;
using RetailApp.Common.Infrastructure.Common.Enum;
using RetailApp.Common.Infrastructure.Common.Interfaces.Discount;

namespace RetailApp.BusinessLogic.Implementation.Discount
{
    /// <summary>
    /// Class AffilateDiscount.
    /// </summary>
    /// <seealso cref="RetailApp.Common.Infrastructure.Common.Interfaces.Discount.IDiscount" />
    [RetailExceptionFilter]
    public class AffilateDiscount : IDiscount
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AffilateDiscount"/> class.
        /// </summary>
        public AffilateDiscount()
        {
            this.UserType = UserType.Afiliate;
        }

        /// <summary>
        /// Gets or sets the type of the user.
        /// </summary>
        /// <value>The type of the user.</value>
        public UserType UserType { get; set; }

        /// <summary>
        /// Determines whether [is discount applicable] [the specified association years].
        /// </summary>
        /// <param name="associationYears">The association years.</param>
        /// <returns><c>true</c> if [is discount applicable] [the specified association years]; otherwise, <c>false</c>.</returns>
        public bool IsDiscountApplicable(int associationYears = 3)
        {
            return true;
        }

        /// <summary>
        /// Gets the discount.
        /// </summary>
        /// <param name="amount">The amount.</param>
        /// <returns>System.Double.</returns>
        public double GetDiscount(double amount)
        {
            return ((10 * amount) / 100);
        }
    }
}