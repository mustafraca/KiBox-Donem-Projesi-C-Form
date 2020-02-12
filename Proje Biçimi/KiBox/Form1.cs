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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        
        OleDbConnection baglan = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=KiBox.mdb");
        OleDbCommand komut;
        OleDbCommand komut2;
        OleDbCommand komut3;
        OleDbDataReader reader;
        OleDbDataReader reader2;
        OleDbDataReader reader3;

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            textBox1.Focus();
            try
            {
                baglan.Open();
                string eh = "SELECT * FROM hatirla";
                komut = new OleDbCommand(eh, baglan);
                reader = komut.ExecuteReader();
                if (reader.Read())
                {
                    if (reader["checkbox"].ToString() == "evet")
                    {
                        checkBox1.Checked = true;
                        textBox1.Text = reader["id"].ToString();
                        textBox2.Text = reader["sifre"].ToString();
                    }
                }
                komut.Dispose();
                komut = new OleDbCommand("SELECT id FROM k_raporu");
                komut.Connection = baglan;
                reader2 = komut.ExecuteReader();
                reader2.Read();
                if (Convert.ToInt16(reader2["id"]) == 0)
                {
                    MessageBox.Show("Hoşgeldiniz.\nAşağıda verilen kullanıcı bilgileri ile programa bir defaya mashsus giriş yapabilirsiniz." + "\nKullanıcı Adı: kibox\nŞifre: kibox\nDikkat: Giriş yaptıktan sonra admin paneline yönlendirileceksiniz." + " Yönlendirildiğiniz menüden kayıt olunuz!", "Bilgilendirme Mesajı", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    komut.Dispose();
                    komut = new OleDbCommand();
                    komut.Connection = baglan;
                    komut.CommandText = "UPDATE k_raporu SET id='" + 1 + "'";
                    komut.ExecuteNonQuery();
                }
                baglan.Close();
            }
            catch (Exception hata)
            {
                MessageBox.Show(hata.Message);
            }
        }

        public static int admin_mi = 0;
        public static string id;
        public static string kibox;
        public static string s_giris;

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "" && textBox2.Text != "")
            {
                try
                {
                    baglan.Open();
                    id = "SELECT id FROM kullanici WHERE id='" + textBox1.Text + "'";
                    string sifre = "SELECT sifre FROM kullanici WHERE sifre='" + textBox2.Text + "' AND id='" + textBox1.Text + "'";
                    string admin = "SELECT admin FROM kullanici WHERE id='" + textBox1.Text + "' AND admin='" + "admin" + "'";
                    komut = new OleDbCommand(id, baglan);
                    komut2 = new OleDbCommand(sifre, baglan);
                    komut3 = new OleDbCommand(admin, baglan);
                    reader = komut.ExecuteReader();
                    reader2 = komut2.ExecuteReader();
                    reader3= komut3.ExecuteReader();
                    reader.Read(); reader2.Read(); reader3.Read();
                    if (reader.HasRows == true && reader2.HasRows == true)
                    {
                        if (textBox1.Text != "kibox" && textBox2.Text != "kibox")
                        {
                            if (reader3.HasRows == true)
                            {
                                admin_mi = 1;
                                id = textBox1.Text;
                            }
                            else
                            {
                                admin_mi = 0;
                                id = textBox1.Text;
                            }
                            komut.Dispose();
                            reader.Dispose();
                            string giris = "SELECT s_giris FROM kullanici WHERE id='" + Form1.id + "'";
                            komut = new OleDbCommand(giris, baglan);
                            reader = komut.ExecuteReader();
                            reader.Read();
                            if (reader.HasRows == true)
                            {
                                s_giris = reader["s_giris"].ToString();
                            }
                            Form2 x = new Form2();
                            x.Show(); this.Hide();
                        }
                        else
                        {
                            admin_mi = 1;
                            id = textBox1.Text;
                            MessageBox.Show("Dikkat: Girdiğiniz kullanıcı adı ve şifre programa ilk girişinizi sağladığı için silinecektir. " +
                                "\nYönlendirildiğiniz menüden kayıt olunuz. Bu işlemden sonra kayıt olduğunuz bilgiler ile giriş yapıcağınız " +
                                "için bu husus önemlidir!", "Bilgilendirme Mesajı", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                            Form10 x = new Form10();
                            x.Show(); this.Hide();
                        }
                    }
                    else
                    {
                        if (reader.HasRows == true && reader2.HasRows == false)
                        {
                            MessageBox.Show("Kullanıcı adı veya şifre yanlış!", "Bilgilendirme Mesajı",
                                MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                            textBox1.Clear();
                            textBox2.Clear();
                            textBox1.Focus();
                        }
                        else if (reader.HasRows == false && reader2.HasRows == true)
                        {
                            MessageBox.Show("Kullanıcı adı veya şifre yanlış!", "Bilgilendirme Mesajı",
                                MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                            textBox1.Clear();
                            textBox2.Clear();
                            textBox1.Focus();
                        }
                        else
                        {
                            MessageBox.Show("Kullanıcı Kayıtlı Değil!", "Bilgilendirme Mesajı",
                                MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                            textBox1.Clear();
                            textBox2.Clear();
                            textBox1.Focus();
                        }
                    }
                }
                catch (Exception hata)
                {
                    MessageBox.Show(hata.Message);
                }
            }
            else if (textBox1.Text == "" && textBox2.Text != "")
            {
                MessageBox.Show("Kullanıcı Adı Alanı Boş Bırakılamaz!", "Bilgilendirme Mesajı", 
                    MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                textBox1.Focus();
            }
            else if (textBox2.Text == "" && textBox1.Text != "")
            {
                MessageBox.Show("Şifre Alanı Boş Bırakılamaz!", "Bilgilendirme Mesajı", 
                    MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                textBox2.Focus();
            }
            else
            {
                MessageBox.Show("Alanları Doldurunuz Lütfen!", "Bilgilendirme Mesajı", 
                    MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                textBox1.Focus();
            }
            komut.Dispose();
            komut = new OleDbCommand();
            komut.Connection = baglan;

            komut.CommandText = "UPDATE kullanici SET s_giris=@ps_giris WHERE id='" + Form1.id + "'";
            komut.Parameters.AddWithValue("@ps_giris", DateTime.Now.ToShortDateString() + " " + DateTime.Now.ToShortTimeString());
            komut.ExecuteNonQuery();
            baglan.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
                Application.Exit();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Form3 x = new Form3();
            x.Show(); this.Hide();
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

        }

        private void checkBox1_Click(object sender, EventArgs e)
        {
            try
            {
                if (checkBox1.Checked == true)
                {
                    komut = new OleDbCommand();
                    baglan.Open();
                    komut.Connection = baglan;
                    komut.CommandText = "UPDATE hatirla SET id=@pid, sifre=@psifre, checkbox=@pcheckbox";
                    komut.Parameters.AddWithValue("@pid", textBox1.Text);
                    komut.Parameters.AddWithValue("@psifre", textBox2.Text);
                    komut.Parameters.AddWithValue("@pcheckbox", "evet");
                    komut.ExecuteNonQuery();
                    baglan.Close();
                }
                else
                {
                    baglan.Open();
                    komut = new OleDbCommand();
                    komut.Connection = baglan;
                    komut.CommandText = "UPDATE hatirla SET id=@pid, sifre=@psifre, checkbox=@pcheckbox";
                    komut.Parameters.AddWithValue("@pid", "");
                    komut.Parameters.AddWithValue("@psifre", "");
                    komut.Parameters.AddWithValue("@pcheckbox", "hayır");
                    komut.ExecuteNonQuery();
                    baglan.Close();
                }

            }
            catch (Exception hata)
            {
                MessageBox.Show(hata.Message);
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Programa ilk girişiniz ise verilen kullanıcı bilgileri ile programa bir defaya mashsus giriş yapabilirsiniz." + 
                "\nKullanıcı Adı: kibox\nŞifre: kibox\nDikkat: Giriş yaptıktan sonra admin paneline yönlendirileceksiniz." + 
                " Yönlendirildiğiniz menüden kayıt olunuz!", "Bilgilendirme Mesajı", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
        }
    }
}
