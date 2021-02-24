using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PaymentSystem.WebService.Models.Request
{
    public class UpdateInvoicePayRequest
    {
        public int InvoiceId { get; set; }

        public string UpdateUser { get; set; }
    }
}