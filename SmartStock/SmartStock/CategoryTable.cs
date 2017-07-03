using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Sql;
using System.Data.SqlClient;

namespace SmartStock
{
    public partial class CategoryTable : Form
    {
        public CategoryTable()
        {
            InitializeComponent();
        }

        private void CategoryTable_Load(object sender, EventArgs e)
        {
            SqlConnection con = DAO.getCon();

            SqlDataAdapter da = new SqlDataAdapter("Select categoryId [Kategori ID], category [Kategori] From ProductCategory", con);

            DataSet ds = new DataSet();

            try
            {
                con.Open();

                da.Fill(ds, "ProductCategory");

                dataGridViewKategori.DataSource = ds.Tables["ProductCategory"];

                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata : " + ex.Message);
            }
        }

        private void dataGridViewKategori_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                txtBoxKategoriId.Text = dataGridViewKategori.Rows[e.RowIndex].Cells[0].Value.ToString();
                txtBoxKategori.Text = dataGridViewKategori.Rows[e.RowIndex].Cells[1].Value.ToString();
            }
            catch (Exception)
            {
                
            }
        }

        private string catName="";

        public string CatName
        {
            get { return catName; }
            set { catName = value; }
        }

        private void btnKategoriEkle_Click(object sender, EventArgs e)
        {
            SqlConnection con = DAO.getCon();

            SqlCommand cmd = new SqlCommand("Insert Into ProductCategory(category) Values(@category)", con);
            cmd.Parameters.AddWithValue("@category", txtBoxKategori.Text);

            try
            {
                con.Open();

                int sonuc = cmd.ExecuteNonQuery();

                if (sonuc > 0)
                {
                    MessageBox.Show("Kategori Eklendi");
                    catName = txtBoxKategori.Text;
                }
                else
                {
                    MessageBox.Show("Ekleme Başarısız!");
                }
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata : " + ex.Message);
            }
        }

        private int catId=0;

        public int CatId
        {
            get { return catId; }
            set { catId = value; }
        }

        private void btnKategoriSil_Click(object sender, EventArgs e)
        {
            SqlConnection con = DAO.getCon();

            SqlCommand cmd = new SqlCommand("Delete From ProductCategory Where categoryId=@categoryId", con);
            cmd.Parameters.AddWithValue("@categoryId", Convert.ToInt32(txtBoxKategoriId.Text));

            try
            {
                con.Open();

                int sonuc = cmd.ExecuteNonQuery();

                if (sonuc > 0)
                {
                    MessageBox.Show("Kategori Silindi");
                    catId = Convert.ToInt32(txtBoxKategoriId.Text);
                    catName = txtBoxKategori.Text;
                }
                else
                {
                    MessageBox.Show("Silme Başarısız!");
                }
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata : " + ex.Message);
            }
        }
    }
}
