using RetailApp.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RetailApp.Common.Models
{
    public class ProductModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Cost { get; set; }
        public ProductType Type { get; set; }
    }
}