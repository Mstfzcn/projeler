using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PaymentSystem.WebService.Models.Request
{
    public class OfficerCheckRequest
    {
        public string UserCode { get; set; }

        public string UserPassword { get; set; }
    }
}