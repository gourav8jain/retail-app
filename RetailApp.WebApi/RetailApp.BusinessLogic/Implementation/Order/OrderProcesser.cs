using System.Linq;
using RetailApp.BusinessLogic.Implementation.Filters.Exception;
using RetailApp.Common;
using RetailApp.Common.Infrastructure.Common.Enum;
using RetailApp.Common.Infrastructure.Common.Interfaces.Order;
using RetailApp.Common.Infrastructure.Common.Interfaces.Product;
using RetailApp.Common.Infrastructure.Common.Models;

namespace RetailApp.BusinessLogic.Implementation.Order
{
    [RetailExceptionFilter]
    public class OrderProcesser : IOrder
    {
        private readonly IProduct _product;
        public OrderProcesser(IProduct product)
        {
            this._product = product;
        }

        public double GetDiscountedOrderPrice(OrderModel order, UserType userType, int associationYears)
        {
            foreach (var product in order.Products)
            {
                product.Cost = this._product.GetDiscountedProductPrice(product, userType, associationYears);
            }

            return GetTotalPrice(order);

        }

        private static double GetTotalPrice(OrderModel order)
        {
            double totalPrice = 0;
            foreach (var item in order.Products.Where(x => x.Quantity > 0))
            {
                totalPrice += item.Quantity * item.Cost;
            }

            return totalPrice;
        }
    }
}
