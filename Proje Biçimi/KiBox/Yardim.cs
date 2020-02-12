using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KiBox
{
    public partial class Yardim : Form
    {
        public Yardim()
        {
            InitializeComponent();
        }

        private void Yardim_Load(object sender, EventArgs e)
        {
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            ToolTip toolTip = new ToolTip();
            toolTip.ShowAlways = true;
            toolTip.SetToolTip(button2, "Ana Menüye Dön");
            toolTip.SetToolTip(button2, "ÇIKIŞ");
        }

        private void button1_Click(object sender, EventArgs e)
        {

            Form2 x = new KiBox.Form2();
            x.Show(); this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult secenek = MessageBox.Show("Programdan Çıkmak İstediğinizden Emin misiniz?", "Bilgilendirme Mesajı",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
            if (secenek == DialogResult.Yes)
            {
                Application.Exit();
            }
        }
    }
}
