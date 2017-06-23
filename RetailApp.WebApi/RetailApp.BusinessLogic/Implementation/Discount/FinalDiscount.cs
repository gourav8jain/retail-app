using System;
using RetailApp.Common;
using RetailApp.Common.Infrastructure.Common.Enum;
using RetailApp.Common.Infrastructure.Common.Interfaces.Discount;

namespace RetailApp.BusinessLogic.Implementation.Discount
{
    public class FinalDiscount : IDiscount
    {
        public FinalDiscount()
        {
            this.UserType = UserType.Other;
        }
        public UserType UserType { get; set; }

        public double GetDiscount(double totalAmount)
        {
            return (Math.Floor(totalAmount / 100)) * 5;
        }

        public bool IsDiscountApplicable(int associationYears)
        {
            return true;
        }
    }
}