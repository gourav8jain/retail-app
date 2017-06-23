using RetailApp.WebApi.Implementation;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RetailApp.Common.Implementation
{
    public interface IDiscountInvoker
    {
        IDiscount GetDiscountType(UserType userType);
    }
}
