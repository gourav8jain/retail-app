using RetailApp.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RetailApp.Common.Models;

namespace RetailApp.Common.Implementation
{
    public class Order : IOrder
    {
        private IDiscountInvoker discountInvoker;
        private IProduct product;
        public Order(IProduct product, IDiscountInvoker discountInvoker)
        {
            this.product = product;
            this.discountInvoker = discountInvoker;
        }

        public double GetDiscountedOrderPrice(OrderModel order, UserType userType, int associationYears)
        {
            foreach (var product in order.Products)
            {
                product.Cost = this.product.GetDiscountedProductPrice(product, userType, associationYears);
            }

            return this.GetTotalPrice(order);

        }

        private double GetTotalPrice(OrderModel order)
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
