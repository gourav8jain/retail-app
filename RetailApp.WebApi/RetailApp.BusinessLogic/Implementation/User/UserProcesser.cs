// ***********************************************************************
// Assembly         : RetailApp.BusinessLogic
// Author           : gjain
// Created          : 06-23-2017
//
// Last Modified By : gjain
// Last Modified On : 06-27-2017
// ***********************************************************************
// <copyright file="UserProcesser.cs" company="">
//     Copyright ©  2017
// </copyright>
// <summary></summary>
// ***********************************************************************
using RetailApp.BusinessLogic.Implementation.Filters.Exception;
using RetailApp.Common.Infrastructure.Common.Enum;
using RetailApp.Common.Infrastructure.Common.Interfaces.Factory;
using RetailApp.Common.Infrastructure.Common.Interfaces.Order;
using RetailApp.Common.Infrastructure.Common.Interfaces.User;
using RetailApp.Common.Infrastructure.Common.Models;

namespace RetailApp.BusinessLogic.Implementation.User
{
    /// <summary>
    /// Class UserProcesser.
    /// </summary>
    /// <seealso cref="RetailApp.Common.Infrastructure.Common.Interfaces.User.IUser" />
    [RetailExceptionFilter]
    public class UserProcesser : IUser
    {
        /// <summary>
        /// The order
        /// </summary>
        private readonly IOrder _order;
        /// <summary>
        /// The discount invoker
        /// </summary>
        private readonly IDiscountInvoker _discountInvoker;

        /// <summary>
        /// Initializes a new instance of the <see cref="UserProcesser"/> class.
        /// </summary>
        /// <param name="order">The order.</param>
        /// <param name="discountInvoker">The discount invoker.</param>
        public UserProcesser(IOrder order, IDiscountInvoker discountInvoker)
        {
            this._order = order;
            this._discountInvoker = discountInvoker;
        }

        /// <summary>
        /// Gets the orders.
        /// </summary>
        /// <param name="userModel">The user model.</param>
        /// <returns>UserModel.</returns>
        public UserModel GetOrders(UserModel userModel)
        {
            foreach (var order in userModel.Orders)
            {
                var discountedPrice = this._order.GetDiscountedOrderPrice(order, userModel.Type, userModel.AssociationYears);
                var finalDiscount = this._discountInvoker.GetDiscountType(UserType.Other).GetDiscount(discountedPrice);
                order.DiscountedPrice = discountedPrice - finalDiscount;
            }

            return userModel;
        }
    }
}
