using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using log4net;

namespace RetailApp.Common.Infrastructure.Common.Logging
{
    public interface ILogger
    {
        ILog Log { get; set; }
    }
}
