// ***********************************************************************
// Assembly         : RetailApp.Common
// Author           : gjain
// Created          : 06-23-2017
//
// Last Modified By : gjain
// Last Modified On : 06-23-2017
// ***********************************************************************
// <copyright file="ILogger.cs" company="">
//     Copyright ©  2017
// </copyright>
// <summary></summary>
// ***********************************************************************
using log4net;

namespace RetailApp.Common.Infrastructure.Common.Logging
{
    /// <summary>
    /// Interface ILogger
    /// </summary>
    public interface ILogger
    {
        /// <summary>
        /// Gets or sets the log.
        /// </summary>
        /// <value>The log.</value>
        ILog Log { get; set; }
    }
}
