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
    public partial class PayBill : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
                FillGrid();
        }

        protected void Menu1_MenuItemClick(object sender, MenuEventArgs e)
        {
            Response.Redirect(e.Item.Value);
        }

        public void FillGrid()
        {
            SubscriberCheckResponse UserInfo = (SubscriberCheckResponse)Session["UserInfo"];

            LabelWarning.Text = "";

            var InvoiceAllUnpaidList = WebServiceHelpers.GetInvoiceAllUnpaid(UserInfo.SubscriberId).ToList();

            if (InvoiceAllUnpaidList.Count > 0)
            {
                GridViewInvoice.DataSource = InvoiceAllUnpaidList;
                GridViewInvoice.DataBind();
            }
            else
            {
                GridViewInvoice.DataSource = null;
                GridViewInvoice.DataBind();
                LabelWarning.Text = "Ödenmemiş Fatura Bulunamadı!";
            }
        }

        protected void PayButton_Click(object sender, EventArgs e)
        {
            List<int> SelectedInvoiceIdList = new List<int>();
            foreach (GridViewRow item in GridViewInvoice.Rows)
            {
                CheckBox chk = (CheckBox)item.FindControl("CheckBoxSelect");
                if (chk != null)
                {
                    if (chk.Checked)
                    {
                        int InvoiceId = Convert.ToInt32(item.Cells[1].Text);
                        SelectedInvoiceIdList.Add(InvoiceId);
                    }
                }
            }

            if (SelectedInvoiceIdList.Count == 0)
            {
                LabelWarning.Text = "Fatura Seçiniz!";
                return;
            }
            else
            {
                SubscriberCheckResponse UserInfo = (SubscriberCheckResponse)Session["UserInfo"];

                foreach (int InvoiceId in SelectedInvoiceIdList)
                {
                    bool Result = WebServiceHelpers.UpdateInvoicePay(new UpdateInvoicePayRequest()
                    {
                        InvoiceId = InvoiceId,
                        UpdateUser = UserInfo.Name + " " + UserInfo.Surname
                    });
                }

                FillGrid();
                LabelWarning.Text = "Fatura Ödendi";
            }
        }

        protected void ButtonLogOut_Click(object sender, EventArgs e)
        {
            Session["UserInfo"] = null;
            Response.Redirect("LoginSubscriber.aspx");
        }
    }
}