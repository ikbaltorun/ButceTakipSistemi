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
    public partial class Form2 : Form
    {
        public string girisYapanKullanici; //form1 den gelir
        public int girisYapanID; //form1 den gelir

        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            lblHosgeldin.Text = "Hoş Geldiniz, " + girisYapanKullanici;

            VerileriGetir();
            ToplamHarcamaHesapla();
        }

        void ToplamHarcamaHesapla()
        {
            try
            {
                string dbYolu = Path.Combine(Application.StartupPath, "veritabani.db");
                using (var baglanti = new SQLiteConnection($"Data Source={dbYolu};Version=3;"))
                {
                    baglanti.Open();
                    string sql = "SELECT SUM(miktar) FROM Harcamalar WHERE kullanici_id = @id";

                    using (var komut = new SQLiteCommand(sql, baglanti))
                    {
                        komut.Parameters.AddWithValue("@id", girisYapanID);
                        object sonuc = komut.ExecuteScalar();

                        if (sonuc != DBNull.Value && sonuc != null)
                        {
                            lblToplamHarcama.Text = "Şu anki toplam harcamanız: " + sonuc.ToString() + " TL";
                        }
                        else
                        {
                            lblToplamHarcama.Text = "Henüz bir harcama kaydı bulunmuyor.";
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Toplam hesaplanırken hata: " + ex.Message);
            }
        }

        void VerileriGetir()
        {
            try
            {
                string dbYolu = System.IO.Path.Combine(Application.StartupPath, "veritabani.db");

                using (System.Data.SQLite.SQLiteConnection baglanti = new System.Data.SQLite.SQLiteConnection($"Data Source={dbYolu};Version=3;"))
                {
                    baglanti.Open();

                    
                    string sql = "SELECT kategori AS 'Harcama Türü', miktar AS 'Tutar' FROM Harcamalar WHERE kullanici_id = @p1";

                    using (System.Data.SQLite.SQLiteDataAdapter da = new System.Data.SQLite.SQLiteDataAdapter(sql, baglanti))
                    {
                        da.SelectCommand.Parameters.AddWithValue("@p1", girisYapanID);

                        System.Data.DataTable dt = new System.Data.DataTable();
                        da.Fill(dt);
                        dataGridView1.DataSource = dt;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Harcamalar listelenirken hata oluştu: " + ex.Message);
            }
        }
        private void harcamaEkleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form3 f3 = new Form3();
            f3.girisYapanID = this.girisYapanID;
            f3.ShowDialog();
            VerileriGetir();
            ToplamHarcamaHesapla();
        }

        private void grafiklerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form4 f4 = new Form4();
            f4.girisYapanID = this.girisYapanID;
            f4.Show();
        }

        private void geriStripMenuItem1_Click(object sender, EventArgs e)
        {
            DialogResult sonuc = MessageBox.Show("Oturumu kapatıp giriş ekranına dönmek istiyor musunuz?", "Oturumu Kapat", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (sonuc == DialogResult.Yes)
            {
                Form1 f1 = new Form1();
                f1.Show();
                this.FormClosed -= Form2_FormClosed;
                this.Close();
            }
        }

        private void btnRaporAl_Click(object sender, EventArgs e)
        {
            try
            {
                string kullaniciAdi = girisYapanKullanici;
                string dosyaIsmi = kullaniciAdi + "_HarcamaRaporu.txt";
                string dosyaYolu = Path.Combine(Application.StartupPath, dosyaIsmi);

                using (StreamWriter sw = new StreamWriter(dosyaYolu))
                {
                    sw.WriteLine($"--- {kullaniciAdi.ToUpper()} HARCAMA RAPORU ---");
                    sw.WriteLine("Tarih: " + DateTime.Now.ToString());
                    sw.WriteLine("-------------------------------");

                    foreach (DataGridViewRow satir in dataGridView1.Rows)
                    {
                        if (!satir.IsNewRow)
                        {
                            string tur = satir.Cells[0].Value?.ToString() ?? "Belirsiz";
                            string tutar = satir.Cells[1].Value?.ToString() ?? "0";

                            sw.WriteLine($"Kategori: {tur} - Tutar: {tutar} TL");
                        }
                    }
                }
                MessageBox.Show(dosyaIsmi + " başarıyla oluşturuldu!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Dosya yazılırken hata: " + ex.Message);
            }
        }

        private void btnRaporOku_Click(object sender, EventArgs e)
        {
            try
            {
                string dosyaIsmi = girisYapanKullanici + "_HarcamaRaporu.txt";
                string dosyaYolu = Path.Combine(Application.StartupPath, dosyaIsmi);

                if (File.Exists(dosyaYolu))
                {
                    System.Diagnostics.Process.Start(dosyaYolu);
                }
                else
                {
                    MessageBox.Show(girisYapanKullanici + " için henüz bir rapor oluşturulmamış! Önce 'Rapor Al' butonuna basın.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Dosya açılırken bir hata oluştu: " + ex.Message);
            }
        }
        private void Form2_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}