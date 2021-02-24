using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PaymentSystem.WebService.Models.Response
{
    public class SubscriberResponse
    {
        public int SubscriberId { get; set; }

        public string Name { get; set; }

        public string Surname { get; set; }

        public int SubscriberTypeId { get; set; }

        public string SubscriberTypeName { get; set; }

        public string IdentificationTaxNumber { get; set; }

        public int SubscriptionId { get; set; }

        public string SubscriptionType { get; set; }

        public bool Active { get; set; }

        public string InsertUser { get; set; }

        public DateTime InsertDate { get; set; }

        public string UpdateUser { get; set; }

        public DateTime? UpdateDate { get; set; }
    }
}