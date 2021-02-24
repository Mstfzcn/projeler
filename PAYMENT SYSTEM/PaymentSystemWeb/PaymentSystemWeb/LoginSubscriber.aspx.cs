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
    public partial class LoginSubscriber : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                var SubscriberTypes = WebServiceHelpers.GetAllSubscriberType();

                RadioButtonListCustomer.Items.Clear();
                foreach(SubscriberTypeResponse SubscriberType in SubscriberTypes)
                {
                    RadioButtonListCustomer.Items.Add(new ListItem(SubscriberType.TypeName, SubscriberType.SubscriberTypeId.ToString()));
                }
                RadioButtonListCustomer.SelectedValue = "1";
            }
            LabelWarning.Text = "";
        }

        protected void LoginButton_Click(object sender, EventArgs e)
        {
            if (IdentificationTaxNumberTextBox.Text.Trim().Equals("") || PasswordTextBox.Text.Equals(""))
            {
                LabelWarning.Text = "Giriş Başarısız!";
                return;
            }

            Session["UserInfo"] = null;
            var UserInfo = WebServiceHelpers.GetUserSubscriberCheck(new SubscriberCheckRequest()
            {
                IdentificationTaxNumber = IdentificationTaxNumberTextBox.Text.Trim(),
                UserPassword = PasswordTextBox.Text,
                SubscriberTypeId = Convert.ToInt32(RadioButtonListCustomer.SelectedItem.Value)
            });

            if (UserInfo.SubscriberId > 0)
            {
                Session["UserInfo"] = UserInfo;
                Response.Redirect("IndexSubscriber.aspx");
            }
            else
            {
                Session["UserInfo"] = null;
                LabelWarning.Text = "Giriş Başarısız!";
            }
        }

        protected void RadioButtonListCustomer_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (RadioButtonListCustomer.SelectedItem.Value.Equals("1"))
                Label2.Text = "T.C. Kimlik Numarası";
            else if (RadioButtonListCustomer.SelectedItem.Value.Equals("2"))
                Label2.Text = "Vergi Numarası";
        }
    }
}