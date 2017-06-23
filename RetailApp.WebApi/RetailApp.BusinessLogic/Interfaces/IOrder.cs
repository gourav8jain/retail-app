using RetailApp.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RetailApp.Common.Interfaces
{
    public interface IOrder
    {
        double GetDiscountedOrderPrice(OrderModel order, UserType userType, int associationYears);
    }
}