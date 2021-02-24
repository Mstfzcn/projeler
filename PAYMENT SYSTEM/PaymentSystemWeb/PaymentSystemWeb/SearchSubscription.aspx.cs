using PaymentSystemWeb.Models.Data;
using PaymentSystemWeb.PaymentSystemWebService;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PaymentSystemWeb
{
    public partial class SearchSubscription : System.Web.UI.Page
    {
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
            if(IdentificationTaxNumberTextBox.Text.Trim().Equals(""))
            {
                GridViewSubscriber.DataSource = null;
                GridViewSubscriber.DataBind();
                LabelWarning.Text = "T.C. Kimlik/Vergi Numarası Giriniz!";
                return;
            }

            var Subscriber = WebServiceHelpers.GetUserSubscriber(new SubscriberRequest()
            {
                IdentificationTaxNumber = IdentificationTaxNumberTextBox.Text.Trim()
            });

            if(Subscriber.SubscriberId > 0)
            {
                List<SubscriberResponse> SubscriberResponseList = new List<SubscriberResponse>();
                SubscriberResponseList.Add(Subscriber);

                GridViewSubscriber.DataSource = SubscriberResponseList;
                GridViewSubscriber.DataBind();
            }
            else
            {
                GridViewSubscriber.DataSource = null;
                GridViewSubscriber.DataBind();
                LabelWarning.Text = "Abone Bulunamadı!";
            }
        }

        protected void ButtonLogOut_Click(object sender, EventArgs e)
        {
            Session["UserInfo"] = null;
            Response.Redirect("LoginOfficer.aspx");
        }
    }
}