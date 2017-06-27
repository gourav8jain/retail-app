// ***********************************************************************
// Assembly         : RetailApp.UnitTests
// Author           : gjain
// Created          : 06-27-2017
//
// Last Modified By : gjain
// Last Modified On : 06-27-2017
// ***********************************************************************
// <copyright file="ProductProcessorTest.cs" company="">
//     Copyright ©  2017
// </copyright>
// <summary></summary>
// ***********************************************************************
using Moq;
using NUnit.Framework;
using RetailApp.BusinessLogic.Implementation.Discount;
using RetailApp.Common.Infrastructure.Common.Enum;
using RetailApp.Common.Infrastructure.Common.Interfaces.Discount;
using RetailApp.Common.Infrastructure.Common.Interfaces.Factory;
using RetailApp.Common.Infrastructure.Common.Models;
using System.Web.Http;

namespace RetailApp.UnitTests.Implementation.Product
{
    /// <summary>
    /// Class ProductProcessorTest.
    /// </summary>
    /// <seealso cref="System.Web.Http.ApiController" />
    [TestFixture]
    public class ProductProcessorTest : ApiController
    {
        /// <summary>
        /// The product
        /// </summary>
        private BusinessLogic.Implementation.Product.ProductProcessor _product;
        /// <summary>
        /// The discount invoker mock
        /// </summary>
        private readonly Mock<IDiscountInvoker> _discountInvokerMock = new Mock<IDiscountInvoker>();
        /// <summary>
        /// The discount mock
        /// </summary>
        private readonly Mock<IDiscount> _discountMock = new Mock<IDiscount>();
        /// <summary>
        /// The product model
        /// </summary>
        private ProductOrderMappingModel _productModel = new ProductOrderMappingModel();

        /// <summary>
        /// Setups this instance.
        /// </summary>
        [OneTimeSetUp]
        public void Setup()
        {
            _productModel = new ProductOrderMappingModel
            {
                Name = "Item-1",
                Id = 1,
                Type = ProductType.NonGrocery,
                Cost = 100,
                Quantity = 1
            };
        }

        /// <summary>
        /// Gets the orders for employees test.
        /// </summary>
        [TestCase]
        public void GetOrdersForEmployeesTest()
        {
            _discountInvokerMock.Setup(x => x.GetDiscountType(UserType.Employee)).Returns(new EmployeeDiscount());
            _discountMock.Setup(x => x.GetDiscount(It.IsAny<double>())).Returns(30);
            _product = new BusinessLogic.Implementation.Product.ProductProcessor(_discountInvokerMock.Object);
            double actualResult = _product.GetDiscountedProductPrice(_productModel, UserType.Employee, 1);
            double expectedResult = 70;
            Assert.AreEqual(actualResult, expectedResult);
        }


        /// <summary>
        /// Gets the orders for customers test.
        /// </summary>
        [TestCase]
        public void GetOrdersForCustomersTest()
        {
            _discountInvokerMock.Setup(x => x.GetDiscountType(UserType.Customer)).Returns(new CustomerDiscount());
            _discountMock.Setup(x => x.GetDiscount(It.IsAny<double>())).Returns(0);
            _product = new BusinessLogic.Implementation.Product.ProductProcessor(_discountInvokerMock.Object);
            double actualResult = _product.GetDiscountedProductPrice(_productModel, UserType.Customer, 1);
            double expectedResult = 100;
            Assert.AreEqual(actualResult, expectedResult);
        }


        /// <summary>
        /// Gets the orders for affilate test.
        /// </summary>
        [TestCase]
        public void GetOrdersForAffilateTest()
        {
            _discountInvokerMock.Setup(x => x.GetDiscountType(UserType.Afiliate)).Returns(new AffilateDiscount());
            _discountMock.Setup(x => x.GetDiscount(It.IsAny<double>())).Returns(10);
            _product = new BusinessLogic.Implementation.Product.ProductProcessor(_discountInvokerMock.Object);
            double actualResult = _product.GetDiscountedProductPrice(_productModel, UserType.Afiliate, 1);
            double expectedResult = 90;
            Assert.AreEqual(actualResult, expectedResult);
        }

        /// <summary>
        /// Gets the orders for customer more than two years test.
        /// </summary>
        [TestCase]
        public void GetOrdersForCustomerMoreThanTwoYearsTest()
        {
            _discountInvokerMock.Setup(x => x.GetDiscountType(UserType.Customer)).Returns(new CustomerDiscount());
            _discountMock.Setup(x => x.GetDiscount(It.IsAny<double>())).Returns(5);
            _product = new BusinessLogic.Implementation.Product.ProductProcessor(_discountInvokerMock.Object);
            double actualResult = _product.GetDiscountedProductPrice(_productModel, UserType.Customer, 3);
            double expectedResult = 95;
            Assert.AreEqual(actualResult, expectedResult);
        }
    }
}
