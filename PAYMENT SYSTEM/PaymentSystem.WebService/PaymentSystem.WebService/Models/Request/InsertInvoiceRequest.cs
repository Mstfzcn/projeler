using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PaymentSystem.WebService.Models.Request
{
    public class InsertInvoiceRequest
    {
        public int SubscriberId { get; set; }

        public int SubscriptionId { get; set; }
    }
}