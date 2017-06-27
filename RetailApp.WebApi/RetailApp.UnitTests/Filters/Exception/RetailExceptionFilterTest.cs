// ***********************************************************************
// Assembly         : RetailApp.UnitTests
// Author           : gjain
// Created          : 06-27-2017
//
// Last Modified By : gjain
// Last Modified On : 06-27-2017
// ***********************************************************************
// <copyright file="RetailExceptionFilterTest.cs" company="">
//     Copyright ©  2017
// </copyright>
// <summary></summary>
// ***********************************************************************
using NUnit.Framework;
using RetailApp.BusinessLogic.Implementation.Filters.Exception;
using RetailApp.BusinessLogic.Implementation.Logging;
using RetailApp.Common.Infrastructure.Common.Logging;
using System.Web.Http.Filters;

namespace RetailApp.UnitTests.Filters.Exception
{
    /// <summary>
    /// Class RetailExceptionFilterTest.
    /// </summary>
    public class RetailExceptionFilterTest
    {
        /// <summary>
        /// The logger
        /// </summary>
        private ILogger _logger;
        /// <summary>
        /// The retail exception filter
        /// </summary>
        private RetailExceptionFilter _retailExceptionFilter;

        /// <summary>
        /// Setups this instance.
        /// </summary>
        [OneTimeSetUp]
        public void Setup()
        {
            _logger = new RetailLogger();
            _retailExceptionFilter = new RetailExceptionFilter(_logger);
        }

        /// <summary>
        /// Gets the exception test.
        /// </summary>
        [TestCase]
        public void GetExceptionTest()
        {
            var httpException = new HttpActionExecutedContext {Exception = new System.Exception()};
            _retailExceptionFilter.OnException(httpException);
        }
    }
}
