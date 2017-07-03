namespace SmartStock
{
    partial class DealerPanel
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DealerPanel));
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPageSiparis = new System.Windows.Forms.TabPage();
            this.label1 = new System.Windows.Forms.Label();
            this.dataGridViewStok = new System.Windows.Forms.DataGridView();
            this.tabPageMuhasebe = new System.Windows.Forms.TabPage();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtBoxUrunId = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtBoxAdet = new System.Windows.Forms.TextBox();
            this.btnSiparis = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.txtBoxKartSifre = new System.Windows.Forms.TextBox();
            this.pictureBoxUrunResim = new System.Windows.Forms.PictureBox();
            this.tabControl1.SuspendLayout();
            this.tabPageSiparis.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewStok)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxUrunResim)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPageSiparis);
            this.tabControl1.Controls.Add(this.tabPageMuhasebe);
            this.tabControl1.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.tabControl1.Location = new System.Drawing.Point(12, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1338, 688);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPageSiparis
            // 
            this.tabPageSiparis.BackColor = System.Drawing.SystemColors.Window;
            this.tabPageSiparis.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.tabPageSiparis.Controls.Add(this.pictureBoxUrunResim);
            this.tabPageSiparis.Controls.Add(this.txtBoxKartSifre);
            this.tabPageSiparis.Controls.Add(this.label5);
            this.tabPageSiparis.Controls.Add(this.btnSiparis);
            this.tabPageSiparis.Controls.Add(this.txtBoxAdet);
            this.tabPageSiparis.Controls.Add(this.label4);
            this.tabPageSiparis.Controls.Add(this.txtBoxUrunId);
            this.tabPageSiparis.Controls.Add(this.label3);
            this.tabPageSiparis.Controls.Add(this.label2);
            this.tabPageSiparis.Controls.Add(this.label1);
            this.tabPageSiparis.Controls.Add(this.dataGridViewStok);
            this.tabPageSiparis.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.tabPageSiparis.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.tabPageSiparis.Location = new System.Drawing.Point(4, 29);
            this.tabPageSiparis.Name = "tabPageSiparis";
            this.tabPageSiparis.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageSiparis.Size = new System.Drawing.Size(1330, 655);
            this.tabPageSiparis.TabIndex = 0;
            this.tabPageSiparis.Text = "SİPARİŞ";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label1.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label1.Location = new System.Drawing.Point(332, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(192, 22);
            this.label1.TabIndex = 1;
            this.label1.Text = "STOKTAKİ ÜRÜNLER";
            // 
            // dataGridViewStok
            // 
            this.dataGridViewStok.AllowUserToAddRows = false;
            this.dataGridViewStok.AllowUserToDeleteRows = false;
            this.dataGridViewStok.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewStok.BackgroundColor = System.Drawing.SystemColors.GradientActiveCaption;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewStok.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridViewStok.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewStok.Location = new System.Drawing.Point(33, 68);
            this.dataGridViewStok.Name = "dataGridViewStok";
            this.dataGridViewStok.ReadOnly = true;
            this.dataGridViewStok.Size = new System.Drawing.Size(798, 529);
            this.dataGridViewStok.TabIndex = 0;
            this.dataGridViewStok.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewStok_CellContentClick);
            // 
            // tabPageMuhasebe
            // 
            this.tabPageMuhasebe.BackColor = System.Drawing.SystemColors.Window;
            this.tabPageMuhasebe.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.tabPageMuhasebe.ForeColor = System.Drawing.SystemColors.WindowText;
            this.tabPageMuhasebe.Location = new System.Drawing.Point(4, 29);
            this.tabPageMuhasebe.Name = "tabPageMuhasebe";
            this.tabPageMuhasebe.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageMuhasebe.Size = new System.Drawing.Size(1330, 655);
            this.tabPageMuhasebe.TabIndex = 1;
            this.tabPageMuhasebe.Text = "MUHASEBE";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label2.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label2.Location = new System.Drawing.Point(1025, 46);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(136, 22);
            this.label2.TabIndex = 2;
            this.label2.Text = "SİPARİŞ İŞLEM";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(907, 96);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(56, 17);
            this.label3.TabIndex = 3;
            this.label3.Text = "Ürün ID";
            // 
            // txtBoxUrunId
            // 
            this.txtBoxUrunId.Location = new System.Drawing.Point(1007, 93);
            this.txtBoxUrunId.Name = "txtBoxUrunId";
            this.txtBoxUrunId.Size = new System.Drawing.Size(100, 23);
            this.txtBoxUrunId.TabIndex = 4;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(907, 158);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(37, 17);
            this.label4.TabIndex = 5;
            this.label4.Text = "Adet";
            // 
            // txtBoxAdet
            // 
            this.txtBoxAdet.Location = new System.Drawing.Point(1007, 155);
            this.txtBoxAdet.Name = "txtBoxAdet";
            this.txtBoxAdet.Size = new System.Drawing.Size(100, 23);
            this.txtBoxAdet.TabIndex = 6;
            // 
            // btnSiparis
            // 
            this.btnSiparis.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnSiparis.Location = new System.Drawing.Point(992, 262);
            this.btnSiparis.Name = "btnSiparis";
            this.btnSiparis.Size = new System.Drawing.Size(115, 53);
            this.btnSiparis.TabIndex = 7;
            this.btnSiparis.Text = "Sipariş Ver";
            this.btnSiparis.UseVisualStyleBackColor = true;
            this.btnSiparis.Click += new System.EventHandler(this.btnSiparis_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(907, 220);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(77, 17);
            this.label5.TabIndex = 8;
            this.label5.Text = "Kart Şifresi";
            // 
            // txtBoxKartSifre
            // 
            this.txtBoxKartSifre.Location = new System.Drawing.Point(1007, 217);
            this.txtBoxKartSifre.Name = "txtBoxKartSifre";
            this.txtBoxKartSifre.PasswordChar = '*';
            this.txtBoxKartSifre.Size = new System.Drawing.Size(100, 23);
            this.txtBoxKartSifre.TabIndex = 9;
            // 
            // pictureBoxUrunResim
            // 
            this.pictureBoxUrunResim.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pictureBoxUrunResim.Location = new System.Drawing.Point(1123, 93);
            this.pictureBoxUrunResim.Name = "pictureBoxUrunResim";
            this.pictureBoxUrunResim.Size = new System.Drawing.Size(197, 222);
            this.pictureBoxUrunResim.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBoxUrunResim.TabIndex = 10;
            this.pictureBoxUrunResim.TabStop = false;
            // 
            // DealerPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.ClientSize = new System.Drawing.Size(1362, 741);
            this.Controls.Add(this.tabControl1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "DealerPanel";
            this.Text = "Bayi İşlemleri";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.DealerPanel_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPageSiparis.ResumeLayout(false);
            this.tabPageSiparis.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewStok)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxUrunResim)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPageSiparis;
        private System.Windows.Forms.TabPage tabPageMuhasebe;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dataGridViewStok;
        private System.Windows.Forms.TextBox txtBoxKartSifre;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnSiparis;
        private System.Windows.Forms.TextBox txtBoxAdet;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtBoxUrunId;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.PictureBox pictureBoxUrunResim;
    }
}