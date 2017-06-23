using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RetailApp.Common.Models
{
    public class OrderModel
    {
        public OrderModel()
        {
            this.Products = new List<ProductOrderMappingModel>();
        }

        public double DiscountedPrice { get; set; }
        public List<ProductOrderMappingModel> Products { get; set; }
    }
}