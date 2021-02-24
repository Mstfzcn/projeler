using PaymentSystemWeb.PaymentSystemWebService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PaymentSystemWeb.Models.Data
{
    public class WebServiceHelpers
    {
        public static OfficerCheckResponse GetUserOfficerCheck(OfficerCheckRequest request)
        {
            Service client = new Service();
            OfficerCheckResponse response = client.GetUserOfficerCheck(request);

            return response;
        }

        public static SubscriberCheckResponse GetUserSubscriberCheck(SubscriberCheckRequest request)
        {
            Service client = new Service();
            SubscriberCheckResponse response = client.GetUserSubscriberCheck(request);

            return response;
        }

        public static SubscriberResponse GetUserSubscriber(SubscriberRequest request)
        {
            Service client = new Service();
            SubscriberResponse response = client.GetUserSubscriber(request);

            return response;
        }

        public static bool InsertSubscriber(InsertSubscriberRequest request)
        {
            Service client = new Service();
            bool response = client.InsertSubscriber(request);

            return response;
        }

        public static bool UpdateInvoicePay(UpdateInvoicePayRequest request)
        {
            Service client = new Service();
            bool response = client.UpdateInvoicePay(request);

            return response;
        }

        public static List<InvoiceAllUnpaidResponse> GetInvoiceAllUnpaid(int SubscriberId)
        {
            Service client = new Service();
            List<InvoiceAllUnpaidResponse> response = client.GetInvoiceAllUnpaid(SubscriberId).ToList();

            return response;
        }

        public static List<InvoicePaidResponse> GetInvoicePaid(int SubscriberId)
        {
            Service client = new Service();
            List<InvoicePaidResponse> response = client.GetInvoicePaid(SubscriberId).ToList();

            return response;
        }

        public static bool CloseSubscription(CloseSubscriptionRequest request)
        {
            Service client = new Service();
            bool response = client.CloseSubscription(request);

            return response;
        }

        public static List<SubscriberTypeResponse> GetAllSubscriberType()
        {
            Service client = new Service();
            List<SubscriberTypeResponse> response = client.GetAllSubscriberType().ToList();

            return response;
        }

        public static List<SubscriptionResponse> GetAllSubscription()
        {
            Service client = new Service();
            List<SubscriptionResponse> response = client.GetAllSubscription().ToList();

            return response;
        }

        public static int GetInvoiceAllUnpaidTotalAmount(int SubscriberId)
        {
            Service client = new Service();
            int response = client.GetInvoiceAllUnpaidTotalAmount(SubscriberId);

            return response;
        }
    }
}