using RetailApp.Common.Infrastructure.Common.Enum;
using RetailApp.Common.Infrastructure.Common.Models;

namespace RetailApp.Common.Infrastructure.Common.Interfaces.Product
{
    public interface IProduct
    {
        double GetDiscountedProductPrice(ProductOrderMappingModel product, UserType userType, int associationYears);
    }
}