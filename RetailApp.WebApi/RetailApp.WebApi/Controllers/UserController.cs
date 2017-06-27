// ***********************************************************************
// Assembly         : RetailApp.WebApi
// Author           : gjain
// Created          : 06-22-2017
//
// Last Modified By : gjain
// Last Modified On : 06-27-2017
// ***********************************************************************
// <copyright file="UserController.cs" company="">
//     Copyright ©  2017
// </copyright>
// <summary></summary>
// ***********************************************************************
using RetailApp.BusinessLogic.Implementation.Filters.Exception;
using RetailApp.Common.Infrastructure.Common.Interfaces.User;
using RetailApp.Common.Infrastructure.Common.Models;
using RetailApp.Common.Infrastructure.Common.ViewModel;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace RetailApp.WebApi.Controllers
{
    /// <summary>
    /// Class UserController.
    /// </summary>
    /// <seealso cref="System.Web.Http.ApiController" />
    public class UserController : ApiController
    {
        /// <summary>
        /// The user
        /// </summary>
        private readonly IUser _user;

        /// <summary>
        /// Initializes a new instance of the <see cref="UserController"/> class.
        /// </summary>
        /// <param name="user">The user.</param>
        public UserController(IUser user)
        {
            this._user = user;
        }

        /// <summary>
        /// Gets the invoice.
        /// </summary>
        /// <param name="user">The user.</param>
        /// <returns>IEnumerable&lt;UserInvoiceViewModel&gt;.</returns>
        [System.Web.Http.HttpPost]
        [RetailExceptionFilter]
        public IEnumerable<UserInvoiceViewModel> GetInvoice([FromBody] UserModel user)
        {
            var orders = this._user.GetOrders(user);
            return orders.Orders.Select(x => new UserInvoiceViewModel { InvoiceId = x.Id, InvoiceName = x.Name, InvoiceAmount = x.DiscountedPrice });
        }
    }
}