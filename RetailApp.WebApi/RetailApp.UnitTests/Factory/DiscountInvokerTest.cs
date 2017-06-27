using System.Collections;
using System.Collections.Generic;
using Moq;
using NUnit.Framework;
using RetailApp.BusinessLogic.Implementation.Discount;
using RetailApp.BusinessLogic.Implementation.Factory;
using RetailApp.BusinessLogic.Implementation.Filters.Exception;
using RetailApp.Common.Infrastructure.Common.Enum;
using RetailApp.Common.Infrastructure.Common.Interfaces.Discount;
using RetailApp.Common.Infrastructure.Common.Interfaces.Factory;
using RetailApp.Common.Infrastructure.Common.Models;

namespace RetailApp.UnitTests.Factory
{
    public class DiscountInvokerTest
    {
        private IDiscountInvoker _discountInvoker;
        private IDiscount _actualDiscount;
        private IDiscount _expectedDiscount;

        [OneTimeSetUp]
        public void Setup()
        {
            _discountInvoker = new DiscountInvoker();
        }

        [TestCase]
        public void GetDiscountTypeForEmployeeTest()
        {
            _actualDiscount = new EmployeeDiscount();
            _expectedDiscount = _discountInvoker.GetDiscountType(UserType.Employee);
            Assert.AreEqual(_actualDiscount.UserType, _expectedDiscount.UserType);
        }

        [TestCase]
        public void GetDiscountTypeForCustomerTest()
        {
            _actualDiscount = new CustomerDiscount();
            _expectedDiscount = _discountInvoker.GetDiscountType(UserType.Customer);
            Assert.AreEqual(_actualDiscount.UserType, _expectedDiscount.UserType);
        }

        [TestCase]
        public void GetDiscountTypeForAffilateTest()
        {
            _actualDiscount = new AffilateDiscount();
            _expectedDiscount = _discountInvoker.GetDiscountType(UserType.Afiliate);
            Assert.AreEqual(_actualDiscount.UserType, _expectedDiscount.UserType);
        }

    }
}
