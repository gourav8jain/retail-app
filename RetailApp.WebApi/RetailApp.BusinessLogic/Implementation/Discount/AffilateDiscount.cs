using RetailApp.Common;
using RetailApp.Common.Infrastructure.Common.Enum;
using RetailApp.Common.Infrastructure.Common.Interfaces.Discount;

namespace RetailApp.BusinessLogic.Implementation.Discount
{
    public class AffilateDiscount : IDiscount
    {
        public AffilateDiscount()
        {
            this.UserType = UserType.Afiliate;
        }

        public UserType UserType { get; set; }

        public bool IsDiscountApplicable(int associationYears = 3)
        {
            return true;
        }

        public double GetDiscount(double amount)
        {
            return ((10 * amount) / 100);
        }
    }
}