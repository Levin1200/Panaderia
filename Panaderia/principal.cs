using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Panaderia
{
    public partial class principal : Form
    {
        public principal()
        {
            InitializeComponent();
        }

        private void button10_Click(object sender, EventArgs e)
        {
           
        }

        private void principal_Load(object sender, EventArgs e)
        {
            label1.Text = "Hola, "+label6.Text;
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            bancos bc = new bancos();
            bc.MdiParent = this.MdiParent;
            bc.Show();
        }
    }
}
