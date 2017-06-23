using RetailApp.Common;
using RetailApp.Common.Interfaces;
using RetailApp.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;

namespace RetailApp.WebApi.Controllers
{
    public class UserController : ApiController
    {
        private IUser user;
        // FOR MOCK-UP DATA
        private List<UserModel> userList = new List<UserModel>();

        public UserController(IUser user)
        {
            this.user = user;
            FillMockData();
        }

        // GET: Retail
        public object GetAll()
        {
            var orders = this.user.GetOrders(new UserModel
            {
                Id = 1,
                AssociationYears = 1,
                Name = "Gourav",
                Orders = new List<OrderModel> {
                  new OrderModel
                  {
                      DiscountedPrice=0,
                      Products=new List<ProductOrderMappingModel>
                      {
                          new ProductOrderMappingModel
                          {
                              Id=1,
                              Cost=30,
                              Name="Item1",
                              Quantity=1,
                              Type=ProductType.NonGrocery,
                          },
                           new ProductOrderMappingModel
                          {
                              Id=2,
                              Cost=100,
                              Name="Item2",
                              Quantity=1,
                              Type=ProductType.NonGrocery,
                          },
                            new ProductOrderMappingModel
                          {
                              Id=1,
                              Cost=200,
                              Name="Item3",
                              Quantity=2,
                              Type=ProductType.NonGrocery,
                          }
                      }
                  }
              }
            });
            return orders;
        }

        // GET: Retail
        public object GetByOrder(int orderId)
        {
            return new object();
        }

        // GET: Retail
        public object GetByUser(int userId)
        {
            return new object();
        }

        private void FillMockData()
        {
            this.userList.Add(new UserModel
            {
                Id = 1,
                AssociationYears = 1,
                Name = "Gourav",
                Orders = new List<OrderModel> {
                  new OrderModel
                  {
                      DiscountedPrice=0,
                      Products=new List<ProductOrderMappingModel>
                      {
                          new ProductOrderMappingModel
                          {
                              Id=1,
                              Cost=30,
                              Name="Item1",
                              Quantity=1,
                              Type=ProductType.NonGrocery
                          }
                      }
                  }
              }
            });
        }
    }
}