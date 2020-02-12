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
using System.IO;

namespace KiBox
{
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
        }

        OleDbConnection baglan = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=KiBox.mdb");
        OleDbCommand komut;
        OleDbDataReader reader;
        private void Form4_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void textenabledfalse(Control ctl)
        {
            foreach (Control item in ctl.Controls)
            {
                if (item is TextBox)
                {
                    ((TextBox)item).Enabled = false;
                }
                if (item.Controls.Count > 0)
                {
                    textenabledfalse(item);
                }
            }
        }

        private void textenabledtrue(Control ctl)
        {
            foreach (Control item in ctl.Controls)
            {
                if (item is TextBox)
                {
                    ((TextBox)item).Enabled = true;
                }
                if (item.Controls.Count > 0)
                {
                    textenabledtrue(item);
                }
            }
        }

        private void textclear(Control ctl)
        {
            foreach (Control item in ctl.Controls)
            {
                if (item is TextBox)
                {
                    ((TextBox)item).Clear();
                }
                if (item.Controls.Count > 0)
                {
                    textclear(item);
                }
            }
        }

        private void Form4_Load(object sender, EventArgs e)
        {
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            kaydetToolStripMenuItem.Enabled = false;
            geriToolStripMenuItem.Enabled = false;
            temizleToolStripMenuItem.Enabled = false;
            button4.Enabled = false;
            textenabledfalse(this);
            textBox11.Enabled = true;
            pictureBox1.Enabled = false;
            groupBox1.Enabled = false;
            comboBox1.Enabled = false;
            comboBox2.Enabled = false;
            comboBox3.Enabled = false;
            comboBox4.Enabled = false;
            comboBox5.Enabled = false;
            richTextBox1.Enabled = false;
            try
            {
                komut = new OleDbCommand();
                baglan.Open();
                komut.Connection = baglan;
                komut.CommandText = "SELECT * FROM kisiler";
                reader = komut.ExecuteReader();
                while (reader.Read())
                {
                    listBox1.Items.Add(reader["ad_soyad"]);
                }
                baglan.Close();
            }
            catch (Exception hata)
            {
                MessageBox.Show(hata.Message);
            }

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                baglan.Open();
                string aktar = Convert.ToString(listBox1.SelectedItem);
                komut = new OleDbCommand("SELECT * FROM kisiler WHERE ad_soyad='" + aktar + "'", baglan);
                komut.Connection = baglan;
                reader = komut.ExecuteReader();
                if (reader.Read())
                {
                    pictureBox1.ImageLocation = reader["resim"].ToString();
                    textBox1.Text = reader["ad_soyad"].ToString();
                    textBox2.Text = reader["ev_adresi"].ToString();
                    comboBox1.Text = reader["sehir"].ToString();
                    textBox3.Text = reader["ilce"].ToString();
                    textBox4.Text = reader["meslek"].ToString();
                    comboBox2.Text = reader["cinsiyet"].ToString();
                    textBox5.Text = reader["ev_telefona"].ToString();
                    textBox6.Text = reader["ev_telefonb"].ToString();
                    textBox7.Text = reader["cep_telefona"].ToString();
                    textBox8.Text = reader["cep_telefonb"].ToString();
                    textBox9.Text = reader["email"].ToString();
                    textBox10.Text = reader["web"].ToString();
                    textBox12.Text = reader["f_ad"].ToString();
                    textBox13.Text = reader["f_adres"].ToString();
                    comboBox3.Text = reader["f_sehir"].ToString();
                    textBox14.Text = reader["f_ilce"].ToString();
                    textBox15.Text = reader["f_aracplaka"].ToString();
                    textBox16.Text = reader["f_vergino"].ToString();
                    textBox17.Text = reader["f_telefona"].ToString();
                    textBox18.Text = reader["f_telefonb"].ToString();
                    textBox19.Text = reader["f_cep"].ToString();
                    textBox20.Text = reader["f_vergidaire"].ToString();
                    textBox21.Text = reader["f_faks"].ToString();
                    textBox22.Text = reader["f_email"].ToString();
                    textBox23.Text = reader["f_web"].ToString();
                    comboBox4.Text = reader["kimlik"].ToString();
                    textBox24.Text = reader["baba_adi"].ToString();
                    textBox25.Text = reader["anne_adi"].ToString();
                    textBox26.Text = reader["dogum_yeri"].ToString();
                    textBox27.Text = reader["dogum_tarihi"].ToString();
                    textBox28.Text = reader["kimlik_serino"].ToString();
                    comboBox5.Text = reader["kimlik_il"].ToString();
                    textBox29.Text = reader["mah_koy"].ToString();
                    textBox30.Text = reader["ver_yer"].ToString();
                    textBox31.Text = reader["ver_tarih"].ToString();
                    textBox32.Text = reader["tc_no"].ToString();
                    textBox33.Text = reader["kimlik_ilce"].ToString();
                    textBox34.Text = reader["ciltno"].ToString();
                    textBox35.Text = reader["ailesirano"].ToString();
                    textBox36.Text = reader["sirano"].ToString();
                    richTextBox1.Text = reader["dusunce"].ToString();
                }
                baglan.Close();
            }
            catch (Exception hata)
            {
                MessageBox.Show(hata.Message);
            }
        }
        public static int kaydet_b = 0;
        private void button1_Click(object sender, EventArgs e)
        {
            kaydet_b = 1;
            textclear(this);
            textenabledtrue(this);
            pictureBox1.Enabled = true;
            groupBox1.Enabled = true;
            groupBox2.Enabled = false;
            comboBox1.Enabled = true;
            comboBox2.Enabled = true;
            comboBox3.Enabled = true;
            comboBox4.Enabled = true;
            comboBox5.Enabled = true;
            richTextBox1.Enabled = true;
            comboBox1.Text = comboBox1.Items[0].ToString();
            comboBox2.Text = comboBox2.Items[0].ToString();
            comboBox3.Text = comboBox3.Items[0].ToString();
            comboBox4.Text = comboBox4.Items[0].ToString();
            comboBox5.Text = comboBox5.Items[0].ToString();
            richTextBox1.Clear();
            pictureBox1.Image = null;
            button1.Enabled = false;
            button2.Enabled = false;
            button3.Enabled = false;
            button4.Enabled = true;
            listBox1.Items.Add("");
            listBox1.SelectedItem = "";
            button6.Visible = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            button11.Visible = true;
            button6.Visible = true;
            kaydet_b = 0;
            pictureBox1.Enabled = true;
            groupBox1.Enabled = true;
            groupBox2.Enabled = false;
            button1.Enabled = false;
            button2.Enabled = false;
            button3.Enabled = false;
            button4.Enabled = true;
            textenabledtrue(this);
            comboBox1.Enabled = true;
            comboBox2.Enabled = true;
            comboBox3.Enabled = true;
            comboBox4.Enabled = true;
            comboBox5.Enabled = true;
            richTextBox1.Enabled = true;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult cevap = MessageBox.Show("Kişi Silinsin mi?", "Bilgilendirme Mesajı", 
                    MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                if (cevap == DialogResult.Yes)
                {
                    textclear(this);
                    baglan.Open();
                    komut = new OleDbCommand();
                    komut.Connection = baglan;
                    komut.CommandText = "SELECT * FROM kisiler WHERE ad_soyad='" + listBox1.SelectedItem + "'";
                    reader = komut.ExecuteReader();
                    if (reader.Read())
                    {
                        komut.Dispose();
                        komut = new OleDbCommand();
                        komut.Connection = baglan;
                        komut.CommandText = "DELETE FROM kisiler WHERE ad_soyad='" + listBox1.SelectedItem + "'";
                        komut.ExecuteNonQuery();

                        komut.CommandText = "SELECT ad_soyad FROM kisiler";
                        reader = komut.ExecuteReader();
                        listBox1.Items.Clear();
                        while (reader.Read())
                        {
                            listBox1.Items.Add(reader["ad_soyad"]);
                        }
                    }
                }
                baglan.Close();
                listBox1.SelectedIndex = 0;
            }
            catch (Exception hata)
            {
                MessageBox.Show(hata.Message);
            }
        }
        public static string ad2;
        private void button4_Click(object sender, EventArgs e)
        {
            ad2 = listBox1.SelectedItem.ToString();
            if (kaydet_b == 1)
            {
                DialogResult cevap = MessageBox.Show("Kişi Kaydedilsin mi?", "Bilgilendirme Mesajı",
                    MessageBoxButtons.YesNoCancel, MessageBoxIcon.Information);
                if (cevap == DialogResult.Yes)
                {
                    if (textBox1.Text != "")
                    {
                        string ad = textBox1.Text.ToString();
                        try
                        {

                            textenabledfalse(this);
                            pictureBox1.Enabled = false;
                            groupBox1.Enabled = false;
                            textBox11.Enabled = true;
                            groupBox2.Enabled = true;
                            comboBox1.Enabled = false;
                            comboBox2.Enabled = false;
                            comboBox3.Enabled = false;
                            comboBox4.Enabled = false;
                            comboBox5.Enabled = false;
                            richTextBox1.Enabled = false;
                            button1.Enabled = true;
                            button2.Enabled = true;
                            button3.Enabled = true;
                            button4.Enabled = false;
                            button6.Visible = false;
                            button11.Visible = false;
                            baglan.Open();

                            string ekle = "INSERT INTO kisiler(ad_soyad,ev_adresi,sehir,ilce,meslek,cinsiyet,ev_telefona,ev_telefonb,cep_telefona,cep_telefonb,email,web,f_ad,f_adres,f_sehir,f_ilce,f_aracplaka,f_vergino,f_telefona,f_telefonb,f_cep,f_vergidaire,f_faks,f_email,f_web,kimlik,baba_adi,anne_adi,dogum_yeri,dogum_tarihi,kimlik_serino,kimlik_il,mah_koy,ver_yer,ver_tarih,tc_no,kimlik_ilce,ciltno,ailesirano,sirano,dusunce) VALUES (@ad_soyad,@ev_adresi,@sehir,@ilce,@meslek,@cinsiyet,@ev_telefona,@ev_telefonb,@cep_telefona,@cep_telefonb,@email,@web,@f_ad,@f_adres,@f_sehir,@f_ilce,@f_aracplaka,@f_vergino,@f_telefona,@f_telefonb,@f_cep,@f_vergidaire,@f_faks,@f_email,@f_web,@kimlik,@baba_adi,@anne_adi,@dogum_yeri,@dogum_tarihi,@kimlik_serino,@kimlik_il,@mah_koy,@ver_yer,@ver_tarih,@tc_no,@kimlik_ilce,@ciltno,@ailesirano,@sirano,@dusunce)";
                            OleDbCommand komut = new OleDbCommand(ekle, baglan);
                            komut.Parameters.AddWithValue("@ad_soyad", textBox1.Text);
                            komut.Parameters.AddWithValue("@ev_adresi", textBox2.Text);
                            komut.Parameters.AddWithValue("@sehir", comboBox1.Text);
                            komut.Parameters.AddWithValue("@ilce", textBox3.Text);
                            komut.Parameters.AddWithValue("@meslek", textBox4.Text);
                            komut.Parameters.AddWithValue("@cinsiyet", comboBox2.Text);
                            komut.Parameters.AddWithValue("@ev_telefona", textBox5.Text);
                            komut.Parameters.AddWithValue("@ev_telefonb", textBox6.Text);
                            komut.Parameters.AddWithValue("@cep_telefona", textBox7.Text);
                            komut.Parameters.AddWithValue("@cep_telefonb", textBox8.Text);
                            komut.Parameters.AddWithValue("@email", textBox9.Text);
                            komut.Parameters.AddWithValue("@web", textBox10.Text);
                            komut.Parameters.AddWithValue("@f_ad", textBox12.Text);
                            komut.Parameters.AddWithValue("@f_adres", textBox13.Text);
                            komut.Parameters.AddWithValue("@f_sehir", comboBox3.Text);
                            komut.Parameters.AddWithValue("@f_ilce", textBox14.Text);
                            komut.Parameters.AddWithValue("@f_aracplaka", textBox15.Text);
                            komut.Parameters.AddWithValue("@f_vergino", textBox16.Text);
                            komut.Parameters.AddWithValue("@f_telefona", textBox17.Text);
                            komut.Parameters.AddWithValue("@f_telefonb", textBox18.Text);
                            komut.Parameters.AddWithValue("@f_cep", textBox19.Text);
                            komut.Parameters.AddWithValue("@f_vergidaire", textBox20.Text);
                            komut.Parameters.AddWithValue("@f_faks", textBox21.Text);
                            komut.Parameters.AddWithValue("@f_email", textBox22.Text);
                            komut.Parameters.AddWithValue("@f_web", textBox23.Text);
                            komut.Parameters.AddWithValue("@f_kimlik", comboBox4.Text);
                            komut.Parameters.AddWithValue("@baba_adi", textBox24.Text);
                            komut.Parameters.AddWithValue("@anne_adi", textBox25.Text);
                            komut.Parameters.AddWithValue("@dogum_yeri", textBox26.Text);
                            komut.Parameters.AddWithValue("@dogum_tarihi", textBox27.Text);
                            komut.Parameters.AddWithValue("@kimlik_serino", textBox28.Text);
                            komut.Parameters.AddWithValue("@kimlik_il", comboBox5.Text);
                            komut.Parameters.AddWithValue("@mah_koy", textBox29.Text);
                            komut.Parameters.AddWithValue("@ver_yer", textBox30.Text);
                            komut.Parameters.AddWithValue("@ver_tarih", textBox31.Text);
                            komut.Parameters.AddWithValue("@tc_no", textBox32.Text);
                            komut.Parameters.AddWithValue("@kimlik_ilce", textBox33.Text);
                            komut.Parameters.AddWithValue("@ciltno", textBox34.Text);
                            komut.Parameters.AddWithValue("@ailesirano", textBox35.Text);
                            komut.Parameters.AddWithValue("@sirano", textBox36.Text);
                            komut.Parameters.AddWithValue("@dusunce", richTextBox1.Text);
                            komut.ExecuteNonQuery();
                            komut.Connection = baglan;
                            komut.CommandText = "SELECT ad_soyad FROM kisiler";
                            reader = komut.ExecuteReader();
                            listBox1.Items.Clear();
                            while (reader.Read())
                            {
                                listBox1.Items.Add(reader["ad_soyad"]);
                            }
                            komut.Dispose();
                            baglan.Close();
                        }
                        catch (Exception hata)
                        {
                            MessageBox.Show(hata.Message);
                        }
                        listBox1.SelectedItem = ad;
                    }
                    else
                    {
                        MessageBox.Show("Ad Soyad Kısmı Boş Bırakılamaz!", "Bilgilendirme Mesajı", 
                            MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        textBox1.Focus();
                    }
                }
                else if (cevap == DialogResult.No)
                {
                    textenabledfalse(this);
                    textBox11.Enabled = true;
                    groupBox2.Enabled = true;
                    comboBox1.Enabled = false;
                    comboBox2.Enabled = false;
                    comboBox3.Enabled = false;
                    comboBox4.Enabled = false;
                    comboBox5.Enabled = false;
                    richTextBox1.Enabled = false;
                    button1.Enabled = true;
                    button2.Enabled = true;
                    button3.Enabled = true;
                    button4.Enabled = false;
                    button6.Visible = false;
                    button11.Visible = false;
                    pictureBox1.Enabled = false;
                    groupBox1.Enabled = false;
                    listBox1.SelectedIndex = 0;
                }

            }
            else
            {

                DialogResult cevap = MessageBox.Show("Kişi Güncellesin mi?", "Bilgilendirme Mesajı",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                if (cevap == DialogResult.Yes)
                {
                    if (textBox1.Text != "")
                    {
                        try
                        {
                            textenabledfalse(this);
                            pictureBox1.Enabled = false;
                            groupBox1.Enabled = false;
                            textBox11.Enabled = true;
                            comboBox1.Enabled = false;
                            comboBox2.Enabled = false;
                            comboBox3.Enabled = false;
                            comboBox4.Enabled = false;
                            comboBox5.Enabled = false;
                            richTextBox1.Enabled = false;
                            groupBox2.Enabled = true;
                            button1.Enabled = true;
                            button2.Enabled = true;
                            button3.Enabled = true;
                            button4.Enabled = false;
                            button6.Visible = false;
                            button11.Visible = false;
                            button6.Visible = false;
                            komut = new OleDbCommand();
                            baglan.Open();
                            komut.Connection = baglan;
                            komut.CommandText = "UPDATE kisiler SET ad_soyad=@pad_soyad, ev_adresi=@pev_adresi,sehir=@psehir,ilce=@pilce,meslek=@pmeslek,cinsiyet=@pcinsiyet,ev_telefona=@pev_telefona,ev_telefonb=@pev_telefonb,cep_telefona=@pcep_telefona,cep_telefonb=@pcep_telefonb,email=@pemail,web=@pweb,f_ad=@pf_ad,f_adres=@pf_adres,f_sehir=@pf_sehir,f_ilce=@pf_ilce,f_aracplaka=@paracplaka,f_vergino=@pf_vergino,f_telefona=@pf_telefona,f_telefonb=@f_telefonb,f_cep=@pf_cep,f_vergidaire=@pf_vergidaire,f_faks=@pf_faks,f_email=@pf_email,f_web=@pf_web,kimlik=@pkimlik,baba_adi=@pbaba_adi,anne_adi=@panne_adi,dogum_yeri=@pdogum_yeri,dogum_tarihi=@pdogum_tarihi,kimlik_serino=@pkimlik_serino,kimlik_il=@pkimlik_il,mah_koy=@pmah_koy,ver_yer=@pver_yer,ver_tarih=@pver_tarih,tc_no=@ptc_no,kimlik_ilce=@pkimlik_ilce,ciltno=@pciltno,ailesirano=@pailesirano,sirano=@sirano,dusunce=@pdusunce WHERE ad_soyad='" + listBox1.SelectedItem.ToString() + "'";
                            komut.Parameters.AddWithValue("@pad_soyad", textBox1.Text);
                            komut.Parameters.AddWithValue("@pev_adresi", textBox2.Text);
                            komut.Parameters.AddWithValue("@psehir", comboBox1.Text);
                            komut.Parameters.AddWithValue("@pilce", textBox3.Text);
                            komut.Parameters.AddWithValue("@pmeslek", textBox4.Text);
                            komut.Parameters.AddWithValue("@pcinsiyet", comboBox2.Text);
                            komut.Parameters.AddWithValue("@pev_telefona", textBox5.Text);
                            komut.Parameters.AddWithValue("@pev_telefonb", textBox6.Text);
                            komut.Parameters.AddWithValue("@pcep_telefona", textBox7.Text);
                            komut.Parameters.AddWithValue("@pcep_telefona", textBox8.Text);
                            komut.Parameters.AddWithValue("@pemail", textBox9.Text);
                            komut.Parameters.AddWithValue("@pweb", textBox10.Text);
                            komut.Parameters.AddWithValue("@pf_ad", textBox12.Text);
                            komut.Parameters.AddWithValue("@pf_adres", textBox13.Text);
                            komut.Parameters.AddWithValue("@pf_sehir", comboBox3.Text);
                            komut.Parameters.AddWithValue("@f_ilce", textBox14.Text);
                            komut.Parameters.AddWithValue("@paracplaka", textBox15.Text);
                            komut.Parameters.AddWithValue("@pf_vergino", textBox16.Text);
                            komut.Parameters.AddWithValue("@pf_telefona", textBox17.Text);
                            komut.Parameters.AddWithValue("@pf_telefona", textBox18.Text);
                            komut.Parameters.AddWithValue("@pf_cep", textBox19.Text);
                            komut.Parameters.AddWithValue("@pf_vergidaire", textBox20.Text);
                            komut.Parameters.AddWithValue("@pf_faks", textBox21.Text);
                            komut.Parameters.AddWithValue("@pf_email", textBox22.Text);
                            komut.Parameters.AddWithValue("@pf_web", textBox23.Text);
                            komut.Parameters.AddWithValue("@pkimlik", comboBox4.Text);
                            komut.Parameters.AddWithValue("@pbaba_adi", textBox24.Text);
                            komut.Parameters.AddWithValue("@panne_adi", textBox25.Text);
                            komut.Parameters.AddWithValue("@pdogum_yeri", textBox26.Text);
                            komut.Parameters.AddWithValue("@pdogum_tarihi", textBox27.Text);
                            komut.Parameters.AddWithValue("@pkimlik_serino", textBox28.Text);
                            komut.Parameters.AddWithValue("@pkimlik_il", comboBox5.Text);
                            komut.Parameters.AddWithValue("@pmah_koy", textBox29.Text);
                            komut.Parameters.AddWithValue("@pver_yer", textBox30.Text);
                            komut.Parameters.AddWithValue("@pver_tarih", textBox31.Text);
                            komut.Parameters.AddWithValue("@ptc_no", textBox32.Text);
                            komut.Parameters.AddWithValue("@pkimlik_ilce", textBox33.Text);
                            komut.Parameters.AddWithValue("@pciltno", textBox34.Text);
                            komut.Parameters.AddWithValue("@pailesirano", textBox35.Text);
                            komut.Parameters.AddWithValue("@psirano", textBox36.Text);
                            komut.Parameters.AddWithValue("@pdusunce", richTextBox1.Text);
                            komut.ExecuteNonQuery();
                            baglan.Close();
                        }
                        catch (Exception hata)
                        {
                            MessageBox.Show(hata.Message);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Ad Soyad Kısmı Boş Bırakılamaz!", "Bilgilendirme Mesajı", 
                            MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        textBox1.Focus();
                    }
                }
                else
                {
                    textenabledfalse(this);
                    pictureBox1.Enabled = false;
                    groupBox1.Enabled = false;
                    textBox11.Enabled = true;
                    comboBox1.Enabled = false;
                    comboBox2.Enabled = false;
                    comboBox3.Enabled = false;
                    comboBox4.Enabled = false;
                    comboBox5.Enabled = false;
                    richTextBox1.Enabled = false;
                    groupBox2.Enabled = true;
                    button1.Enabled = true;
                    button2.Enabled = true;
                    button3.Enabled = true;
                    button4.Enabled = false;
                    button6.Visible = false;
                    button11.Visible = false;
                    button6.Visible = false;
                    komut.Connection = baglan;
                    baglan.Open();
                    komut.CommandText = "SELECT ad_soyad FROM kisiler";
                    reader = komut.ExecuteReader();
                    listBox1.Items.Clear();
                    while (reader.Read())
                    {
                        listBox1.Items.Add(reader["ad_soyad"]);
                    }
                    komut.Dispose();
                    baglan.Close();
                    listBox1.SelectedItem = ad2;
                }

            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            printPreviewDialog1.Document = printDocument1;
            printPreviewDialog1.ShowDialog();
        }

        private void button6_Click_1(object sender, EventArgs e)
        {
            DialogResult cevap = MessageBox.Show("İşlem İptal Edilsin mi?", "Bilgilendirme Mesajı",
                        MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (cevap == DialogResult.Yes)
            {
                button6.Visible = false;
                button11.Visible = false;
                textenabledfalse(this);
                textBox11.Enabled = true;
                groupBox2.Enabled = true;
                comboBox1.Enabled = false;
                comboBox2.Enabled = false;
                comboBox3.Enabled = false;
                comboBox4.Enabled = false;
                comboBox5.Enabled = false;
                richTextBox1.Enabled = false;
                button1.Enabled = true;
                button2.Enabled = true;
                button3.Enabled = true;
                button4.Enabled = false;
                pictureBox1.Enabled = false;
                groupBox1.Enabled = false;
                baglan.Open();
                komut.Connection = baglan;
                komut.CommandText = "SELECT ad_soyad FROM kisiler";
                reader = komut.ExecuteReader();
                listBox1.Items.Clear();
                while (reader.Read())
                {
                    listBox1.Items.Add(reader["ad_soyad"]);
                }

                baglan.Close();
                listBox1.SelectedIndex = 0;
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            DialogResult cevap = MessageBox.Show("Çıkış Yapılsın mı?", "Bilgilendirme Mesajı", MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2);
            if (cevap == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            baglan.Open();
            komut.Connection = baglan;
            komut.CommandText = "SELECT ad_soyad FROM kisiler";
            reader = komut.ExecuteReader();
            listBox1.Items.Clear();
            while (reader.Read())
            {
                listBox1.Items.Add(reader["ad_soyad"]);
            }

            baglan.Close();
        }

        public static string resimyolu;
        private void button9_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog dosya = new OpenFileDialog();
                dosya.Filter = "Resim dosyaları |*.jpg;*.jpeg;*.bmp;" +
                    "*.png;*ico|JPEG Files ( *.jpg;*.jpeg )|*.jpg;*.jpeg|BMP Files ( *.bmp )" +
                    "|*.bmp|PNG Files ( *.png )|*.png|Icon Files ( *.ico )|*.ico";
                dosya.Title = "Resim Seçiniz.";
                dosya.ShowDialog();
                resimyolu = dosya.FileName;
                string isim = Path.GetFileName(dosya.FileName);
                try
                {
                    File.Copy(resimyolu, Application.StartupPath + "\\Resimler\\" + isim);
                    pictureBox1.ImageLocation = resimyolu;
                    baglan.Open();
                    new OleDbCommand();
                    komut.Connection = baglan;
                    komut.CommandText = "UPDATE kisiler SET resim=@presim WHERE ad_soyad='" + textBox1.Text + "'";
                    komut.Parameters.AddWithValue("@presim", Application.StartupPath + "\\Resimler\\" + isim);
                    komut.ExecuteNonQuery();
                    komut.Dispose();
                    baglan.Close();
                }
                catch (Exception)
                {
                    MessageBox.Show("Bu Profil Resmi Kullanılmaktadır!", "Bilgilendirme Mesajı");
                }
            }
            catch (Exception hata)
            {
                MessageBox.Show(hata.Message);
            }
        }

        private void button10_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult cevap = MessageBox.Show("Kayıtlı Kişinin Resmi Silinsin mi ?", "Bilgilendirme Mesajı",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                if (cevap == DialogResult.Yes)
                {
                    baglan.Open();
                    komut = new OleDbCommand("SELECT * FROM kisiler WHERE ad_soyad='" + listBox1.SelectedItem + "'", baglan);
                    komut.Connection = baglan;
                    reader = komut.ExecuteReader();
                    if (reader.Read())
                    {
                        string yol = reader["resim"].ToString();
                        File.Delete(yol);
                    }
                    komut.Dispose();
                    komut = new OleDbCommand();
                    komut.Connection = baglan;
                    komut.CommandText = "UPDATE kisiler SET resim=@presim WHERE ad_soyad='" + listBox1.SelectedItem + "'";
                    komut.Parameters.AddWithValue("@presim", "");
                    komut.ExecuteNonQuery();
                    baglan.Close();
                    pictureBox1.ImageLocation = "";
                    komut.Dispose();
                }
            }
            catch (Exception hata)
            {
                MessageBox.Show(hata.Message);
            }     
        }

        private void button11_Click(object sender, EventArgs e)
        {
            DialogResult cevap = MessageBox.Show("Alanlar Temizlensin mi?", "Bilgilendirme Mesajı",
                MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2);
            if (cevap == DialogResult.OK)
            {
                textclear(this);
                comboBox1.Text = comboBox1.Items[0].ToString();
                comboBox2.Text = comboBox2.Items[0].ToString();
                comboBox3.Text = comboBox3.Items[0].ToString();
                comboBox4.Text = comboBox4.Items[0].ToString();
                comboBox5.Text = comboBox5.Items[0].ToString();
                richTextBox1.Clear();
                pictureBox1.Image = null;
            }
        }

        private void ekleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            kaydet_b = 1;
            geriToolStripMenuItem.Enabled = true;
            ekleToolStripMenuItem.Enabled = false;
            silToolStripMenuItem.Enabled = false;
            düzenleToolStripMenuItem.Enabled = false;
            kaydetToolStripMenuItem.Enabled = true;
            textclear(this);
            textenabledtrue(this);
            pictureBox1.Enabled = true;
            groupBox1.Enabled = true;
            groupBox2.Enabled = false;
            comboBox1.Enabled = true;
            comboBox2.Enabled = true;
            comboBox3.Enabled = true;
            comboBox4.Enabled = true;
            comboBox5.Enabled = true;
            richTextBox1.Enabled = true;
            comboBox1.Text = comboBox1.Items[0].ToString();
            comboBox2.Text = comboBox2.Items[0].ToString();
            comboBox3.Text = comboBox3.Items[0].ToString();
            comboBox4.Text = comboBox4.Items[0].ToString();
            comboBox5.Text = comboBox5.Items[0].ToString();
            richTextBox1.Clear();
            pictureBox1.Image = null;
            button1.Enabled = false;
            button2.Enabled = false;
            button3.Enabled = false;
            button4.Enabled = true;
            listBox1.Items.Add("");
            listBox1.SelectedItem = "";
        }

        private void silToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult cevap = MessageBox.Show("Kişi Silinsin mi?", "Bilgilendirme Mesajı", 
                    MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                if (cevap == DialogResult.Yes)
                {
                    textclear(this);
                    baglan.Open();
                    komut = new OleDbCommand();
                    komut.Connection = baglan;
                    komut.CommandText = "SELECT * FROM kisiler WHERE ad_soyad='" + listBox1.SelectedItem + "'";
                    reader = komut.ExecuteReader();
                    if (reader.Read())
                    {
                        komut.Dispose();
                        komut = new OleDbCommand();
                        komut.Connection = baglan;
                        komut.CommandText = "DELETE FROM kisiler WHERE ad_soyad='" + listBox1.SelectedItem + "'";
                        komut.ExecuteNonQuery();

                        komut.CommandText = "SELECT ad_soyad FROM kisiler";
                        reader = komut.ExecuteReader();
                        listBox1.Items.Clear();
                        while (reader.Read())
                        {
                            listBox1.Items.Add(reader["ad_soyad"]);
                        }
                    }
                }
                baglan.Close();
                listBox1.SelectedIndex = 0;
            }
            catch (Exception hata)
            {
                MessageBox.Show(hata.Message);
            }
        }

        private void kaydetToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (kaydet_b == 1)
            {
                if (textBox1.Text != "")
                {
                    DialogResult cevap = MessageBox.Show("Kişi Kaydedilsin mi?", "Bilgilendirme Mesajı",
                        MessageBoxButtons.YesNoCancel, MessageBoxIcon.Information);
                    if (cevap == DialogResult.Yes)
                    {
                        string ad = textBox1.Text.ToString();
                        try
                        {

                            textenabledfalse(this);
                            pictureBox1.Enabled = false;
                            groupBox1.Enabled = false;
                            textBox11.Enabled = true;
                            groupBox2.Enabled = true;
                            comboBox1.Enabled = false;
                            comboBox2.Enabled = false;
                            comboBox3.Enabled = false;
                            comboBox4.Enabled = false;
                            comboBox5.Enabled = false;
                            richTextBox1.Enabled = false;
                            button1.Enabled = true;
                            button2.Enabled = true;
                            button3.Enabled = true;
                            button4.Enabled = false;
                            button6.Visible = false;
                            button11.Visible = false;
                            ekleToolStripMenuItem.Enabled = true;
                            silToolStripMenuItem.Enabled = true;
                            düzenleToolStripMenuItem.Enabled = true;
                            kaydetToolStripMenuItem.Enabled = false;
                            geriToolStripMenuItem.Enabled = false;
                            temizleToolStripMenuItem.Enabled = false;
                            baglan.Open();

                            string ekle = "INSERT INTO kisiler(ad_soyad,ev_adresi,sehir,ilce,meslek,cinsiyet,ev_telefona,ev_telefonb,cep_telefona,cep_telefonb,email,web,f_ad,f_adres,f_sehir,f_ilce,f_aracplaka,f_vergino,f_telefona,f_telefonb,f_cep,f_vergidaire,f_faks,f_email,f_web,kimlik,baba_adi,anne_adi,dogum_yeri,dogum_tarihi,kimlik_serino,kimlik_il,mah_koy,ver_yer,ver_tarih,tc_no,kimlik_ilce,ciltno,ailesirano,sirano,dusunce) VALUES (@ad_soyad,@ev_adresi,@sehir,@ilce,@meslek,@cinsiyet,@ev_telefona,@ev_telefonb,@cep_telefona,@cep_telefonb,@email,@web,@f_ad,@f_adres,@f_sehir,@f_ilce,@f_aracplaka,@f_vergino,@f_telefona,@f_telefonb,@f_cep,@f_vergidaire,@f_faks,@f_email,@f_web,@kimlik,@baba_adi,@anne_adi,@dogum_yeri,@dogum_tarihi,@kimlik_serino,@kimlik_il,@mah_koy,@ver_yer,@ver_tarih,@tc_no,@kimlik_ilce,@ciltno,@ailesirano,@sirano,@dusunce)";
                            OleDbCommand komut = new OleDbCommand(ekle, baglan);
                            komut.Parameters.AddWithValue("@ad_soyad", textBox1.Text);
                            komut.Parameters.AddWithValue("@ev_adresi", textBox2.Text);
                            komut.Parameters.AddWithValue("@sehir", comboBox1.Text);
                            komut.Parameters.AddWithValue("@ilce", textBox3.Text);
                            komut.Parameters.AddWithValue("@meslek", textBox4.Text);
                            komut.Parameters.AddWithValue("@cinsiyet", comboBox2.Text);
                            komut.Parameters.AddWithValue("@ev_telefona", textBox5.Text);
                            komut.Parameters.AddWithValue("@ev_telefonb", textBox6.Text);
                            komut.Parameters.AddWithValue("@cep_telefona", textBox7.Text);
                            komut.Parameters.AddWithValue("@cep_telefonb", textBox8.Text);
                            komut.Parameters.AddWithValue("@email", textBox9.Text);
                            komut.Parameters.AddWithValue("@web", textBox10.Text);
                            komut.Parameters.AddWithValue("@f_ad", textBox12.Text);
                            komut.Parameters.AddWithValue("@f_adres", textBox13.Text);
                            komut.Parameters.AddWithValue("@f_sehir", comboBox3.Text);
                            komut.Parameters.AddWithValue("@f_ilce", textBox14.Text);
                            komut.Parameters.AddWithValue("@f_aracplaka", textBox15.Text);
                            komut.Parameters.AddWithValue("@f_vergino", textBox16.Text);
                            komut.Parameters.AddWithValue("@f_telefona", textBox17.Text);
                            komut.Parameters.AddWithValue("@f_telefonb", textBox18.Text);
                            komut.Parameters.AddWithValue("@f_cep", textBox19.Text);
                            komut.Parameters.AddWithValue("@f_vergidaire", textBox20.Text);
                            komut.Parameters.AddWithValue("@f_faks", textBox21.Text);
                            komut.Parameters.AddWithValue("@f_email", textBox22.Text);
                            komut.Parameters.AddWithValue("@f_web", textBox23.Text);
                            komut.Parameters.AddWithValue("@f_kimlik", comboBox4.Text);
                            komut.Parameters.AddWithValue("@baba_adi", textBox24.Text);
                            komut.Parameters.AddWithValue("@anne_adi", textBox25.Text);
                            komut.Parameters.AddWithValue("@dogum_yeri", textBox26.Text);
                            komut.Parameters.AddWithValue("@dogum_tarihi", textBox27.Text);
                            komut.Parameters.AddWithValue("@kimlik_serino", textBox28.Text);
                            komut.Parameters.AddWithValue("@kimlik_il", comboBox5.Text);
                            komut.Parameters.AddWithValue("@mah_koy", textBox29.Text);
                            komut.Parameters.AddWithValue("@ver_yer", textBox30.Text);
                            komut.Parameters.AddWithValue("@ver_tarih", textBox31.Text);
                            komut.Parameters.AddWithValue("@tc_no", textBox32.Text);
                            komut.Parameters.AddWithValue("@kimlik_ilce", textBox33.Text);
                            komut.Parameters.AddWithValue("@ciltno", textBox34.Text);
                            komut.Parameters.AddWithValue("@ailesirano", textBox35.Text);
                            komut.Parameters.AddWithValue("@sirano", textBox36.Text);
                            komut.Parameters.AddWithValue("@dusunce", richTextBox1.Text);
                            komut.ExecuteNonQuery();
                            komut.Connection = baglan;
                            komut.CommandText = "SELECT ad_soyad FROM kisiler";
                            reader = komut.ExecuteReader();
                            listBox1.Items.Clear();
                            while (reader.Read())
                            {
                                listBox1.Items.Add(reader["ad_soyad"]);
                            }
                            komut.Dispose();
                            baglan.Close();
                        }
                        catch (Exception hata)
                        {
                            MessageBox.Show(hata.Message);
                        }
                        listBox1.SelectedItem = ad;
                    }
                    else if (cevap == DialogResult.No)
                    {
                        textenabledfalse(this);
                        textBox11.Enabled = true;
                        groupBox2.Enabled = true;
                        comboBox1.Enabled = false;
                        comboBox2.Enabled = false;
                        comboBox3.Enabled = false;
                        comboBox4.Enabled = false;
                        comboBox5.Enabled = false;
                        richTextBox1.Enabled = false;
                        button1.Enabled = true;
                        button2.Enabled = true;
                        button3.Enabled = true;
                        button4.Enabled = false;
                        button6.Visible = false;
                        button11.Visible = false;
                        button6.Visible = false;
                        pictureBox1.Enabled = false;
                        groupBox1.Enabled = false;
                        ekleToolStripMenuItem.Enabled = true;
                        silToolStripMenuItem.Enabled = true;
                        düzenleToolStripMenuItem.Enabled = true;
                        kaydetToolStripMenuItem.Enabled = false;
                        geriToolStripMenuItem.Enabled = false;
                        temizleToolStripMenuItem.Enabled = false;
                        baglan.Open();
                        komut.Connection = baglan;
                        komut.CommandText = "SELECT ad_soyad FROM kisiler";
                        reader = komut.ExecuteReader();
                        listBox1.Items.Clear();
                        while (reader.Read())
                        {
                            listBox1.Items.Add(reader["ad_soyad"]);
                        }

                        baglan.Close();
                        listBox1.SelectedIndex = 0;
                    }
                }
                else
                {
                    MessageBox.Show("Ad Soyad Kısmı Boş Bırakılamaz!", "Bilgilendirme Mesajı", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    textBox1.Focus();
                }
            }
            else
            {
                if (textBox1.Text != "")
                {
                    DialogResult cevap = MessageBox.Show("Kişi Güncellesin mi?", "Bilgilendirme Mesajı",
                        MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                    if (cevap == DialogResult.Yes)
                    {
                        try
                        {
                            textenabledfalse(this);
                            pictureBox1.Enabled = false;
                            groupBox1.Enabled = false;
                            textBox11.Enabled = true;
                            comboBox1.Enabled = false;
                            comboBox2.Enabled = false;
                            comboBox3.Enabled = false;
                            comboBox4.Enabled = false;
                            comboBox5.Enabled = false;
                            richTextBox1.Enabled = false;
                            groupBox2.Enabled = true;
                            button1.Enabled = true;
                            button2.Enabled = true;
                            button3.Enabled = true;
                            button4.Enabled = false;
                            button6.Visible = false;
                            button11.Visible = false;
                            button6.Visible = false;
                            ekleToolStripMenuItem.Enabled = true;
                            silToolStripMenuItem.Enabled = true;
                            düzenleToolStripMenuItem.Enabled = true;
                            kaydetToolStripMenuItem.Enabled = false;
                            geriToolStripMenuItem.Enabled = false;
                            temizleToolStripMenuItem.Enabled = false;
                            komut = new OleDbCommand();
                            baglan.Open();
                            komut.Connection = baglan;
                            komut.CommandText = "UPDATE kisiler SET ad_soyad=@pad_soyad, ev_adresi=@pev_adresi,sehir=@psehir,ilce=@pilce,meslek=@pmeslek,cinsiyet=@pcinsiyet,ev_telefona=@pev_telefona,ev_telefonb=@pev_telefonb,cep_telefona=@pcep_telefona,cep_telefonb=@pcep_telefonb,email=@pemail,web=@pweb,f_ad=@pf_ad,f_adres=@pf_adres,f_sehir=@pf_sehir,f_ilce=@pf_ilce,f_aracplaka=@paracplaka,f_vergino=@pf_vergino,f_telefona=@pf_telefona,f_telefonb=@f_telefonb,f_cep=@pf_cep,f_vergidaire=@pf_vergidaire,f_faks=@pf_faks,f_email=@pf_email,f_web=@pf_web,kimlik=@pkimlik,baba_adi=@pbaba_adi,anne_adi=@panne_adi,dogum_yeri=@pdogum_yeri,dogum_tarihi=@pdogum_tarihi,kimlik_serino=@pkimlik_serino,kimlik_il=@pkimlik_il,mah_koy=@pmah_koy,ver_yer=@pver_yer,ver_tarih=@pver_tarih,tc_no=@ptc_no,kimlik_ilce=@pkimlik_ilce,ciltno=@pciltno,ailesirano=@pailesirano,sirano=@sirano,dusunce=@pdusunce WHERE ad_soyad='" + listBox1.SelectedItem.ToString() + "'";
                            komut.Parameters.AddWithValue("@pad_soyad", textBox1.Text);
                            komut.Parameters.AddWithValue("@pev_adresi", textBox2.Text);
                            komut.Parameters.AddWithValue("@psehir", comboBox1.Text);
                            komut.Parameters.AddWithValue("@pilce", textBox3.Text);
                            komut.Parameters.AddWithValue("@pmeslek", textBox4.Text);
                            komut.Parameters.AddWithValue("@pcinsiyet", comboBox2.Text);
                            komut.Parameters.AddWithValue("@pev_telefona", textBox5.Text);
                            komut.Parameters.AddWithValue("@pev_telefonb", textBox6.Text);
                            komut.Parameters.AddWithValue("@pcep_telefona", textBox7.Text);
                            komut.Parameters.AddWithValue("@pcep_telefona", textBox8.Text);
                            komut.Parameters.AddWithValue("@pemail", textBox9.Text);
                            komut.Parameters.AddWithValue("@pweb", textBox10.Text);
                            komut.Parameters.AddWithValue("@pf_ad", textBox12.Text);
                            komut.Parameters.AddWithValue("@pf_adres", textBox13.Text);
                            komut.Parameters.AddWithValue("@pf_sehir", comboBox3.Text);
                            komut.Parameters.AddWithValue("@f_ilce", textBox14.Text);
                            komut.Parameters.AddWithValue("@paracplaka", textBox15.Text);
                            komut.Parameters.AddWithValue("@pf_vergino", textBox16.Text);
                            komut.Parameters.AddWithValue("@pf_telefona", textBox17.Text);
                            komut.Parameters.AddWithValue("@pf_telefona", textBox18.Text);
                            komut.Parameters.AddWithValue("@pf_cep", textBox19.Text);
                            komut.Parameters.AddWithValue("@pf_vergidaire", textBox20.Text);
                            komut.Parameters.AddWithValue("@pf_faks", textBox21.Text);
                            komut.Parameters.AddWithValue("@pf_email", textBox22.Text);
                            komut.Parameters.AddWithValue("@pf_web", textBox23.Text);
                            komut.Parameters.AddWithValue("@pkimlik", comboBox4.Text);
                            komut.Parameters.AddWithValue("@pbaba_adi", textBox24.Text);
                            komut.Parameters.AddWithValue("@panne_adi", textBox25.Text);
                            komut.Parameters.AddWithValue("@pdogum_yeri", textBox26.Text);
                            komut.Parameters.AddWithValue("@pdogum_tarihi", textBox27.Text);
                            komut.Parameters.AddWithValue("@pkimlik_serino", textBox28.Text);
                            komut.Parameters.AddWithValue("@pkimlik_il", comboBox5.Text);
                            komut.Parameters.AddWithValue("@pmah_koy", textBox29.Text);
                            komut.Parameters.AddWithValue("@pver_yer", textBox30.Text);
                            komut.Parameters.AddWithValue("@pver_tarih", textBox31.Text);
                            komut.Parameters.AddWithValue("@ptc_no", textBox32.Text);
                            komut.Parameters.AddWithValue("@pkimlik_ilce", textBox33.Text);
                            komut.Parameters.AddWithValue("@pciltno", textBox34.Text);
                            komut.Parameters.AddWithValue("@pailesirano", textBox35.Text);
                            komut.Parameters.AddWithValue("@psirano", textBox36.Text);
                            komut.Parameters.AddWithValue("@pdusunce", richTextBox1.Text);
                            komut.ExecuteNonQuery();
                            baglan.Close();
                        }
                        catch (Exception hata)
                        {
                            MessageBox.Show(hata.Message);
                        }
                    }
                    else
                    {
                        textenabledfalse(this);
                        pictureBox1.Enabled = false;
                        groupBox1.Enabled = false;
                        textBox11.Enabled = true;
                        comboBox1.Enabled = false;
                        comboBox2.Enabled = false;
                        comboBox3.Enabled = false;
                        comboBox4.Enabled = false;
                        comboBox5.Enabled = false;
                        richTextBox1.Enabled = false;
                        groupBox2.Enabled = true;
                        button1.Enabled = true;
                        button2.Enabled = true;
                        button3.Enabled = true;
                        button4.Enabled = false;
                        button6.Visible = false;
                        button11.Visible = false;
                        ekleToolStripMenuItem.Enabled = true;
                        silToolStripMenuItem.Enabled = true;
                        düzenleToolStripMenuItem.Enabled = true;
                        kaydetToolStripMenuItem.Enabled = false;
                        geriToolStripMenuItem.Enabled = false;
                        temizleToolStripMenuItem.Enabled = false;
                    }
                }
                else
                {
                    MessageBox.Show("Ad Soyad Kısmı Boş Bırakılamaz!", "Bilgilendirme Mesajı", 
                        MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    textBox1.Focus();
                }
            }
        }

        private void anaMenüyeDönToolStripMenuItem_Click(object sender, EventArgs e)
        {
                Form2 x = new Form2();
                x.Show(); this.Hide();
        }

        private void çıkışToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult cevap = MessageBox.Show("Çıkış Yapılsın mı?", "Bilgilendirme Mesajı", 
                MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2);
            if (cevap == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void düzenleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            kaydet_b = 0;
            ekleToolStripMenuItem.Enabled = false;
            silToolStripMenuItem.Enabled = false;
            düzenleToolStripMenuItem.Enabled = false;
            kaydetToolStripMenuItem.Enabled = true;
            temizleToolStripMenuItem.Enabled = true;
            geriToolStripMenuItem.Enabled = true;
            pictureBox1.Enabled = true;
            groupBox1.Enabled = true;
            groupBox2.Enabled = false;
            button1.Enabled = false;
            button2.Enabled = false;
            button3.Enabled = false;
            button4.Enabled = true;
            button11.Visible = true;
            button6.Visible = true;
            textenabledtrue(this);
            comboBox1.Enabled = true;
            comboBox2.Enabled = true;
            comboBox3.Enabled = true;
            comboBox4.Enabled = true;
            comboBox5.Enabled = true;
            richTextBox1.Enabled = true;
        }

        private void geriToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult cevap = MessageBox.Show("İşlem İptal Edilsin mi?", "Bilgilendirme Mesajı",
                        MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (cevap == DialogResult.Yes)
            {
                button6.Visible = false;
                button11.Visible = false;
                textenabledfalse(this);
                textBox11.Enabled = true;
                groupBox2.Enabled = true;
                comboBox1.Enabled = false;
                comboBox2.Enabled = false;
                comboBox3.Enabled = false;
                comboBox4.Enabled = false;
                comboBox5.Enabled = false;
                richTextBox1.Enabled = false;
                button1.Enabled = true;
                button2.Enabled = true;
                button3.Enabled = true;
                button4.Enabled = false;
                pictureBox1.Enabled = false;
                groupBox1.Enabled = false;
                ekleToolStripMenuItem.Enabled = true;
                silToolStripMenuItem.Enabled = true;
                kaydetToolStripMenuItem.Enabled = false;
                geriToolStripMenuItem.Enabled = false;
                temizleToolStripMenuItem.Enabled = false;
                düzenleToolStripMenuItem.Enabled = true;
                baglan.Open();
                komut.Connection = baglan;
                komut.CommandText = "SELECT ad_soyad FROM kisiler";
                reader = komut.ExecuteReader();
                listBox1.Items.Clear();
                while (reader.Read())
                {
                    listBox1.Items.Add(reader["ad_soyad"]);
                }

                baglan.Close();
                listBox1.SelectedIndex = 0;
            }
        }

        private void temizleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult cevap = MessageBox.Show("Alanlar Temizlensin mi?", "Bilgilendirme Mesajı",
                MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2);
            if (cevap == DialogResult.OK)
            {
                textclear(this);
                comboBox1.Text = comboBox1.Items[0].ToString();
                comboBox2.Text = comboBox2.Items[0].ToString();
                comboBox3.Text = comboBox3.Items[0].ToString();
                comboBox4.Text = comboBox4.Items[0].ToString();
                comboBox5.Text = comboBox5.Items[0].ToString();
                richTextBox1.Clear();
                pictureBox1.Image = null;
            }
        }

        private void telefonlarıYazdırToolStripMenuItem_Click(object sender, EventArgs e)
        {
            printPreviewDialog1.Document = printDocument1;
            printPreviewDialog1.ShowDialog();
        }

        private void detaylıYazdırToolStripMenuItem_Click(object sender, EventArgs e)
        {
            printPreviewDialog2.Document = printDocument2;
            printPreviewDialog2.ShowDialog();
        }

        private void kişiKişilerinTümBilgileriniYazdırToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form9 x = new Form9();
            x.Show(); this.Hide();
        }

        private void yardımToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Yardim x = new Yardim();
            x.Show(); this.Hide();
        }

        private void kullanıcıRaporuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form8 x = new Form8();
            x.Show(); this.Hide();
        }

        private void textBox11_TextChanged(object sender, EventArgs e)
        {
            listBox1.SetSelected(0, false);
            if (listBox1.FindString(textBox11.Text) != -1)
            {
                listBox1.SetSelected(listBox1.FindString(textBox11.Text), true);
            }
        }

        int i = 0;
        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            baglan.Open();
            Font baslik_fontu = new Font("Tahoma", 14, FontStyle.Bold);
            Font yazi_fontu = new Font("Tahoma", 9, FontStyle.Regular);
            Font kalinyazi_fontu = new Font("Tahoma", 9, FontStyle.Bold);
            int x = 125, y = 125, say = listBox1.Items.Count;
            System.Drawing.Printing.PageSettings p = printDocument1.DefaultPageSettings;
            e.Graphics.DrawString("Kayıtlı Telefonlar", baslik_fontu, Brushes.Black, 340, 60);
            e.Graphics.DrawString(DateTime.Now.ToShortDateString(), kalinyazi_fontu, Brushes.Black, 680, 80);
            e.Graphics.DrawLine(new Pen(Color.Black, 20), p.Margins.Left - 30, 115, p.PaperSize.Width + 30 - p.Margins.Right, 115);
            e.Graphics.DrawString("Adı Soyadı", kalinyazi_fontu, Brushes.White, 90, 108);
            e.Graphics.DrawString("Ev Telefonu", kalinyazi_fontu, Brushes.White, 2 * 160, 108);
            e.Graphics.DrawString("Cep Telefonu", kalinyazi_fontu, Brushes.White, 3 * 155, 108);
            e.Graphics.DrawString("Firma / İş Telefonu", kalinyazi_fontu, Brushes.White, 4 * 150, 108);

            while (i < say)
            {
                x += 25;
                string ad = listBox1.Items[i].ToString();
                e.Graphics.DrawString(ad, kalinyazi_fontu, Brushes.Black, 90, x - 20);
                komut = new OleDbCommand("SELECT ev_telefona, cep_telefona, f_telefona FROM kisiler WHERE ad_soyad='" + ad + "'", baglan);
                komut.Connection = baglan;
                reader = komut.ExecuteReader();
                if (reader.Read())
                {
                    e.Graphics.DrawString(reader["ev_telefona"].ToString(), yazi_fontu, Brushes.Black, 2 * 160, x - 20);
                    e.Graphics.DrawString(reader["cep_telefona"].ToString(), yazi_fontu, Brushes.Black, 3 * 155, x - 20);
                    e.Graphics.DrawString(reader["f_telefona"].ToString(), yazi_fontu, Brushes.Black, 4 * 150, x - 20);
                }
                e.Graphics.DrawLine(new Pen(Color.Black, 2), p.Margins.Left - 30, x, p.PaperSize.Width + 30 - p.Margins.Right, x);
                i++;

                if ((x + y + 20) > (p.PaperSize.Height + 80 - p.Margins.Bottom + 80))
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
            e.Graphics.DrawLine(new Pen(Color.Black, 2), p.Margins.Left - 29, 125, p.Margins.Left - 29, x);
            e.Graphics.DrawLine(new Pen(Color.Black, 2), p.Margins.Left + 656, 125, p.Margins.Left + 656, x);
            baglan.Close();
        }

        private void printDocument2_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            baglan.Open();
            Font baslik_fontu = new Font("Tahoma", 14, FontStyle.Bold);
            Font yazi_fontu = new Font("Tahoma", 8, FontStyle.Regular);
            Font kalinyazi_fontu = new Font("Tahoma", 8, FontStyle.Bold);
            int x = 115, y = 115, say = listBox1.Items.Count;
            System.Drawing.Printing.PageSettings p = printDocument1.DefaultPageSettings;
            e.Graphics.DrawString("Kişisel Detaylar", baslik_fontu, Brushes.Black, 340, 60);
            e.Graphics.DrawString(DateTime.Now.ToShortDateString(), yazi_fontu, Brushes.Black, 700, 80);

            while (i < say)
            {
                e.Graphics.DrawLine(new Pen(Color.Black, 2), p.Margins.Left - 30, x - 10, p.PaperSize.Width + 30 - p.Margins.Right, x - 10);
                e.Graphics.DrawString("Ad Soyad :", kalinyazi_fontu, Brushes.Black, 80, x);
                e.Graphics.DrawString("Ev Telefonu :", kalinyazi_fontu, Brushes.Black, 80, x + 25);
                e.Graphics.DrawString("Cep Telefonu :", kalinyazi_fontu, Brushes.Black, 80, x + 50);
                e.Graphics.DrawString("Firma Telefonu :", kalinyazi_fontu, Brushes.Black, 80, x + 75);
                e.Graphics.DrawString("İli :", kalinyazi_fontu, Brushes.Black, 360, x);
                e.Graphics.DrawString("İlçesi :", kalinyazi_fontu, Brushes.Black, 560, x);
                e.Graphics.DrawString("Meslek :", kalinyazi_fontu, Brushes.Black, 360, x + 25);
                e.Graphics.DrawString("Ev Adresi :", kalinyazi_fontu, Brushes.Black, 360, x + 50);
                e.Graphics.DrawString("Mail Adresi :", kalinyazi_fontu, Brushes.Black, 360, x + 75);

                x += 25;
                string ad = listBox1.Items[i].ToString();
                e.Graphics.DrawString(ad, yazi_fontu, Brushes.Black, 175, x - 25);
                komut = new OleDbCommand("SELECT ev_adresi, sehir, ilce, meslek, email, ev_telefona, cep_telefona, f_telefona FROM kisiler WHERE ad_soyad='" + ad + "'", baglan);
                komut.Connection = baglan;
                reader = komut.ExecuteReader();
                if (reader.Read())
                {
                    e.Graphics.DrawString(reader["ev_telefona"].ToString(), yazi_fontu, Brushes.Black, 175, x);
                    e.Graphics.DrawString(reader["cep_telefona"].ToString(), yazi_fontu, Brushes.Black, 175, x + 25);
                    e.Graphics.DrawString(reader["f_telefona"].ToString(), yazi_fontu, Brushes.Black, 175, x + 50);
                    e.Graphics.DrawString(reader["sehir"].ToString(), yazi_fontu, Brushes.Black, 435, x - 25);
                    e.Graphics.DrawString(reader["ilce"].ToString(), yazi_fontu, Brushes.Black, 605, x - 25);
                    e.Graphics.DrawString(reader["meslek"].ToString(), yazi_fontu, Brushes.Black, 435, x);
                    e.Graphics.DrawString(reader["ev_adresi"].ToString(), yazi_fontu, Brushes.Black, 435, x + 25);
                    e.Graphics.DrawString(reader["email"].ToString(), yazi_fontu, Brushes.Black, 435, x + 50);
                }
                e.Graphics.DrawLine(new Pen(Color.Black, 2), p.Margins.Left - 30, x + 85, p.PaperSize.Width + 30 - p.Margins.Right, x + 85);
                e.Graphics.DrawLine(new Pen(Color.Black, 2), p.Margins.Left - 29, x - 35, p.Margins.Left - 29, x + 85);
                e.Graphics.DrawLine(new Pen(Color.Black, 2), p.Margins.Left + 250, x - 35, p.Margins.Left + 250, x + 85);
                e.Graphics.DrawLine(new Pen(Color.Black, 2), p.Margins.Left + 656, x - 35, p.Margins.Left + 656, x + 85);
                i++; x += 100;

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
    }
}
