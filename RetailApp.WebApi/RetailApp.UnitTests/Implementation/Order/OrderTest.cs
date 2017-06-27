using System.Collections.Generic;
using System.Web.Http;
using Moq;
using NUnit.Framework;
using RetailApp.BusinessLogic.Implementation.Discount;
using RetailApp.Common.Infrastructure.Common.Enum;
using RetailApp.Common.Infrastructure.Common.Interfaces.Discount;
using RetailApp.Common.Infrastructure.Common.Interfaces.Factory;
using RetailApp.Common.Infrastructure.Common.Interfaces.Product;
using RetailApp.Common.Infrastructure.Common.Models;

namespace RetailApp.UnitTests.Implementation.Order
{
    [TestFixture]
    public class OrderTest : ApiController
    {
        private BusinessLogic.Implementation.Order.Order _order;
        private readonly Mock<IProduct> _productMock = new Mock<IProduct>();
        private ProductOrderMappingModel _productModel = new ProductOrderMappingModel();
        private OrderModel _orderModel = new OrderModel();

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

        [TestCase]
        public void GetDiscountedProductPriceForEmployeesTest()
        {
            _productMock.Setup(x => x.GetDiscountedProductPrice(It.IsAny<ProductOrderMappingModel>(), UserType.Employee, 1)).Returns(100);
            _order = new BusinessLogic.Implementation.Order.Order(_productMock.Object);
            double actualResult = _order.GetDiscountedOrderPrice(_orderModel, UserType.Employee, 1);
            double expectedResult = 700;
            Assert.AreEqual(actualResult, expectedResult);
        }


        [TestCase]
        public void GetDiscountedProductPriceForCustomersTest()
        {
            _productMock.Setup(x => x.GetDiscountedProductPrice(It.IsAny<ProductOrderMappingModel>(), UserType.Customer, 1)).Returns(100);
            _order = new BusinessLogic.Implementation.Order.Order(_productMock.Object);
            double actualResult = _order.GetDiscountedOrderPrice(_orderModel, UserType.Customer, 1);
            double expectedResult = 700;
            Assert.AreEqual(actualResult, expectedResult);
        }


        [TestCase]
        public void GetDiscountedProductPriceForAffilateTest()
        {
            _productMock.Setup(x => x.GetDiscountedProductPrice(It.IsAny<ProductOrderMappingModel>(), UserType.Afiliate, 1)).Returns(100);
            _order = new BusinessLogic.Implementation.Order.Order(_productMock.Object);
            double actualResult = _order.GetDiscountedOrderPrice(_orderModel, UserType.Afiliate, 1);
            double expectedResult = 700;
            Assert.AreEqual(actualResult, expectedResult);
        }

        [TestCase]
        public void GetDiscountedProductPriceForCustomerMoreThanTwoYearsTest()
        {
            _productMock.Setup(x => x.GetDiscountedProductPrice(It.IsAny<ProductOrderMappingModel>(), UserType.Customer, 3)).Returns(100);
            _order = new BusinessLogic.Implementation.Order.Order(_productMock.Object);
            double actualResult = _order.GetDiscountedOrderPrice(_orderModel, UserType.Customer, 3);
            double expectedResult = 700;
            Assert.AreEqual(actualResult, expectedResult);
        }
    }
}
