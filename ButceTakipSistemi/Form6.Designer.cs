namespace ButceTakipSistemi
{
    partial class Form6
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
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtYeniAd = new System.Windows.Forms.TextBox();
            this.txtYeniSifre = new System.Windows.Forms.TextBox();
            this.btnProfilGuncelle = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.btnHarcamaSil = new System.Windows.Forms.Button();
            this.btnHarcamaGuncelle = new System.Windows.Forms.Button();
            this.cmbHarcamaKategori = new System.Windows.Forms.ComboBox();
            this.txtHarcamaMiktar = new System.Windows.Forms.TextBox();
            this.lblSeciliID = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.ForeColor = System.Drawing.Color.Red;
            this.button1.Location = new System.Drawing.Point(12, 12);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "Geri";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Palatino Linotype", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label1.Location = new System.Drawing.Point(12, 101);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(150, 23);
            this.label1.TabIndex = 1;
            this.label1.Text = "Yeni Kullanıcı Adı:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Palatino Linotype", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label2.Location = new System.Drawing.Point(12, 129);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(86, 23);
            this.label2.TabIndex = 2;
            this.label2.Text = "Yeni Şifre:";
            // 
            // txtYeniAd
            // 
            this.txtYeniAd.Location = new System.Drawing.Point(179, 102);
            this.txtYeniAd.Name = "txtYeniAd";
            this.txtYeniAd.Size = new System.Drawing.Size(100, 22);
            this.txtYeniAd.TabIndex = 3;
            // 
            // txtYeniSifre
            // 
            this.txtYeniSifre.Location = new System.Drawing.Point(179, 131);
            this.txtYeniSifre.Name = "txtYeniSifre";
            this.txtYeniSifre.Size = new System.Drawing.Size(100, 22);
            this.txtYeniSifre.TabIndex = 4;
            // 
            // btnProfilGuncelle
            // 
            this.btnProfilGuncelle.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnProfilGuncelle.Location = new System.Drawing.Point(87, 174);
            this.btnProfilGuncelle.Name = "btnProfilGuncelle";
            this.btnProfilGuncelle.Size = new System.Drawing.Size(93, 34);
            this.btnProfilGuncelle.TabIndex = 5;
            this.btnProfilGuncelle.Text = "Güncelle";
            this.btnProfilGuncelle.UseVisualStyleBackColor = true;
            this.btnProfilGuncelle.Click += new System.EventHandler(this.btnProfilGuncelle_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.BackgroundColor = System.Drawing.SystemColors.ControlLight;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(352, 79);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(422, 193);
            this.dataGridView1.TabIndex = 6;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            // 
            // btnHarcamaSil
            // 
            this.btnHarcamaSil.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnHarcamaSil.Location = new System.Drawing.Point(466, 329);
            this.btnHarcamaSil.Name = "btnHarcamaSil";
            this.btnHarcamaSil.Size = new System.Drawing.Size(85, 35);
            this.btnHarcamaSil.TabIndex = 7;
            this.btnHarcamaSil.Text = "Sil";
            this.btnHarcamaSil.UseVisualStyleBackColor = true;
            this.btnHarcamaSil.Click += new System.EventHandler(this.btnHarcamaSil_Click);
            // 
            // btnHarcamaGuncelle
            // 
            this.btnHarcamaGuncelle.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnHarcamaGuncelle.Location = new System.Drawing.Point(585, 329);
            this.btnHarcamaGuncelle.Name = "btnHarcamaGuncelle";
            this.btnHarcamaGuncelle.Size = new System.Drawing.Size(86, 35);
            this.btnHarcamaGuncelle.TabIndex = 8;
            this.btnHarcamaGuncelle.Text = "Güncelle";
            this.btnHarcamaGuncelle.UseVisualStyleBackColor = true;
            this.btnHarcamaGuncelle.Click += new System.EventHandler(this.btnHarcamaGuncelle_Click);
            // 
            // cmbHarcamaKategori
            // 
            this.cmbHarcamaKategori.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.cmbHarcamaKategori.FormattingEnabled = true;
            this.cmbHarcamaKategori.Location = new System.Drawing.Point(430, 290);
            this.cmbHarcamaKategori.Name = "cmbHarcamaKategori";
            this.cmbHarcamaKategori.Size = new System.Drawing.Size(121, 26);
            this.cmbHarcamaKategori.TabIndex = 9;
            // 
            // txtHarcamaMiktar
            // 
            this.txtHarcamaMiktar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txtHarcamaMiktar.Location = new System.Drawing.Point(585, 290);
            this.txtHarcamaMiktar.Name = "txtHarcamaMiktar";
            this.txtHarcamaMiktar.Size = new System.Drawing.Size(117, 24);
            this.txtHarcamaMiktar.TabIndex = 10;
            // 
            // lblSeciliID
            // 
            this.lblSeciliID.AutoSize = true;
            this.lblSeciliID.Location = new System.Drawing.Point(546, 375);
            this.lblSeciliID.Name = "lblSeciliID";
            this.lblSeciliID.Size = new System.Drawing.Size(0, 16);
            this.lblSeciliID.TabIndex = 11;
            this.lblSeciliID.Visible = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Palatino Linotype", 18F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label3.Location = new System.Drawing.Point(209, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(375, 40);
            this.label3.TabIndex = 12;
            this.label3.Text = "Kullanıcı İşlemleri Ekranı";
            // 
            // Form6
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lblSeciliID);
            this.Controls.Add(this.txtHarcamaMiktar);
            this.Controls.Add(this.cmbHarcamaKategori);
            this.Controls.Add(this.btnHarcamaGuncelle);
            this.Controls.Add(this.btnHarcamaSil);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.btnProfilGuncelle);
            this.Controls.Add(this.txtYeniSifre);
            this.Controls.Add(this.txtYeniAd);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Form6";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form6";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form6_FormClosed);
            this.Load += new System.EventHandler(this.Form6_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtYeniAd;
        private System.Windows.Forms.TextBox txtYeniSifre;
        private System.Windows.Forms.Button btnProfilGuncelle;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button btnHarcamaSil;
        private System.Windows.Forms.Button btnHarcamaGuncelle;
        private System.Windows.Forms.ComboBox cmbHarcamaKategori;
        private System.Windows.Forms.TextBox txtHarcamaMiktar;
        private System.Windows.Forms.Label lblSeciliID;
        private System.Windows.Forms.Label label3;
    }
}