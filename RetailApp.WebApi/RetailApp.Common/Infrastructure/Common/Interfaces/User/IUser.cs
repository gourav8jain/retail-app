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
using RetailApp.Common.Infrastructure.Common.Models;

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
        UserModel GetOrders(UserModel userModel);
    }
}