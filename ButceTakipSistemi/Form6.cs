using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ButceTakipSistemi
{
    public partial class Form6 : Form
    {
        public int kullaniciID; // Form1'den gelen ID
        public Form6()
        {
            InitializeComponent();
        }

        private void Form6_Load(object sender, EventArgs e)
        {
            HarcamalarimiGetir();
        }
        void HarcamalarimiGetir()
        {
            try
            {
                string dbYolu = Path.Combine(Application.StartupPath, "veritabani.db");

                using (SQLiteConnection baglanti = new SQLiteConnection($"Data Source={dbYolu};Version=3;"))
                {
                    baglanti.Open();

                    string sql = "SELECT id, kategori, miktar FROM Harcamalar WHERE kullanici_id = @id";

                    using (SQLiteDataAdapter da = new SQLiteDataAdapter(sql, baglanti))
                    {
                        da.SelectCommand.Parameters.AddWithValue("@id", kullaniciID);

                        DataTable dt = new DataTable();
                        da.Fill(dt);

                        dataGridView1.DataSource = dt;
                    }
                }

                if (dataGridView1.Columns.Count > 0)
                {
                    dataGridView1.Columns["id"].HeaderText = "İşlem No";
                    dataGridView1.Columns["kategori"].HeaderText = "Harcama Türü";
                    dataGridView1.Columns["miktar"].HeaderText = "Tutar (TL)";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Veriler listelenirken bir hata oluştu: " + ex.Message);
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow satir = dataGridView1.Rows[e.RowIndex];

                lblSeciliID.Text = satir.Cells["id"].Value.ToString();
                cmbHarcamaKategori.Text = satir.Cells["kategori"].Value.ToString();
                txtHarcamaMiktar.Text = satir.Cells["miktar"].Value.ToString();
            }
        }

        private void btnHarcamaGuncelle_Click(object sender, EventArgs e)
        {
            if (lblSeciliID.Text == "") { MessageBox.Show("Lütfen tablodan bir harcama seçin!"); return; }

            string dbYolu = Path.Combine(Application.StartupPath, "veritabani.db");
            using (var baglanti = new SQLiteConnection($"Data Source={dbYolu};Version=3;"))
            {
                baglanti.Open();
                string sql = "UPDATE Harcamalar SET kategori=@p1, miktar=@p2 WHERE id=@p3";

                using (var komut = new SQLiteCommand(sql, baglanti))
                {
                    komut.Parameters.AddWithValue("@p1", cmbHarcamaKategori.Text);
                    komut.Parameters.AddWithValue("@p2", txtHarcamaMiktar.Text);
                    komut.Parameters.AddWithValue("@p3", lblSeciliID.Text);

                    komut.ExecuteNonQuery();
                }
            }
            MessageBox.Show("Harcama başarıyla güncellendi!");
            HarcamalarimiGetir();
        }
        
        private void btnHarcamaSil_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(lblSeciliID.Text) || lblSeciliID.Text == "LabelID")
            {
                MessageBox.Show("Lütfen önce tablodan silinecek harcamayı seçin!");
                return;
            }

            DialogResult onay = MessageBox.Show("Bu harcama kaydını silmek istediğinize emin misiniz?", "Silme Onayı", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (onay == DialogResult.Yes)
            {
                try
                {
                    string dbYolu = Path.Combine(Application.StartupPath, "veritabani.db");
                    using (var baglanti = new SQLiteConnection($"Data Source={dbYolu};Version=3;"))
                    {
                        baglanti.Open();
                        string sql = "DELETE FROM Harcamalar WHERE id = @p1";

                        using (var komut = new SQLiteCommand(sql, baglanti))
                        {
                            komut.Parameters.AddWithValue("@p1", lblSeciliID.Text);
                            komut.ExecuteNonQuery();
                        }
                    }

                    MessageBox.Show("Harcama başarıyla silindi!");

                    HarcamalarimiGetir();
                    lblSeciliID.Text = "";
                    txtHarcamaMiktar.Clear();
                    cmbHarcamaKategori.SelectedIndex = -1;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Silme işlemi sırasında hata: " + ex.Message);
                }
            }
        }

        private void btnProfilGuncelle_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtYeniAd.Text) || string.IsNullOrEmpty(txtYeniSifre.Text))
            {
                MessageBox.Show("Kullanıcı adı ve şifre boş bırakılamaz!");
                return;
            }

            try
            {
                string dbYolu = Path.Combine(Application.StartupPath, "veritabani.db");
                using (var baglanti = new SQLiteConnection($"Data Source={dbYolu};Version=3;"))
                {
                    baglanti.Open();

                    string sql = "UPDATE Kullanicilar SET kullanici_adi = @p1, sifre = @p2 WHERE id = @p3";

                    using (var komut = new SQLiteCommand(sql, baglanti))
                    {
                        komut.Parameters.AddWithValue("@p1", txtYeniAd.Text);
                        komut.Parameters.AddWithValue("@p2", txtYeniSifre.Text);
                        komut.Parameters.AddWithValue("@p3", kullaniciID);

                        int etkilenenSatir = komut.ExecuteNonQuery();

                        if (etkilenenSatir > 0)
                        {
                            MessageBox.Show("Profil bilgileriniz başarıyla güncellendi! Yeni bilgilerinizle tekrar giriş yapmalısınız.");

                            Form1 giris = new Form1();
                            giris.Show();

                            this.FormClosed -= Form6_FormClosed;

                            this.Close();
                        }
                        else
                        {
                            MessageBox.Show("Güncelleme yapılamadı, ID bulunamadı.");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Profil güncellenirken hata oluştu: " + ex.Message);
            }
        }

        private void button1_Click(object sender, EventArgs e)//geri butonu
        {
            Form1 giris = new Form1();
            giris.Show();
            this.FormClosed -= Form6_FormClosed;
            this.Close();
        }
        private void Form6_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}
