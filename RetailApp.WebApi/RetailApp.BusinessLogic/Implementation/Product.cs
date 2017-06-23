using RetailApp.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RetailApp.Common.Models;

namespace RetailApp.Common.Implementation
{
    public class Product : IProduct
    {
        private IDiscountInvoker discountInvoker;
        public Product(IDiscountInvoker discountInvoker)
        {
            this.discountInvoker = discountInvoker;
        }

        public double GetDiscountedProductPrice(ProductOrderMappingModel product, UserType userType, int associationYears)
        {
            bool isDiscountApplicable = this.discountInvoker.GetDiscountType(userType).IsDiscountApplicable(associationYears);
            double discount = product.Type.Equals(ProductType.NonGrocery) && isDiscountApplicable ? this.discountInvoker.GetDiscountType(userType).GetDiscount(product.Cost) : 0;
            return product.Cost - discount;
        }
    }
}
