using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApiSera
{
    public partial class bilgiGuncelle : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["seraAd"] != null && Request.QueryString["seraAd"] != "")
            {
                MySqlConnection conn = new MySqlConnection("Server=185.87.123.67;Database=kayra_mustafa;Uid=stjyr_mustafa;Pwd=q1w2E3r4;CharSet=utf8;");
                conn.Open();
                MySqlCommand cmd = new MySqlCommand("Update serabilgi Set seraSicaklik='"+Request.QueryString["seraSicaklik"]+"' Where seraAd='"+Request.QueryString["seraAd"]+"' ", conn);
                cmd.ExecuteNonQuery();
                conn.Close();
                conn.Dispose();
            }
        }
    }
}