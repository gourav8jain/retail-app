using RetailApp.Common.Infrastructure.Common.Interfaces.User;
using RetailApp.Common.Infrastructure.Common.Models;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using RetailApp.BusinessLogic.Implementation.Filters.Exception;
using RetailApp.Common.Infrastructure.Common.Logging;

namespace RetailApp.WebApi.Controllers
{
    public class UserController : ApiController
    {
        private readonly IUser _user;
        // FOR MOCK-UP DATA
        public readonly List<UserModel> UserList = new List<UserModel>();

        private readonly ILogger _logger;

        public UserController(IUser user, ILogger logger)
        {
            this._user = user;
            this._logger = logger;
        }

        [System.Web.Http.HttpPost]
        [RetailExceptionFilter]
        public object GetInvoice([FromBody] UserModel user)
        {
            var orders = this._user.GetOrders(user);
            return orders.Orders.Select(x => new { InvoiceId = x.Id, InvoiceName = x.Name, InvoiceAmount = x.DiscountedPrice });
        }
    }
}