using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MySql.Data.MySqlClient;

namespace personelYonetimApi
{
    public partial class personelBilgi : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["kAdi"] != null && Request.QueryString["kAdi"] != "")
            {
                Response.Clear();
                Response.ClearContent();
                Response.ClearHeaders();

                string kAdi = Request.QueryString["kAdi"];

                string strSonuc = "";

                try
                {
                    string conStr = "Server=185.87.123.67;Database=kayra_mustafa;Uid=stjyr_mustafa;Pwd=q1w2E3r4;CharSet=utf8;"; //Projenin kullanacağı veri tabanının bulunduğu sunucu ve veri tabanı bilgileri

                    MySqlConnection connection = new MySqlConnection(conStr);
                    connection.Open();

                    string sorgu = "Select kAdi, sifre, soyad, unvan, gorev, sonTarih From personel Where kAdi=@kAdi";

                    MySqlCommand cmd = new MySqlCommand(sorgu, connection);
                    cmd.Parameters.AddWithValue("@kAdi", kAdi);

                    MySqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        var nes = new
                        {
                            kAdi = reader["kAdi"].ToString(),
                            sifre = reader["sifre"].ToString(),
                            soyad = reader["soyad"].ToString(),
                            unvan = reader["unvan"].ToString(),
                            gorev = reader["gorev"].ToString(),
                            sonTarih = reader["sonTarih"].ToString(),
                        };
                        strSonuc = new System.Web.Script.Serialization.JavaScriptSerializer().Serialize(nes);
                    }
                }
                catch (Exception ex)
                {
                    strSonuc = "Hata : " + ex.Message;
                }

                Response.Write(strSonuc);
            }
        }
    }
}