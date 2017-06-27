// ***********************************************************************
// Assembly         : RetailApp.Common
// Author           : gjain
// Created          : 06-23-2017
//
// Last Modified By : gjain
// Last Modified On : 06-23-2017
// ***********************************************************************
// <copyright file="ProductOrderMappingModel.cs" company="">
//     Copyright ©  2017
// </copyright>
// <summary></summary>
// ***********************************************************************
namespace RetailApp.Common.Infrastructure.Common.Models
{
    /// <summary>
    /// Class ProductOrderMappingModel.
    /// </summary>
    /// <seealso cref="RetailApp.Common.Infrastructure.Common.Models.ProductModel" />
    public class ProductOrderMappingModel : ProductModel
    {
        /// <summary>
        /// Gets or sets the quantity.
        /// </summary>
        /// <value>The quantity.</value>
        public int Quantity { get; set; }
    }
}