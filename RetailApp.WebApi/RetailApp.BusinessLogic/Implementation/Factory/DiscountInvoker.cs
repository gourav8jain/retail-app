using System.Collections;
using RetailApp.BusinessLogic.Implementation.Discount;
using RetailApp.Common;
using RetailApp.Common.Infrastructure.Common.Enum;
using RetailApp.Common.Infrastructure.Common.Interfaces.Discount;
using RetailApp.Common.Infrastructure.Common.Interfaces.Factory;

namespace RetailApp.BusinessLogic.Implementation.Factory
{
    public class DiscountInvoker : IDiscountInvoker
    {
        private readonly ArrayList _objArrayList = new ArrayList();

        public DiscountInvoker()
        {
            _objArrayList.Add(new CustomerDiscount());
            _objArrayList.Add(new AffilateDiscount());
            _objArrayList.Add(new EmployeeDiscount());
            _objArrayList.Add(new FinalDiscount());
        }

        public IDiscount GetDiscountType(UserType userType)
        {
            foreach (var item in _objArrayList)
            {
                IDiscount discount = (IDiscount)item;
                if (discount.UserType.Equals(userType))
                {
                    return discount;
                }
            }
            return null;
        }
    }
}
