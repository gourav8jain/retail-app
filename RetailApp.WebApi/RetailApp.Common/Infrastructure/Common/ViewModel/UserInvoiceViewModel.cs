using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RetailApp.Common.Infrastructure.Common.ViewModel
{
    public class UserInvoiceViewModel
    {
        public int InvoiceId { get; set; }
        public string InvoiceName { get; set; }
        public double InvoiceAmount { get; set; }
    }
}
