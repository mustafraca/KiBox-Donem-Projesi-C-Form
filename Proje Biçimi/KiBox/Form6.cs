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
    public partial class Form6 : Form
    {
        public Form6()
        {
            InitializeComponent();
        }

        OleDbConnection baglan = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=KiBox.mdb");
        DataSet data = new DataSet();
        OleDbDataAdapter adapter = new OleDbDataAdapter();

        private void Form6_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void Form6_Load(object sender, EventArgs e)
        {
            try
            {
                baglan.Open();
                adapter = new OleDbDataAdapter("SELECT ad, soyad, eposta, tel, dogum FROM kullanici", baglan);
                adapter.Fill(data, "kullanici");
                dataGridView1.DataSource = data.Tables["kullanici"];
                adapter.Dispose();
            }
            catch (Exception hata)
            {
                MessageBox.Show(hata.Message);
            }
            baglan.Close();
        }

        private void anaMenüyeDönToolStripMenuItem_Click(object sender, EventArgs e)
        {
                Form2 x = new KiBox.Form2();
                x.Show(); this.Hide();
        }

        private void kiBoxProgramınaGitToolStripMenuItem_Click(object sender, EventArgs e)
        {
                Form4 x = new KiBox.Form4();
                x.Show(); this.Hide();
        }

        private void çıkışToolStripMenuItem_Click(object sender, EventArgs e)
        {
                Application.Exit();
        }
    }
}
