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
    public partial class Form5 : Form
    {
        public Form5()
        {
            InitializeComponent();
        }

        private void Form5_Load(object sender, EventArgs e)
        {
            TumVerileriGetir();
            TumKullanicilariGetir();
        }
        void TumVerileriGetir()
        {
            try
            {
                string dbYolu = Path.Combine(Application.StartupPath, "veritabani.db");
                using (SQLiteConnection baglanti = new SQLiteConnection($"Data Source={dbYolu};Version=3;"))
                {
                    baglanti.Open();

                    string sql = @"
                        SELECT 
                            Harcamalar.id AS 'İşlem ID', 
                            Kullanicilar.kullanici_adi AS 'Kullanıcı Adı', 
                            Harcamalar.kategori AS 'Kategori', 
                            Harcamalar.miktar AS 'Tutar' 
                        FROM Harcamalar 
                        INNER JOIN Kullanicilar ON Harcamalar.kullanici_id = Kullanicilar.id";

                    SQLiteDataAdapter da = new SQLiteDataAdapter(sql, baglanti);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dataGridView1.DataSource = dt;
                }
            }
            catch (Exception hata)
            {
                MessageBox.Show("Veriler yüklenirken bir hata oluştu: " + hata.Message);
            }
        }

        private void button1_Click(object sender, EventArgs e)//geri butonu
        {
            Form1 giris = new Form1();
            giris.Show();
            this.FormClosed -= Form5_FormClosed;
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)//güncelle butonu
        {
            TumVerileriGetir();
            MessageBox.Show("Veriler başarıyla güncellendi!", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        void TumKullanicilariGetir()
        {
            string dbYolu = Path.Combine(Application.StartupPath, "veritabani.db");
            using (SQLiteConnection baglanti = new SQLiteConnection($"Data Source={dbYolu};Version=3;"))
            {
                baglanti.Open();
                string sql = "SELECT id, kullanici_adi FROM Kullanicilar WHERE kullanici_adi != 'admin'";

                SQLiteDataAdapter da = new SQLiteDataAdapter(sql, baglanti);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dgvKullanicilar.DataSource = dt;

                dgvKullanicilar.Columns["id"].HeaderText = "Üye No";
                dgvKullanicilar.Columns["kullanici_adi"].HeaderText = "Kullanıcı Adı";
                dgvKullanicilar.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            }
        }

        private void dgvKullanicilar_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                lblSilinecekKullaniciID.Text = dgvKullanicilar.Rows[e.RowIndex].Cells["id"].Value.ToString();
            }
        }

        private void btnKullaniciSil_Click(object sender, EventArgs e)
        {
            if (lblSilinecekKullaniciID.Text == "") { MessageBox.Show("Lütfen silinecek kullanıcıyı seçin!"); return; }

            DialogResult onay = MessageBox.Show("Bu kullanıcıyı ve tüm harcamalarını silmek istediğinize emin misiniz?", "Kritik Uyarı", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (onay == DialogResult.Yes)
            {
                string dbYolu = Path.Combine(Application.StartupPath, "veritabani.db");
                using (var baglanti = new SQLiteConnection($"Data Source={dbYolu};Version=3;"))
                {
                    baglanti.Open();
                    string sqlHarcamaSil = "DELETE FROM Harcamalar WHERE kullanici_id = @id";
                    string sqlKullaniciSil = "DELETE FROM Kullanicilar WHERE id = @id";

                    using (var komut1 = new SQLiteCommand(sqlHarcamaSil, baglanti))
                    {
                        komut1.Parameters.AddWithValue("@id", lblSilinecekKullaniciID.Text);
                        komut1.ExecuteNonQuery();
                    }

                    using (var komut2 = new SQLiteCommand(sqlKullaniciSil, baglanti))
                    {
                        komut2.Parameters.AddWithValue("@id", lblSilinecekKullaniciID.Text);
                        komut2.ExecuteNonQuery();
                    }
                }
                MessageBox.Show("Kullanıcı başarıyla sistemden silindi.");
                TumKullanicilariGetir();
                lblSilinecekKullaniciID.Text = "";
            }
        }
        private void Form5_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}

