using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SQLite;
using System.IO;


namespace ButceTakipSistemi
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)//kayıt ol butonu
        {
            try
            {
                string klasorYolu = Application.StartupPath;
                string tamYol = Path.Combine(klasorYolu, "veritabani.db");//klasör yolu ile veritabanını birleştirir

                using (var baglanti = new System.Data.SQLite.SQLiteConnection($"Data Source={tamYol};Version=3;"))//sql bağlantısı
                {
                    baglanti.Open();

                    string sql = "INSERT INTO Kullanicilar (kullanici_adi, sifre) VALUES (@p1, @p2)";
                    using (var komut = new System.Data.SQLite.SQLiteCommand(sql, baglanti))
                    {
                        komut.Parameters.AddWithValue("@p1", textBox1.Text);
                        komut.Parameters.AddWithValue("@p2", textBox2.Text);
                        komut.ExecuteNonQuery();
                    }

                    baglanti.Close();
                }

                MessageBox.Show("BAŞARILI!");
            }
            catch (Exception hata)
            {
                MessageBox.Show("Hata: " + hata.Message);
            }
        }

        private void button1_Click(object sender, EventArgs e)//giriş yap butonu
        {
            try
            {
                string dbYolu = Path.Combine(Application.StartupPath, "veritabani.db");

                using (SQLiteConnection baglanti = new SQLiteConnection($"Data Source={dbYolu};Version=3;"))
                {
                    baglanti.Open();
                    string sql = "SELECT * FROM Kullanicilar WHERE kullanici_adi=@p1 AND sifre=@p2";

                    using (SQLiteCommand komut = new SQLiteCommand(sql, baglanti))
                    {
                        komut.Parameters.AddWithValue("@p1", textBox1.Text);
                        komut.Parameters.AddWithValue("@p2", textBox2.Text);

                        using (SQLiteDataReader oku = komut.ExecuteReader())
                        {
                            if (oku.Read())
                            {
                                string kadi = oku["kullanici_adi"].ToString();
                                int id = Convert.ToInt32(oku["id"]);

                                if (kadi.ToLower() == "admin")
                                {
                                    MessageBox.Show("Yönetici Paneline Hoş Geldiniz!");
                                    Form5 adminPanel = new Form5();
                                    adminPanel.Show();
                                }
                                else
                                {
                                    MessageBox.Show("Hoş geldiniz, " + kadi);
                                    Form2 anaSayfa = new Form2();
                                    anaSayfa.girisYapanKullanici = kadi;
                                    anaSayfa.girisYapanID = id;
                                    anaSayfa.Show();
                                }

                                this.Hide();
                            }
                            else
                            {
                                MessageBox.Show("Kullanıcı adı veya şifre hatalı!");
                            }
                        }
                    }
                }
            }
            catch (Exception hata)
            {
                MessageBox.Show("Bir hata oluştu: " + hata.Message);
            }
        }

        private void button3_Click(object sender, EventArgs e)//kullanıcı işlemleri butonu
        {
            try
            {
                string dbYolu = Path.Combine(Application.StartupPath, "veritabani.db");

                using (SQLiteConnection baglanti = new SQLiteConnection($"Data Source={dbYolu};Version=3;"))
                {
                    baglanti.Open();
                    string sql = "SELECT id FROM Kullanicilar WHERE kullanici_adi=@p1 AND sifre=@p2";

                    using (SQLiteCommand komut = new SQLiteCommand(sql, baglanti))
                    {
                        komut.Parameters.AddWithValue("@p1", textBox1.Text);
                        komut.Parameters.AddWithValue("@p2", textBox2.Text);

                        object sonuc = komut.ExecuteScalar();

                        if (sonuc != null)
                        {
                            Form6 f6 = new Form6();
                            f6.kullaniciID = Convert.ToInt32(sonuc);
                            f6.Show();
                            this.Hide();
                        }
                        else
                        {
                            MessageBox.Show("Geçerli kullanıcı adı ve şifrenizi girmelisiniz!");
                        }
                    }
                }
            }
            catch (Exception hata)
            {
                MessageBox.Show("İşlem sırasında hata: " + hata.Message);
            }
        }
    }
}
