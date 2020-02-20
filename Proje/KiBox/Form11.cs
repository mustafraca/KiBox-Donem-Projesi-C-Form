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
    public partial class Form11 : Form
    {
        public Form11()
        {
            InitializeComponent();
        }

        private void Form11_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void Form11_Load(object sender, EventArgs e)
        {
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            ToolTip toolTip = new ToolTip();
            toolTip.ShowAlways = true;
            toolTip.SetToolTip(button1, "Ana Menüye Git");
            toolTip.SetToolTip(button2, "ÇIKIŞ");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form2 yeni = new Form2();
            yeni.Show(); this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
