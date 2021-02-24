using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PaymentSystem.WebService.Constants
{
    public class SQLConstants
    {
        public static readonly string SP_GET_USER_OFFICER_CHECK = "SP_GET_USER_OFFICER_CHECK";

        public static readonly string SP_GET_USER_SUBSCRIBER_CHECK = "SP_GET_USER_SUBSCRIBER_CHECK";

        public static readonly string SP_GET_USER_SUBSCRIBER = "SP_GET_USER_SUBSCRIBER";

        public static readonly string SP_GET_INVOICE_ALL_UNPAID = "SP_GET_INVOICE_ALL_UNPAID";

        public static readonly string SP_GET_INVOICE_PAID = "SP_GET_INVOICE_PAID";

        public static readonly string SP_INSERT_SUBSCRIBER = "SP_INSERT_SUBSCRIBER";

        public static readonly string SP_UPDATE_INVOICE_PAY = "SP_UPDATE_INVOICE_PAY";

        public static readonly string SP_CLOSE_SUBSCRIPTION = "SP_CLOSE_SUBSCRIPTION";

        public static readonly string SP_GET_ALL_SUBSCRIBER_TYPE = "SP_GET_ALL_SUBSCRIBER_TYPE";

        public static readonly string SP_GET_ALL_SUBSCRIPTION = "SP_GET_ALL_SUBSCRIPTION";

        public static readonly string SP_GET_INVOICE_ALL_UNPAID_TOTAL_AMOUNT = "SP_GET_INVOICE_ALL_UNPAID_TOTAL_AMOUNT";
    }
}