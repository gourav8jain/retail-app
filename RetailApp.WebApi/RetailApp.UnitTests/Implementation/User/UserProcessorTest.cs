// ***********************************************************************
// Assembly         : RetailApp.UnitTests
// Author           : gjain
// Created          : 06-27-2017
//
// Last Modified By : gjain
// Last Modified On : 06-27-2017
// ***********************************************************************
// <copyright file="UserProcessorTest.cs" company="">
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
using RetailApp.Common.Infrastructure.Common.Interfaces.Order;
using RetailApp.Common.Infrastructure.Common.Models;
using System.Collections.Generic;
using System.Web.Http;

namespace RetailApp.UnitTests.Implementation.User
{
    /// <summary>
    /// Class UserProcessorTest.
    /// </summary>
    /// <seealso cref="System.Web.Http.ApiController" />
    [TestFixture]
    public class UserProcessorTest : ApiController
    {
        /// <summary>
        /// The user
        /// </summary>
        private BusinessLogic.Implementation.User.UserProcesser _user;
        /// <summary>
        /// The order mock
        /// </summary>
        private readonly Mock<IOrder> _orderMock = new Mock<IOrder>();
        /// <summary>
        /// The discount invoker mock
        /// </summary>
        private readonly Mock<IDiscountInvoker> _discountInvokerMock = new Mock<IDiscountInvoker>();
        /// <summary>
        /// The discount mock
        /// </summary>
        private readonly Mock<IDiscount> _discountMock = new Mock<IDiscount>();
        /// <summary>
        /// The user model
        /// </summary>
        private UserModel _userModel = new UserModel();
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

        /// <summary>
        /// Gets the orders test.
        /// </summary>
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
