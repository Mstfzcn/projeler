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
    public partial class LoginOfficer : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            LabelWarning.Text = "";
        }

        protected void LoginButton_Click(object sender, EventArgs e)
        {
            if(UserCodeTextBox.Text.Trim().Equals("") || PasswordTextBox.Text.Equals(""))
            {
                LabelWarning.Text = "Giriş Başarısız!";
                return;
            }

            Session["UserInfo"] = null;
            var UserInfo = WebServiceHelpers.GetUserOfficerCheck(new OfficerCheckRequest()
            {
                UserCode = UserCodeTextBox.Text.Trim(),
                UserPassword = PasswordTextBox.Text
            });

            if(UserInfo.OfficerId > 0)
            {
                Session["UserInfo"] = UserInfo;
                Response.Redirect("IndexOfficer.aspx");
            }
            else
            {
                Session["UserInfo"] = null;
                LabelWarning.Text = "Giriş Başarısız!";
            }
        }
    }
}