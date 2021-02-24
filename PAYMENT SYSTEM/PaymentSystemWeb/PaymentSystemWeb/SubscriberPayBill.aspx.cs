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
    public partial class SubscriberPayBill : System.Web.UI.Page
    {
        public static int SubscriberId = 0;

        protected void Page_Load(object sender, EventArgs e)
        {
            LabelWarning.Text = "";
        }

        protected void Menu1_MenuItemClick(object sender, MenuEventArgs e)
        {
            Response.Redirect(e.Item.Value);
        }

        protected void SearchButton_Click(object sender, EventArgs e)
        {
            if (IdentificationTaxNumberTextBox.Text.Trim().Equals(""))
            {
                LabelWarning.Text = "Abone Bulunamadı!";
                return;
            }

            var Subscriber = WebServiceHelpers.GetUserSubscriber(new SubscriberRequest()
            {
                IdentificationTaxNumber = IdentificationTaxNumberTextBox.Text.Trim()
            });

            SubscriberId = Subscriber.SubscriberId;

            if (SubscriberId > 0)
            {
                FillGrid();
            }
            else
            {
                GridViewInvoice.DataSource = null;
                GridViewInvoice.DataBind();
                LabelWarning.Text = "Aktif Abone Bulunamadı!";
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
                OfficerCheckResponse UserInfo = (OfficerCheckResponse)Session["UserInfo"];

                foreach(int InvoiceId in SelectedInvoiceIdList)
                {
                    bool Result = WebServiceHelpers.UpdateInvoicePay(new UpdateInvoicePayRequest()
                    {
                        InvoiceId = InvoiceId,
                        UpdateUser = UserInfo.UserCode
                    });
                }

                FillGrid();
                LabelWarning.Text = "Fatura Ödendi";
            }
        }

        public void FillGrid()
        {
            LabelWarning.Text = "";

            var InvoiceAllUnpaidList = WebServiceHelpers.GetInvoiceAllUnpaid(SubscriberId).ToList();

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

        protected void ButtonLogOut_Click(object sender, EventArgs e)
        {
            Session["UserInfo"] = null;
            Response.Redirect("LoginOfficer.aspx");
        }
    }
}