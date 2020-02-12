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
    public partial class Form8 : Form
    {
        public Form8()
        {
            InitializeComponent();
        }

        OleDbConnection baglan = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=KiBox.mdb");
        OleDbCommand komut;
        OleDbDataReader reader;

        private void Form8_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void Form8_Load(object sender, EventArgs e)
        {
            try
            {
                komut = new OleDbCommand();
                baglan.Open();
                komut.Connection = baglan;
                komut.CommandText = "SELECT rapor FROM k_raporu";
                reader = komut.ExecuteReader();
                while (reader.Read())
                {
                    string rapor = reader["rapor"].ToString();
                    richTextBox1.Text = rapor;
                }
                baglan.Close();
            }
            catch (Exception hata)
            {
                MessageBox.Show(hata.Message);
            }
            ToolTip toolTip = new ToolTip();
            toolTip.ShowAlways = true;
            toolTip.SetToolTip(button1, "Kes");
            toolTip.SetToolTip(button2, "Kopyala");
            toolTip.SetToolTip(button3, "Yapıştır");
            toolTip.SetToolTip(button4, "Sil");
            toolTip.SetToolTip(button5, "Kaydet");
            toolTip.SetToolTip(button6, "Metin Belgesi Olarak Kaydet");
            toolTip.SetToolTip(button7, "Metin Belgesi Aç");
            toolTip.SetToolTip(button8, "Ana Menüye Git");
            toolTip.SetToolTip(button9, "ÇIKIŞ");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (richTextBox1.SelectionLength > 0)
                {
                    button1.Enabled = true;
                    Clipboard.SetText(richTextBox1.SelectedText);
                    richTextBox1.SelectedText = "";
                }
                else
                {
                    button1.Enabled = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                if (richTextBox1.SelectionLength > 0)
                {
                    button2.Enabled = true;
                    Clipboard.SetText(richTextBox1.SelectedText);

                }
                else
                {
                    button2.Enabled = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                if (Clipboard.ContainsText())
                {
                    richTextBox1.SelectedText = Clipboard.GetText();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                if (richTextBox1.SelectionLength > 0)
                {
                    richTextBox1.SelectedText = "";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            try
            {       
                komut = new OleDbCommand();
                baglan.Open();
                komut.Connection = baglan;
                komut.CommandText = "UPDATE k_raporu SET rapor='" + richTextBox1.Text.ToString() + 
                    "' WHERE id='" + 1 + "'";
                komut.ExecuteNonQuery();
                MessageBox.Show("Kaydedildi.", "Bilgilendirme Mesajı", 
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                baglan.Close();
            }
            catch (Exception hata)
            {
                MessageBox.Show(hata.Message);
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            try
            {
                saveFileDialog1.Title = "Dosya Adı Giriniz:";
                saveFileDialog1.Filter = "Metin Dosyaları |*.txt|" + "Bütün Dosyalar|*.*";
                saveFileDialog1.DefaultExt = "txt";
                if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    string dosyaadi = saveFileDialog1.FileName;
                    System.IO.TextWriter dosya = System.IO.File.CreateText(dosyaadi);
                    dosya.Write(richTextBox1.Text);
                    dosya.Close();
                }
            }
            catch (Exception hata)
            {
                MessageBox.Show(hata.Message);
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            try
            {
                openFileDialog1.Filter = "Metin Dosyaları |*.txt|" + "Bütün Dosyalar|*.*";
                openFileDialog1.Title = "Açılacak Dosyayı Seçiniz:";
                if (openFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    string dosyaadi = openFileDialog1.FileName;
                    System.IO.TextReader dosya = System.IO.File.OpenText(dosyaadi);
                    string x = dosya.ReadToEnd();
                    dosya.Close();
                    richTextBox1.Text = x;
                }
            }
            catch (Exception hata)
            {
                MessageBox.Show(hata.Message);
            }
        }

        public static string kontrol;
        public static string rich;
        private void button8_Click(object sender, EventArgs e)
        {
            try
            {          
                komut = new OleDbCommand();
                baglan.Open();
                komut.Connection = baglan;
                komut.CommandText = "SELECT rapor FROM k_raporu";
                reader = komut.ExecuteReader();
                while (reader.Read())
                {
                    kontrol = reader["rapor"].ToString();
                }
                rich = richTextBox1.Text.ToString();
                if (kontrol != rich)
                {
                    DialogResult secenek = MessageBox.Show("Değişiklikleri Kaydetmek İstiyor musunuz?", "Bilgilendirme Mesajı",
            MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                    if (secenek == DialogResult.Yes)
                    {
                        komut.Dispose();
                        komut = new OleDbCommand();
                        komut.Connection = baglan;
                        komut.CommandText = "UPDATE k_raporu SET rapor='" + richTextBox1.Text.ToString() +
                            "' WHERE id='" + 1 + "'";
                        komut.ExecuteNonQuery(); ;
                        Form2 x = new KiBox.Form2();
                        x.Show(); this.Hide();
                    }
                    else
                    {
                        Form2 x = new KiBox.Form2();
                        x.Show(); this.Hide();
                    }
                }
                else
                {
                        Form2 x = new KiBox.Form2();
                        x.Show(); this.Hide();
                }
            }
            catch (Exception hata)
            {
                MessageBox.Show(hata.Message);
            }
            baglan.Close();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            try
            {
                komut = new OleDbCommand();
                baglan.Open();
                komut.Connection = baglan;
                komut.CommandText = "SELECT rapor FROM k_raporu";
                reader = komut.ExecuteReader();
                reader.Read();
                while (reader.HasRows == true)
                {
                    kontrol = reader["rapor"].ToString();
                }
                rich = richTextBox1.Text.ToString();
                if (kontrol != rich)
                {
                    DialogResult secenek = MessageBox.Show("Değişiklikleri Kaydetmek İstiyor musunuz?", "Bilgilendirme Mesajı",
            MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                    if (secenek == DialogResult.Yes)
                    {
                        komut.Dispose();
                        komut = new OleDbCommand();
                        komut.Connection = baglan;
                        komut.CommandText = "UPDATE k_raporu SET rapor='" + richTextBox1.Text.ToString() +
                            "' WHERE id='" + 1 + "'";
                        komut.ExecuteNonQuery(); ;
                        Form2 x = new KiBox.Form2();
                        x.Show(); this.Hide();
                    }
                    else
                    {
                        Form2 x = new KiBox.Form2();
                        x.Show(); this.Hide();
                    }
                }
                else
                {
                    DialogResult cıkıs = MessageBox.Show("Çıkış Yapılsın mı?", "Bilgilendirme Mesajı",
            MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                    if (cıkıs == DialogResult.Yes)
                    {
                        Application.Exit();
                    }
                }
            }
            catch (Exception hata)
            {
                MessageBox.Show(hata.Message);
            }
            baglan.Close();
        }
    }
}
