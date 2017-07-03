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
    public partial class DealerPanel : Form
    {
        public DealerPanel()
        {
            InitializeComponent();
        }

        private void DealerPanel_Load(object sender, EventArgs e)
        {
            DealerPanel.gridDoldur(dataGridViewStok);
        }

        public static void gridDoldur(DataGridView dgv)
        {
            SqlConnection con = DAO.getCon();

            SqlDataAdapter da = new SqlDataAdapter("Select P.productId [Ürün ID], P.mark [Marka], P.model [Model], PC.category [Kategori], W.warehouseName [Depo Adı], P.unitPrice [Birim Fiyat (TL)], P.stockQuantity [Stok Miktar] From Products P Left Join ProductCategory PC On P.categoryId=PC.categoryId Left Join Warehouse W On P.warehouseId=W.warehouseId", con);

            DataSet ds = new DataSet();

            try
            {
                con.Open();

                da.Fill(ds, "Products");

                dgv.DataSource = ds.Tables["Products"];

                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata : " + ex.Message);
            }
        }

        private void dataGridViewStok_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                txtBoxUrunId.Text = dataGridViewStok.Rows[e.RowIndex].Cells[0].Value.ToString();
                pictureBoxUrunResim.Image = Image.FromFile(AdminPanel.getImagePath(Convert.ToInt32(txtBoxUrunId.Text)));
            }
            catch (Exception)
            {
                
            }
        }

        private void btnSiparis_Click(object sender, EventArgs e)
        {
            int toplamTutar = AdminPanel.getUrunFiyat(Convert.ToInt32(txtBoxUrunId.Text)) * Convert.ToInt32(txtBoxAdet.Text);

            int kalanMiktar = getUrunAdet(Convert.ToInt32(txtBoxUrunId.Text)) - Convert.ToInt32(txtBoxAdet.Text);

            if (kalanMiktar >= 0)
            {
                SqlConnection con = DAO.getCon();

                SqlCommand cmdStok = new SqlCommand("Update Products Set stockQuantity=@stokMiktar Where productId=@urunId", con);
                cmdStok.Parameters.AddWithValue("@stokMiktar", kalanMiktar);
                cmdStok.Parameters.AddWithValue("@urunId", Convert.ToInt32(txtBoxUrunId.Text));

                SqlCommand cmdSiparis = new SqlCommand("Insert Into ProductOrder(productId, quantity, dealerId, orderDate, orderStatus) Values(@urunId, @adet, @bayiId, @siparisTarih, @siparisDurum)", con);
                cmdSiparis.Parameters.AddWithValue("@urunId", Convert.ToInt32(txtBoxUrunId.Text));
                cmdSiparis.Parameters.AddWithValue("@adet", Convert.ToInt32(txtBoxAdet.Text));
                cmdSiparis.Parameters.AddWithValue("@bayiId", getBayiId(LoginPanel.id));
                DateTime now = DateTime.Now;
                cmdSiparis.Parameters.AddWithValue("@siparisTarih", now.ToString());
                cmdSiparis.Parameters.AddWithValue("@siparisDurum", "Beklemede");

                try
                {
                    con.Open();

                    int sonucStok = cmdStok.ExecuteNonQuery();
                    int sonucSiparis = cmdSiparis.ExecuteNonQuery();

                    if (sonucStok > 0 && sonucSiparis > 0)
                    {
                        MessageBox.Show("Sipariş İşlemi Tamamlandı");
                        AdminPanel.gridDoldur(dataGridViewStok);
                    }
                    else
                    {
                        MessageBox.Show("Sipariş Başarısız!");
                    }

                    con.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        public static int getBayiId(int kisiId)
        {
            int bayiId = 0;

            SqlConnection con = DAO.getCon();

            SqlCommand cmd = new SqlCommand("Select dealerId From Persons Where personId=@kisiId", con);
            cmd.Parameters.AddWithValue("@kisiId", kisiId);

            try
            {
                con.Open();

                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    bayiId = Convert.ToInt32(dr["dealerId"].ToString());
                }

                dr.Close();
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            return bayiId;
        }

        public static int getUrunAdet(int urunId)
        {
            int urunAdet = 0;

            SqlConnection con = DAO.getCon();

            SqlCommand cmd = new SqlCommand("Select stockQuantity From Products Where productId=@urunId", con);
            cmd.Parameters.AddWithValue("@urunId", urunId);

            try
            {
                con.Open();

                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    urunAdet = Convert.ToInt32(dr["stockQuantity"].ToString());
                }

                dr.Close();
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            return urunAdet;
        }
    }
}
