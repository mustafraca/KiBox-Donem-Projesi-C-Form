using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;

namespace KiBox
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }
        OleDbConnection baglan = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=KiBox.mdb");
        OleDbCommand komut;
        OleDbDataReader reader;

        private void Form2_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            if (Form1.admin_mi == 1)
            {
                button7.Enabled = true;
            }
            else
            { button7.Enabled = false; }
            ToolTip toolTip = new ToolTip();
            toolTip.ShowAlways = true;
            toolTip.SetToolTip(button9, "ÇIKIŞ");

            try
            {
                baglan.Open();
                string adsoyad = "SELECT ad, soyad, s_giris FROM kullanici WHERE id='" + Form1.id + "'";
                komut = new OleDbCommand(adsoyad, baglan);
                reader = komut.ExecuteReader();
                if (reader.Read())
                {
                    label1.Text = "Sn. " + reader["ad"].ToString() + " " + reader["soyad"].ToString();
                    label2.Text = "Hoşgeldiniz";
                    if (reader["s_giris"].ToString() == "")
                    {
                        label6.Text = "Son Girişiniz: " + DateTime.Now.ToShortDateString() + " " + DateTime.Now.ToShortTimeString();
                    }
                    else
                    {
                        label6.Text = "Son Girişiniz: " + Form1.s_giris;
                    }
                }
                komut.Dispose();
            }
            catch (Exception hata)
            {
                MessageBox.Show(hata.Message);
            }
            baglan.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form4 yeni = new Form4();
            yeni.Show(); this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form5 yeni = new Form5();
            yeni.Show(); this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form6 yeni = new Form6();
            yeni.Show(); this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form7 yeni = new Form7();
            yeni.Show(); this.Hide();
        }
        
        private void button7_Click(object sender, EventArgs e)
        {
            Form10 yeni = new Form10();
            yeni.Show(); this.Hide();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            Form11 yeni = new Form11();
            yeni.Show(); this.Hide();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            DialogResult cıkıs = MessageBox.Show("Çıkış Yapılsın mı?", "Bilgilendirme Mesajı", 
                MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2);
            if(cıkıs == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            label3.Text = "Kullanıcı Adı: " + Form1.id;
            label4.Text = "Tarih: " + DateTime.Now.ToShortDateString();
            label5.Text = "Saat : " + DateTime.Now.ToLongTimeString();
        }
    }
}
