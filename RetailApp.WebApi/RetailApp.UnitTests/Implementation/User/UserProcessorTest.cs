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
using RetailApp.Common.Infrastructure.Common.Interfaces.User;
using RetailApp.Common.Infrastructure.Common.Models;
using RetailApp.WebApi.Controllers;

namespace RetailApp.UnitTests.Implementation.User
{
    [TestFixture]
    public class UserProcessorTest : ApiController
    {
        private BusinessLogic.Implementation.User.UserProcesser _user;
        private readonly Mock<IOrder> _orderMock = new Mock<IOrder>();
        private readonly Mock<IDiscountInvoker> _discountInvokerMock = new Mock<IDiscountInvoker>();
        private readonly Mock<IDiscount> _discountMock = new Mock<IDiscount>();
        private UserModel _userModel = new UserModel();
        private OrderModel _orderModel = new OrderModel();

        [OneTimeSetUp]
        public void Setup()
        {
            _userModel = new UserModel
            {
                Id = 1,
                Name = "Gourav",
                AssociationYears = 1,
                Type = UserType.Employee,
                Orders = new List<OrderModel>
                {
                    new OrderModel
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
                    }
                }
            };
        }

        [TestCase]
        public void GetOrdersTest()
        {

            var userModelMockObject = new UserModel
            {
                Id = 1,
                Name = "Gourav",
                AssociationYears = 1,
                Type = UserType.Employee,
                Orders = new List<OrderModel>
                {
                    new OrderModel
                    {
                        Id = 1,
                        Name = "Order-1",
                        DiscountedPrice = 470,
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
                    }
                }
            };
            _orderMock.Setup(x => x.GetDiscountedOrderPrice(It.IsAny<OrderModel>(), It.IsAny<UserType>(), It.IsAny<int>())).Returns(userModelMockObject.Orders[0].DiscountedPrice);
            _discountInvokerMock.Setup(x => x.GetDiscountType(UserType.Other)).Returns(new FinalDiscount());
            _discountMock.Setup(x => x.GetDiscount(It.IsAny<double>())).Returns(20);
            _user = new BusinessLogic.Implementation.User.UserProcesser(_orderMock.Object, _discountInvokerMock.Object);
            double actualResult = _user.GetOrders(_userModel).Orders[0].DiscountedPrice;
            double expectedResult = 450;
            Assert.AreEqual(actualResult, expectedResult);
        }
    }
}
