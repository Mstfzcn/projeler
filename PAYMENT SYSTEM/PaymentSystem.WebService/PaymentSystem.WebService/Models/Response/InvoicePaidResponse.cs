using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PaymentSystem.WebService.Models.Response
{
    public class InvoicePaidResponse
    {
        public int InvoiceId { get; set; }

        public int SubscriberId { get; set; }

        public string NameSurname { get; set; }

        public int SubscriptionId { get; set; }

        public string SubscriptionType { get; set; }

        public int InvoiceAmount { get; set; }

        public DateTime CutOffDate { get; set; }

        public DateTime FinalPaymentDate { get; set; }

        public string InsertUser { get; set; }

        public DateTime InsertDate { get; set; }

        public string UpdateUser { get; set; }

        public DateTime? UpdateDate { get; set; }
    }
}