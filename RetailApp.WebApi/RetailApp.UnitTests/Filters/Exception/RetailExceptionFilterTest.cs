using System.Web.Http.Filters;
using NUnit.Framework;
using RetailApp.BusinessLogic.Implementation.Discount;
using RetailApp.BusinessLogic.Implementation.Factory;
using RetailApp.BusinessLogic.Implementation.Filters.Exception;
using RetailApp.BusinessLogic.Implementation.Logging;
using RetailApp.Common.Infrastructure.Common.Enum;
using RetailApp.Common.Infrastructure.Common.Interfaces.Discount;
using RetailApp.Common.Infrastructure.Common.Interfaces.Factory;
using RetailApp.Common.Infrastructure.Common.Logging;

namespace RetailApp.UnitTests.Filters.Exception
{
    public class RetailExceptionFilterTest
    {
        private ILogger _logger;
        private RetailExceptionFilter retailExceptionFilter;

        [OneTimeSetUp]
        public void Setup()
        {
            _logger = new RetailLogger();
            retailExceptionFilter = new RetailExceptionFilter(_logger);
        }

        [TestCase]
        public void GetExceptionTest()
        {
            var httpException = new HttpActionExecutedContext {Exception = new System.Exception()};
            retailExceptionFilter.OnException(httpException);
        }

    }
}
