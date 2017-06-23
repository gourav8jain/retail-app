using RetailApp.Common;
using RetailApp.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RetailApp.WebApi.Implementation
{
    public class EmployeeDiscount : IDiscount
    {
        private UserType userType;

        public EmployeeDiscount()
        {
            this.userType = UserType.Employee;
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
            return ((30 * amount) / 100);
        }

        public bool IsDiscountApplicable(int associationYears)
        {
            return true;
        }
    }
}