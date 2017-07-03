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
    public partial class WarehouseTable : Form
    {
        public WarehouseTable()
        {
            InitializeComponent();
        }

        private void WarehouseTable_Load(object sender, EventArgs e)
        {
            SqlConnection con = DAO.getCon();

            SqlDataAdapter da = new SqlDataAdapter("Select warehouseId [Depo ID], warehouseName [Depo Adı], fieldSize [Alan (m2)], city [Şehir], address [Adres] From Warehouse", con);

            DataSet ds = new DataSet();

            try
            {
                con.Open();

                da.Fill(ds, "Warehouse");

                dataGridViewDepo.DataSource = ds.Tables["Warehouse"];

                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata : " + ex.Message);
            }
        }

        private void dataGridViewDepo_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                txtBoxDepoId.Text = dataGridViewDepo.Rows[e.RowIndex].Cells[0].Value.ToString();
                txtBoxDepoAd.Text = dataGridViewDepo.Rows[e.RowIndex].Cells[1].Value.ToString();
                txtBoxAlan.Text = dataGridViewDepo.Rows[e.RowIndex].Cells[2].Value.ToString();
                txtBoxSehir.Text = dataGridViewDepo.Rows[e.RowIndex].Cells[3].Value.ToString();
                richTextBoxAdres.Text = dataGridViewDepo.Rows[e.RowIndex].Cells[4].Value.ToString();
            }
            catch (Exception)
            {
                
            }
        }

        private string whName = "";

        public string WhName
        {
            get { return whName; }
            set { whName = value; }
        }

        private void btnDepoEkle_Click(object sender, EventArgs e)
        {
            SqlConnection con = DAO.getCon();

            SqlCommand cmd = new SqlCommand("Insert Into Warehouse(warehouseName, fieldSize, city, address) Values(@depoAd, @alan, @sehir, @adres)", con);
            cmd.Parameters.AddWithValue("@depoAd", txtBoxDepoAd.Text);
            cmd.Parameters.AddWithValue("@alan", txtBoxAlan.Text);
            cmd.Parameters.AddWithValue("@sehir", txtBoxSehir.Text);
            cmd.Parameters.AddWithValue("@adres", richTextBoxAdres.Text);

            try
            {
                con.Open();

                int sonuc = cmd.ExecuteNonQuery();

                if (sonuc > 0)
                {
                    MessageBox.Show("Depo Eklendi");
                    whName = txtBoxDepoAd.Text;
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

        private int whId = 0;

        public int WhId
        {
            get { return whId; }
            set { whId = value; }
        }

        private void btnDepoSil_Click(object sender, EventArgs e)
        {
            SqlConnection con = DAO.getCon();

            SqlCommand cmd = new SqlCommand("Delete From Warehouse Where warehouseId=@depoId", con);
            cmd.Parameters.AddWithValue("@depoId", txtBoxDepoId.Text);

            try
            {
                con.Open();

                int sonuc = cmd.ExecuteNonQuery();

                if (sonuc > 0)
                {
                    MessageBox.Show("Depo Silindi");
                    whId = Convert.ToInt32(txtBoxDepoId.Text);
                    whName = txtBoxDepoAd.Text;
                }
                else
                {
                    MessageBox.Show("Silme Başarısız!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata : " + ex.Message);
            }
        }
    }
}
