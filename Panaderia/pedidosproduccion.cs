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
    public partial class pedidosproduccion : Form
    {
        public pedidosproduccion()
        {
            InitializeComponent();
        }

        private void cargarpedidos()
        {
            try
            {
                using (SqlConnection cn = new SqlConnection("server=" + label12.Text + " ; database=" + label9.Text + " ; user id = sa; password='Valley';"))
                {
                    using (SqlCommand cmd = new SqlCommand("ppedido", cn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@id", SqlDbType.Int).Value = 1; //int.Parse(label13.Text);
                        cmd.Parameters.Add("@cod", SqlDbType.VarChar).Value = textBox8.Text;
                        cmd.Parameters.Add("@sucursal", SqlDbType.Int).Value = 1;
                        cmd.Parameters.Add("@estado", SqlDbType.VarChar).Value = int.Parse(label13.Text);
                        cmd.Parameters.Add("@opcion", SqlDbType.Int).Value = 8;
                        cn.Open();
                        cmd.ExecuteNonQuery();
                        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                        DataSet ds = new DataSet();
                        adapter.Fill(ds);
                        dataGridView1.DataSource = ds.Tables[0];
                    }
                }
            }
            catch { MessageBox.Show("Ha sucedido un error", "Pedidos", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private void pedidosproduccion_Load(object sender, EventArgs e)
        {
            cargarpedidos();
        }
        private void ocultar() {
            final.Visible = false;
            allpedidos.Visible = false;
            ingredientes.Visible = false;
            panesrecetas.Visible = false;
        }

        private void cargardetingredientes()
        {
            try
            {
                using (SqlConnection cn = new SqlConnection("server=" + label12.Text + " ; database=" + label9.Text + " ; user id = sa; password='Valley';"))
                {
                    using (SqlCommand cmd = new SqlCommand("pexingredientes", cn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@id", SqlDbType.Int).Value = deting; //int.Parse(label13.Text);
                        cmd.Parameters.Add("@cantidad", SqlDbType.Decimal).Value = 1;
                        cmd.Parameters.Add("@precio", SqlDbType.Decimal).Value = 1;
                        cmd.Parameters.Add("@estado", SqlDbType.VarChar).Value = int.Parse(label13.Text);
                        cmd.Parameters.Add("@opcion", SqlDbType.Int).Value = 3;
                        cn.Open();
                        cmd.ExecuteNonQuery();
                        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                        DataSet ds = new DataSet();
                        adapter.Fill(ds);
                        dataGridView4.DataSource = ds.Tables[0];
                    }
                }
            }
            catch { MessageBox.Show("Ha sucedido un error", "Inventario", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private void cargarrecetas()
        {
            try
            {
                using (SqlConnection cn = new SqlConnection("server=" + label12.Text + " ; database=" + label9.Text + " ; user id = sa; password='Valley';"))
                {
                    using (SqlCommand cmd = new SqlCommand("precetas", cn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@id_pan", SqlDbType.Int).Value = panreceta;
                        cmd.Parameters.Add("@nombrer", SqlDbType.VarChar).Value = "";
                        cmd.Parameters.Add("@codigo", SqlDbType.VarChar).Value = "1";
                        cmd.Parameters.Add("@estador", SqlDbType.Int).Value = int.Parse(label13.Text);
                        cmd.Parameters.Add("@opcion", SqlDbType.Int).Value = 4;
                        cmd.Parameters.Add("@iid", SqlDbType.Int).Value = 1;
                        cmd.Parameters.Add("@tpan", SqlDbType.Int).Value = 1;
                        cmd.Parameters.Add("@tiempo", SqlDbType.VarChar).Value = "1";
                        cn.Open();
                        cmd.ExecuteNonQuery();
                        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                        DataSet ds = new DataSet();
                        adapter.Fill(ds);
                        dataGridView2.DataSource = ds.Tables[0];
                        //label17.Text = dataGridView4.Rows.Count.ToString();
                       // posicion(3);
                    }
                }
            }
            catch { MessageBox.Show("Ha sucedido un error", "Recetas", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        int detrecetas = 0;
        private void cargardetrecetas()
        {
            try
            {
                using (SqlConnection cn = new SqlConnection("server=" + label12.Text + " ; database=" + label9.Text + " ; user id = sa; password='Valley';"))
                {
                    using (SqlCommand cmd = new SqlCommand("pdetrecetas", cn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@id_rece", SqlDbType.Int).Value = detrecetas;
                        cmd.Parameters.Add("@codigo", SqlDbType.VarChar).Value = "1";
                        cmd.Parameters.Add("@id_ingred", SqlDbType.Int).Value = 1;
                        cmd.Parameters.Add("@cantidad", SqlDbType.Decimal).Value = 1;
                        cmd.Parameters.Add("@estado", SqlDbType.Int).Value = 1;
                        cmd.Parameters.Add("@iid", SqlDbType.Int).Value = 1;
                        cmd.Parameters.Add("@totalpedido", SqlDbType.Decimal).Value = 1;
                        cmd.Parameters.Add("@opcion", SqlDbType.Int).Value = 4;
                        cn.Open();
                        cmd.ExecuteNonQuery();
                        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                        DataSet ds = new DataSet();
                        adapter.Fill(ds);
                        dataGridView3.DataSource = ds.Tables[0];
                        //label17.Text = dataGridView1.Rows.Count.ToString();
                        //posicion(3);
                    }
                }
            }
            catch { MessageBox.Show("Ha sucedido un error", "Detalle Recetas", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private void cargarcolatemporal()
        {
           try
           {
                using (SqlConnection cn = new SqlConnection("server=" + label12.Text + " ; database=" + label9.Text + " ; user id = sa; password='Valley';"))
                {
                    using (SqlCommand cmd = new SqlCommand("pdettemporal", cn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@id", SqlDbType.Int).Value = int.Parse(label3.Text); //int.Parse(label13.Text);
                        cmd.Parameters.Add("@cod", SqlDbType.VarChar).Value = "1";
                        cmd.Parameters.Add("@cantidad", SqlDbType.Int).Value = 1;
                        cmd.Parameters.Add("@estado", SqlDbType.Int).Value = 1;
                        cmd.Parameters.Add("@opcion", SqlDbType.Int).Value = 5;
                        cmd.Parameters.Add("@receta", SqlDbType.Int).Value = 1;
                        cmd.Parameters.Add("@pan", SqlDbType.Int).Value = 1; ;
                        cmd.Parameters.Add("@estadotemporal", SqlDbType.Int).Value = int.Parse(label26.Text);
                        cmd.Parameters.Add("@total", SqlDbType.Int).Value =1;
                        cn.Open();
                        cmd.ExecuteNonQuery();
                        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                        DataSet ds = new DataSet();
                        adapter.Fill(ds);
                        colaproduccion.DataSource = ds.Tables[0];
                        //label17.Text = dataGridView1.Rows.Count.ToString();
                        //posicion(3);
                    }
                }
            }
           catch { MessageBox.Show("Ha sucedido un error", "Cola pedidos", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private void aceptarpedidocola()
        {
            try
            {
                using (SqlConnection cn = new SqlConnection("server=" + label12.Text + " ; database=" + label9.Text + " ; user id = sa; password='Valley';"))
                {
                    using (SqlCommand cmd = new SqlCommand("pdettemporal", cn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@id", SqlDbType.Int).Value = int.Parse(label3.Text); //int.Parse(label13.Text);
                        cmd.Parameters.Add("@cod", SqlDbType.VarChar).Value = "1";
                        cmd.Parameters.Add("@cantidad", SqlDbType.Int).Value = int.Parse(label30.Text);
                        cmd.Parameters.Add("@estado", SqlDbType.Int).Value = int.Parse(label26.Text);
                        cmd.Parameters.Add("@opcion", SqlDbType.Int).Value = 6;
                        cmd.Parameters.Add("@receta", SqlDbType.Int).Value = int.Parse(label23.Text);
                        cmd.Parameters.Add("@pan", SqlDbType.Int).Value = int.Parse(label25.Text); ;
                        cmd.Parameters.Add("@estadotemporal", SqlDbType.Int).Value = int.Parse(label26.Text);
                        cmd.Parameters.Add("@total", SqlDbType.Int).Value = int.Parse(label28.Text);
                        cn.Open();
                        cmd.ExecuteNonQuery();
                        cargarcolatemporal();
                        cargardetpedidos();
                    }
                }
            }
            catch { MessageBox.Show("Ha sucedido un error", "Detalle Pedidos", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private void cargardetpedidos()
        {
            try
            {
                using (SqlConnection cn = new SqlConnection("server=" + label12.Text + " ; database=" + label9.Text + " ; user id = sa; password='Valley';"))
                {
                    using (SqlCommand cmd = new SqlCommand("pdetpedido", cn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@id", SqlDbType.Int).Value = detpedidos; //int.Parse(label13.Text);
                        cmd.Parameters.Add("@cod", SqlDbType.VarChar).Value = "1";
                        cmd.Parameters.Add("@cantidad", SqlDbType.Int).Value = 1;
                        cmd.Parameters.Add("@estado", SqlDbType.VarChar).Value = int.Parse(label13.Text);
                        cmd.Parameters.Add("@opcion", SqlDbType.Int).Value = 6;
                        cn.Open();
                        cmd.ExecuteNonQuery();
                        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                        DataSet ds = new DataSet();
                        adapter.Fill(ds);
                        dataGridView5.DataSource = ds.Tables[0];
                    }
                }
            }
            catch { MessageBox.Show("Ha sucedido un error", "Detalle Pedidos", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }


        int epedidocod;
        int detpedidos;
        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.RowCount > 0) {
                label3.Text = "" + dataGridView1.CurrentRow.Cells[0].Value;
                label46.Text = "" + dataGridView1.CurrentRow.Cells[0].Value;
                detpedidos = int.Parse(dataGridView1.CurrentRow.Cells[0].Value.ToString());
                cargardetpedidos();
                ocultar();
                panesrecetas.Visible = true;
                if (dataGridView5.RowCount > 0)
                {
                    button5.Visible = true;
                   // button3.Visible = false;
                }
                else
                {

                    button5.Visible = false;
                   // button3.Visible = true;
                    cargarcolatemporal();
                }
               // retornarinventario();
                //if (dataGridView7.RowCount > 0) {
                //    button10_Click(sender, e);
                //}
                

            }
            
        }

        int estados;
        private void agregarpedido() {

            if (label3.Text == "0")
            {
                MessageBox.Show("Error desconocido", "Pedido", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else {
                try
               {
                    using (SqlConnection cn = new SqlConnection("server=" + label12.Text + " ; database=" + label9.Text + " ; user id = sa; password='Valley';"))
                    {
                        using (SqlCommand cmd = new SqlCommand("ppedido", cn))
                        {
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.Parameters.Add("@id", SqlDbType.Int).Value = int.Parse(label46.Text); //int.Parse(label13.Text);
                            cmd.Parameters.Add("@cod", SqlDbType.VarChar).Value = "1";
                            cmd.Parameters.Add("@sucursal", SqlDbType.Int).Value = 1;
                        MessageBox.Show("Estado: " + estados);
                            cmd.Parameters.Add("@estado", SqlDbType.Int).Value = estados;
                            cmd.Parameters.Add("@opcion", SqlDbType.Int).Value = 7;

                            cn.Open();
                            cmd.ExecuteNonQuery();
                            MessageBox.Show("Accion Realizada", "Produccion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            cargarpedidos();
                        }
                    }
               }
               catch
               {
                    MessageBox.Show("Ha sucedido un error al insertar", "Pedido", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
           
        }


        private void button6_Click(object sender, EventArgs e)
        {
            

            DialogResult result = MessageBox.Show("¿Desea aceptar el pedido?", "Produccion", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                epedidocod = int.Parse(label3.Text);
                estados = int.Parse(label14.Text);
                agregarpedido();
                label3.Text = "0";
                dataGridView5.DataSource = null;
                dataGridView2.DataSource = null;
                ocultar();
                allpedidos.Visible = true;

            }
            else
            {
                MessageBox.Show("Operacion cancelada", "Produccion", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("¿Realmente desea rechazar el pedido?", "Produccion",MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                epedidocod = int.Parse(label46.Text);
                estados = int.Parse(label17.Text);
                agregarpedido();
                label3.Text = "0";
                dataGridView5.DataSource = null;
                dataGridView2.DataSource = null;
                button10_Click(sender, e);
                ocultar();
                allpedidos.Visible = true;

            }
            else {
                MessageBox.Show("Operacion cancelada", "Produccion", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            
        }

        private void button15_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dataGridView2_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }
        int panreceta;
        private void dataGridView5_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
           
        }
        int deting;
        private void dataGridView3_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
           
        }

        private void generardetalle()
        {
            try
            {
                using (SqlConnection cn = new SqlConnection("server=" + label12.Text + " ; database=" + label9.Text + " ; user id = sa; password='Valley';"))
                {
                    using (SqlCommand cmd = new SqlCommand("pdettemporal", cn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@id", SqlDbType.Int).Value = int.Parse(label3.Text); //int.Parse(label13.Text);
                        cmd.Parameters.Add("@cod", SqlDbType.VarChar).Value = "1";
                        cmd.Parameters.Add("@cantidad", SqlDbType.Int).Value = 1;
                        cmd.Parameters.Add("@estado", SqlDbType.Int).Value = int.Parse(label13.Text);
                        cmd.Parameters.Add("@opcion", SqlDbType.Int).Value = 7;
                        cmd.Parameters.Add("@receta", SqlDbType.Int).Value = 1;
                        cmd.Parameters.Add("@pan", SqlDbType.Int).Value = 1; ;
                        cmd.Parameters.Add("@estadotemporal", SqlDbType.Int).Value =int.Parse(label26.Text);
                        cmd.Parameters.Add("@total", SqlDbType.Int).Value = 1;
                        cn.Open();
                        cmd.ExecuteNonQuery();
                        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                        DataSet ds = new DataSet();
                        adapter.Fill(ds);
                        dataGridView3.DataSource = ds.Tables[0];
                        //label17.Text = dataGridView1.Rows.Count.ToString();
                        //posicion(3);
                    }
                }
            }
            catch { MessageBox.Show("Ha sucedido un error", "Cola pedidos generados", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private void cargarnuevodetalle()
            {
                try
                {
                using (SqlConnection cn = new SqlConnection("server=" + label12.Text + " ; database=" + label9.Text + " ; user id = sa; password='Valley';"))
                {
                    using (SqlCommand cmd = new SqlCommand("pdettemporal", cn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@id", SqlDbType.Int).Value = int.Parse(label3.Text); //int.Parse(label13.Text);
                        cmd.Parameters.Add("@cod", SqlDbType.VarChar).Value = "1";
                        cmd.Parameters.Add("@cantidad", SqlDbType.Int).Value = 1;
                        cmd.Parameters.Add("@estado", SqlDbType.Int).Value = int.Parse(label13.Text);
                        cmd.Parameters.Add("@opcion", SqlDbType.Int).Value = 9;
                        cmd.Parameters.Add("@receta", SqlDbType.Int).Value = 1;
                        cmd.Parameters.Add("@pan", SqlDbType.Int).Value = 1; ;
                        cmd.Parameters.Add("@estadotemporal", SqlDbType.Int).Value = 1;
                        cmd.Parameters.Add("@total", SqlDbType.Int).Value = 1;
                        cn.Open();
                        cmd.ExecuteNonQuery();
                        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                        DataSet ds = new DataSet();
                        adapter.Fill(ds);
                        dataGridView3.DataSource = ds.Tables[0];
                        //label17.Text = dataGridView1.Rows.Count.ToString();
                        //posicion(3);
                    }
                }
                }
                catch { MessageBox.Show("Ha sucedido un error", "Cola pedidos generados", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            }

            private void button3_Click(object sender, EventArgs e)
        {
            if (dataGridView5.RowCount > 0)
            {


            }
            else
            {
                ocultar();
                ingredientes.Visible = true;
                generardetalle();
                if (dataGridView3.RowCount > 0)
                {
                    button4.Enabled = false;
                }
                else
                {
                    button4.Enabled = true;
                }

            } 
               

        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (dataGridView5.RowCount > 0)
            {

            }
            else {
                ocultar();
                final.Visible = true;
                retornarinventario();
            }
        }

        private void dataGridView5_CellDoubleClick_1(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView5.RowCount > 0)
            {
                panreceta = int.Parse(dataGridView5.CurrentRow.Cells[0].Value.ToString());
                label25.Text = dataGridView5.CurrentRow.Cells[0].Value.ToString();
                label30.Text = dataGridView5.CurrentRow.Cells[2].Value.ToString();
                cargarrecetas();
                dataGridView2_CellDoubleClick_1(sender, e);
            }
            else {
                button3.Enabled = true;

            }
         
        }

        private void dataGridView2_CellDoubleClick_1(object sender, DataGridViewCellEventArgs e)
        {
            detrecetas = int.Parse(dataGridView2.CurrentRow.Cells[0].Value.ToString());
            label28.Text = dataGridView2.CurrentRow.Cells[3].Value.ToString();
            cargardetrecetas();
            label23.Text = "" + detrecetas;
        }

        private void dataGridView3_CellDoubleClick_1(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView3.RowCount > 0) {
                deting = int.Parse(dataGridView3.CurrentRow.Cells[0].Value.ToString());
                label37.Text = dataGridView3.CurrentRow.Cells[0].Value.ToString();
                label39.Text = dataGridView3.CurrentRow.Cells[2].Value.ToString();
                cargardetingredientes();
            }
          
        }

        private void button5_Click(object sender, EventArgs e)
        {
            aceptarpedidocola();
            dataGridView2.DataSource = null;
            label23.Text = "";
        }

        private void button7_Click(object sender, EventArgs e)
        {
            ocultar();
            allpedidos.Visible = true;
        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void button8_Click(object sender, EventArgs e)
        {
            ocultar();
            panesrecetas.Visible = true;
        }

        private void dataGridView4_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView4.RowCount > 0)
            {
                label42.Text = dataGridView4.CurrentRow.Cells[1].Value.ToString();
                label36.Text = dataGridView4.CurrentRow.Cells[2].Value.ToString();
                //cargardetingredientes();
                button9.Enabled = true;
            }
        }

        private void confirmarinventario()
        {
            try
            {
                using (SqlConnection cn = new SqlConnection("server=" + label12.Text + " ; database=" + label9.Text + " ; user id = sa; password='Valley';"))
                {
                    using (SqlCommand cmd = new SqlCommand("updatetemporal", cn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@id", SqlDbType.Int).Value = int.Parse(label3.Text); //int.Parse(label13.Text);
                        cmd.Parameters.Add("@precio", SqlDbType.Decimal).Value = double.Parse(label36.Text);
                        cmd.Parameters.Add("@ingred", SqlDbType.Int).Value = int.Parse(label37.Text);
                        cmd.Parameters.Add("@cantidad", SqlDbType.Decimal).Value = double.Parse(label42.Text)-double.Parse(label39.Text);
                        cmd.Parameters.Add("@estado", SqlDbType.Int).Value = int.Parse(label13.Text);
                        cmd.Parameters.Add("@estadoesperado", SqlDbType.Int).Value = int.Parse(label26.Text);
                        cmd.Parameters.Add("@opcion", SqlDbType.Int).Value = 3;
                        cn.Open();
                        cmd.ExecuteNonQuery();
                        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                        DataSet ds = new DataSet();
                        adapter.Fill(ds);
                        dataGridView6.DataSource = ds.Tables[0];
                        //dataGridView7.DataSource = ds.Tables[0];
                        cargarnuevodetalle();
                        //label17.Text = dataGridView1.Rows.Count.ToString();
                        //posicion(3);
                    }
                }
            }
            catch { MessageBox.Show("Ha sucedido un error", "Cola pedidos", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private void retornarinventario()
        {
            try
            {
                using (SqlConnection cn = new SqlConnection("server=" + label12.Text + " ; database=" + label9.Text + " ; user id = sa; password='Valley';"))
                {
                    using (SqlCommand cmd = new SqlCommand("updatetemporal", cn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@id", SqlDbType.Int).Value =int.Parse(label46.Text); //int.Parse(label13.Text);
                        cmd.Parameters.Add("@precio", SqlDbType.Decimal).Value =1;
                        cmd.Parameters.Add("@ingred", SqlDbType.Int).Value = 1;
                        cmd.Parameters.Add("@cantidad", SqlDbType.Decimal).Value = 1;
                        cmd.Parameters.Add("@estado", SqlDbType.Int).Value = 1;
                        cmd.Parameters.Add("@estadoesperado", SqlDbType.Int).Value = int.Parse(label26.Text);
                        cmd.Parameters.Add("@opcion", SqlDbType.Int).Value = 4;
                        cn.Open();
                        cmd.ExecuteNonQuery();
                        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                        DataSet ds = new DataSet();
                        adapter.Fill(ds);
                        dataGridView7.DataSource = ds.Tables[0];
                        //label17.Text = dataGridView1.Rows.Count.ToString();
                        //posicion(3);
                    }
                }
           }
          catch { MessageBox.Show("Ha sucedido un error", "Cola pedidos", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            double cantidanecesaria = double.Parse(label39.Text);
            double eninvnetario = double.Parse(label42.Text);

            if (eninvnetario >= cantidanecesaria)
            {
                confirmarinventario();
                button9.Enabled = false;
                label37.Text = "0";
                label39.Text = "0";
                label36.Text = "0";
                label42.Text = "0";
                if (dataGridView3.RowCount > 0)
                {
                    button4.Enabled = false;
                }
                else
                {
                    button4.Enabled = true;
                }
            }
            else
            {
                MessageBox.Show("El inventario debe ser mayor que lo solicitado por el pedido", "Cola pedidos", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }


        double precio;
        double enespera;
        double disponible;
        int ingrediente;
        double total;
        private void button10_Click(object sender, EventArgs e)
        {
            if (dataGridView7.RowCount > 0) {
                for (int i = 0; i < dataGridView7.Rows.Count; i++)
                {
                    ingrediente = int.Parse(dataGridView7.Rows[i].Cells[0].Value.ToString());
                    enespera = double.Parse(dataGridView7.Rows[i].Cells[2].Value.ToString());
                    disponible = double.Parse(dataGridView7.Rows[i].Cells[3].Value.ToString());
                   precio = double.Parse(dataGridView7.Rows[i].Cells[4].Value.ToString());
                    total = enespera + disponible;
                    //try
                    //{
                        using (SqlConnection cn = new SqlConnection("server=" + label12.Text + " ; database=" + label9.Text + " ; user id = sa; password='Valley';"))
                        {
                            using (SqlCommand cmd = new SqlCommand("updatetemporal", cn))
                            {
                                cmd.CommandType = CommandType.StoredProcedure;
                                cmd.Parameters.Add("@id", SqlDbType.Int).Value = int.Parse(label46.Text); //int.Parse(label13.Text);
                                cmd.Parameters.Add("@precio", SqlDbType.Decimal).Value = precio;
                                cmd.Parameters.Add("@ingred", SqlDbType.Int).Value = ingrediente;
                                cmd.Parameters.Add("@cantidad", SqlDbType.Decimal).Value = total;
                                //MessageBox.Show("Total "+total);
                                cmd.Parameters.Add("@estado", SqlDbType.Int).Value = label17.Text;
                                cmd.Parameters.Add("@estadoesperado", SqlDbType.Int).Value = int.Parse(label26.Text);
                                cmd.Parameters.Add("@opcion", SqlDbType.Int).Value = 5;
                                cn.Open();
                                cmd.ExecuteNonQuery();
                                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                                DataSet ds = new DataSet();
                                adapter.Fill(ds);
                                //dataGridView7.DataSource = ds.Tables[0];
                                //label17.Text = dataGridView1.Rows.Count.ToString();
                                //posicion(3);
                            }
                        }
                    //}
                   // catch { MessageBox.Show("Ha sucedido un error", "Cola pedidos", MessageBoxButtons.OK, MessageBoxIcon.Error); }







                }
                
            }
            label46.Text = "0";
            label3.Text = "0";
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            retornarinventario();
        }
    }
}
