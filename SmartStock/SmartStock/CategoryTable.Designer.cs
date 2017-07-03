namespace SmartStock
{
    partial class CategoryTable
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
            this.dataGridViewKategori = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.txtBoxKategori = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtBoxKategoriId = new System.Windows.Forms.TextBox();
            this.btnKategoriEkle = new System.Windows.Forms.Button();
            this.btnKategoriSil = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewKategori)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridViewKategori
            // 
            this.dataGridViewKategori.AllowUserToAddRows = false;
            this.dataGridViewKategori.AllowUserToDeleteRows = false;
            this.dataGridViewKategori.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewKategori.BackgroundColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.dataGridViewKategori.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewKategori.Location = new System.Drawing.Point(12, 12);
            this.dataGridViewKategori.Name = "dataGridViewKategori";
            this.dataGridViewKategori.ReadOnly = true;
            this.dataGridViewKategori.Size = new System.Drawing.Size(560, 234);
            this.dataGridViewKategori.TabIndex = 0;
            this.dataGridViewKategori.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewKategori_CellContentClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label1.Location = new System.Drawing.Point(9, 284);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(61, 17);
            this.label1.TabIndex = 1;
            this.label1.Text = "Kategori";
            // 
            // txtBoxKategori
            // 
            this.txtBoxKategori.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txtBoxKategori.Location = new System.Drawing.Point(79, 281);
            this.txtBoxKategori.Name = "txtBoxKategori";
            this.txtBoxKategori.Size = new System.Drawing.Size(143, 23);
            this.txtBoxKategori.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label2.Location = new System.Drawing.Point(296, 284);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(78, 17);
            this.label2.TabIndex = 3;
            this.label2.Text = "Kategori ID";
            // 
            // txtBoxKategoriId
            // 
            this.txtBoxKategoriId.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txtBoxKategoriId.Location = new System.Drawing.Point(380, 281);
            this.txtBoxKategoriId.Name = "txtBoxKategoriId";
            this.txtBoxKategoriId.Size = new System.Drawing.Size(68, 23);
            this.txtBoxKategoriId.TabIndex = 4;
            // 
            // btnKategoriEkle
            // 
            this.btnKategoriEkle.Location = new System.Drawing.Point(148, 310);
            this.btnKategoriEkle.Name = "btnKategoriEkle";
            this.btnKategoriEkle.Size = new System.Drawing.Size(74, 41);
            this.btnKategoriEkle.TabIndex = 5;
            this.btnKategoriEkle.Text = "Kategori Ekle";
            this.btnKategoriEkle.UseVisualStyleBackColor = true;
            this.btnKategoriEkle.Click += new System.EventHandler(this.btnKategoriEkle_Click);
            // 
            // btnKategoriSil
            // 
            this.btnKategoriSil.Location = new System.Drawing.Point(454, 272);
            this.btnKategoriSil.Name = "btnKategoriSil";
            this.btnKategoriSil.Size = new System.Drawing.Size(68, 41);
            this.btnKategoriSil.TabIndex = 6;
            this.btnKategoriSil.Text = "Kategori Sil";
            this.btnKategoriSil.UseVisualStyleBackColor = true;
            this.btnKategoriSil.Click += new System.EventHandler(this.btnKategoriSil_Click);
            // 
            // CategoryTable
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(584, 461);
            this.Controls.Add(this.btnKategoriSil);
            this.Controls.Add(this.btnKategoriEkle);
            this.Controls.Add(this.txtBoxKategoriId);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtBoxKategori);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dataGridViewKategori);
            this.Name = "CategoryTable";
            this.Text = "Kategori Tablosu";
            this.Load += new System.EventHandler(this.CategoryTable_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewKategori)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridViewKategori;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtBoxKategori;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtBoxKategoriId;
        private System.Windows.Forms.Button btnKategoriEkle;
        private System.Windows.Forms.Button btnKategoriSil;
    }
}