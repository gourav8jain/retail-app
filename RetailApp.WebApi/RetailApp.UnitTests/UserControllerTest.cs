using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using Moq;
using NUnit.Framework;
using RetailApp.BusinessLogic.Implementation.Factory;
using RetailApp.BusinessLogic.Implementation.Order;
using RetailApp.BusinessLogic.Implementation.Product;
using RetailApp.BusinessLogic.Implementation.User;
using RetailApp.Common.Infrastructure.Common.Enum;
using RetailApp.Common.Infrastructure.Common.Interfaces.User;
using RetailApp.Common.Infrastructure.Common.Models;
using RetailApp.Common.Infrastructure.Common.ViewModel;
using RetailApp.WebApi.Controllers;

namespace RetailApp.UnitTests
{
    [TestFixture]
    public class UserControllerTest : ApiController
    {
        private UserModel _userModel;
        private UserController _userController;
        private Mock<IUser> _userMock = new Mock<IUser>();

        [TestCase]
        public void GetInvoiceTest()
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
            var userModelObject = new UserModel
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
            _userMock.Setup(x => x.GetOrders(_userModel)).Returns(userModelObject);
            _userController = new UserController(_userMock.Object);
            double actualResult = _userController.GetInvoice(_userModel).ToList()[0].InvoiceAmount;
            double expectedResult = 470;
            Assert.AreEqual(actualResult, expectedResult);
        }
    }
}
