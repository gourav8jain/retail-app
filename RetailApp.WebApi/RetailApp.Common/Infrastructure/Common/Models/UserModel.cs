using System.Collections.Generic;
using RetailApp.Common.Infrastructure.Common.Enum;

namespace RetailApp.Common.Infrastructure.Common.Models
{
    public class UserModel
    {
        public UserModel()
        {
            this.Orders = new List<OrderModel>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public UserType Type { get; set; }
        public int AssociationYears { get; set; }
        public List<OrderModel> Orders { get; set; }
    }
}