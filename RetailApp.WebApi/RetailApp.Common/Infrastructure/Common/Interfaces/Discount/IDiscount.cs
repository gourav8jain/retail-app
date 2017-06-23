using RetailApp.Common.Infrastructure.Common.Enum;

namespace RetailApp.Common.Infrastructure.Common.Interfaces.Discount
{
    public interface IDiscount
    {
        UserType UserType { get; set; }
        double GetDiscount(double amount);
        bool IsDiscountApplicable(int associationYears);
    }
}
