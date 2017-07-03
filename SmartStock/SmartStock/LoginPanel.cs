using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data.Sql;

namespace SmartStock
{
    public partial class LoginPanel : Form
    {
        public LoginPanel()
        {
            InitializeComponent();
        }

        public static int id;
        public static String password = null;
        private void btnLogin_Click(object sender, EventArgs e)
        {
            id = Convert.ToInt32(txtBoxKID.Text);
            password = txtBoxSifre.Text;

            SqlConnection con = DAO.getCon();

            SqlCommand cmd = new SqlCommand("Select password From Persons Where personId=@id", con);
            cmd.Parameters.AddWithValue("@id", id);

            try
            {
                con.Open();

                SqlDataReader dr = cmd.ExecuteReader();

                String pass = null;
                while (dr.Read())
                {
                    pass = dr["password"].ToString();
                }

                dr.Close();

                cmd.CommandText = "Select authority From Persons P Inner Join PersonDegree PD On P.degreeId=PD.degreeId Where P.personId=@id";

                dr = cmd.ExecuteReader();

                String authority = null;
                while (dr.Read())
                {
                    authority = dr["authority"].ToString().Trim();
                }

                if (pass.Equals(password))
                {
                    if (authority.Equals("Admin"))
                    {
                        this.Hide();
                        AdminPanel ap = new AdminPanel();
                        ap.Show();
                    }
                    else
                    {
                        this.Hide();
                        DealerPanel dp = new DealerPanel();
                        dp.Show();
                    }
                }
                else
                {
                    MessageBox.Show("Hatalı Giriş Yaptınız!");
                }

                dr.Close();
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata : " + ex.Message);
            }
        }

        
    }
}
