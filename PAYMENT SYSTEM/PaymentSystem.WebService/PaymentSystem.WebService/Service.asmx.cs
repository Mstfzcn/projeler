using PaymentSystem.WebService.Globals;
using PaymentSystem.WebService.Models.Request;
using PaymentSystem.WebService.Models.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace PaymentSystem.WebService
{
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    public class Service : System.Web.Services.WebService
    {
        [WebMethod]
        public OfficerCheckResponse GetUserOfficerCheck(OfficerCheckRequest request)
        {
            return DBLayer.GetUserOfficerCheck(request);
        }

        [WebMethod]
        public SubscriberCheckResponse GetUserSubscriberCheck(SubscriberCheckRequest request)
        {
            return DBLayer.GetUserSubscriberCheck(request);
        }

        [WebMethod]
        public SubscriberResponse GetUserSubscriber(SubscriberRequest request)
        {
            return DBLayer.GetUserSubscriber(request);
        }

        [WebMethod]
        public bool InsertSubscriber(InsertSubscriberRequest request)
        {
            return DBLayer.InsertSubscriber(request);
        }

        [WebMethod]
        public bool UpdateInvoicePay(UpdateInvoicePayRequest request)
        {
            return DBLayer.UpdateInvoicePay(request);
        }

        [WebMethod]
        public List<InvoiceAllUnpaidResponse> GetInvoiceAllUnpaid(int SubscriberId)
        {
            return DBLayer.GetInvoiceAllUnpaid(SubscriberId);
        }

        [WebMethod]
        public List<InvoicePaidResponse> GetInvoicePaid(int SubscriberId)
        {
            return DBLayer.GetInvoicePaid(SubscriberId);
        }

        [WebMethod]
        public bool CloseSubscription(CloseSubscriptionRequest request)
        {
            return DBLayer.CloseSubscription(request);
        }

        [WebMethod]
        public List<SubscriberTypeResponse> GetAllSubscriberType()
        {
            return DBLayer.GetAllSubscriberType();
        }

        [WebMethod]
        public List<SubscriptionResponse> GetAllSubscription()
        {
            return DBLayer.GetAllSubscription();
        }

        [WebMethod]
        public int GetInvoiceAllUnpaidTotalAmount(int SubscriberId)
        {
            return DBLayer.GetInvoiceAllUnpaidTotalAmount(SubscriberId);
        }
    }
}
