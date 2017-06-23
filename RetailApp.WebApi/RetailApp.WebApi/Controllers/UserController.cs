using System.Collections.Generic;
using RetailApp.BusinessLogic.Implementation.Filters.Exception;
using RetailApp.Common.Infrastructure.Common.Interfaces.User;
using RetailApp.Common.Infrastructure.Common.Models;
using RetailApp.Common.Infrastructure.Common.ViewModel;
using System.Linq;
using System.Web.Http;

namespace RetailApp.WebApi.Controllers
{
    public class UserController : ApiController
    {
        private readonly IUser _user;

        public UserController(IUser user)
        {
            this._user = user;
        }

        [System.Web.Http.HttpPost]
        [RetailExceptionFilter]
        public IEnumerable<UserInvoiceViewModel> GetInvoice([FromBody] UserModel user)
        {
            var orders = this._user.GetOrders(user);
            return orders.Orders.Select(x => new UserInvoiceViewModel { InvoiceId = x.Id, InvoiceName = x.Name, InvoiceAmount = x.DiscountedPrice });
        }
    }
}