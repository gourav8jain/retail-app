
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
            return this._user.GetOrders(user);
        }
    }
}
