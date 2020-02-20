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
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        OleDbConnection baglan = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=KiBox.mdb");
        OleDbCommand komut;
        OleDbDataReader reader;

        private void Form3_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form1 x = new KiBox.Form1();
            x.Show(); this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "" && textBox2.Text != "" && textBox3.Text != "" && maskedTextBox1.Text != "" && maskedTextBox2.Text != "")
            {
                try
                {
                    komut = new OleDbCommand();
                    baglan.Open();
                    komut.Connection = baglan;
                    komut.CommandText = "SELECT * FROM kullanici WHERE id='" + textBox1.Text +
                        "' AND ad='" + textBox2.Text + "' AND soyad='" + textBox3.Text + "' AND tel='"
                        + maskedTextBox1.Text + "' AND dogum='" + maskedTextBox2.Text + "'";
                    reader = komut.ExecuteReader();
                    if (reader.Read())
                    {
                        groupBox1.Enabled = true;
                    }
                    else
                    {
                        MessageBox.Show("Kullanıcı bilgileri eksik veya hatalı girildi. Tekrar deneyiniz!", "Bilgilendirme Mesajı", 
                            MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    }
                }
                catch (Exception hata)
                {
                    MessageBox.Show(hata.Message);
                }
            }
            else
            {
                MessageBox.Show("Boş Alan Bırakmayınız!", "Bilgilendirme Mesajı", 
                    MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
            baglan.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (textBox6.Text != "" && textBox7.Text != "")
            {
                try
                {
                    komut = new OleDbCommand();
                    baglan.Open();
                    komut.Connection = baglan;
                    if (textBox6.Text == textBox7.Text)
                    {
                        komut.CommandText = "UPDATE kullanici SET sifre=@psifre WHERE id='" + textBox1.Text + "'";
                        komut.Parameters.AddWithValue("@psifre", textBox6.Text);
                        komut.ExecuteNonQuery();
                        Form1 x = new Form1();
                        x.Show(); this.Hide();
                    }
                    else
                    {
                        MessageBox.Show("Şifreler Birbiriyle Eşleşmiyor!", "Bilgilendirme Mesajı", 
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception hata)
                {
                    MessageBox.Show(hata.Message);
                }
            }
            else
            {
                MessageBox.Show("Boş Alan Bırakmayınız!", "Bilgilendirme Mesajı", 
                    MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
            baglan.Close();
        }
    }
}
