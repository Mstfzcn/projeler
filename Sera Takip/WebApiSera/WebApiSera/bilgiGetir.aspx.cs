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
    public partial class bilgiGetir : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
                DataTable dt = new DataTable();

                //VeriTabanı Bağlan Veriyi DataTable'ye at
                MySqlConnection conn = new MySqlConnection("Server=185.87.123.67;Database=serabilgi;Uid=stjyr_mustafa;Pwd=q1w2E3r4;CharSet=utf8;");
                conn.Open();
                MySqlDataAdapter da = new MySqlDataAdapter("SELECT * FROM serabilgi", conn);
                da.Fill(dt);
                conn.Close();
                conn.Dispose();

                string json = "{ \"seralar\" : [";
                foreach (DataRow item in dt.Rows)
                {
                    json += "{ \"seraAd\" : " + "\"" + item["seraAd"] + "\"" + ", \"seraSicaklik\" : " + item["seraSicaklik"] + "},";
                }
                json = json.Substring(0, json.Length - 1);
                json += "]}";

                Response.ContentType = "application/json";
                Response.Write(json);
        }
    }
}