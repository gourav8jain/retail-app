using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http.Filters;
using RetailApp.BusinessLogic.Implementation.Logging;
using RetailApp.Common.Infrastructure.Common.Logging;

namespace RetailApp.BusinessLogic.Implementation.Filters.Exception
{
    [RetailExceptionFilter]
    public class RetailExceptionFilter : ExceptionFilterAttribute
    {
        private readonly ILogger _logger;

        public RetailExceptionFilter(): this(new RetailLogger())
        {   
        }

        public RetailExceptionFilter(ILogger logger)
        {
            this._logger = logger;
        }

        public override void OnException(HttpActionExecutedContext actionExecutedContext)
        {
            this._logger.Log.Error(actionExecutedContext.Exception.Message);
        }
    }
}
