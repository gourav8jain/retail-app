// ***********************************************************************
// Assembly         : RetailApp.BusinessLogic
// Author           : gjain
// Created          : 06-23-2017
//
// Last Modified By : gjain
// Last Modified On : 06-27-2017
// ***********************************************************************
// <copyright file="ProductProcessor.cs" company="">
//     Copyright ©  2017
// </copyright>
// <summary></summary>
// ***********************************************************************
using RetailApp.BusinessLogic.Implementation.Filters.Exception;
using RetailApp.Common.Infrastructure.Common.Enum;
using RetailApp.Common.Infrastructure.Common.Interfaces.Factory;
using RetailApp.Common.Infrastructure.Common.Interfaces.Product;
using RetailApp.Common.Infrastructure.Common.Models;

namespace RetailApp.BusinessLogic.Implementation.Product
{
    /// <summary>
    /// Class ProductProcessor.
    /// </summary>
    /// <seealso cref="RetailApp.Common.Infrastructure.Common.Interfaces.Product.IProduct" />
    [RetailExceptionFilter]
    public class ProductProcessor : IProduct
    {
        /// <summary>
        /// The discount invoker
        /// </summary>
        private readonly IDiscountInvoker _discountInvoker;
        /// <summary>
        /// Initializes a new instance of the <see cref="ProductProcessor"/> class.
        /// </summary>
        /// <param name="discountInvoker">The discount invoker.</param>
        public ProductProcessor(IDiscountInvoker discountInvoker)
        {
            this._discountInvoker = discountInvoker;
        }

        /// <summary>
        /// Gets the discounted product price.
        /// </summary>
        /// <param name="product">The product.</param>
        /// <param name="userType">Type of the user.</param>
        /// <param name="associationYears">The association years.</param>
        /// <returns>System.Double.</returns>
        public double GetDiscountedProductPrice(ProductOrderMappingModel product, UserType userType, int associationYears)
        {
            bool isDiscountApplicable = this._discountInvoker.GetDiscountType(userType).IsDiscountApplicable(associationYears);
            double discount = product.Type.Equals(ProductType.NonGrocery) && isDiscountApplicable ? this._discountInvoker.GetDiscountType(userType).GetDiscount(product.Cost) : 0;
            return product.Cost - discount;
        }
    }
}
