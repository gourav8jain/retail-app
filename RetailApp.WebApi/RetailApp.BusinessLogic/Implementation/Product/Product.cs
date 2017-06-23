using RetailApp.Common;
using RetailApp.Common.Infrastructure.Common.Enum;
using RetailApp.Common.Infrastructure.Common.Interfaces.Factory;
using RetailApp.Common.Infrastructure.Common.Interfaces.Product;
using RetailApp.Common.Infrastructure.Common.Models;

namespace RetailApp.BusinessLogic.Implementation.Product
{
    public class Product : IProduct
    {
        private readonly IDiscountInvoker _discountInvoker;
        public Product(IDiscountInvoker discountInvoker)
        {
            this._discountInvoker = discountInvoker;
        }

        public double GetDiscountedProductPrice(ProductOrderMappingModel product, UserType userType, int associationYears)
        {
            bool isDiscountApplicable = this._discountInvoker.GetDiscountType(userType).IsDiscountApplicable(associationYears);
            double discount = product.Type.Equals(ProductType.NonGrocery) && isDiscountApplicable ? this._discountInvoker.GetDiscountType(userType).GetDiscount(product.Cost) : 0;
            return product.Cost - discount;
        }
    }
}
