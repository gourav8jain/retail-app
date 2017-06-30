// ***********************************************************************
// Assembly         : RetailApp.Common
// Author           : gjain
// Created          : 06-23-2017
//
// Last Modified By : gjain
// Last Modified On : 06-23-2017
// ***********************************************************************
// <copyright file="IUser.cs" company="">
//     Copyright ©  2017
// </copyright>
// <summary></summary>
// ***********************************************************************

using System.Collections.Generic;
using RetailApp.Common.Infrastructure.Common.Models;
using RetailApp.Common.Infrastructure.Common.ViewModel;

namespace RetailApp.Common.Infrastructure.Common.Interfaces.User
{
    /// <summary>
    /// Interface IUser
    /// </summary>
    public interface IUser
    {
        /// <summary>
        /// Gets the orders.
        /// </summary>
        /// <param name="userModel">The user model.</param>
        /// <returns>UserModel.</returns>
        IEnumerable<UserInvoiceViewModel> GetOrders(UserModel userModel);
    }
}