using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;
using Newtonsoft.Json.Linq;
using MySql.Data.MySqlClient;
using System.Data;

namespace SeraTakip.Controllers
{
    public class HomeController : Controller
    {
        public static Bilgiler bilgilerimiz = new Bilgiler();
        // GET: Home
        public ActionResult Index()
        {
            HomeController bilgiler = new HomeController();

            while (true)
            {
                bilgiler.sicaklikGuncelle("AnaSera");

                string sicaklik = bilgilerimiz.seraSicaklik.ToString();
                ViewBag.Veri = sicaklik;

                return View();

                System.Threading.Thread.Sleep(5000);
            }
        }

        public ActionResult Istatistik()
        {
            return View();
        }

        //public void bilgileriGetir(int ID)
        //{
        //    string cs = ConfigurationManager.ConnectionStrings["DBBaglan"].ConnectionString;

        //    using (SqlConnection con = new SqlConnection(cs))
        //    {
        //        SqlCommand cmd = new SqlCommand("SP_BilgileriGetir", con);
        //        cmd.CommandType = System.Data.CommandType.StoredProcedure;

        //        SqlParameter parameter = new SqlParameter();
        //        parameter.ParameterName = "@ID";
        //        parameter.Value = ID;

        //        cmd.Parameters.Add(parameter);
        //        con.Open();
        //        SqlDataReader dr = cmd.ExecuteReader();
        //        while (dr.Read())
        //        {
        //            bilgilerimiz.ID = Convert.ToInt32(dr["ID"].ToString());
        //            bilgilerimiz.seraAd = dr["seraAd"].ToString();
        //            bilgilerimiz.seraSicaklik = Convert.ToInt32(dr["seraSicaklik"].ToString());
        //        }
        //    }
        //}

        public void sicaklikGuncelle(string seraAd)
        {
            MySqlConnection conn = new MySqlConnection("Server=185.87.123.67;Database=kayra_mustafa;Uid=stjyr_mustafa;Pwd=q1w2E3r4;CharSet=utf8;");
            conn.Open();

            MySqlCommand cmd = new MySqlCommand("SELECT seraSicaklik FROM serabilgi Where seraAd = '" + seraAd + "'", conn);

            MySqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                bilgilerimiz.seraSicaklik = Convert.ToInt32(dr["seraSicaklik"].ToString());
            }

            conn.Close();
            conn.Dispose();
        }
    }
}