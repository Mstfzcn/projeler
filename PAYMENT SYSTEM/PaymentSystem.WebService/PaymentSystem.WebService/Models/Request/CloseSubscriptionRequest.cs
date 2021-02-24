using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PaymentSystem.WebService.Models.Request
{
    public class CloseSubscriptionRequest
    {
        public int SubscriberId { get; set; }

        public string UpdateUser { get; set; }
    }
}