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
            contarcompras();
            contarpedidos();
            contarproduccion();
            contarventas();
           
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

        private void contarpedidos()
        {
            try
            {
                using (SqlConnection cn = new SqlConnection("server=" + label26.Text + " ; database=" + label25.Text + " ; user id = sa; password='Valley';"))
                {
                    using (SqlCommand cmd = new SqlCommand("ppedido", cn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@id", SqlDbType.Int).Value = 1; //int.Parse(label13.Text);
                        cmd.Parameters.Add("@cod", SqlDbType.VarChar).Value = "1";
                        cmd.Parameters.Add("@sucursal", SqlDbType.Int).Value = 1;
                        cmd.Parameters.Add("@estado", SqlDbType.VarChar).Value = 1;
                        cmd.Parameters.Add("@opcion", SqlDbType.Int).Value = 5;
                        cn.Open();
                        cmd.ExecuteNonQuery();
                        int total = (int)cmd.ExecuteScalar();
                        label28.Text = "" + total;
                    }
                }
            }
            catch { MessageBox.Show("No se pueden contar los panes"); }
        }

        private void contarventas()
        {
            try
            {
                using (SqlConnection cn = new SqlConnection("server=" + label26.Text + " ; database=" + label25.Text + " ; user id = sa; password='Valley';"))
                {
                    using (SqlCommand cmd = new SqlCommand("proventas", cn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@id", SqlDbType.Int).Value = 1; //int.Parse(label13.Text);
                        cmd.Parameters.Add("@codfact", SqlDbType.VarChar).Value = "";
                        cmd.Parameters.Add("@idcli", SqlDbType.Int).Value = 1;
                        cmd.Parameters.Add("@tpago", SqlDbType.Int).Value = 1;
                        cmd.Parameters.Add("@idusu", SqlDbType.Int).Value = 1;
                        cmd.Parameters.Add("@tot", SqlDbType.Decimal).Value = 1;
                        cmd.Parameters.Add("@idsucur", SqlDbType.Int).Value = int.Parse(label60.Text) ;
                        cmd.Parameters.Add("@opcion", SqlDbType.Int).Value = 5;
                        cn.Open();
                        cmd.ExecuteNonQuery();
                        int total = (int)cmd.ExecuteScalar();
                        label48.Text = "" + total;
                    }
                }
            }
            catch { MessageBox.Show("No se pueden contar los panes"); }
        }

        private void contarcompras()
        {
            try
            {
                using (SqlConnection cn = new SqlConnection("server=" + label26.Text + " ; database=" + label25.Text + " ; user id = sa; password='Valley';"))
                {
                    using (SqlCommand cmd = new SqlCommand("pcompra_encabezado", cn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@id", SqlDbType.Int).Value = 1; //int.Parse(label13.Text);
                        cmd.Parameters.Add("@cod_fac", SqlDbType.VarChar).Value = 1;
                        cmd.Parameters.Add("@prov", SqlDbType.Int).Value = 1;
                        cmd.Parameters.Add("@usuario", SqlDbType.Int).Value = 1;
                        cmd.Parameters.Add("@tpago", SqlDbType.Int).Value = 1;
                        cmd.Parameters.Add("@total", SqlDbType.Decimal).Value = 1;
                        cmd.Parameters.Add("@estado", SqlDbType.VarChar).Value = 1;
                        cmd.Parameters.Add("@opcion", SqlDbType.Int).Value = 4;
                        cn.Open();
                        cmd.ExecuteNonQuery();
                        int total = (int)cmd.ExecuteScalar();
                        label41.Text = "" + total;
                    }
                }
            }
            catch { MessageBox.Show("No se pueden contar las compras"); }
        }


        private void contarproduccion()
        {
            try
            {
                using (SqlConnection cn = new SqlConnection("server=" + label26.Text + " ; database=" + label25.Text + " ; user id = sa; password='Valley';"))
                {
                    using (SqlCommand cmd = new SqlCommand("pproduccion", cn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@id", SqlDbType.Int).Value = 1; //int.Parse(label13.Text);
                        cmd.Parameters.Add("@cod", SqlDbType.VarChar).Value = "1";
                        cmd.Parameters.Add("@total", SqlDbType.Decimal).Value = 1;
                        cmd.Parameters.Add("@estado", SqlDbType.VarChar).Value = int.Parse(label39.Text);
                        cmd.Parameters.Add("@estados", SqlDbType.VarChar).Value =1;
                        cmd.Parameters.Add("@tipo", SqlDbType.Int).Value = 3;
                        cmd.Parameters.Add("@opcion", SqlDbType.Int).Value = 7;
                        cn.Open();
                        cmd.ExecuteNonQuery();
                        int total = (int)cmd.ExecuteScalar();
                        label35.Text = "" + total;
                    }
                }
            }
            catch { MessageBox.Show("No se pueden contar las compras"); }
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
            contarpanes();
           
            
        }

        private void limpiar() {
            pprinciapal.Visible = false;
            mantenimiento.Visible = false;
            panaderia.Visible = false;
            personas.Visible = false;
            pproduccion.Visible = false;
            Ventas.Visible = false;
            compras.Visible = false;
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
            contarpanes();
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            limpiar();
            label8.Text = "Panaderia";
            panaderia.Visible = true;
        }

        private void button11_Click(object sender, EventArgs e)
        {
            limpiar();
            label8.Text = "Ventas";
            Ventas.Visible = true;
            contarventas();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            limpiar();
            label8.Text = "Compras";
            compras.Visible = true;
            contarcompras();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            contarproduccion();
            contarpedidos();
            limpiar();
            label8.Text = "Produccion";
            pproduccion.Visible = true;
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

        private void pictureBox18_MouseEnter(object sender, EventArgs e)
        {
           
        }

        private void button16_Click(object sender, EventArgs e)
        {
            estadopedido bc = new estadopedido();
            bc.MdiParent = this.MdiParent;
            bc.Show();
           
        }

        private void button6_Click(object sender, EventArgs e)
        {
            pedidosproduccion bc = new pedidosproduccion();
            bc.MdiParent = this.MdiParent;
            bc.Show();
            pedidocurrent = 1;
        }

        private void pictureBox13_Click(object sender, EventArgs e)
        {
            empleados bc = new empleados();
            bc.MdiParent = this.MdiParent;
            bc.Show();
        }

        private void pictureBox11_Click_1(object sender, EventArgs e)
        {
            clientes bc = new clientes();
            bc.MdiParent = this.MdiParent;
            bc.Show();
        }

        private void button21_Click(object sender, EventArgs e)
        {
            ventashoy bc = new ventashoy();
            bc.MdiParent = this.MdiParent;
            bc.Show();

        }

        private void button18_Click(object sender, EventArgs e)
        {
           comprashoy bc = new comprashoy();
            bc.MdiParent = this.MdiParent;
            bc.Show();
        }

        private void button27_Click(object sender, EventArgs e)
        {
           
          
        }

        private void button12_Click(object sender, EventArgs e)
        {
            produccion bc = new produccion();
            bc.MdiParent = this.MdiParent;
            bc.Show();
        }
        int pedidocurrent;
        private void label57_MouseEnter(object sender, EventArgs e)
        {
           
        }

        private void button25_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox17_MouseEnter(object sender, EventArgs e)
        {
            if (pedidocurrent == 0) { } else { contarpedidos();pedidocurrent = 0; }
        }

        private void pictureBox45_Click(object sender, EventArgs e)
        {
            adrecetas bc = new adrecetas();
            bc.MdiParent = this.MdiParent;
            bc.Show();
        }

        private void button26_Click(object sender, EventArgs e)
        {
            enviarsucursal bc = new enviarsucursal();
            bc.MdiParent = this.MdiParent;
            bc.Show();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            enviarsucursal bc = new enviarsucursal();
            bc.MdiParent = this.MdiParent;
            bc.Show();
        }

        private void button20_Click(object sender, EventArgs e)
        {
            compras bc = new compras();
            bc.MdiParent = this.MdiParent;
            bc.Show();
        }

        private void button19_Click(object sender, EventArgs e)
        {
            exingredientes bc = new exingredientes();
            bc.MdiParent = this.MdiParent;
            bc.Show();
        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void button28_Click(object sender, EventArgs e)
        {
            recibirpedido bc = new recibirpedido();
            bc.MdiParent = this.MdiParent;
            bc.Show();
        }

        private void button23_Click(object sender, EventArgs e)
        {
            ventas bc = new ventas();
            bc.MdiParent = this.MdiParent;
            bc.Show();
        }

        private void button17_Click(object sender, EventArgs e)
        {
            facturarcompras bc = new facturarcompras();
            bc.MdiParent = this.MdiParent;
            bc.Show();
        }

        private void button22_Click(object sender, EventArgs e)
        {
            stock bc = new stock();
            bc.MdiParent = this.MdiParent;
            bc.Show();
        }
    }
}
