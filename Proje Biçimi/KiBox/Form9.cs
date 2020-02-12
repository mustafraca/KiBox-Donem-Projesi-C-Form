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
    public partial class Form9 : Form
    {
        public Form9()
        {
            InitializeComponent();
        }

        OleDbConnection baglan = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=KiBox.mdb");
        OleDbCommand komut;
        OleDbDataReader reader;

        private void Form9_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void Form9_Load(object sender, EventArgs e)
        {
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            textBox1.Focus();
            button1.Focus();
            try
            {
                baglan.Open();
                string ad = "SELECT ad_soyad FROM kisiler";
                komut = new OleDbCommand(ad, baglan);
                reader = komut.ExecuteReader();
                while (reader.Read())
                {
                    listBox1.Items.Add(reader["ad_soyad"]).ToString();
                }
                baglan.Close();
                textBox1.Focus();
                ToolTip toolTip = new ToolTip();
                toolTip.ShowAlways = true;
                toolTip.SetToolTip(button4, "Ana Menüye Git");
                toolTip.SetToolTip(button3, "KiBox'a Git");
                toolTip.SetToolTip(button5, "ÇIKIŞ");
            }
            catch (Exception hata)
            {
                MessageBox.Show(hata.Message);
            }
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            textBox1.Text = listBox1.SelectedItem.ToString();
        }

        public static int b;
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                baglan.Open();
                string ad = "SELECT ad_soyad FROM kisiler WHERE ad_soyad='" + textBox1.Text.ToString() + "'";
                komut = new OleDbCommand(ad, baglan);
                reader = komut.ExecuteReader();
                if (reader.Read())
                {
                    b = 0;
                    baglan.Close();
                    printPreviewDialog1.Document = printDocument1;
                    printPreviewDialog1.ShowDialog();
                }
                else
                {
                    MessageBox.Show("Kullanıcı Adı Bulunamadı.", "Bilgilendirme Mesajı", 
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    textBox1.Clear();
                    textBox1.Focus();
                }
                baglan.Close();
            }
            catch (Exception hata)
            {
                MessageBox.Show(hata.Message);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            b = 1;
            printPreviewDialog1.Document = printDocument1;
            printPreviewDialog1.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form4 yeni = new Form4();
            yeni.Show(); this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form2 yeni = new Form2();
            yeni.Show(); this.Hide();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            DialogResult cıkıs = MessageBox.Show("Çıkış Yapılsın mı?", "Bilgilendirme Mesajı", 
                MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
            if (cıkıs == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        int i = 0;
        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            if (b == 1)
            {
                baglan.Open();
                Font baslik_fontu = new Font("Tahoma", 14, FontStyle.Bold);
                Font yazi_fontu = new Font("Tahoma", 8, FontStyle.Regular);
                Font kalinyazi_fontu = new Font("Tahoma", 8, FontStyle.Bold);
                int x = 115, y = 115, say = listBox1.Items.Count;
                System.Drawing.Printing.PageSettings p = printDocument1.DefaultPageSettings;
                e.Graphics.DrawString("KİŞİLERİN TÜM BİLGİLERİ", baslik_fontu, Brushes.Black, 280, 60);
                e.Graphics.DrawString(DateTime.Now.ToShortDateString(), yazi_fontu, Brushes.Black, 700, 80);

                while (i < say)
                {
                    e.Graphics.DrawLine(new Pen(Color.Black, 2), p.Margins.Left - 30, x - 10, p.PaperSize.Width + 30 - p.Margins.Right, x - 10);
                    e.Graphics.DrawString("Ad Soyad :", kalinyazi_fontu, Brushes.Black, 80, x);
                    e.Graphics.DrawString("Ev Telefonu :", kalinyazi_fontu, Brushes.Black, 80, x + 25);
                    e.Graphics.DrawString("Ev Telefonu 2:", kalinyazi_fontu, Brushes.Black, 80, x + 50);
                    e.Graphics.DrawString("Cep Telefonu :", kalinyazi_fontu, Brushes.Black, 80, x + 75);
                    e.Graphics.DrawString("Cep Telefonu 2:", kalinyazi_fontu, Brushes.Black, 80, x + 100);

                    e.Graphics.DrawString("İli :", kalinyazi_fontu, Brushes.Black, 335, x);
                    e.Graphics.DrawString("İlçesi :", kalinyazi_fontu, Brushes.Black, 560, x);
                    e.Graphics.DrawString("Meslek :", kalinyazi_fontu, Brushes.Black, 335, x + 25);
                    e.Graphics.DrawString("Cinsiyet :", kalinyazi_fontu, Brushes.Black, 560, x + 25);
                    e.Graphics.DrawString("Ev Adresi :", kalinyazi_fontu, Brushes.Black, 335, x + 50);
                    e.Graphics.DrawString("Mail Adresi :", kalinyazi_fontu, Brushes.Black, 335, x + 75);
                    e.Graphics.DrawString("Web Adresi :", kalinyazi_fontu, Brushes.Black, 335, x + 100);

                    e.Graphics.DrawString("Firma Adı :", kalinyazi_fontu, Brushes.Black, 80, x + 150);
                    e.Graphics.DrawString("Firma Tel No:", kalinyazi_fontu, Brushes.Black, 80, x + 175);
                    e.Graphics.DrawString("Firma Tel No 2:", kalinyazi_fontu, Brushes.Black, 80, x + 200);
                    e.Graphics.DrawString("Firma Cep No:", kalinyazi_fontu, Brushes.Black, 80, x + 225);
                    e.Graphics.DrawString("Firma Faks No:", kalinyazi_fontu, Brushes.Black, 80, x + 250);

                    e.Graphics.DrawString("Firma Adresi :", kalinyazi_fontu, Brushes.Black, 335, x + 150);
                    e.Graphics.DrawString("Firma Şehir :", kalinyazi_fontu, Brushes.Black, 335, x + 175);
                    e.Graphics.DrawString("Firma İlçe :", kalinyazi_fontu, Brushes.Black, 560, x + 175);
                    e.Graphics.DrawString("Araç Plakası :", kalinyazi_fontu, Brushes.Black, 335, x + 200);
                    e.Graphics.DrawString("Firma Vergi No :", kalinyazi_fontu, Brushes.Black, 560, x + 200);
                    e.Graphics.DrawString("Web Adresi :", kalinyazi_fontu, Brushes.Black, 335, x + 225);
                    e.Graphics.DrawString("Vergi Dairesi :", kalinyazi_fontu, Brushes.Black, 560, x + 225);
                    e.Graphics.DrawString("Mail Adresi :", kalinyazi_fontu, Brushes.Black, 335, x + 250);

                    e.Graphics.DrawString("Kimlik Türü :", kalinyazi_fontu, Brushes.Black, 80, x + 300);
                    e.Graphics.DrawString("TC Numarası :", kalinyazi_fontu, Brushes.Black, 80, x + 325);
                    e.Graphics.DrawString("Baba Adı :", kalinyazi_fontu, Brushes.Black, 80, x + 350);
                    e.Graphics.DrawString("Anne Adı :", kalinyazi_fontu, Brushes.Black, 80, x + 375);
                    e.Graphics.DrawString("Doğum Yeri :", kalinyazi_fontu, Brushes.Black, 80, x + 400);
                    e.Graphics.DrawString("Doğum Tarihi :", kalinyazi_fontu, Brushes.Black, 80, x + 425);

                    e.Graphics.DrawString("Kimlik Seri No :", kalinyazi_fontu, Brushes.Black, 335, x + 375);
                    e.Graphics.DrawString("Kimlik İl :", kalinyazi_fontu, Brushes.Black, 335, x + 300);
                    e.Graphics.DrawString("Mahalle/Köy :", kalinyazi_fontu, Brushes.Black, 335, x + 400);
                    e.Graphics.DrawString("Verildi Yer :", kalinyazi_fontu, Brushes.Black, 335, x + 325);
                    e.Graphics.DrawString("Verildiği Tarih :", kalinyazi_fontu, Brushes.Black, 335, x + 425);
                    e.Graphics.DrawString("Kimlik İlçe :", kalinyazi_fontu, Brushes.Black, 335, x + 350);
                    e.Graphics.DrawString("Cilt No :", kalinyazi_fontu, Brushes.Black, 560, x + 300);
                    e.Graphics.DrawString("Aile Sıra No :", kalinyazi_fontu, Brushes.Black, 560, x + 325);
                    e.Graphics.DrawString("Sıra No :", kalinyazi_fontu, Brushes.Black, 560, x + 350);
                    x += 25;
                    string ad = listBox1.Items[i].ToString();
                    e.Graphics.DrawString(ad, yazi_fontu, Brushes.Black, 175, x - 25);
                    komut = new OleDbCommand("SELECT * FROM kisiler WHERE ad_soyad='" + ad + "'", baglan);
                    komut.Connection = baglan;
                    reader = komut.ExecuteReader();
                    if (reader.Read())
                    {
                        e.Graphics.DrawString(reader["ev_telefona"].ToString(), yazi_fontu, Brushes.Black, 175, x);
                        e.Graphics.DrawString(reader["ev_telefonb"].ToString(), yazi_fontu, Brushes.Black, 175, x + 25);
                        e.Graphics.DrawString(reader["cep_telefona"].ToString(), yazi_fontu, Brushes.Black, 175, x + 50);
                        e.Graphics.DrawString(reader["cep_telefonb"].ToString(), yazi_fontu, Brushes.Black, 175, x + 75);

                        e.Graphics.DrawString(reader["sehir"].ToString(), yazi_fontu, Brushes.Black, 415, x - 25);
                        e.Graphics.DrawString(reader["ilce"].ToString(), yazi_fontu, Brushes.Black, 620, x - 25);
                        e.Graphics.DrawString(reader["meslek"].ToString(), yazi_fontu, Brushes.Black, 415, x);
                        e.Graphics.DrawString(reader["cinsiyet"].ToString(), yazi_fontu, Brushes.Black, 620, x);
                        e.Graphics.DrawString(reader["ev_adresi"].ToString(), yazi_fontu, Brushes.Black, 415, x + 25);
                        e.Graphics.DrawString(reader["email"].ToString(), yazi_fontu, Brushes.Black, 415, x + 50);
                        e.Graphics.DrawString(reader["web"].ToString(), yazi_fontu, Brushes.Black, 415, x + 75);

                        e.Graphics.DrawString(reader["f_ad"].ToString(), yazi_fontu, Brushes.Black, 175, x + 125);
                        e.Graphics.DrawString(reader["f_telefona"].ToString(), yazi_fontu, Brushes.Black, 175, x + 150);
                        e.Graphics.DrawString(reader["f_telefona"].ToString(), yazi_fontu, Brushes.Black, 175, x + 175);
                        e.Graphics.DrawString(reader["f_cep"].ToString(), yazi_fontu, Brushes.Black, 175, x + 200);
                        e.Graphics.DrawString(reader["f_faks"].ToString(), yazi_fontu, Brushes.Black, 175, x + 225);

                        e.Graphics.DrawString(reader["f_adres"].ToString(), yazi_fontu, Brushes.Black, 418, x + 125);
                        e.Graphics.DrawString(reader["f_sehir"].ToString(), yazi_fontu, Brushes.Black, 418, x + 150);
                        e.Graphics.DrawString(reader["f_ilce"].ToString(), yazi_fontu, Brushes.Black, 630, x + 150);
                        e.Graphics.DrawString(reader["f_aracplaka"].ToString(), yazi_fontu, Brushes.Black, 418, x + 175);
                        e.Graphics.DrawString(reader["f_vergino"].ToString(), yazi_fontu, Brushes.Black, 655, x + 175);
                        e.Graphics.DrawString(reader["f_web"].ToString(), yazi_fontu, Brushes.Black, 418, x + 200);
                        e.Graphics.DrawString(reader["f_vergidaire"].ToString(), yazi_fontu, Brushes.Black, 645, x + 200);
                        e.Graphics.DrawString(reader["f_email"].ToString(), yazi_fontu, Brushes.Black, 418, x + 225);

                        e.Graphics.DrawString(reader["kimlik"].ToString(), yazi_fontu, Brushes.Black, 175, x + 275);
                        e.Graphics.DrawString(reader["tc_no"].ToString(), yazi_fontu, Brushes.Black, 175, x + 300);
                        e.Graphics.DrawString(reader["baba_adi"].ToString(), yazi_fontu, Brushes.Black, 175, x + 325);
                        e.Graphics.DrawString(reader["anne_adi"].ToString(), yazi_fontu, Brushes.Black, 175, x + 350);
                        e.Graphics.DrawString(reader["dogum_yeri"].ToString(), yazi_fontu, Brushes.Black, 175, x + 375);
                        e.Graphics.DrawString(reader["dogum_tarihi"].ToString(), yazi_fontu, Brushes.Black, 175, x + 400);

                        e.Graphics.DrawString(reader["kimlik_serino"].ToString(), yazi_fontu, Brushes.Black, 430, x + 350);
                        e.Graphics.DrawString(reader["kimlik_il"].ToString(), yazi_fontu, Brushes.Black, 415, x + 275);
                        e.Graphics.DrawString(reader["mah_koy"].ToString(), yazi_fontu, Brushes.Black, 430, x + 375);
                        e.Graphics.DrawString(reader["ver_yer"].ToString(), yazi_fontu, Brushes.Black, 415, x + 300);
                        e.Graphics.DrawString(reader["ver_tarih"].ToString(), yazi_fontu, Brushes.Black, 430, x + 400);
                        e.Graphics.DrawString(reader["kimlik_ilce"].ToString(), yazi_fontu, Brushes.Black, 415, x + 325);
                        e.Graphics.DrawString(reader["ciltno"].ToString(), yazi_fontu, Brushes.Black, 645, x + 275);
                        e.Graphics.DrawString(reader["ailesirano"].ToString(), yazi_fontu, Brushes.Black, 645, x + 300);
                        e.Graphics.DrawString(reader["sirano"].ToString(), yazi_fontu, Brushes.Black, 645, x + 325);
                    }
                    e.Graphics.DrawLine(new Pen(Color.Black, 2), p.Margins.Left - 30, x + 425, p.PaperSize.Width + 30 - p.Margins.Right, x + 425);
                    e.Graphics.DrawLine(new Pen(Color.Black, 2), p.Margins.Left - 29, x - 35, p.Margins.Left - 29, x + 425);
                    e.Graphics.DrawLine(new Pen(Color.Black, 2), p.Margins.Left + 225, x - 35, p.Margins.Left + 225, x + 425);
                    e.Graphics.DrawLine(new Pen(Color.Black, 2), p.Margins.Left + 656, x - 35, p.Margins.Left + 656, x + 425);
                    i++; x += 500;

                    if ((x + y + 40) > (p.PaperSize.Height + 80 - p.Margins.Bottom + 80))
                    {
                        e.HasMorePages = true;
                        break;
                    }
                }
                if (i >= say)
                {
                    e.HasMorePages = false;
                    i = 0;
                }
                baglan.Close();
            }
            else
            {
                Font baslik_fontu = new Font("Tahoma", 14, FontStyle.Bold);
                Font yazi_fontu = new Font("Tahoma", 8, FontStyle.Regular);
                Font kalinyazi_fontu = new Font("Tahoma", 8, FontStyle.Bold);
                int x = 115;
                System.Drawing.Printing.PageSettings p = printDocument1.DefaultPageSettings;
                e.Graphics.DrawString("KİŞİLERİN TÜM BİLGİLERİ", baslik_fontu, Brushes.Black, 280, 60);
                e.Graphics.DrawString(DateTime.Now.ToShortDateString(), yazi_fontu, Brushes.Black, 700, 80);

                e.Graphics.DrawLine(new Pen(Color.Black, 2), p.Margins.Left - 30, x - 10, p.PaperSize.Width + 30 - p.Margins.Right, x - 10);
                e.Graphics.DrawString("Ad Soyad :", kalinyazi_fontu, Brushes.Black, 80, x);
                e.Graphics.DrawString("Ev Telefonu :", kalinyazi_fontu, Brushes.Black, 80, x + 25);
                e.Graphics.DrawString("Ev Telefonu 2:", kalinyazi_fontu, Brushes.Black, 80, x + 50);
                e.Graphics.DrawString("Cep Telefonu :", kalinyazi_fontu, Brushes.Black, 80, x + 75);
                e.Graphics.DrawString("Cep Telefonu 2:", kalinyazi_fontu, Brushes.Black, 80, x + 100);

                e.Graphics.DrawString("İli :", kalinyazi_fontu, Brushes.Black, 335, x);
                e.Graphics.DrawString("İlçesi :", kalinyazi_fontu, Brushes.Black, 560, x);
                e.Graphics.DrawString("Meslek :", kalinyazi_fontu, Brushes.Black, 335, x + 25);
                e.Graphics.DrawString("Cinsiyet :", kalinyazi_fontu, Brushes.Black, 560, x + 25);
                e.Graphics.DrawString("Ev Adresi :", kalinyazi_fontu, Brushes.Black, 335, x + 50);
                e.Graphics.DrawString("Mail Adresi :", kalinyazi_fontu, Brushes.Black, 335, x + 75);
                e.Graphics.DrawString("Web Adresi :", kalinyazi_fontu, Brushes.Black, 335, x + 100);

                e.Graphics.DrawString("Firma Adı :", kalinyazi_fontu, Brushes.Black, 80, x + 150);
                e.Graphics.DrawString("Firma Tel No:", kalinyazi_fontu, Brushes.Black, 80, x + 175);
                e.Graphics.DrawString("Firma Tel No 2:", kalinyazi_fontu, Brushes.Black, 80, x + 200);
                e.Graphics.DrawString("Firma Cep No:", kalinyazi_fontu, Brushes.Black, 80, x + 225);
                e.Graphics.DrawString("Firma Faks No:", kalinyazi_fontu, Brushes.Black, 80, x + 250);

                e.Graphics.DrawString("Firma Adresi :", kalinyazi_fontu, Brushes.Black, 335, x + 150);
                e.Graphics.DrawString("Firma Şehir :", kalinyazi_fontu, Brushes.Black, 335, x + 175);
                e.Graphics.DrawString("Firma İlçe :", kalinyazi_fontu, Brushes.Black, 560, x + 175);
                e.Graphics.DrawString("Araç Plakası :", kalinyazi_fontu, Brushes.Black, 335, x + 200);
                e.Graphics.DrawString("Firma Vergi No :", kalinyazi_fontu, Brushes.Black, 560, x + 200);
                e.Graphics.DrawString("Web Adresi :", kalinyazi_fontu, Brushes.Black, 335, x + 225);
                e.Graphics.DrawString("Vergi Dairesi :", kalinyazi_fontu, Brushes.Black, 560, x + 225);
                e.Graphics.DrawString("Mail Adresi :", kalinyazi_fontu, Brushes.Black, 335, x + 250);

                e.Graphics.DrawString("Kimlik Türü :", kalinyazi_fontu, Brushes.Black, 80, x + 300);
                e.Graphics.DrawString("TC Numarası :", kalinyazi_fontu, Brushes.Black, 80, x + 325);
                e.Graphics.DrawString("Baba Adı :", kalinyazi_fontu, Brushes.Black, 80, x + 350);
                e.Graphics.DrawString("Anne Adı :", kalinyazi_fontu, Brushes.Black, 80, x + 375);
                e.Graphics.DrawString("Doğum Yeri :", kalinyazi_fontu, Brushes.Black, 80, x + 400);
                e.Graphics.DrawString("Doğum Tarihi :", kalinyazi_fontu, Brushes.Black, 80, x + 425);

                e.Graphics.DrawString("Kimlik Seri No :", kalinyazi_fontu, Brushes.Black, 335, x + 375);
                e.Graphics.DrawString("Kimlik İl :", kalinyazi_fontu, Brushes.Black, 335, x + 300);
                e.Graphics.DrawString("Mahalle/Köy :", kalinyazi_fontu, Brushes.Black, 335, x + 400);
                e.Graphics.DrawString("Verildi Yer :", kalinyazi_fontu, Brushes.Black, 335, x + 325);
                e.Graphics.DrawString("Verildiği Tarih :", kalinyazi_fontu, Brushes.Black, 335, x + 425);
                e.Graphics.DrawString("Kimlik İlçe :", kalinyazi_fontu, Brushes.Black, 335, x + 350);
                e.Graphics.DrawString("Cilt No :", kalinyazi_fontu, Brushes.Black, 560, x + 300);
                e.Graphics.DrawString("Aile Sıra No :", kalinyazi_fontu, Brushes.Black, 560, x + 325);
                e.Graphics.DrawString("Sıra No :", kalinyazi_fontu, Brushes.Black, 560, x + 350);
                x += 25;
                string ad = textBox1.Text.ToString();
                e.Graphics.DrawString(ad, yazi_fontu, Brushes.Black, 175, x - 25);
                baglan.Open();
                komut = new OleDbCommand("SELECT * FROM kisiler WHERE ad_soyad='" + ad + "'", baglan);
                komut.Connection = baglan;
                reader = komut.ExecuteReader();
                if (reader.Read())
                {
                    e.Graphics.DrawString(reader["ev_telefona"].ToString(), yazi_fontu, Brushes.Black, 175, x);
                    e.Graphics.DrawString(reader["ev_telefonb"].ToString(), yazi_fontu, Brushes.Black, 175, x + 25);
                    e.Graphics.DrawString(reader["cep_telefona"].ToString(), yazi_fontu, Brushes.Black, 175, x + 50);
                    e.Graphics.DrawString(reader["cep_telefonb"].ToString(), yazi_fontu, Brushes.Black, 175, x + 75);

                    e.Graphics.DrawString(reader["sehir"].ToString(), yazi_fontu, Brushes.Black, 415, x - 25);
                    e.Graphics.DrawString(reader["ilce"].ToString(), yazi_fontu, Brushes.Black, 620, x - 25);
                    e.Graphics.DrawString(reader["meslek"].ToString(), yazi_fontu, Brushes.Black, 415, x);
                    e.Graphics.DrawString(reader["cinsiyet"].ToString(), yazi_fontu, Brushes.Black, 620, x);
                    e.Graphics.DrawString(reader["ev_adresi"].ToString(), yazi_fontu, Brushes.Black, 415, x + 25);
                    e.Graphics.DrawString(reader["email"].ToString(), yazi_fontu, Brushes.Black, 415, x + 50);
                    e.Graphics.DrawString(reader["web"].ToString(), yazi_fontu, Brushes.Black, 415, x + 75);

                    e.Graphics.DrawString(reader["f_ad"].ToString(), yazi_fontu, Brushes.Black, 175, x + 125);
                    e.Graphics.DrawString(reader["f_telefona"].ToString(), yazi_fontu, Brushes.Black, 175, x + 150);
                    e.Graphics.DrawString(reader["f_telefona"].ToString(), yazi_fontu, Brushes.Black, 175, x + 175);
                    e.Graphics.DrawString(reader["f_cep"].ToString(), yazi_fontu, Brushes.Black, 175, x + 200);
                    e.Graphics.DrawString(reader["f_faks"].ToString(), yazi_fontu, Brushes.Black, 175, x + 225);

                    e.Graphics.DrawString(reader["f_adres"].ToString(), yazi_fontu, Brushes.Black, 418, x + 125);
                    e.Graphics.DrawString(reader["f_sehir"].ToString(), yazi_fontu, Brushes.Black, 418, x + 150);
                    e.Graphics.DrawString(reader["f_ilce"].ToString(), yazi_fontu, Brushes.Black, 630, x + 150);
                    e.Graphics.DrawString(reader["f_aracplaka"].ToString(), yazi_fontu, Brushes.Black, 418, x + 175);
                    e.Graphics.DrawString(reader["f_vergino"].ToString(), yazi_fontu, Brushes.Black, 655, x + 175);
                    e.Graphics.DrawString(reader["f_web"].ToString(), yazi_fontu, Brushes.Black, 418, x + 200);
                    e.Graphics.DrawString(reader["f_vergidaire"].ToString(), yazi_fontu, Brushes.Black, 645, x + 200);
                    e.Graphics.DrawString(reader["f_email"].ToString(), yazi_fontu, Brushes.Black, 418, x + 225);

                    e.Graphics.DrawString(reader["kimlik"].ToString(), yazi_fontu, Brushes.Black, 175, x + 275);
                    e.Graphics.DrawString(reader["tc_no"].ToString(), yazi_fontu, Brushes.Black, 175, x + 300);
                    e.Graphics.DrawString(reader["baba_adi"].ToString(), yazi_fontu, Brushes.Black, 175, x + 325);
                    e.Graphics.DrawString(reader["anne_adi"].ToString(), yazi_fontu, Brushes.Black, 175, x + 350);
                    e.Graphics.DrawString(reader["dogum_yeri"].ToString(), yazi_fontu, Brushes.Black, 175, x + 375);
                    e.Graphics.DrawString(reader["dogum_tarihi"].ToString(), yazi_fontu, Brushes.Black, 175, x + 400);

                    e.Graphics.DrawString(reader["kimlik_serino"].ToString(), yazi_fontu, Brushes.Black, 430, x + 350);
                    e.Graphics.DrawString(reader["kimlik_il"].ToString(), yazi_fontu, Brushes.Black, 415, x + 275);
                    e.Graphics.DrawString(reader["mah_koy"].ToString(), yazi_fontu, Brushes.Black, 430, x + 375);
                    e.Graphics.DrawString(reader["ver_yer"].ToString(), yazi_fontu, Brushes.Black, 415, x + 300);
                    e.Graphics.DrawString(reader["ver_tarih"].ToString(), yazi_fontu, Brushes.Black, 430, x + 400);
                    e.Graphics.DrawString(reader["kimlik_ilce"].ToString(), yazi_fontu, Brushes.Black, 415, x + 325);
                    e.Graphics.DrawString(reader["ciltno"].ToString(), yazi_fontu, Brushes.Black, 645, x + 275);
                    e.Graphics.DrawString(reader["ailesirano"].ToString(), yazi_fontu, Brushes.Black, 645, x + 300);
                    e.Graphics.DrawString(reader["sirano"].ToString(), yazi_fontu, Brushes.Black, 645, x + 325);
                }
                baglan.Close();
                e.Graphics.DrawLine(new Pen(Color.Black, 2), p.Margins.Left - 30, x + 425, p.PaperSize.Width + 30 - p.Margins.Right, x + 425);
                e.Graphics.DrawLine(new Pen(Color.Black, 2), p.Margins.Left - 29, x - 35, p.Margins.Left - 29, x + 425);
                e.Graphics.DrawLine(new Pen(Color.Black, 2), p.Margins.Left + 225, x - 35, p.Margins.Left + 225, x + 425);
                e.Graphics.DrawLine(new Pen(Color.Black, 2), p.Margins.Left + 656, x - 35, p.Margins.Left + 656, x + 425);
            }
        }
    }
}
