using PaymentSystemWeb.Models.Data;
using PaymentSystemWeb.PaymentSystemWebService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PaymentSystemWeb
{
    public partial class PaidInvoicesExtracts : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
                FillGrid();
        }

        protected void Menu1_MenuItemClick(object sender, MenuEventArgs e)
        {
            Response.Redirect(e.Item.Value);
        }

        public void FillGrid()
        {
            SubscriberCheckResponse UserInfo = (SubscriberCheckResponse)Session["UserInfo"];

            var InvoiceAllUnpaidList = WebServiceHelpers.GetInvoicePaid(UserInfo.SubscriberId).ToList();

            if (InvoiceAllUnpaidList.Count > 0)
            {
                GridViewInvoice.DataSource = InvoiceAllUnpaidList;
                GridViewInvoice.DataBind();
            }
            else
            {
                GridViewInvoice.DataSource = null;
                GridViewInvoice.DataBind();
            }
        }

        protected void ButtonLogOut_Click(object sender, EventArgs e)
        {
            Session["UserInfo"] = null;
            Response.Redirect("LoginSubscriber.aspx");
        }
    }
}