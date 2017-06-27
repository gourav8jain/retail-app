// ***********************************************************************
// Assembly         : RetailApp.BusinessLogic
// Author           : gjain
// Created          : 06-23-2017
//
// Last Modified By : gjain
// Last Modified On : 06-23-2017
// ***********************************************************************
// <copyright file="DiscountInvoker.cs" company="">
//     Copyright ©  2017
// </copyright>
// <summary></summary>
// ***********************************************************************
using RetailApp.BusinessLogic.Implementation.Discount;
using RetailApp.BusinessLogic.Implementation.Filters.Exception;
using RetailApp.Common.Infrastructure.Common.Enum;
using RetailApp.Common.Infrastructure.Common.Interfaces.Discount;
using RetailApp.Common.Infrastructure.Common.Interfaces.Factory;
using System.Collections;

namespace RetailApp.BusinessLogic.Implementation.Factory
{
    /// <summary>
    /// Class DiscountInvoker.
    /// </summary>
    /// <seealso cref="RetailApp.Common.Infrastructure.Common.Interfaces.Factory.IDiscountInvoker" />
    [RetailExceptionFilter]
    public class DiscountInvoker : IDiscountInvoker
    {
        /// <summary>
        /// The object array list
        /// </summary>
        private readonly ArrayList _objArrayList = new ArrayList();

        /// <summary>
        /// Initializes a new instance of the <see cref="DiscountInvoker"/> class.
        /// </summary>
        public DiscountInvoker()
        {
            _objArrayList.Add(new CustomerDiscount());
            _objArrayList.Add(new AffilateDiscount());
            _objArrayList.Add(new EmployeeDiscount());
            _objArrayList.Add(new FinalDiscount());
        }

        /// <summary>
        /// Gets the type of the discount.
        /// </summary>
        /// <param name="userType">Type of the user.</param>
        /// <returns>IDiscount.</returns>
        public IDiscount GetDiscountType(UserType userType)
        {
            foreach (var item in _objArrayList)
            {
                IDiscount discount = (IDiscount)item;
                if (discount.UserType.Equals(userType))
                {
                    return discount;
                }
            }
            return null;
        }
    }
}
