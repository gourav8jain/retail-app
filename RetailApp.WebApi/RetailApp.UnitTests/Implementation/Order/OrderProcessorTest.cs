// ***********************************************************************
// Assembly         : RetailApp.UnitTests
// Author           : gjain
// Created          : 06-27-2017
//
// Last Modified By : gjain
// Last Modified On : 06-27-2017
// ***********************************************************************
// <copyright file="OrderProcessorTest.cs" company="">
//     Copyright ©  2017
// </copyright>
// <summary></summary>
// ***********************************************************************
using Moq;
using NUnit.Framework;
using RetailApp.Common.Infrastructure.Common.Enum;
using RetailApp.Common.Infrastructure.Common.Interfaces.Product;
using RetailApp.Common.Infrastructure.Common.Models;
using System.Collections.Generic;
using System.Web.Http;

namespace RetailApp.UnitTests.Implementation.Order
{
    /// <summary>
    /// Class OrderProcessorTest.
    /// </summary>
    /// <seealso cref="System.Web.Http.ApiController" />
    [TestFixture]
    public class OrderProcessorTest : ApiController
    {
        /// <summary>
        /// The order
        /// </summary>
        private BusinessLogic.Implementation.Order.OrderProcesser _order;
        /// <summary>
        /// The product mock
        /// </summary>
        private readonly Mock<IProduct> _productMock = new Mock<IProduct>();
        /// <summary>
        /// The order model
        /// </summary>
        private OrderModel _orderModel = new OrderModel();

        /// <summary>
        /// Setups this instance.
        /// </summary>
        [OneTimeSetUp]
        public void Setup()
        {
            this._orderModel = new OrderModel
            {
                Id = 1,
                Name = "Order-1",
                Products = new List<ProductOrderMappingModel>
                {
                    new ProductOrderMappingModel
                    {
                        Name = "Item-1",
                        Id = 1,
                        Type = ProductType.NonGrocery,
                        Cost = 100,
                        Quantity = 1
                    },
                    new ProductOrderMappingModel
                    {
                        Name = "Item-2",
                        Id = 2,
                        Type = ProductType.NonGrocery,
                        Cost = 200,
                        Quantity = 2
                    },
                    new ProductOrderMappingModel
                    {
                        Name = "Item-3",
                        Id = 3,
                        Type = ProductType.NonGrocery,
                        Cost = 50,
                        Quantity = 4
                    }

                }
            };
        }

        /// <summary>
        /// Gets the discounted product price for employees test.
        /// </summary>
        [TestCase]
        public void GetDiscountedProductPriceForEmployeesTest()
        {
            _productMock.Setup(x => x.GetDiscountedProductPrice(It.IsAny<ProductOrderMappingModel>(), UserType.Employee, 1)).Returns(100);
            _order = new BusinessLogic.Implementation.Order.OrderProcesser(_productMock.Object);
            double actualResult = _order.GetDiscountedOrderPrice(_orderModel, UserType.Employee, 1);
            double expectedResult = 700;
            Assert.AreEqual(actualResult, expectedResult);
        }


        /// <summary>
        /// Gets the discounted product price for customers test.
        /// </summary>
        [TestCase]
        public void GetDiscountedProductPriceForCustomersTest()
        {
            _productMock.Setup(x => x.GetDiscountedProductPrice(It.IsAny<ProductOrderMappingModel>(), UserType.Customer, 1)).Returns(100);
            _order = new BusinessLogic.Implementation.Order.OrderProcesser(_productMock.Object);
            double actualResult = _order.GetDiscountedOrderPrice(_orderModel, UserType.Customer, 1);
            double expectedResult = 700;
            Assert.AreEqual(actualResult, expectedResult);
        }


        /// <summary>
        /// Gets the discounted product price for affilate test.
        /// </summary>
        [TestCase]
        public void GetDiscountedProductPriceForAffilateTest()
        {
            _productMock.Setup(x => x.GetDiscountedProductPrice(It.IsAny<ProductOrderMappingModel>(), UserType.Afiliate, 1)).Returns(100);
            _order = new BusinessLogic.Implementation.Order.OrderProcesser(_productMock.Object);
            double actualResult = _order.GetDiscountedOrderPrice(_orderModel, UserType.Afiliate, 1);
            double expectedResult = 700;
            Assert.AreEqual(actualResult, expectedResult);
        }

        /// <summary>
        /// Gets the discounted product price for customer more than two years test.
        /// </summary>
        [TestCase]
        public void GetDiscountedProductPriceForCustomerMoreThanTwoYearsTest()
        {
            _productMock.Setup(x => x.GetDiscountedProductPrice(It.IsAny<ProductOrderMappingModel>(), UserType.Customer, 3)).Returns(100);
            _order = new BusinessLogic.Implementation.Order.OrderProcesser(_productMock.Object);
            double actualResult = _order.GetDiscountedOrderPrice(_orderModel, UserType.Customer, 3);
            double expectedResult = 700;
            Assert.AreEqual(actualResult, expectedResult);
        }
    }
}
