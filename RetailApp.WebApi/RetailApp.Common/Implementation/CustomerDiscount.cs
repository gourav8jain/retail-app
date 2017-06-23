using RetailApp.Common;
using RetailApp.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RetailApp.WebApi.Implementation
{
    public class CustomerDiscount : IDiscount
    {
        private UserType userType;

        public CustomerDiscount()
        {
            this.userType = UserType.Customer;
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

        public double GetDiscount(double amount)
        {
            return ((5 * amount) / 100);
        }

        public bool IsDiscountApplicable(int associationYears)
        {
            return associationYears > 2 ? true : false;
        }
    }
}