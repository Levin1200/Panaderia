using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

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
            contarpanes();
        }

        private void contarpanes() {
            try
            {
                using (SqlConnection cn = new SqlConnection("server=" + label26.Text + " ; database=" + label25.Text + " ; user id = sa; password='Valley';"))
                {
                    using (SqlCommand cmd = new SqlCommand("propan", cn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@pcod", SqlDbType.Int).Value = 1;
                        cmd.Parameters.Add("@pnom", SqlDbType.VarChar).Value = "1";
                        cmd.Parameters.Add("@pprecio", SqlDbType.Decimal).Value =1;
                        cmd.Parameters.Add("@pestado", SqlDbType.Int).Value = 1;
                        cmd.Parameters.Add("@opcion", SqlDbType.Int).Value = 5;
                        cmd.Parameters.Add("@pid", SqlDbType.Int).Value = 1;
                        cn.Open();
                        cmd.ExecuteNonQuery();
                        int total = (int)cmd.ExecuteScalar();
                        label21.Text = "" + total;
                    }
                }
            }
            catch { MessageBox.Show("No se pueden contar los panes"); }
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

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            proveedores bc = new proveedores();
            bc.MdiParent = this.MdiParent;
            bc.Show();
        }

        private void pictureBox9_Click(object sender, EventArgs e)
        {
            recetas bc = new recetas();
            bc.MdiParent = this.MdiParent;
            bc.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            pictureBox9_Click(sender, e);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            pictureBox10_Click(sender, e);
        }
    }
}
