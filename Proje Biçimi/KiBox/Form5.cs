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
using Microsoft.VisualBasic;

namespace KiBox
{
    public partial class Form5 : Form
    {
        public Form5()
        {
            InitializeComponent();
        }

        OleDbConnection baglan = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=KiBox.mdb");
        OleDbCommand komut;
        OleDbDataReader reader;

        private void Form5_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void Form5_Load(object sender, EventArgs e)
        {
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            try
            {
                komut = new OleDbCommand();
                baglan.Open();
                komut.Connection = baglan;
                komut.CommandText = "SELECT * FROM kullanici WHERE id='" + Form1.id + "'";
                reader = komut.ExecuteReader();
                if (reader.Read())
                {
                    komut = new OleDbCommand("SELECT * FROM kullanici WHERE id='" + Form1.id + "'", baglan);
                    reader = komut.ExecuteReader();
                    while (reader.Read())
                    {
                        textBox2.Text = reader["ad"].ToString();
                        textBox3.Text = reader["soyad"].ToString();
                        textBox4.Text = reader["eposta"].ToString();
                        maskedTextBox1.Text = reader["tel"].ToString();
                        maskedTextBox2.Text = reader["dogum"].ToString();
                    }
                }
            }
            catch (Exception hata)
            {
                MessageBox.Show(hata.Message);
            }
            baglan.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form2 x = new Form2();
            x.Show(); this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            groupBox1.Enabled = true;
            button2.Enabled = false;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (textBox2.Text != "" && textBox3.Text != "" && textBox4.Text != ""
                && maskedTextBox1.Text != "(   )    -" && maskedTextBox2.Text != "  .  .")
            {
                try
                {
                    komut = new OleDbCommand();
                    baglan.Open();
                    komut.Connection = baglan;
                    komut.CommandText = "UPDATE kullanici SET ad='" + textBox2.Text +
                        "', soyad='" + textBox3.Text + "', eposta='" + textBox4.Text +
                        "', tel='" + maskedTextBox1.Text + "', dogum='" + maskedTextBox2.Text +
                        "' WHERE id='" + Form1.id + "'";
                    komut.ExecuteNonQuery();
                    MessageBox.Show("Bilgileriniz Güncellendi.", "Bilgilendirme Mesajı", 
                        MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    groupBox1.Enabled = false;
                    button2.Enabled = true;
            }
                catch (Exception hata)
            {
                MessageBox.Show(hata.Message);
            }
            baglan.Close();
            }
            else
            {
                MessageBox.Show("Boş Alan Bırakmayın Lütfen.", "Bilgilendirme Mesajı", 
                    MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
        }
    }
}
