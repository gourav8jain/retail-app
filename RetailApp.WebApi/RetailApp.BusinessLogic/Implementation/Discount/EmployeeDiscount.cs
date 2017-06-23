using RetailApp.Common;
using RetailApp.Common.Infrastructure.Common.Enum;
using RetailApp.Common.Infrastructure.Common.Interfaces.Discount;

namespace RetailApp.BusinessLogic.Implementation.Discount
{
    public class EmployeeDiscount : IDiscount
    {
        public EmployeeDiscount()
        {
            this.UserType = UserType.Employee;
        }
        public UserType UserType { get; set; }

        public double GetDiscount(double amount)
        {
            return ((30 * amount) / 100);
        }

        public bool IsDiscountApplicable(int associationYears)
        {
            return true;
        }
    }
}