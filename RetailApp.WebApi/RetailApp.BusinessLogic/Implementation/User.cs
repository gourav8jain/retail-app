using RetailApp.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RetailApp.Common.Models;

namespace RetailApp.Common.Implementation
{
    public class User : IUser
    {
        private IOrder order;

        public User(IOrder order)
        {
            this.order = order;
        }

        public UserModel GetOrders(UserModel userModel)
        {
            foreach (var order in userModel.Orders)
            {
                order.DiscountedPrice = this.order.GetDiscountedOrderPrice(order, userModel.Type, userModel.AssociationYears);
            }

            return userModel;
        }
    }
}
