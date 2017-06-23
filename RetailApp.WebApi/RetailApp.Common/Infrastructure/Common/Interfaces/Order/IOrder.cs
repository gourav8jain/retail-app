using RetailApp.Common.Infrastructure.Common.Enum;
using RetailApp.Common.Infrastructure.Common.Models;

namespace RetailApp.Common.Infrastructure.Common.Interfaces.Order
{
    public interface IOrder
    {
        double GetDiscountedOrderPrice(OrderModel order, UserType userType, int associationYears);
    }
}