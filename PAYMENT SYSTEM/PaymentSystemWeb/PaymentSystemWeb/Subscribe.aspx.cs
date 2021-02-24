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
    public partial class Subscribe : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            LabelWarning.Text = "";

            if (!IsPostBack)
            {
                var SubscriberTypes = WebServiceHelpers.GetAllSubscriberType();

                RadioButtonListCustomer.Items.Clear();
                foreach (SubscriberTypeResponse SubscriberType in SubscriberTypes)
                {
                    RadioButtonListCustomer.Items.Add(new ListItem(SubscriberType.TypeName, SubscriberType.SubscriberTypeId.ToString()));
                }
                RadioButtonListCustomer.SelectedValue = "1";

                var SubscriptionTypes = WebServiceHelpers.GetAllSubscription();
                DropDownListSubscriptionType.DataSource = SubscriptionTypes;
                DropDownListSubscriptionType.DataValueField = "SubscriptionId";
                DropDownListSubscriptionType.DataTextField = "SubscriptionType";
                DropDownListSubscriptionType.DataBind();
                DropDownListSubscriptionType.SelectedIndex = 0;
            }
        }

        protected void Menu1_MenuItemClick(object sender, MenuEventArgs e)
        {
            Response.Redirect(e.Item.Value);
        }

        protected void RadioButtonListCustomer_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (RadioButtonListCustomer.SelectedItem.Value.Equals("1"))
                Label2.Text = "T.C. Kimlik Numarası";
            else if (RadioButtonListCustomer.SelectedItem.Value.Equals("2"))
                Label2.Text = "Vergi Numarası";
        }

        protected void SaveButton_Click(object sender, EventArgs e)
        {
            OfficerCheckResponse UserInfo = (OfficerCheckResponse)Session["UserInfo"];

            bool Result = WebServiceHelpers.InsertSubscriber(new InsertSubscriberRequest()
            {
                SubscriberTypeId = Convert.ToInt32(RadioButtonListCustomer.SelectedItem.Value),
                IdentificationTaxNumber = IdentificationTaxNumberTextBox.Text.Trim(),
                UserPassword = PasswordTextBox.Text,
                Name = NameTextBox.Text.Trim(),
                Surname = SurnameTextBox.Text.Trim(),
                SubscriptionId = Convert.ToInt32(DropDownListSubscriptionType.SelectedValue),
                InsertUser = UserInfo.UserCode
            });

            if (Result)
                LabelWarning.Text = "Abone Kayıt Edildi";
            else
                LabelWarning.Text = "Abone Kayıt Edilemedi!";
        }

        protected void ButtonLogOut_Click(object sender, EventArgs e)
        {
            Session["UserInfo"] = null;
            Response.Redirect("LoginOfficer.aspx");
        }
    }
}