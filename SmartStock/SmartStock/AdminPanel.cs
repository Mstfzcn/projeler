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
using System.IO;
using System.Collections;

namespace SmartStock
{
    public partial class AdminPanel : Form
    {
        public AdminPanel()
        {
            InitializeComponent();
        }

        private void AdminPanel_Load(object sender, EventArgs e)
        {
            AdminPanel.gridDoldur(dataGridViewStok);

            AdminPanel.siparisGridDoldur(dataGridViewSiparis);

            AdminPanel.bitenSiparisGridDoldur(dataGridViewSiparisBiten);

            lblSiparisKazanc.Text = AdminPanel.getSiparisKazanc();

            lblSiparisToplamGelir.Text = AdminPanel.getToplamGelir();

            ArrayList kategoriAd = AdminPanel.getKategoriAd();

            int atla = 0;
            foreach (string i in kategoriAd)
            {
                if (atla > 1)
                {
                    comboBoxKategori.Items.Add(i);
                }
                atla++;
            }

            ArrayList depoAd = AdminPanel.getDepoAd();

            atla = 0;
            foreach (string i in depoAd)
            {
                if (atla > 1)
                {
                    comboBoxDepo.Items.Add(i);
                }
            }

            calisanGridDoldur(dataGridViewCalisan);
        }

        public static void gridDoldur(DataGridView dgv)
        {
            SqlConnection con = DAO.getCon();

            SqlDataAdapter da = new SqlDataAdapter("Select P.productId [Ürün ID], P.mark [Marka], P.model [Model], PC.category [Kategori], W.warehouseName [Depo Adı], P.unitPrice [Birim Fiyat (TL)], P.stockQuantity [Stok Miktar], Case When P.criticalStock=1 Then 'Kritik' Else 'Normal' End As [Stok Durumu] From Products P Left Join ProductCategory PC On P.categoryId=PC.categoryId Left Join Warehouse W On P.warehouseId=W.warehouseId", con);

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
                txtBoxMarka.Text = dataGridViewStok.Rows[e.RowIndex].Cells[1].Value.ToString();
                txtBoxModel.Text = dataGridViewStok.Rows[e.RowIndex].Cells[2].Value.ToString();
                comboBoxKategori.Text = dataGridViewStok.Rows[e.RowIndex].Cells[3].Value.ToString();
                comboBoxDepo.Text = dataGridViewStok.Rows[e.RowIndex].Cells[4].Value.ToString();
                txtBoxBirimFiyat.Text = dataGridViewStok.Rows[e.RowIndex].Cells[5].Value.ToString();
                txtBoxStokMiktar.Text = dataGridViewStok.Rows[e.RowIndex].Cells[6].Value.ToString();
                pictureBoxUrun.Image = Image.FromFile(getImagePath(Convert.ToInt32(txtBoxUrunId.Text)));
            }
            catch (Exception)
            {

            }
        }

        public static String getImagePath(int urunId)
        {
            String imagePath = null;

            SqlConnection con = DAO.getCon();

            SqlCommand cmd = new SqlCommand("Select imagePath From Products Where productId=@urunId", con);

            cmd.Parameters.AddWithValue("@urunId", urunId);

            try
            {
                con.Open();

                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    imagePath = dr["imagePath"].ToString().Trim();
                }

                dr.Close();
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata : " + ex.Message);
            }

            return imagePath;
        }

        private void btnKategoriTablo_Click(object sender, EventArgs e)
        {
            CategoryTable ct = new CategoryTable();
            ct.FormClosed += ct_FormClosed;
            ct.Show();
        }

        void ct_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (!(sender as CategoryTable).CatName.Equals(""))
            {
                comboBoxKategori.Items.Add((sender as CategoryTable).CatName);
            }
            if ((sender as CategoryTable).CatId != 0)
            {
                comboBoxKategori.Items.Remove((sender as CategoryTable).CatName);
            }
        }

        private void btnDepoTablo_Click(object sender, EventArgs e)
        {
            WarehouseTable wt = new WarehouseTable();
            wt.FormClosed += wt_FormClosed;
            wt.Show();
        }

        void wt_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (!(sender as WarehouseTable).WhName.Equals(""))
            {
                comboBoxDepo.Items.Add((sender as WarehouseTable).WhName);
            }
            if ((sender as WarehouseTable).WhId != 0)
            {
                comboBoxDepo.Items.Remove((sender as WarehouseTable).WhName);
            }
        }

        public String pathProductImage = "";
        public String nameProductImage = "";
        private void pictureBoxUrun_Click(object sender, EventArgs e)
        {
            openFileDialogProductImage.Title = "Resim Seçiniz";
            openFileDialogProductImage.Filter = "(*.png)|*.png|(*.jpg)|*.jpg";

            if (openFileDialogProductImage.ShowDialog() == DialogResult.OK)
            {
                pictureBoxUrun.Image = Image.FromFile(openFileDialogProductImage.FileName);
            }

            pathProductImage = Path.GetDirectoryName(openFileDialogProductImage.FileName);
            nameProductImage = Path.GetFileName(openFileDialogProductImage.FileName);
        }

        public static String imagePath = null;
        private void btnEkle_Click(object sender, EventArgs e)
        {
            imagePath = "D:/SOFTWARE WOKS/VS PROJECTS/SmartStock/SmartStock/Resources/" + nameProductImage;

            saveFileDialogProductImage.FileName = imagePath;

            pictureBoxUrun.Name = nameProductImage;

            SqlConnection con = DAO.getCon();

            SqlCommand cmd = new SqlCommand("Insert Into Products(mark, model, categoryId, warehouseId, unitPrice, stockQuantity, criticalStock, imagePath) Values(@marka, @model, @kategoriId, @depoId, @birimFiyat, @stokMiktar, @kritikStok, @resimYol)", con);
            cmd.Parameters.AddWithValue("@marka", txtBoxMarka.Text);
            cmd.Parameters.AddWithValue("@model", txtBoxModel.Text);
            cmd.Parameters.AddWithValue("@kategoriId", AdminPanel.getKategoriId(comboBoxKategori.Text));
            cmd.Parameters.AddWithValue("@depoId", AdminPanel.getDepoId(comboBoxDepo.Text));
            cmd.Parameters.AddWithValue("@birimFiyat", Convert.ToInt32(txtBoxBirimFiyat.Text));
            cmd.Parameters.AddWithValue("@stokMiktar", Convert.ToInt32(txtBoxStokMiktar.Text));
            cmd.Parameters.AddWithValue("@kritikStok", 0);
            cmd.Parameters.AddWithValue("@resimYol", imagePath);

            try
            {
                pictureBoxUrun.Image.Save(saveFileDialogProductImage.FileName);

                con.Open();

                int sonuc = cmd.ExecuteNonQuery();

                if (sonuc > 0)
                {
                    AdminPanel.gridDoldur(dataGridViewStok);
                    MessageBox.Show("Ürün Eklendi");
                }
                else
                {
                    MessageBox.Show("Ekleme Başarısız!");
                }

                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata : " + ex.Message + "\nYeni Resim Yükleyin");
            }
        }

        public static int getKategoriId(String kategoriAdi)
        {
            int kategoriId = 0;

            SqlConnection con = DAO.getCon();

            SqlCommand cmd = new SqlCommand("Select categoryId From ProductCategory Where category=@kategoriAdi", con);
            cmd.Parameters.AddWithValue("@kategoriAdi", kategoriAdi);

            try
            {
                con.Open();

                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    kategoriId = Convert.ToInt32(dr["categoryId"].ToString());
                }

                dr.Close();
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata : " + ex.Message);
            }

            return kategoriId;
        }

        public static int getDepoId(String depoAdi)
        {
            int depoId = 0;

            SqlConnection con = DAO.getCon();

            SqlCommand cmd = new SqlCommand("Select warehouseId From Warehouse Where warehouseName=@depoAdi", con);
            cmd.Parameters.AddWithValue("@depoAdi", depoAdi);

            try
            {
                con.Open();

                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    depoId = Convert.ToInt32(dr["warehouseId"].ToString());
                }

                dr.Close();
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata : " + ex.Message);
            }

            return depoId;
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            SqlConnection con = DAO.getCon();

            SqlCommand cmd = new SqlCommand("Delete From Products Where productId=@urunId", con);
            cmd.Parameters.AddWithValue("@urunId", txtBoxUrunId.Text);

            try
            {
                con.Open();

                int sonuc = 0;

                DialogResult dr = MessageBox.Show("Silmek İstiyor musunuz?", "Uyarı", MessageBoxButtons.YesNo);

                if (dr == DialogResult.Yes)
                {
                    sonuc = cmd.ExecuteNonQuery();

                    if (sonuc > 0)
                    {
                        AdminPanel.gridDoldur(dataGridViewStok);
                        MessageBox.Show("Ürün Silindi");
                    }
                    else
                    {
                        MessageBox.Show("Silme Başarısız!");
                    }
                }

                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata : " + ex.Message);
            }
        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            SqlConnection con = DAO.getCon();

            SqlCommand cmd = new SqlCommand("Update Products Set mark=@marka, model=@model, categoryId=@kategoriId, warehouseId=@depoId, unitPrice=@birimFiyat, stockQuantity=@stokMiktar, criticalStock=@kritikStok Where productId=@urunId", con);
            cmd.Parameters.AddWithValue("@marka", txtBoxMarka.Text);
            cmd.Parameters.AddWithValue("@model", txtBoxModel.Text);
            cmd.Parameters.AddWithValue("@kategoriId", AdminPanel.getKategoriId(comboBoxKategori.Text));
            cmd.Parameters.AddWithValue("@depoId", AdminPanel.getDepoId(comboBoxDepo.Text));
            cmd.Parameters.AddWithValue("@birimFiyat", Convert.ToInt32(txtBoxBirimFiyat.Text));
            cmd.Parameters.AddWithValue("@stokMiktar", Convert.ToInt32(txtBoxStokMiktar.Text));
            cmd.Parameters.AddWithValue("@kritikStok", 0);
            cmd.Parameters.AddWithValue("@urunId", Convert.ToInt32(txtBoxUrunId.Text));

            try
            {
                con.Open();

                int sonuc = cmd.ExecuteNonQuery();

                if (sonuc > 0)
                {
                    AdminPanel.gridDoldur(dataGridViewStok);
                    MessageBox.Show("Ürün Güncellendi");
                }
                else
                {
                    MessageBox.Show("Güncelleme Başarısız!");
                }

                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata : " + ex.Message);
            }
        }

        public static ArrayList getKategoriAd()
        {
            ArrayList catNames = new ArrayList();

            SqlConnection con = DAO.getCon();

            SqlCommand cmd = new SqlCommand("Select category From ProductCategory", con);

            try
            {
                con.Open();

                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    catNames.Add(dr["category"].ToString());
                }

                dr.Close();
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            return catNames;
        }

        public static ArrayList getDepoAd()
        {
            ArrayList depoAd = new ArrayList();

            SqlConnection con = DAO.getCon();

            SqlCommand cmd = new SqlCommand("Select warehouseName From Warehouse", con);

            try
            {
                con.Open();

                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    depoAd.Add(dr["warehouseName"].ToString());
                }

                dr.Close();
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            return depoAd;
        }

        public static void siparisGridDoldur(DataGridView dgv)
        {
            SqlConnection con = DAO.getCon();

            SqlDataAdapter da = new SqlDataAdapter("Select PO.orderId [Sipariş ID], PO.productId [Ürün ID], PO.quantity [Miktar], D.dealerName [Bayi Adı], PO.orderDate [Sipariş Tarihi], PO.orderStatus [Sipariş Durumu] From ProductOrder PO Inner Join Dealers D On D.dealerId=PO.dealerId Where PO.orderStatus='Beklemede'", con);

            DataSet ds = new DataSet();

            try
            {
                con.Open();

                da.Fill(ds, "ProductOrder");

                dgv.DataSource = ds.Tables["ProductOrder"];

                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata : " + ex.Message);
            }
        }

        public static void bitenSiparisGridDoldur(DataGridView dgv)
        {
            SqlConnection con = DAO.getCon();

            SqlDataAdapter da = new SqlDataAdapter("Select PO.orderId [Sipariş ID], PO.productId [Ürün ID], PO.quantity [Miktar], D.dealerName [Bayi Adı], PO.orderDate [Sipariş Tarihi], PO.orderStatus [Sipariş Durumu] From ProductOrder PO Inner Join Dealers D On D.dealerId=PO.dealerId Where PO.orderStatus='Tamamlandı'", con);

            DataSet ds = new DataSet();

            try
            {
                con.Open();

                da.Fill(ds, "ProductOrder");

                dgv.DataSource = ds.Tables["ProductOrder"];

                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata : " + ex.Message);
            }
        }

        public static int getUrunFiyat(int urunId)
        {
            int urunFiyat = 0;

            SqlConnection con = DAO.getCon();

            SqlCommand cmd = new SqlCommand("Select unitPrice From Products Where productId=@urunId", con);
            cmd.Parameters.AddWithValue("@urunId", urunId);

            try
            {
                con.Open();

                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    urunFiyat = Convert.ToInt32(dr["unitPrice"].ToString());
                }
                dr.Close();
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            return urunFiyat;
        }

        public static String getSiparisKazanc()
        {
            String kazanc = "0";

            SqlConnection con = DAO.getCon();

            SqlCommand cmd = new SqlCommand("Select SUM(P.unitPrice * PO.quantity) as [kazanc] From ProductOrder PO Inner Join Products P On PO.productId=P.productId Where PO.orderStatus='Beklemede'", con);

            try
            {
                con.Open();

                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    kazanc = dr["kazanc"].ToString();
                }
                dr.Close();
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            return kazanc;
        }

        private void btnSiparisOnay_Click(object sender, EventArgs e)
        {
            SqlConnection con = DAO.getCon();

            SqlCommand cmd = new SqlCommand("Update ProductOrder Set orderStatus='Tamamlandı'", con);

            try
            {
                con.Open();

                cmd.ExecuteNonQuery();

                lblSiparisKazanc.Text = "0";

                AdminPanel.siparisGridDoldur(dataGridViewSiparis);
                AdminPanel.bitenSiparisGridDoldur(dataGridViewSiparisBiten);

                lblSiparisToplamGelir.Text = AdminPanel.getToplamGelir();

                MessageBox.Show("Siparişler Onaylandı");

                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata oluştu : " + ex.Message);
            }
        }

        public static String getToplamGelir()
        {
            String toplamGelir = "0";

            SqlConnection con = DAO.getCon();

            SqlCommand cmd = new SqlCommand("Select SUM(P.unitPrice * PO.quantity) as [kazanc] From ProductOrder PO Inner Join Products P On PO.productId=P.productId Where PO.orderStatus='Tamamlandı'", con);

            try
            {
                con.Open();

                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    toplamGelir = dr["kazanc"].ToString();
                }
                dr.Close();
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            return toplamGelir;
        }

        public void calisanGridDoldur(DataGridView dgv)
        {
            SqlConnection con = DAO.getCon();

            SqlDataAdapter da = new SqlDataAdapter("Select P.personId [Çalışan ID], P.name [Ad], P.surname [Soyad], P.birthDate [Doğum Tarihi], P.gender [Cinsiyet], PD.degree [Ünvan], P.entryDate [Giriş Tarihi], case when P.releaseDate=NULL then '-' else P.releaseDate end [Ayrılış Tarihi], P.bank [Banka], P.bankAccountNo [Banka Hesap No], P.TCIDNo [TC Kimlik No], P.placeResidence [İkametgah], P.mobileNumber [Telefon No], D.dealerName [Bayi Adı], P.password [Şifre] From Persons P left join PersonDegree PD On P.degreeId=PD.degreeId left join Dealers D On D.dealerId=P.dealerId", con);

            DataSet ds = new DataSet();

            try
            {
                con.Open();

                da.Fill(ds, "Persons");

                dgv.DataSource = ds.Tables["Persons"];

                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata : " + ex.Message);
            }
        }

        private void dataGridViewCalisan_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                txtBoxCalisanId.Text = dataGridViewCalisan.Rows[e.RowIndex].Cells[0].Value.ToString();
                txtBoxAd.Text = dataGridViewCalisan.Rows[e.RowIndex].Cells[1].Value.ToString();
                txtBoxSoyad.Text = dataGridViewCalisan.Rows[e.RowIndex].Cells[2].Value.ToString();
                dateTimePickerDTarih.Text = dataGridViewCalisan.Rows[e.RowIndex].Cells[3].Value.ToString();
                comboBoxCinsiyet.Text = dataGridViewCalisan.Rows[e.RowIndex].Cells[4].Value.ToString();
                comboBoxUnvan.Text = dataGridViewCalisan.Rows[e.RowIndex].Cells[5].Value.ToString();
                dateTimePickerGirisTarih.Text = dataGridViewCalisan.Rows[e.RowIndex].Cells[6].Value.ToString();
                dateTimePickerAyrilisTarih.Text = dataGridViewCalisan.Rows[e.RowIndex].Cells[7].Value.ToString();
                txtBoxBanka.Text = dataGridViewCalisan.Rows[e.RowIndex].Cells[8].Value.ToString();
                txtBoxBankaHesapNo.Text = dataGridViewCalisan.Rows[e.RowIndex].Cells[9].Value.ToString();
                txtBoxTc.Text = dataGridViewCalisan.Rows[e.RowIndex].Cells[10].Value.ToString();
                txtBoxIkametgah.Text = dataGridViewCalisan.Rows[e.RowIndex].Cells[11].Value.ToString();
                txtBoxTelNo.Text = dataGridViewCalisan.Rows[e.RowIndex].Cells[12].Value.ToString();
                comboBoxBayiAd.Text = dataGridViewCalisan.Rows[e.RowIndex].Cells[13].Value.ToString();
                txtBoxSifre.Text = dataGridViewCalisan.Rows[e.RowIndex].Cells[14].Value.ToString();
            }
            catch (Exception)
            {
                
            }
        }

        private void butonEkle_Click(object sender, EventArgs e)
        {
            SqlConnection con = DAO.getCon();

            SqlCommand cmd = new SqlCommand("Insert Into Persons(name, surname, birthDate, gender, degreeId, entryDate,  bank, bankAccountNo, TCIDNo, placeResidence, mobileNumber, dealerId, password) Values(@ad, @soyad, @dTarih, @cinsiyet, @unvanId, @girisTarih, @banka, @bankaHesapNo, @TcNo, @ikametgah, @telNo, @bayiId, @sifre)", con);
            cmd.Parameters.AddWithValue("@ad", txtBoxAd.Text);
            cmd.Parameters.AddWithValue("@soyad", txtBoxSoyad.Text);
            cmd.Parameters.AddWithValue("@dTarih", dateTimePickerDTarih.Value);
            cmd.Parameters.AddWithValue("@cinsiyet", comboBoxCinsiyet.Text);
            cmd.Parameters.AddWithValue("@unvanId", Convert.ToInt32(getUnvanId(comboBoxUnvan.Text.Trim())));
            cmd.Parameters.AddWithValue("@girisTarih", dateTimePickerGirisTarih.Value);
            cmd.Parameters.AddWithValue("@banka", txtBoxBanka.Text);
            cmd.Parameters.AddWithValue("@bankaHesapNo", txtBoxBankaHesapNo.Text);
            cmd.Parameters.AddWithValue("@TcNo", txtBoxTc.Text);
            cmd.Parameters.AddWithValue("@ikametgah", txtBoxIkametgah.Text);
            cmd.Parameters.AddWithValue("@telNo", txtBoxTelNo.Text);
            cmd.Parameters.AddWithValue("@bayiId", Convert.ToInt32(getBayiId(comboBoxBayiAd.Text.Trim())));
            cmd.Parameters.AddWithValue("@sifre", txtBoxSifre.Text);

            try
            {
                con.Open();

                int sonuc = cmd.ExecuteNonQuery();

                if (sonuc > 0)
                {
                    MessageBox.Show("Çalışan Eklendi");
                    calisanGridDoldur(dataGridViewCalisan);
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

        public static int getBayiId(String bayiAd)
        {
            int bayiId = 0;

            SqlConnection con = DAO.getCon();

            SqlCommand cmd = new SqlCommand("Select dealerId From Dealers Where dealerName=@bayiAd", con);
            cmd.Parameters.AddWithValue("@bayiAd", bayiAd);

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

        public static int getUnvanId(String unvan)
        {
            int unvanId = 0;

            SqlConnection con = DAO.getCon();

            SqlCommand cmd = new SqlCommand("Select degreeId From PersonDegree Where degree=@unvan", con);
            cmd.Parameters.AddWithValue("@unvan", unvan);

            try
            {
                con.Open();

                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    unvanId = Convert.ToInt32(dr["degreeId"].ToString());
                }

                dr.Close();
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            return unvanId;
        }

        private void butonCikar_Click(object sender, EventArgs e)
        {
            SqlConnection con = DAO.getCon();

            SqlCommand cmd = new SqlCommand("Update Persons Set releaseDate=@ayrilisTarih Where personId=@calisanId", con);
            cmd.Parameters.AddWithValue("@ayrilisTarih", dateTimePickerAyrilisTarih.Value);
            cmd.Parameters.AddWithValue("@calisanId", Convert.ToInt32(txtBoxCalisanId.Text));

            try
            {
                con.Open();

                int sonuc = cmd.ExecuteNonQuery();

                if (sonuc > 0)
                {
                    MessageBox.Show("Çalışan Çıkarıldı");
                    calisanGridDoldur(dataGridViewCalisan);
                }
                else
                {
                    MessageBox.Show("Çıkarma Başarısız!");
                }

                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void butonGuncelle_Click(object sender, EventArgs e)
        {
            SqlConnection con = DAO.getCon();

            SqlCommand cmd = new SqlCommand("Update Persons Set name=@ad, surname=@soyad, birthDate=@dTarih, gender=@cinsiyet, degreeId=@unvanId, entryDate=@girisTarih, releaseDate=@ayrilisTarih, bank=@banka, bankAccountNo=@bankaHesapNo, TCIDNo=@TCNo, placeResidence=@ikametgah, mobileNumber=@telNo, dealerId=@bayiId, password=@sifre Where personId=@calisanId", con);
            cmd.Parameters.AddWithValue("@calisanId", Convert.ToInt32(txtBoxCalisanId.Text));
            cmd.Parameters.AddWithValue("@ad", txtBoxAd.Text);
            cmd.Parameters.AddWithValue("@soyad", txtBoxSoyad.Text);
            cmd.Parameters.AddWithValue("@dTarih", dateTimePickerDTarih.Value);
            cmd.Parameters.AddWithValue("@cinsiyet", comboBoxCinsiyet.Text);
            cmd.Parameters.AddWithValue("@unvanId", Convert.ToInt32(getUnvanId(comboBoxUnvan.Text.Trim())));
            cmd.Parameters.AddWithValue("@girisTarih", dateTimePickerGirisTarih.Value);
            cmd.Parameters.AddWithValue("@ayrilisTarih", dateTimePickerAyrilisTarih.Value);
            cmd.Parameters.AddWithValue("@banka", txtBoxBanka.Text);
            cmd.Parameters.AddWithValue("@bankaHesapNo", txtBoxBankaHesapNo.Text);
            cmd.Parameters.AddWithValue("@TcNo", txtBoxTc.Text);
            cmd.Parameters.AddWithValue("@ikametgah", txtBoxIkametgah.Text);
            cmd.Parameters.AddWithValue("@telNo", txtBoxTelNo.Text);
            cmd.Parameters.AddWithValue("@bayiId", Convert.ToInt32(getBayiId(comboBoxBayiAd.Text.Trim())));
            cmd.Parameters.AddWithValue("@sifre", txtBoxSifre.Text);

            try
            {
                con.Open();

                int sonuc = cmd.ExecuteNonQuery();

                if (sonuc > 0)
                {
                    MessageBox.Show("Güncellendi");
                    calisanGridDoldur(dataGridViewCalisan);
                }
                else
                {
                    MessageBox.Show("Güncelleme Başarısız!");
                }

                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
