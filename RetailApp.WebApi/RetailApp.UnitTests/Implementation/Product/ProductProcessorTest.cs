using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using Moq;
using NUnit.Framework;
using RetailApp.BusinessLogic.Implementation.Discount;
using RetailApp.Common.Infrastructure.Common.Enum;
using RetailApp.Common.Infrastructure.Common.Interfaces.Discount;
using RetailApp.Common.Infrastructure.Common.Interfaces.Factory;
using RetailApp.Common.Infrastructure.Common.Interfaces.Order;
using RetailApp.Common.Infrastructure.Common.Interfaces.Product;
using RetailApp.Common.Infrastructure.Common.Models;
using RetailApp.WebApi.Controllers;

namespace RetailApp.UnitTests.Implementation.Product
{
    [TestFixture]
    public class ProductProcessorTest : ApiController
    {
        private BusinessLogic.Implementation.Product.ProductProcessor _product;
        private readonly Mock<IDiscountInvoker> _discountInvokerMock = new Mock<IDiscountInvoker>();
        private readonly Mock<IDiscount> _discountMock = new Mock<IDiscount>();
        private ProductOrderMappingModel _productModel = new ProductOrderMappingModel();
        private OrderModel _orderModel = new OrderModel();

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
