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
    public partial class Form3 : Form
    {
        public Form anaForm;
        public int girisYapanID;
        public Form3()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)//harcamayı kaydet butonu
        {
            try
            {
                string dbYolu = Path.Combine(Application.StartupPath, "veritabani.db");
                using (var baglanti = new SQLiteConnection($"Data Source={dbYolu};Version=3;"))
                {
                    baglanti.Open();

                    string sql = "INSERT INTO Harcamalar (kategori, miktar, kullanici_id) VALUES (@p1, @p2, @p3)";

                    using (var komut = new SQLiteCommand(sql, baglanti))
                    {
                        komut.Parameters.AddWithValue("@p1", comboBox1.Text); // Kategori
                        komut.Parameters.AddWithValue("@p2", textBox1.Text);  // Tutar

                        komut.Parameters.AddWithValue("@p3", girisYapanID);

                        komut.ExecuteNonQuery();
                        MessageBox.Show("Harcama Başarıyla Kaydedildi!");
                        textBox1.Clear();
                        comboBox1.SelectedIndex = -1;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata oluştu: " + ex.Message);
            }
        }

        private void btnGeri_Click(object sender, EventArgs e)
        {
            if (anaForm != null)
            {
                anaForm.Show();
            }
            this.FormClosed -= Form3_FormClosed;
            this.Dispose();
        }

        private void Form3_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}
