using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PaymentSystem.WebService.Models.Request
{
    public class SubscriberCheckRequest
    {
        public string IdentificationTaxNumber { get; set; }

        public string UserPassword { get; set; }

        public int SubscriberTypeId { get; set; }
    }
}