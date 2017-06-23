using RetailApp.Common;
using RetailApp.Common.Infrastructure.Common.Enum;
using RetailApp.Common.Infrastructure.Common.Interfaces.Discount;

namespace RetailApp.BusinessLogic.Implementation.Discount
{
    public class CustomerDiscount : IDiscount
    {
        public CustomerDiscount()
        {
            this.UserType = UserType.Customer;
        }

        public UserType UserType { get; set; }

        public double GetDiscount(double amount)
        {
            return ((5 * amount) / 100);
        }

        public bool IsDiscountApplicable(int associationYears)
        {
            return associationYears > 2;
        }
    }
}