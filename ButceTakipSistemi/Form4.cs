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
using System.Windows.Forms.DataVisualization.Charting;



namespace ButceTakipSistemi
{
    public partial class Form4 : Form
    {
        public Form anaForm;
        public int girisYapanID;
        public Form4()
        {
            InitializeComponent();
        }  

        private void Form4_Load(object sender, EventArgs e)
        {
            GrafikleriCiz();
        }

        void GrafikleriCiz()
        {
            try
            {
                string dbYolu = Path.Combine(Application.StartupPath, "veritabani.db");
                using (var baglanti = new SQLiteConnection($"Data Source={dbYolu};Version=3;"))
                {
                    baglanti.Open();
                    string sql = "SELECT kategori, SUM(miktar) FROM Harcamalar WHERE kullanici_id = @p1 GROUP BY kategori";

                    using (var komut = new SQLiteCommand(sql, baglanti))
                    {
                        komut.Parameters.AddWithValue("@p1", girisYapanID);
                        using (var oku = komut.ExecuteReader())
                        {
                            chart1.Series[0].Points.Clear();
                            chart1.Series[0].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Column;
                            chart1.Series[0].Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.BrightPastel; // Renkleri canlandırır
                            chart1.Series[0].IsValueShownAsLabel = true; // Sütunların üzerine tutarları yazar

                            while (oku.Read())
                            {
                                chart1.Series[0].Points.AddXY(oku["kategori"].ToString(), oku["SUM(miktar)"]);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Grafik hatası: " + ex.Message);
            }
        }

        private void button1_Click(object sender, EventArgs e)//geri butonu
        {
            if (anaForm != null)
            {
                anaForm.Show();
            }

            this.FormClosed -= Form4_FormClosed;
            this.Dispose();
        }
        private void Form4_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}
