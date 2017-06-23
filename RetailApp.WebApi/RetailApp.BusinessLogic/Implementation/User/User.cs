using RetailApp.BusinessLogic.Implementation.Filters.Exception;
using RetailApp.Common;
using RetailApp.Common.Infrastructure.Common.Enum;
using RetailApp.Common.Infrastructure.Common.Interfaces.Factory;
using RetailApp.Common.Infrastructure.Common.Interfaces.Order;
using RetailApp.Common.Infrastructure.Common.Interfaces.User;
using RetailApp.Common.Infrastructure.Common.Models;

namespace RetailApp.BusinessLogic.Implementation.User
{
    [RetailExceptionFilter]
    public class User : IUser
    {
        private readonly IOrder _order;
        private readonly IDiscountInvoker _discountInvoker;

        public User(IOrder order, IDiscountInvoker discountInvoker)
        {
            this._order = order;
            this._discountInvoker = discountInvoker;
        }

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
