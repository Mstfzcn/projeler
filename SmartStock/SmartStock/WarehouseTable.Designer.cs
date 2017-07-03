namespace SmartStock
{
    partial class WarehouseTable
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
            this.dataGridViewDepo = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.txtBoxDepoAd = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtBoxAlan = new System.Windows.Forms.TextBox();
            this.txtBoxSehir = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.richTextBoxAdres = new System.Windows.Forms.RichTextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtBoxDepoId = new System.Windows.Forms.TextBox();
            this.btnDepoSil = new System.Windows.Forms.Button();
            this.btnDepoEkle = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewDepo)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridViewDepo
            // 
            this.dataGridViewDepo.AllowUserToAddRows = false;
            this.dataGridViewDepo.AllowUserToDeleteRows = false;
            this.dataGridViewDepo.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewDepo.BackgroundColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.dataGridViewDepo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewDepo.Location = new System.Drawing.Point(12, 12);
            this.dataGridViewDepo.Name = "dataGridViewDepo";
            this.dataGridViewDepo.Size = new System.Drawing.Size(560, 262);
            this.dataGridViewDepo.TabIndex = 0;
            this.dataGridViewDepo.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewDepo_CellContentClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label1.Location = new System.Drawing.Point(12, 297);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(66, 17);
            this.label1.TabIndex = 1;
            this.label1.Text = "Depo Adı";
            // 
            // txtBoxDepoAd
            // 
            this.txtBoxDepoAd.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txtBoxDepoAd.Location = new System.Drawing.Point(84, 294);
            this.txtBoxDepoAd.Name = "txtBoxDepoAd";
            this.txtBoxDepoAd.Size = new System.Drawing.Size(154, 23);
            this.txtBoxDepoAd.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label2.Location = new System.Drawing.Point(12, 326);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(69, 17);
            this.label2.TabIndex = 3;
            this.label2.Text = "Alan (m2)";
            // 
            // txtBoxAlan
            // 
            this.txtBoxAlan.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txtBoxAlan.Location = new System.Drawing.Point(84, 323);
            this.txtBoxAlan.Name = "txtBoxAlan";
            this.txtBoxAlan.Size = new System.Drawing.Size(154, 23);
            this.txtBoxAlan.TabIndex = 4;
            // 
            // txtBoxSehir
            // 
            this.txtBoxSehir.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txtBoxSehir.Location = new System.Drawing.Point(84, 352);
            this.txtBoxSehir.Name = "txtBoxSehir";
            this.txtBoxSehir.Size = new System.Drawing.Size(154, 23);
            this.txtBoxSehir.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label3.Location = new System.Drawing.Point(12, 355);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 17);
            this.label3.TabIndex = 6;
            this.label3.Text = "Şehir";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label4.Location = new System.Drawing.Point(12, 383);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(45, 17);
            this.label4.TabIndex = 7;
            this.label4.Text = "Adres";
            // 
            // richTextBoxAdres
            // 
            this.richTextBoxAdres.Location = new System.Drawing.Point(84, 381);
            this.richTextBoxAdres.Name = "richTextBoxAdres";
            this.richTextBoxAdres.Size = new System.Drawing.Size(226, 68);
            this.richTextBoxAdres.TabIndex = 9;
            this.richTextBoxAdres.Text = "";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label5.Location = new System.Drawing.Point(393, 300);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(59, 17);
            this.label5.TabIndex = 10;
            this.label5.Text = "Depo ID";
            // 
            // txtBoxDepoId
            // 
            this.txtBoxDepoId.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txtBoxDepoId.Location = new System.Drawing.Point(458, 297);
            this.txtBoxDepoId.Name = "txtBoxDepoId";
            this.txtBoxDepoId.Size = new System.Drawing.Size(114, 23);
            this.txtBoxDepoId.TabIndex = 11;
            // 
            // btnDepoSil
            // 
            this.btnDepoSil.Location = new System.Drawing.Point(497, 326);
            this.btnDepoSil.Name = "btnDepoSil";
            this.btnDepoSil.Size = new System.Drawing.Size(75, 32);
            this.btnDepoSil.TabIndex = 12;
            this.btnDepoSil.Text = "Depo Sil";
            this.btnDepoSil.UseVisualStyleBackColor = true;
            this.btnDepoSil.Click += new System.EventHandler(this.btnDepoSil_Click);
            // 
            // btnDepoEkle
            // 
            this.btnDepoEkle.Location = new System.Drawing.Point(316, 411);
            this.btnDepoEkle.Name = "btnDepoEkle";
            this.btnDepoEkle.Size = new System.Drawing.Size(75, 38);
            this.btnDepoEkle.TabIndex = 13;
            this.btnDepoEkle.Text = "Depo Ekle";
            this.btnDepoEkle.UseVisualStyleBackColor = true;
            this.btnDepoEkle.Click += new System.EventHandler(this.btnDepoEkle_Click);
            // 
            // WarehouseTable
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(584, 461);
            this.Controls.Add(this.btnDepoEkle);
            this.Controls.Add(this.btnDepoSil);
            this.Controls.Add(this.txtBoxDepoId);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.richTextBoxAdres);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtBoxSehir);
            this.Controls.Add(this.txtBoxAlan);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtBoxDepoAd);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dataGridViewDepo);
            this.Name = "WarehouseTable";
            this.Text = "Depo Tablosu";
            this.Load += new System.EventHandler(this.WarehouseTable_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewDepo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridViewDepo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtBoxDepoAd;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtBoxAlan;
        private System.Windows.Forms.TextBox txtBoxSehir;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.RichTextBox richTextBoxAdres;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtBoxDepoId;
        private System.Windows.Forms.Button btnDepoSil;
        private System.Windows.Forms.Button btnDepoEkle;
    }
}