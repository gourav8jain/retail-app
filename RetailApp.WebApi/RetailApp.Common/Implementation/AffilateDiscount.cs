using RetailApp.Common;
using RetailApp.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RetailApp.WebApi.Implementation
{
    public class AffilateDiscount : IDiscount
    {
        private UserType userType;

        public AffilateDiscount()
        {
            this.userType = UserType.Afiliate;
        }

        public UserType UserType
        {
            get
            {
                return this.userType;
            }
            set
            {
                this.userType = value;
            }
        }

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