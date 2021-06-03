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
    public partial class compras : Form
    {
        public compras()
        {
            InitializeComponent();
        }

        private void button19_Click(object sender, EventArgs e)
        {
            if (textBox19.Text == "" || textBox2.Text == "" || textBox9.Text == "")
            {
                MessageBox.Show("Debe llenar todos los campos", "Compras", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {

                label30.Text = "#" + textBox19.Text;
                comprascodigo = textBox19.Text;
                realizarcompras.Visible = false;
                compraIng.Visible = true;
                cargaringredientes();
            }
        }

        private void button15_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void compras_Load(object sender, EventArgs e)
        {
            cargarproveedor();
        }
        string comprascodigo;
        private void limpiar()
        {
            panel2.Visible = false;
            textBox5.Text = "";
            textBox19.Text = "";
            textBox2.Text = "";
            button3.Enabled = false;
            label30.Text = "";
            label25.Text = "n/a";
            label28.Text = "Seleccione un ingrediente";
            textBox6.Text = "";
            textBox10.Text = "";
            textBox9.Text = "";
        }

        private void liberar()
        {
            realizarcompras.Visible = false;
            compraIng.Visible = false;
            allpedidos.Visible = false;
        }
        private void finalizarcompra(object sender, EventArgs e)
        {
            int error = 0;
            if (dataGridView3.Rows.Count <= 0)
            {
                MessageBox.Show("No se puede generar una compra vacia", "Compra", MessageBoxButtons.OK, MessageBoxIcon.Information);
                error = 1;
            }
            else
            {
                //Comopra

                try
                {
                    using (SqlConnection cn = new SqlConnection("server=" + label12.Text + " ; database=" + label9.Text + " ; user id = sa; password='Valley';"))
                    {
                        using (SqlCommand cmd = new SqlCommand("pcompra_encabezado", cn))
                        {
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.Parameters.Add("@id", SqlDbType.Int).Value = 1; //int.Parse(label25.Text);
                            cmd.Parameters.Add("@cod_fac", SqlDbType.VarChar).Value = comprascodigo;
                            cmd.Parameters.Add("@prov", SqlDbType.Int).Value = int.Parse(textBox2.Text);
                            cmd.Parameters.Add("@usuario", SqlDbType.Int).Value = int.Parse(label7.Text);
                            cmd.Parameters.Add("@tpago", SqlDbType.Int).Value = int.Parse(textBox9.Text);
                            cmd.Parameters.Add("@total", SqlDbType.Decimal).Value = 1;
                            cmd.Parameters.Add("@estado", SqlDbType.Int).Value = 1;
                            cmd.Parameters.Add("@opcion", SqlDbType.Int).Value = 1;
                            cn.Open();
                            cmd.ExecuteNonQuery();
                            MessageBox.Show("Se ha agregado una nueva Compra", "Compra", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            //cargarusuarios();

                        }
                    }
                }
                catch
                {
                    MessageBox.Show("Ha sucedido un error al insertar", "Compras Encabezado", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    error = 1;
                }
                //Detalles de la compra

                for (int i = 0; i < dataGridView3.Rows.Count; i++)
                {
                    int id = int.Parse(dataGridView3.Rows[i].Cells[1].Value.ToString());
                    int cantidad = int.Parse(dataGridView3.Rows[i].Cells[3].Value.ToString());
                    double precio = double.Parse(dataGridView3.Rows[i].Cells[4].Value.ToString());
                    try
                    {
                        using (SqlConnection cn = new SqlConnection("server=" + label12.Text + " ; database=" + label9.Text + " ; user id = sa; password='Valley';"))
                        {
                            using (SqlCommand cmd = new SqlCommand("pcompra_detalle", cn))
                            {
                                cmd.CommandType = CommandType.StoredProcedure;
                                cmd.Parameters.Add("@id", SqlDbType.Int).Value = id; //int.Parse(label13.Text);
                                cmd.Parameters.Add("@cod", SqlDbType.VarChar).Value = comprascodigo;
                                cmd.Parameters.Add("@cantidad", SqlDbType.Int).Value = cantidad;
                                cmd.Parameters.Add("@precio", SqlDbType.Decimal).Value = precio;
                                cmd.Parameters.Add("@iid", SqlDbType.Int).Value = 1;
                                cmd.Parameters.Add("@bodega", SqlDbType.Int).Value = 1;
                                cmd.Parameters.Add("@opcion", SqlDbType.Int).Value = 1;

                                cn.Open();
                                cmd.ExecuteNonQuery();
                                //MessageBox.Show("Se ha agregado una nuevo Pedido", "Detalle de Pedido", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                //cargarusuarios();
                                limpiar();
                            }
                        }
                    }
                    catch
                    {
                        MessageBox.Show("Ha sucedido un error al insertar", "Compras Detalle", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        error = 1;
                    }
                }
                if (error == 0)
                {
                    button4_Click(sender, e);
                }
                else
                {

                }


            }
        }

        private void cargaringredientes()
        {
            try
            {
                using (SqlConnection cn = new SqlConnection("server=" + label12.Text + " ; database=" + label9.Text + " ; user id = sa; password='Valley';"))
                {
                    using (SqlCommand cmd = new SqlCommand("proingredientes", cn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@icod", SqlDbType.VarChar).Value = "1";
                        cmd.Parameters.Add("@inom", SqlDbType.VarChar).Value = textBox1.Text;
                        cmd.Parameters.Add("@imedida", SqlDbType.VarChar).Value = "1";
                        cmd.Parameters.Add("@iestado", SqlDbType.Int).Value = 1;
                        cmd.Parameters.Add("@opcion", SqlDbType.Int).Value = 3;
                        cmd.Parameters.Add("@iid", SqlDbType.Int).Value = 1;

                        cn.Open();
                        cmd.ExecuteNonQuery();
                        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                        DataSet ds = new DataSet();
                        adapter.Fill(ds);
                        dataGridView2.DataSource = ds.Tables[0];

                    }
                }
            }
            catch { MessageBox.Show("Ha sucedido un error", "Ingredientes", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }
        private void cargarproveedor()
        {
            try
            {
                using (SqlConnection cn = new SqlConnection("server=" + label12.Text + " ; database=" + label9.Text + " ; user id = sa; password='Valley';"))
                {
                    using (SqlCommand cmd = new SqlCommand("pproveedor", cn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@nombrep", SqlDbType.VarChar).Value = textBox1.Text;
                        cmd.Parameters.Add("@nitp", SqlDbType.VarChar).Value = "1";
                        cmd.Parameters.Add("@direccionp", SqlDbType.VarChar).Value = "1";
                        cmd.Parameters.Add("@codigop", SqlDbType.VarChar).Value = "1";
                        cmd.Parameters.Add("@opcion", SqlDbType.Int).Value = 3;
                        cmd.Parameters.Add("@iid", SqlDbType.Int).Value = 1;
                        cmd.Parameters.Add("@numerot", SqlDbType.VarChar).Value = "1";
                        cmd.Parameters.Add("@compañiat", SqlDbType.VarChar).Value = "1";
                        cmd.Parameters.Add("@estadot", SqlDbType.Int).Value = 1;

                        cn.Open();
                        cmd.ExecuteNonQuery();
                        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                        DataSet ds = new DataSet();
                        adapter.Fill(ds);
                        dataGridView4.DataSource = ds.Tables[0];
                    }
                }
            }
            catch { MessageBox.Show("Ha sucedido un error", "Proveedor", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private void posicion(int pos)
        {
            try
            {
                if (dataGridView1.Rows.Count <= 0)
                {
                    pictureBox9.Size = new Size(0, 10);
                    pictureBox10.Size = new Size(0, 10);
                }
                else
                {
                    //texto2.Text = "" + dataGridView1.CurrentRow.Cells[2].Value;
                    string estado = "";
                    int total = 0;
                    for (int i = 0; i < dataGridView1.Rows.Count; i++) { estado = "" + dataGridView1.Rows[i].Cells[pos].Value.ToString(); if (estado == "1") { total += 1; } }
                    double tt = (total * 100) / int.Parse(dataGridView1.Rows.Count.ToString());
                    double ttt = tt * 1.5;
                    int t4 = int.Parse(Math.Round(ttt, MidpointRounding.AwayFromZero).ToString());
                    pictureBox9.Size = new Size(t4, 10);
                    pictureBox10.Size = new Size(150 - t4, 10);
                }
            }
            catch { }

        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            limpiar();
        }

        private void dataGridView3_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView3.CurrentRow == null) { }
            else
            {
                dataGridView3.Rows.RemoveAt(dataGridView3.CurrentRow.Index);
            }
        }

        private void dataGridView3_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Back)
            {
                eliminarcelda();
            }
        }

        private void textBox5_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                button19_Click(sender, e);
                e.Handled = true;
            }
        }
        private void eliminarcelda()
        {
            if (dataGridView3.CurrentRow == null) { }
            else
            {
                dataGridView3.Rows.RemoveAt(dataGridView3.CurrentRow.Index);
            }
        }
        private void textBox8_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                cargaringredientes();
                e.Handled = true;
            }
        }

        private void pictureBox14_Click(object sender, EventArgs e)
        {
            
        }

        private void pictureBox12_Click(object sender, EventArgs e)
        {
            cargarproveedor();
        }
        int detcompras;
        private void cargardetcompras()
        {
            try
            {
                using (SqlConnection cn = new SqlConnection("server=" + label12.Text + " ; database=" + label9.Text + " ; user id = sa; password='Valley';"))
                {
                    using (SqlCommand cmd = new SqlCommand("pcompra_detalle", cn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@id", SqlDbType.Int).Value = 1; //int.Parse(label13.Text);
                        cmd.Parameters.Add("@cod", SqlDbType.VarChar).Value = "1";
                        cmd.Parameters.Add("@cantidad", SqlDbType.Int).Value = 1;
                        cmd.Parameters.Add("@precio", SqlDbType.Decimal).Value = 1;
                        cmd.Parameters.Add("@iid", SqlDbType.Int).Value = detcompras;
                        cmd.Parameters.Add("@bodega", SqlDbType.Int).Value = 1;
                        cmd.Parameters.Add("@opcion", SqlDbType.Int).Value = 3;
                        cn.Open();
                        cmd.ExecuteNonQuery();
                        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                        DataSet ds = new DataSet();
                        adapter.Fill(ds);
                        dataGridView5.DataSource = ds.Tables[0];
                    }
                }
            }
            catch { MessageBox.Show("Ha sucedido un error", "Detalle Compras", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private void cargarcompras()
        {
            try
            {
                using (SqlConnection cn = new SqlConnection("server=" + label12.Text + " ; database=" + label9.Text + " ; user id = sa; password='Valley';"))
                {
                    using (SqlCommand cmd = new SqlCommand("pcompra_encabezado", cn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@id", SqlDbType.Int).Value = 1; //int.Parse(label13.Text);
                        cmd.Parameters.Add("@cod_fac", SqlDbType.VarChar).Value = textBox8.Text;
                        cmd.Parameters.Add("@prov", SqlDbType.Int).Value = 1;
                        cmd.Parameters.Add("@usuario", SqlDbType.Int).Value = int.Parse(label7.Text);
                        cmd.Parameters.Add("@tpago", SqlDbType.Int).Value = 1;
                        cmd.Parameters.Add("@total", SqlDbType.Decimal).Value = 1;
                        cmd.Parameters.Add("@estado", SqlDbType.VarChar).Value = 1;
                        cmd.Parameters.Add("@opcion", SqlDbType.Int).Value = 3;
                        cn.Open();
                        cmd.ExecuteNonQuery();
                        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                        DataSet ds = new DataSet();
                        adapter.Fill(ds);
                        dataGridView1.DataSource = ds.Tables[0];
                        label17.Text = dataGridView1.Rows.Count.ToString();
                        posicion(4);
                    }
                }
            }
            catch { MessageBox.Show("Ha sucedido un error", "Compras", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }
        private void ocultar()
        {
            realizarcompras.Visible = false;
            allpedidos.Visible = false;
            panel2.Visible = false;
        }


        private void button5_Click(object sender, EventArgs e)
        {
            button4_Click(sender, e);
            ocultar();
            allpedidos.Visible = true;
            cargarcompras();
            dataGridView5.DataSource = null;
            panel2.Visible = true;
            label8.Text = "Todas las Compras";
            dataGridView1.AutoResizeColumns();
            dataGridView5.AutoResizeColumns();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            button4_Click(sender, e);
            ocultar();
            realizarcompras.Visible = true;
            panel2.Visible = true;
            label8.Text = "Compras";
        }

        private void button9_Click(object sender, EventArgs e)
        {
            if (textBox6.Text == "" || label25.Text == "n/a" || label28.Text == "Seleccione un Ingrediente")
            {
                MessageBox.Show("Haga doble clic en un Ingrediente, antes", "Compras", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                try
                {
                    int cantidad = int.Parse(textBox6.Text);
                    double precio = double.Parse(textBox10.Text);
                    double total = cantidad * precio;
                    dataGridView3.Rows.Add(comprascodigo, label25.Text, label28.Text, "" + cantidad, "" + precio, "" + total);
                }
                catch
                {
                    MessageBox.Show("Error en la conversion", "Compras", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            label25.Text = "n/a";
            label28.Text = "Seleccione un Ingrediente";
            textBox6.Text = "";
            textBox10.Text = "";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            finalizarcompra(sender, e);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            limpiar();
            compraIng.Visible = false;
            realizarcompras.Visible = true;
            dataGridView3.Rows.Clear();
            panel2.Visible = true;
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            cargaringredientes();
        }

        private void dataGridView2_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            button3.Enabled = true;
            label25.Text = "" + dataGridView2.CurrentRow.Cells[0].Value;
            label28.Text = "" + dataGridView2.CurrentRow.Cells[2].Value;
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            detcompras = int.Parse(dataGridView1.CurrentRow.Cells[0].Value.ToString());
            cargardetcompras();
        }

        private void dataGridView4_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox2.Text = "" + dataGridView4.CurrentRow.Cells[0].Value;
        }
    }
}
