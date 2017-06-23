using RetailApp.Common.Infrastructure.Common.Enum;
using RetailApp.Common.Infrastructure.Common.Interfaces.Discount;

namespace RetailApp.Common.Infrastructure.Common.Interfaces.Factory
{
    public interface IDiscountInvoker
    {
        IDiscount GetDiscountType(UserType userType);
    }
}
