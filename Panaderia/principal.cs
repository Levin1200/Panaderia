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
            limpiar();
            mantenimiento.Visible = true;
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

        private void button1_Click(object sender, EventArgs e)
        {
            limpiar();
            pprinciapal.Visible = true;
        }

        private void limpiar() {
            pprinciapal.Visible = false;
            mantenimiento.Visible = false;
        }

        private void button2_MouseEnter(object sender, EventArgs e)
        {
            button2.ForeColor = Color.BlueViolet;
        }

        private void button2_MouseLeave(object sender, EventArgs e)
        {
            button2.ForeColor = Color.FromArgb(64,64,64);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            pedidos bc = new pedidos();
            bc.MdiParent = this.MdiParent;
            bc.Show();
           
        }

        private void pictureBox11_Click(object sender, EventArgs e)
        {

        }
    }
}
