// ***********************************************************************
// Assembly         : RetailApp.Common
// Author           : gjain
// Created          : 06-23-2017
//
// Last Modified By : gjain
// Last Modified On : 06-23-2017
// ***********************************************************************
// <copyright file="UserInvoiceViewModel.cs" company="">
//     Copyright ©  2017
// </copyright>
// <summary></summary>
// ***********************************************************************

namespace RetailApp.Common.Infrastructure.Common.ViewModel
{
    /// <summary>
    /// Class UserInvoiceViewModel.
    /// </summary>
    public class UserInvoiceViewModel
    {
        /// <summary>
        /// Gets or sets the invoice identifier.
        /// </summary>
        /// <value>The invoice identifier.</value>
        public int InvoiceId { get; set; }
        /// <summary>
        /// Gets or sets the name of the invoice.
        /// </summary>
        /// <value>The name of the invoice.</value>
        public string InvoiceName { get; set; }
        /// <summary>
        /// Gets or sets the invoice amount.
        /// </summary>
        /// <value>The invoice amount.</value>
        public double InvoiceAmount { get; set; }
    }
}
