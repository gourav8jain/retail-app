using RetailApp.Common.Infrastructure.Common.Enum;

namespace RetailApp.Common.Infrastructure.Common.Models
{
    public class ProductModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Cost { get; set; }
        public ProductType Type { get; set; }
    }
}