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
    public partial class Form7 : Form
    {
        public Form7()
        {
            InitializeComponent();
        }

        OleDbConnection baglan = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=KiBox.mdb");
        OleDbCommand komut;
        OleDbDataReader reader;

        private void Form7_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void Form7_Load(object sender, EventArgs e)
        {
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            textBox1.Focus();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "" && textBox2.Text != "")
            {
                try
                {
                    komut = new OleDbCommand();
                    baglan.Open();

                    komut.Connection = baglan;
                    komut.CommandText = "SELECT * FROM kullanici WHERE id='" + textBox1.Text +
                        "' AND sifre='" + textBox2.Text + "'";
                    reader = komut.ExecuteReader();
                    if (reader.Read())
                    {
                        groupBox1.Enabled = true;
                        textBox1.Enabled = false;
                        textBox2.Enabled = false;
                    }
                    else
                    {
                        MessageBox.Show("Bilgiler Eksik veya Hatalı Girildi!", "Bilgilendirme Mesajı", 
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                        textBox1.Clear();
                        textBox2.Clear();
                        textBox1.Focus();
                    }
                }
                catch (Exception hata)
                {
                    MessageBox.Show(hata.Message);
                }
            }
            else
            {
                MessageBox.Show("Boş Alan Bırakmayınız.", "Bilgilendirme Mesajı", 
                    MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
            baglan.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox3.Text != "" && textBox4.Text != "")
            {
                try
                {
                    if (textBox3.Text == textBox4.Text)
                    {
                        komut = new OleDbCommand();
                        baglan.Open();
                        komut.Connection = baglan;
                        komut.CommandText = "UPDATE kullanici SET sifre='" + textBox3.Text + "' WHERE id='" + textBox1.Text + "'";
                        komut.ExecuteNonQuery();
                        MessageBox.Show("Şifreniz Güncellendi.", "Bilgilendirme Mesajı", 
                            MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        groupBox1.Enabled = false;
                        textBox1.Enabled = true;
                        textBox2.Enabled = true;
                        textBox1.Clear();
                        textBox2.Clear();
                        textBox3.Clear();
                        textBox4.Clear();

                    }
                    else
                    {
                        MessageBox.Show("Şifreler Eşleşmedi. Kontrol Ediniz!", "Bilgilendirme Mesajı", 
                            MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        textBox3.Clear();
                        textBox4.Clear();
                        textBox3.Focus();
                    }
                }
                catch (Exception hata)
                {
                    MessageBox.Show(hata.Message);
                }
            }
            else
            {
                MessageBox.Show("Boş Alan Bırakmayınız.", "Bilgilendirme Mesajı", 
                    MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
            baglan.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form2 x = new Form2();
            x.Show(); this.Hide();
        }
    }
}
