using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using log4net;
using RetailApp.Common.Infrastructure.Common.Logging;

namespace RetailApp.BusinessLogic.Implementation.Logging
{
    public class Logger : ILogger
    {
        public Logger()
        {
            this.Log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        }

        public ILog Log { get; set; }
    }
}
