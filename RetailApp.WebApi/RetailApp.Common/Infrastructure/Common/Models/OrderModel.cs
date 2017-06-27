// ***********************************************************************
// Assembly         : RetailApp.Common
// Author           : gjain
// Created          : 06-23-2017
//
// Last Modified By : gjain
// Last Modified On : 06-23-2017
// ***********************************************************************
// <copyright file="OrderModel.cs" company="">
//     Copyright ©  2017
// </copyright>
// <summary></summary>
// ***********************************************************************
using System.Collections.Generic;

namespace RetailApp.Common.Infrastructure.Common.Models
{
    /// <summary>
    /// Class OrderModel.
    /// </summary>
    public class OrderModel
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="OrderModel"/> class.
        /// </summary>
        public OrderModel()
        {
            this.Products = new List<ProductOrderMappingModel>();
        }

        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>The identifier.</value>
        public int Id { get; set; }
        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>The name.</value>
        public string Name { get; set; }
        /// <summary>
        /// Gets or sets the discounted price.
        /// </summary>
        /// <value>The discounted price.</value>
        public double DiscountedPrice { get; set; }
        /// <summary>
        /// Gets or sets the products.
        /// </summary>
        /// <value>The products.</value>
        public List<ProductOrderMappingModel> Products { get; set; }
    }
}