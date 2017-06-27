// ***********************************************************************
// Assembly         : RetailApp.BusinessLogic
// Author           : gjain
// Created          : 06-23-2017
//
// Last Modified By : gjain
// Last Modified On : 06-23-2017
// ***********************************************************************
// <copyright file="RetailExceptionFilter.cs" company="">
//     Copyright ©  2017
// </copyright>
// <summary></summary>
// ***********************************************************************
using RetailApp.BusinessLogic.Implementation.Logging;
using RetailApp.Common.Infrastructure.Common.Logging;
using System.Web.Http.Filters;

namespace RetailApp.BusinessLogic.Implementation.Filters.Exception
{
    /// <summary>
    /// Class RetailExceptionFilter.
    /// </summary>
    /// <seealso cref="System.Web.Http.Filters.ExceptionFilterAttribute" />
    [RetailExceptionFilter]
    public class RetailExceptionFilter : ExceptionFilterAttribute
    {
        /// <summary>
        /// The logger
        /// </summary>
        private readonly ILogger _logger;

        /// <summary>
        /// Initializes a new instance of the <see cref="RetailExceptionFilter"/> class.
        /// </summary>
        public RetailExceptionFilter(): this(new RetailLogger())
        {   
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="RetailExceptionFilter"/> class.
        /// </summary>
        /// <param name="logger">The logger.</param>
        public RetailExceptionFilter(ILogger logger)
        {
            this._logger = logger;
        }

        /// <summary>
        /// Raises the exception event.
        /// </summary>
        /// <param name="actionExecutedContext">The context for the action.</param>
        public override void OnException(HttpActionExecutedContext actionExecutedContext)
        {
            this._logger.Log.Error(actionExecutedContext.Exception.Message);
        }
    }
}
