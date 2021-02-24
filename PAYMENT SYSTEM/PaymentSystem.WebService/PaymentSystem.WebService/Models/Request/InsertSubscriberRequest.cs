using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PaymentSystem.WebService.Models.Request
{
    public class InsertSubscriberRequest
    {
        public int SubscriberTypeId { get; set; }

        public string IdentificationTaxNumber { get; set; }

        public string UserPassword { get; set; }

        public string Name { get; set; }

        public string Surname { get; set; }

        public int SubscriptionId { get; set; }

        public string InsertUser { get; set; }
    }
}