using Moq;
using NUnit.Framework;
using RetailApp.Common.Infrastructure.Common.Enum;
using RetailApp.Common.Infrastructure.Common.Interfaces.User;
using RetailApp.Common.Infrastructure.Common.Models;
using RetailApp.WebApi.Controllers;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using RetailApp.Common.Infrastructure.Common.ViewModel;

namespace RetailApp.UnitTests
{
    [TestFixture]
    public class UserControllerTest : ApiController
    {
        private UserModel _userModel;
        private UserController _userController;
        private readonly Mock<IUser> _userMock = new Mock<IUser>();

        [SetUp]
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
        public void GetInvoiceTest()
        {
            var invoiceModel = new List<UserInvoiceViewModel>
            {
                new UserInvoiceViewModel
                {
                    InvoiceAmount = 470,
                    InvoiceId = 1,
                    InvoiceName = "Order-1"
                }
            };

            _userMock.Setup(x => x.GetOrders(It.IsAny<UserModel>())).Returns(invoiceModel);
            _userController = new UserController(_userMock.Object);
            double actualResult = _userController.GetInvoice(_userModel).ToList()[0].InvoiceAmount;
            double expectedResult = 470;
            Assert.AreEqual(actualResult, expectedResult);
        }
    }
}
