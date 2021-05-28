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
            label8.Text = "Administracion";
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
            label8.Text = "Inicio";
            pprinciapal.Visible = true;
        }

        private void limpiar() {
            pprinciapal.Visible = false;
            mantenimiento.Visible = false;
            panaderia.Visible = false;
            personas.Visible = false;
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

        private void pictureBox10_Click(object sender, EventArgs e)
        {
            pan bc = new pan();
            bc.MdiParent = this.MdiParent;
            bc.Show();
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            limpiar();
            label8.Text = "Panaderia";
            panaderia.Visible = true;
        }

        private void button11_Click(object sender, EventArgs e)
        {
            label8.Text = "Ventas";
        }

        private void button9_Click(object sender, EventArgs e)
        {
            label8.Text = "Compras";
        }

        private void button8_Click(object sender, EventArgs e)
        {
            label8.Text = "Produccion";
        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {
            ingredientes bc = new ingredientes();
            bc.MdiParent = this.MdiParent;
            bc.Show();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            limpiar();
            label8.Text = "Personas";
            personas.Visible = true;
        }

        private void pictureBox12_Click(object sender, EventArgs e)
        {
            usuarios bc = new usuarios();
            bc.MdiParent = this.MdiParent;
            bc.Show();
        }
    }
}
