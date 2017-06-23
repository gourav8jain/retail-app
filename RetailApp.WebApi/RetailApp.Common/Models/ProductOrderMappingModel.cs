using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RetailApp.Common.Models
{
    public class ProductOrderMappingModel : ProductModel
    {
        public int Quantity { get; set; }
    }
}