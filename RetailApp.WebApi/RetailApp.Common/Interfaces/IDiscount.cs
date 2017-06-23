using RetailApp.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RetailApp.Common
{
    public interface IDiscount
    {
        UserType UserType { get; set; }
        double GetDiscount(double user);
        bool IsDiscountApplicable(int associationYears = 3);
    }
}
