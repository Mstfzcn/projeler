using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace PaymentSystem.WebService.Models
{
    public class Variables
    {
        public static string PaymentSystemDBConnection
        {
            get
            {
                return ConfigurationManager.ConnectionStrings["PaymentSystemDBConnection"].ConnectionString;
            }
        }
    }
}