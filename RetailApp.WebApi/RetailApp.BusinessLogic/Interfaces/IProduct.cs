﻿using RetailApp.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RetailApp.Common.Interfaces
{
    public interface IProduct
    {
        double GetDiscountedProductPrice(ProductOrderMappingModel product, UserType userType, int associationYears);
    }
}