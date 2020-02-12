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
    public partial class Form10 : Form
    {
        public Form10()
        {
            InitializeComponent();
        }

        OleDbConnection baglan = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=KiBox.mdb");
        OleDbCommand komut;
        OleDbDataReader reader;

        private void Form10_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void Form10_Load(object sender, EventArgs e)
        {
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            ToolTip toolTip = new ToolTip();
            toolTip.ShowAlways = true;
            toolTip.SetToolTip(button11, "Ana Menüye Git");
            toolTip.SetToolTip(button12, "ÇIKIŞ");
            try
            {
                komut = new OleDbCommand();
                baglan.Open();
                komut.Connection = baglan;
                komut.CommandText = "SELECT id FROM kullanici";
                reader = komut.ExecuteReader();
                while (reader.Read())
                {
                    listBox1.Items.Add(reader["id"]);
                    listBox2.Items.Add(reader["id"]);
                }
                baglan.Close();
                listBox1.Items.Remove(Form1.id);
                listBox2.Items.Remove(Form1.id);
            }
            catch (Exception hata)
            {
                MessageBox.Show(hata.Message);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedIndex = 0;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedIndex = 1;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedIndex = 2;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedIndex = 3;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "" && textBox2.Text != "" && textBox3.Text != "" && textBox4.Text != ""
                && textBox5.Text != "" && textBox6.Text != "" && maskedTextBox1.Text != "(   )    -" && maskedTextBox2.Text != "  .  .")
            {
                try
                {
                    komut = new OleDbCommand();
                    baglan.Open();

                    komut.Connection = baglan;
                    komut.CommandText = "SELECT * FROM kullanici WHERE id='" + textBox1.Text + "'";
                    reader = komut.ExecuteReader();
                    if (reader.Read())
                    {
                        MessageBox.Show("Kullanıcı Adı Kullanılmaktadır.", "Bilgilendirme Mesajı",
                            MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        textBox1.Focus();
                    }
                    else
                    {

                        if (textBox5.Text == textBox6.Text)
                        {
                            komut = new OleDbCommand();
                            komut.Connection = baglan;
                            komut.CommandText = "INSERT INTO kullanici (id, sifre, ad, soyad, eposta, tel, dogum) VALUES ('"
                                + textBox1.Text + "','" + textBox5.Text + "','" + textBox2.Text + "','"
                                + textBox3.Text + "','" + textBox4.Text + "','" + maskedTextBox1.Text + "','"
                                + maskedTextBox2.Text + "')";
                            komut.ExecuteNonQuery();
                            if (Form1.id == "kibox")
                            {
                                komut.CommandText = "DELETE FROM kullanici WHERE id='" + Form1.id + "'";
                                komut.ExecuteNonQuery();

                                Random rastgele = new Random();
                                StringBuilder sb = new StringBuilder();
                                for (int i = 0; i < 8; i++)
                                {
                                    int ascii = rastgele.Next(32, 127);
                                    char karakter = Convert.ToChar(ascii);
                                    sb.Append(karakter);

                                }

                                komut.CommandText = "UPDATE kullanici SET admin='" + "admin" + "', admin_sifre='" +
                                    sb.ToString() + "' WHERE id='" + textBox1.Text + "'";
                                komut.ExecuteNonQuery();
                                DialogResult cevap = MessageBox.Show("Kullanıcı Eklendi. Geçici Admin Şifreniz: " + sb.ToString() +
                                    "\nNOT: Geçici Admin Şifrenizi 'Admin Şifresini Değiştir' Sekmesinden Yapabilirsiniz." +
                                    "\nŞifrenizi Not Etmeyi Unutmayın. Program Yeniden Başlatılıyor!", "Bilgilendirme Mesajı",
                                    MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                                if (cevap == DialogResult.OK)
                                {
                                    Form1 yeni = new Form1();
                                    yeni.Show(); this.Hide();
                                }
                                else
                                    Application.Exit();
                            }
                            else
                            {
                                MessageBox.Show("Kullanıcı Eklendi.", "Bilgilendirme Mesajı",
                                    MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                                komut.Dispose();
                                komut = new OleDbCommand();
                                komut.Connection = baglan;
                                komut.CommandText = "SELECT id FROM kullanici";
                                reader = komut.ExecuteReader();
                                listBox1.Items.Clear();
                                listBox2.Items.Clear();
                                while (reader.Read())
                                {
                                    listBox1.Items.Add(reader["id"]);
                                    listBox2.Items.Add(reader["id"]);
                                }
                                listBox1.Items.Remove(Form1.id);
                                listBox2.Items.Remove(Form1.id);
                            }
                            textBox1.Clear();
                            textBox2.Clear();
                            textBox3.Clear();
                            textBox4.Clear();
                            textBox5.Clear();
                            textBox6.Clear();
                            maskedTextBox1.Clear();
                            maskedTextBox2.Clear();
                        }
                        else
                        {
                            MessageBox.Show("Boş Alan Bırakmayınız!", "Bilgilendirme Mesajı",
                                MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        }
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

        private void button6_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
            textBox6.Clear();
            maskedTextBox1.Clear();
            maskedTextBox2.Clear();
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            textBox7.Text = listBox1.SelectedItem.ToString();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (textBox7.Text != "")
            {
                if (textBox7.Text == Form1.id)
                {
                    MessageBox.Show("Admini Silemezsiniz. Öncelikle Admin Yetkisini Devrediniz.", "Bilgilendirme Mesajı",
                                MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                }
                else
                {
                    try
                    {

                        baglan.Open();
                        komut = new OleDbCommand();
                        komut.Connection = baglan;
                        komut.CommandText = "SELECT * FROM kullanici WHERE id='" + textBox7.Text + "'";
                        reader = komut.ExecuteReader();
                        if (reader.Read())
                        {
                            DialogResult cevap;
                            cevap = MessageBox.Show("Kaydı Silmek İstediğinizden Emin misiniz?", "Bilgilendirme Mesajı",
                                MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk);
                            if (cevap == DialogResult.Yes)
                            {
                                komut.Dispose();
                                komut = new OleDbCommand();
                                komut.Connection = baglan;
                                komut.CommandText = "DELETE FROM kullanici WHERE id='" + textBox7.Text + "'";
                                komut.ExecuteNonQuery();
                                textBox3.Clear();
                                textBox4.Clear();
                                MessageBox.Show("Kişi Silindi.", "Bilgilendirme Mesajı",
                                    MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                                komut.Dispose();
                                komut = new OleDbCommand();
                                komut.Connection = baglan;
                                komut.CommandText = "SELECT id FROM kullanici";
                                reader = komut.ExecuteReader();
                                listBox1.Items.Clear();
                                listBox2.Items.Clear();
                                while (reader.Read())
                                {
                                    listBox1.Items.Add(reader["id"]);
                                    listBox2.Items.Add(reader["id"]);
                                }
                                listBox1.Items.Remove(Form1.id);
                                listBox2.Items.Remove(Form1.id);
                            }
                        }
                        else
                        {
                            MessageBox.Show("Kullanıcı Adı Bulunamadı. Kontrol Ediniz.", "Bilgilendirme Mesajı",
                                MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        }

                    }
                    catch (Exception hata)
                    {
                        MessageBox.Show(hata.Message);
                    }
                }
            }
            else
            {
                MessageBox.Show("Kullanıcı Adı Girmediniz.", "Bilgilendirme Mesajı",
                    MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                textBox7.Focus();
            }
            baglan.Close();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            if (textBox8.Text != "")
            {
                try
                {
                    komut = new OleDbCommand();
                    baglan.Open();
                    komut.Connection = baglan;
                    komut.CommandText = "SELECT admin_sifre FROM kullanici WHERE id='" + Form1.id + 
                        "' AND admin_sifre='" + textBox8.Text + "'";
                    reader = komut.ExecuteReader();
                    if (reader.Read())
                    {
                        if (textBox9.Text != "" && textBox10.Text != "")
                        {
                            if (textBox9.Text == textBox10.Text)
                            {
                                komut.Dispose();
                                komut = new OleDbCommand();
                                komut.Connection = baglan;
                                komut.CommandText = "UPDATE kullanici SET admin_sifre='" + textBox9.Text + 
                                    "' WHERE id='" + Form1.id + "'";
                                komut.ExecuteNonQuery();
                                MessageBox.Show("Admin Şifreniz Güncellendi.", "Bilgilendirme Mesajı",
                                    MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                                textBox8.Clear();
                                textBox9.Clear();
                                textBox10.Clear();
                            }
                            else
                            {
                                MessageBox.Show("Şifreler Eşleşmedi. Kontrol Ediniz!", "Bilgilendirme Mesajı",
                                    MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                                textBox9.Clear();
                                textBox10.Clear();
                                textBox9.Focus();
                            }
                        }

                        else
                        {
                            MessageBox.Show("Boş Alan Bırakmayınız.", "Bilgilendirme Mesajı",
                                MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Güncel Admin Şifreniz Hatalı. Tekrar Deneyiniz!", "Bilgilendirme Mesajı", 
                            MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        textBox8.Clear();
                        textBox8.Focus();
                    }
                    baglan.Close();
                }
                catch (Exception hata)
                {
                    MessageBox.Show(hata.Message);
                }
            }
        }

        private void listBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            textBox11.Text = listBox2.SelectedItem.ToString();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBox11.Text != "" && textBox12.Text != "" && textBox13.Text != "" && textBox14.Text != "")
                {
                    baglan.Open();
                    string kontrol = "SELECT id FROM kullanici WHERE id='" + textBox11.Text + "'";
                    komut = new OleDbCommand(kontrol, baglan);
                    reader = komut.ExecuteReader();
                    reader.Read();
                    if (reader.HasRows == true)
                    {

                        if (textBox12.Text == textBox13.Text)
                        {
                            string kontrol2 = "SELECT admin_sifre FROM kullanici WHERE id='" + Form1.id + 
                                "' AND admin_sifre='" + textBox14.Text + "'";
                            komut.Dispose();
                            reader.Dispose();
                            komut = new OleDbCommand(kontrol2, baglan);
                            reader = komut.ExecuteReader();
                            reader.Read();
                            if (reader.HasRows == true)
                            {
                                komut.Dispose();
                                komut = new OleDbCommand();
                                komut.Connection = baglan;
                                komut.CommandText = "UPDATE kullanici SET admin='" + "" + "', admin_sifre='" + "" +
                                    "' WHERE id='" + Form1.id + "'";
                                komut.ExecuteNonQuery();
                                komut.CommandText = "UPDATE kullanici SET admin='" + "admin" + "', admin_sifre='" +
                                    textBox12.Text + "' WHERE id='" + textBox11.Text + "'";
                                komut.ExecuteNonQuery();
                                komut.Dispose();
                                komut = new OleDbCommand();
                                komut.Connection = baglan;
                                komut.CommandText = "SELECT id FROM kullanici";
                                reader = komut.ExecuteReader();
                                listBox1.Items.Clear();
                                listBox2.Items.Clear();
                                while (reader.Read())
                                {
                                    listBox1.Items.Add(reader["id"]);
                                    listBox2.Items.Add(reader["id"]);
                                }
                                listBox1.Items.Remove(textBox12.Text);
                                listBox2.Items.Remove(textBox12.Text);
                                DialogResult cevap = MessageBox.Show("Admin Devretme İşlemi Tamamlandı.\nYeni Admin: "
                                    + textBox11.Text + "\nProgram Yeniden Başlatılacak, Yeniden Giriş Yapınız.", "Bilgilendirme Mesajı",
                                    MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                                if (cevap == DialogResult.OK)
                                {
                                    Form1 x = new Form1();
                                    x.Show(); this.Close();
                                }
                                else
                                {
                                    Form1 x = new Form1();
                                    x.Show(); this.Close();
                                }
                            }
                            else
                                MessageBox.Show("Güncel Admin Şifreniz Hatalı.", "Bilgilendirme Mesajı",
                                    MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        }
                        else
                        {
                            MessageBox.Show("Şifreler Birbiriyle Uyuşmuyor.", "Bilgilendirme Mesajı",
                                MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                            textBox12.Clear();
                            textBox13.Clear();
                            textBox12.Focus();
                        }

                    }
                    else
                        MessageBox.Show("Kullanıcı Adı Bulunamadı.", "Bilgilendirme Mesajı",
                            MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                }
                else
                    MessageBox.Show("Boş Alan Bırakmayınız.", "Bilgilendirme Mesajı",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception hata)
            {
                MessageBox.Show(hata.Message);
            }
            baglan.Close();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            if (textBox12.PasswordChar == '*')
            {
                textBox12.PasswordChar = '\0';
                textBox13.PasswordChar = '\0';
                textBox14.PasswordChar = '\0';
            }
            else
            {
                textBox12.PasswordChar = '*';
                textBox13.PasswordChar = '*';
                textBox14.PasswordChar = '*';
            }
        }

        private void button11_Click(object sender, EventArgs e)
        {
                Form2 x = new KiBox.Form2();
                x.Show(); this.Hide();
        }

        private void button12_Click(object sender, EventArgs e)
        {
            DialogResult secenek = MessageBox.Show("Çıkış Yapılsın mı?", "Bilgilendirme Mesajı",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
            if (secenek == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void button13_Click(object sender, EventArgs e)
        {
            if (textBox8.PasswordChar == '*')
            {
                textBox8.PasswordChar = '\0';
                textBox9.PasswordChar = '\0';
                textBox10.PasswordChar = '\0';
            }
            else
            {
                textBox8.PasswordChar = '*';
                textBox9.PasswordChar = '*';
                textBox10.PasswordChar = '*';
            }
        }
    }
}
