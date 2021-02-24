using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PaymentSystem.WebService.Models.Response
{
    public class SubscriptionResponse
    {
        public int SubscriptionId { get; set; }

        public string SubscriptionType { get; set; }

        public string FinalPaymentDay { get; set; }

        public int Deposit { get; set; }

        public string InsertUser { get; set; }

        public DateTime InsertDate { get; set; }

        public string UpdateUser { get; set; }

        public DateTime? UpdateDate { get; set; }
    }
}