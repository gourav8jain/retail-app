using System.Collections.Generic;

namespace RetailApp.Common.Infrastructure.Common.Models
{
    public class OrderModel
    {
        public OrderModel()
        {
            this.Products = new List<ProductOrderMappingModel>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public double DiscountedPrice { get; set; }
        public List<ProductOrderMappingModel> Products { get; set; }
    }
}