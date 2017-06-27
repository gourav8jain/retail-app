// ***********************************************************************
// Assembly         : RetailApp.UnitTests
// Author           : gjain
// Created          : 06-27-2017
//
// Last Modified By : gjain
// Last Modified On : 06-27-2017
// ***********************************************************************
// <copyright file="DiscountInvokerTest.cs" company="">
//     Copyright ©  2017
// </copyright>
// <summary></summary>
// ***********************************************************************
using NUnit.Framework;
using RetailApp.BusinessLogic.Implementation.Discount;
using RetailApp.BusinessLogic.Implementation.Factory;
using RetailApp.Common.Infrastructure.Common.Enum;
using RetailApp.Common.Infrastructure.Common.Interfaces.Discount;
using RetailApp.Common.Infrastructure.Common.Interfaces.Factory;

namespace RetailApp.UnitTests.Factory
{
    /// <summary>
    /// Class DiscountInvokerTest.
    /// </summary>
    public class DiscountInvokerTest
    {
        /// <summary>
        /// The discount invoker
        /// </summary>
        private IDiscountInvoker _discountInvoker;
        /// <summary>
        /// The actual discount
        /// </summary>
        private IDiscount _actualDiscount;
        /// <summary>
        /// The expected discount
        /// </summary>
        private IDiscount _expectedDiscount;

        /// <summary>
        /// Setups this instance.
        /// </summary>
        [OneTimeSetUp]
        public void Setup()
        {
            _discountInvoker = new DiscountInvoker();
        }

        /// <summary>
        /// Gets the discount type for employee test.
        /// </summary>
        [TestCase]
        public void GetDiscountTypeForEmployeeTest()
        {
            _actualDiscount = new EmployeeDiscount();
            _expectedDiscount = _discountInvoker.GetDiscountType(UserType.Employee);
            Assert.AreEqual(_actualDiscount.UserType, _expectedDiscount.UserType);
        }

        /// <summary>
        /// Gets the discount type for customer test.
        /// </summary>
        [TestCase]
        public void GetDiscountTypeForCustomerTest()
        {
            _actualDiscount = new CustomerDiscount();
            _expectedDiscount = _discountInvoker.GetDiscountType(UserType.Customer);
            Assert.AreEqual(_actualDiscount.UserType, _expectedDiscount.UserType);
        }

        /// <summary>
        /// Gets the discount type for affilate test.
        /// </summary>
        [TestCase]
        public void GetDiscountTypeForAffilateTest()
        {
            _actualDiscount = new AffilateDiscount();
            _expectedDiscount = _discountInvoker.GetDiscountType(UserType.Afiliate);
            Assert.AreEqual(_actualDiscount.UserType, _expectedDiscount.UserType);
        }

    }
}
