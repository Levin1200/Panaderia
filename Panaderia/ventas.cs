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
    public partial class ventas : Form
    {
        public ventas()
        {
            InitializeComponent();
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

        private void cargarventa()
        {
            try
            {
                using (SqlConnection cn = new SqlConnection("server=" + label12.Text + " ; database=" + label9.Text + " ; user id = sa; password='Valley';"))
                {
                    using (SqlCommand cmd = new SqlCommand("proventas", cn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@id", SqlDbType.Int).Value = 1; //int.Parse(label13.Text);
                        cmd.Parameters.Add("@codfact", SqlDbType.VarChar).Value = textBox8.Text;
                        cmd.Parameters.Add("@idcli", SqlDbType.Int).Value = 1;
                        cmd.Parameters.Add("@tpago", SqlDbType.Int).Value = 1;
                        cmd.Parameters.Add("@idusu", SqlDbType.Int).Value = int.Parse(label7.Text);
                        cmd.Parameters.Add("@tot", SqlDbType.Decimal).Value = 1;
                        cmd.Parameters.Add("@idsucur", SqlDbType.Int).Value = int.Parse(label22.Text) ;
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

        private void pictureBox14_Click(object sender, EventArgs e)
        {
            cargarventa();
            dataGridView5.DataSource = null;
        }

        private void limpiar()
        {
            panel2.Visible = false;
            textBox5.Text = "";
            textBox19.Text = "";
            textBox2.Text = "";
            textBox9.Text = "";
            button3.Enabled = false;
            label30.Text = "";
            label25.Text = "n/a";
            label25.Text = "n/a";
            label28.Text = "Seleccione los panes para la venta";
            textBox6.Text = "";
            textBox10.Text = "";

        }

        private void liberar()
        {
            realizarcompras.Visible = false;
            compraIng.Visible = false;
            allpedidos.Visible = false;
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            limpiar();
        }

        private void button19_Click(object sender, EventArgs e)
        {

            if (textBox19.Text == "" || textBox2.Text == "" || textBox9.Text == "" || textBox10.Text == "")
            {
                MessageBox.Show("Debe llenar todos los campos", "Compras", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {

                label30.Text = "#" + textBox19.Text;
                codigoventas = textBox19.Text;
                realizarcompras.Visible = false;
                compraIng.Visible = true;
                cargarpan();
            }
        }

        private void pictureBox12_Click(object sender, EventArgs e)
        {
            cargarclientes();
        }

        private void cargarclientes()
        {
            try
            {
                using (SqlConnection cn = new SqlConnection("server=" + label12.Text + " ; database=" + label9.Text + " ; user id = sa; password='Valley';"))
                {
                    using (SqlCommand cmd = new SqlCommand("proclientes", cn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@ccod", SqlDbType.VarChar).Value = "1";
                        cmd.Parameters.Add("@cnom", SqlDbType.VarChar).Value = textBox1.Text;
                        cmd.Parameters.Add("@cnit", SqlDbType.VarChar).Value = "1";
                        cmd.Parameters.Add("@ctel", SqlDbType.VarChar).Value = "1";
                        cmd.Parameters.Add("@cdir", SqlDbType.VarChar).Value = "1";
                        cmd.Parameters.Add("@ccred", SqlDbType.Decimal).Value = 1;
                        cmd.Parameters.Add("@cestado", SqlDbType.Int).Value = 1;
                        cmd.Parameters.Add("@opcion", SqlDbType.Int).Value = 6;
                        cmd.Parameters.Add("@cid", SqlDbType.Int).Value = 1;
                        cmd.Parameters.Add("@numerot", SqlDbType.VarChar).Value = "1";
                        cmd.Parameters.Add("@compañiat", SqlDbType.VarChar).Value = "1";
                        cmd.Parameters.Add("@estadot", SqlDbType.Int).Value = 1;
                        cmd.Parameters.Add("@apellidos", SqlDbType.VarChar).Value = textBox2.Text;

                        cn.Open();
                        cmd.ExecuteNonQuery();
                        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                        DataSet ds = new DataSet();
                        adapter.Fill(ds);
                        dataGridView4.DataSource = ds.Tables[0];
                        //label17.Text = dataGridView4.Rows.Count.ToString();
                        // posicion(8);
                    }
                }
            }
            catch { MessageBox.Show("Ha sucedido un error", "Proveedor", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private void button15_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cargarpan()
        {
            try
            {
                using (SqlConnection cn = new SqlConnection("server=" + label12.Text + " ; database=" + label9.Text + " ; user id = sa; password='Valley';"))
                {
                    using (SqlCommand cmd = new SqlCommand("propan", cn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@pcod", SqlDbType.Int).Value = 1;
                        cmd.Parameters.Add("@pnom", SqlDbType.VarChar).Value = textBox1.Text;
                        cmd.Parameters.Add("@pprecio", SqlDbType.Decimal).Value = 1;
                        cmd.Parameters.Add("@pestado", SqlDbType.Int).Value = 1;
                        cmd.Parameters.Add("@opcion", SqlDbType.Int).Value = 3;
                        cmd.Parameters.Add("@pid", SqlDbType.Int).Value = 1;
                        cn.Open();
                        cmd.ExecuteNonQuery();
                        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                        DataSet ds = new DataSet();
                        adapter.Fill(ds);
                        dataGridView2.DataSource = ds.Tables[0];
                        //label17.Text = dataGridView1.Rows.Count.ToString();

                    }
                }
            }
            catch { MessageBox.Show("Ha sucedido un error", "Ingredientes", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }
        private void dataGridView4_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox2.Text = "" + dataGridView4.CurrentRow.Cells[0].Value;
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            cargarpan();
        }

        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            button3.Enabled = true;
            label25.Text = "" + dataGridView2.CurrentRow.Cells[0].Value;
            label28.Text = "" + dataGridView2.CurrentRow.Cells[2].Value;
            label26.Text = "" + dataGridView2.CurrentRow.Cells[3].Value;
        }

        private void button9_Click(object sender, EventArgs e)
        {


            if (textBox6.Text == "" || label25.Text == "n/a" || label25.Text == "n/a" || label28.Text == "Seleccione un pan para la venta")
            {
                MessageBox.Show("Haga doble clic en un Ingrediente, antes", "Compras", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                try
                {
                    int cantidad = int.Parse(textBox6.Text);
                    double precio = double.Parse(label26.Text);
                    double total = cantidad * precio;
                    dataGridView3.Rows.Add(codigoventas, label25.Text, label28.Text, "" + cantidad, "" + precio, "" + total);
                }
                catch
                {
                    MessageBox.Show("Error en la conversion", "Compras", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            label25.Text = "n/a";
            label25.Text = "n/a";
            label28.Text = "Seleccione un Pan para la venta";
            textBox6.Text = "";
        }

        private void button4_Click(object sender, EventArgs e)
        {
            limpiar();
            compraIng.Visible = false;
            realizarcompras.Visible = true;
            dataGridView3.Rows.Clear();
            panel2.Visible = true;
        }

        private void button3_Click(object sender, EventArgs e)
        {

            finalizarventa(sender, e);
        }
        string codigoventas;
        private void finalizarventa(object sender, EventArgs e)
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
                        using (SqlCommand cmd = new SqlCommand("proventas", cn))
                        {
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.Parameters.Add("@id", SqlDbType.Int).Value = 1; //int.Parse(label13.Text);
                            cmd.Parameters.Add("@codfact", SqlDbType.VarChar).Value = codigoventas;
                            cmd.Parameters.Add("@idcli", SqlDbType.Int).Value = int.Parse(textBox2.Text);
                            cmd.Parameters.Add("@tpago", SqlDbType.Int).Value = int.Parse(textBox9.Text);
                            cmd.Parameters.Add("@idusu", SqlDbType.Int).Value = int.Parse(label7.Text);
                            cmd.Parameters.Add("@tot", SqlDbType.Decimal).Value = 1;
                            cmd.Parameters.Add("@idsucur", SqlDbType.Int).Value = int.Parse(textBox10.Text);
                            cmd.Parameters.Add("@opcion", SqlDbType.Int).Value = 1;

                            cn.Open();
                            cmd.ExecuteNonQuery();
                            MessageBox.Show("Se ha agregado una nueva venta", "Ventas", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            //cargarusuarios();

                        }
                    }
                }
                catch
                {
                    MessageBox.Show("Ha sucedido un error al insertar", "Ventas", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    error = 1;
                }
                //Detalles de la venta

                for (int i = 0; i < dataGridView3.Rows.Count; i++)
                {
                    int panid = int.Parse(dataGridView3.Rows[i].Cells[1].Value.ToString());
                    int cantidad = int.Parse(dataGridView3.Rows[i].Cells[3].Value.ToString());
                    double precio = double.Parse(dataGridView3.Rows[i].Cells[4].Value.ToString());


                    try
                    {
                        using (SqlConnection cn = new SqlConnection("server=" + label12.Text + " ; database=" + label9.Text + " ; user id = sa; password='Valley';"))
                        {
                            using (SqlCommand cmd = new SqlCommand("prodetventas", cn))
                            {
                                cmd.CommandType = CommandType.StoredProcedure;
                                cmd.Parameters.Add("@id", SqlDbType.Int).Value = 1; //int.Parse(label13.Text);
                                cmd.Parameters.Add("@codfact", SqlDbType.VarChar).Value = codigoventas;
                                cmd.Parameters.Add("@idsucur", SqlDbType.Int).Value = 1;
                                cmd.Parameters.Add("@idpan", SqlDbType.Int).Value = panid;
                                cmd.Parameters.Add("@cantidad", SqlDbType.Int).Value = cantidad;
                                cmd.Parameters.Add("@precio", SqlDbType.Decimal).Value = precio;
                                cmd.Parameters.Add("@opcion", SqlDbType.Int).Value = 1;
                                cmd.Parameters.Add("@bodeg", SqlDbType.Int).Value = 1;

                                cn.Open();
                                cmd.ExecuteNonQuery();
                                MessageBox.Show("Se ha agregado una nuevo Pedido", "Detalle de Pedido", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                //cargarusuarios();
                                limpiar();
                            }
                        }
                    }
                    catch
                    {
                        MessageBox.Show("Ha sucedido un error al insertar", "Ventas", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        private void ventas_Load(object sender, EventArgs e)
        {
            cargarclientes();
        }

        private void ocultar()
        {
            realizarcompras.Visible = false;
            allpedidos.Visible = false;
            panel2.Visible = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            button4_Click(sender, e);
            ocultar();
            realizarcompras.Visible = true;
            panel2.Visible = true;
            label8.Text = "Ventas";
        }

        private void button5_Click(object sender, EventArgs e)
        {
            button4_Click(sender, e);
            ocultar();
            allpedidos.Visible = true;
            cargarventa();
            dataGridView5.DataSource = null;
            panel2.Visible = true;
            label8.Text = "Todas las Ventas";
            dataGridView1.AutoResizeColumns();
            dataGridView5.AutoResizeColumns();
        }

        private void cargardetventas()
        {
            try
            {
                using (SqlConnection cn = new SqlConnection("server=" + label12.Text + " ; database=" + label9.Text + " ; user id = sa; password='Valley';"))
                {
                    using (SqlCommand cmd = new SqlCommand("prodetventas", cn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@id", SqlDbType.Int).Value = detventas; //int.Parse(label13.Text);
                        cmd.Parameters.Add("@codfact", SqlDbType.VarChar).Value = "1";
                        cmd.Parameters.Add("@idsucur", SqlDbType.Int).Value = int.Parse(label22.Text);
                        cmd.Parameters.Add("@idpan", SqlDbType.Int).Value = 1;
                        cmd.Parameters.Add("@cantidad", SqlDbType.Int).Value = 1;
                        cmd.Parameters.Add("@precio", SqlDbType.Decimal).Value = 1;
                        cmd.Parameters.Add("@opcion", SqlDbType.Int).Value = 4;
                        cmd.Parameters.Add("@bodeg", SqlDbType.Int).Value = 1;

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
        int detventas;
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            detventas = int.Parse(dataGridView1.CurrentRow.Cells[0].Value.ToString());
            cargardetventas();
        }
    }
}
