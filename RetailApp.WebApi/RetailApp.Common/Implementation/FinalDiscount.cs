using RetailApp.Common;
using RetailApp.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RetailApp.WebApi.Implementation
{
    public class FinalDiscount : IDiscount
    {
        private UserType userType;

        public FinalDiscount()
        {
            this.userType = UserType.Other;
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

        public double GetDiscount(double totalAmount)
        {
            return (Convert.ToInt32(totalAmount / 100)) * 5;
        }

        public bool IsDiscountApplicable(int associationYears)
        {
            return true;
        }
    }
}