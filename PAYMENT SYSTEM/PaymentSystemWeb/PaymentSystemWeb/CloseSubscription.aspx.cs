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
    public partial class CloseSubscription : System.Web.UI.Page
    {
        public static SubscriberResponse Subscriber = null;

        protected void Page_Load(object sender, EventArgs e)
        {
            LabelWarning.Text = "";
            LabelMsg.Text = "";
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

            Subscriber = WebServiceHelpers.GetUserSubscriber(new SubscriberRequest()
            {
                IdentificationTaxNumber = IdentificationTaxNumberTextBox.Text.Trim()
            });

            if (Subscriber.SubscriberId > 0)
            {
                FillGrid();
            }
            else
            {
                LabelWarning.Text = "Abone Bulunamadı!";
            }
        }

        protected void CloseSubscribtionButton_Click(object sender, EventArgs e)
        {
            List<int> SelectedSubscriberIdList = new List<int>();
            foreach (GridViewRow item in GridViewSubscriber.Rows)
            {
                CheckBox chk = (CheckBox)item.FindControl("CheckBoxSelect");
                if (chk != null)
                {
                    if (chk.Checked)
                    {
                        int SubscriberId = Convert.ToInt32(item.Cells[1].Text);
                        SelectedSubscriberIdList.Add(SubscriberId);
                    }
                }
            }

            if (SelectedSubscriberIdList.Count == 0)
            {
                LabelWarning.Text = "Abone Seçiniz!";
                return;
            }
            else if(SelectedSubscriberIdList.Count > 1)
            {
                LabelWarning.Text = "1 Aboneden Fazla Seçim Yapılamaz!";
                return;
            }
            else
            {
                OfficerCheckResponse UserInfo = (OfficerCheckResponse)Session["UserInfo"];
                int TotalAmount = 0;

                foreach (int SubscriberId in SelectedSubscriberIdList)
                {
                    TotalAmount = WebServiceHelpers.GetInvoiceAllUnpaidTotalAmount(SubscriberId);

                    if(TotalAmount > 0)
                    {
                        string msg = TotalAmount.ToString() + " TL tutarında abone borcu bulunmaktadır. Aboneden tutarı tahsil etmeniz gerekmektedir. Tahsilata devam etmek istiyor musunuz?";
                        LabelMsg.Text = "<script language='javascript'>" + Environment.NewLine + "if(window.confirm('" + msg + "')) document.location = 'SubscriberPayBill.aspx';</script>";
                    }
                    else
                    {
                        string msg = "Borç Bulunmamaktadır. Depozito İade Edebilirsiniz. Abonelik Kapatılıyor.";
                        LabelMsg.Text = "<script language='javascript'>" + Environment.NewLine + "if(window.confirm('" + msg + "')) document.location = 'CloseSubscription.aspx';</script>";

                        bool Result = WebServiceHelpers.CloseSubscription(new CloseSubscriptionRequest()
                        {
                            SubscriberId = SubscriberId,
                            UpdateUser = UserInfo.UserCode
                        });

                        LabelWarning.Text = "Abonelik Kapatıldı";
                    }
                }

                FillGrid();
            }
        }

        public void FillGrid()
        {
            List<SubscriberResponse> SubscriberResponseList = new List<SubscriberResponse>();
            SubscriberResponseList.Add(Subscriber);

            GridViewSubscriber.DataSource = SubscriberResponseList;
            GridViewSubscriber.DataBind();
        }

        protected void ButtonLogOut_Click(object sender, EventArgs e)
        {
            Session["UserInfo"] = null;
            Response.Redirect("LoginOfficer.aspx");
        }
    }
}