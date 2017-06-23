using RetailApp.WebApi.Implementation;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RetailApp.Common.Implementation
{
    public class DiscountInvoker : IDiscountInvoker
    {
        private ArrayList objArrayList = new ArrayList();

        public DiscountInvoker()
        {
            objArrayList.Add(new CustomerDiscount());
            objArrayList.Add(new AffilateDiscount());
            objArrayList.Add(new EmployeeDiscount());
            objArrayList.Add(new FinalDiscount());
        }

        public IDiscount GetDiscountType(UserType userType)
        {
            foreach (var item in objArrayList)
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
