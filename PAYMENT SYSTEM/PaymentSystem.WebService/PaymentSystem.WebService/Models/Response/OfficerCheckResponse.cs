using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PaymentSystem.WebService.Models.Response
{
    public class OfficerCheckResponse
    {
        public int OfficerId { get; set; }

        public string UserCode { get; set; }

        public string Name { get; set; }

        public string Surname { get; set; }

        public string InsertUser { get; set; }

        public DateTime InsertDate { get; set; }

        public string UpdateUser { get; set; }

        public DateTime? UpdateDate { get; set; }
    }
}