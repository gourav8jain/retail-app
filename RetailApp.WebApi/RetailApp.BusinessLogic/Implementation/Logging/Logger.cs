// ***********************************************************************
// Assembly         : RetailApp.BusinessLogic
// Author           : gjain
// Created          : 06-23-2017
//
// Last Modified By : gjain
// Last Modified On : 06-23-2017
// ***********************************************************************
// <copyright file="Logger.cs" company="">
//     Copyright ©  2017
// </copyright>
// <summary></summary>
// ***********************************************************************
using log4net;
using RetailApp.Common.Infrastructure.Common.Logging;

namespace RetailApp.BusinessLogic.Implementation.Logging
{
    /// <summary>
    /// Class RetailLogger.
    /// </summary>
    /// <seealso cref="RetailApp.Common.Infrastructure.Common.Logging.ILogger" />
    public class RetailLogger : ILogger
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="RetailLogger"/> class.
        /// </summary>
        public RetailLogger()
        {
            this.Log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        }

        /// <summary>
        /// Gets or sets the log.
        /// </summary>
        /// <value>The log.</value>
        public ILog Log { get; set; }
    }
}
