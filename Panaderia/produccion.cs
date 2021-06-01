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
    public partial class produccion : Form
    {
        public produccion()
        {
            InitializeComponent();
        }

        private void produccion_Load(object sender, EventArgs e)
        {
            cargarpedidos();
        }

        int detpedidos;

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
                        cmd.Parameters.Add("@estado", SqlDbType.VarChar).Value = 1;
                        cmd.Parameters.Add("@opcion", SqlDbType.Int).Value = 5;
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
                        cmd.Parameters.Add("@estado", SqlDbType.VarChar).Value = int.Parse(label3.Text);
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

        private void ocultar()
        {

            allpedidos.Visible = false;
            produccionpedido.Visible = false;
            automatizado.Visible = false;
            manual.Visible = false;
            autotiempo.Visible = false;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            ocultar();
           allpedidos.Visible = true;
            cargarpedidos();
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            detpedidos = int.Parse(dataGridView1.CurrentRow.Cells[0].Value.ToString());
            cargardetpedidos();
            ocultar();
            produccionpedido.Visible = true;
        }

        private void man_Click(object sender, EventArgs e)
        {
            auto.Checked = false;
        }

        private void auto_Click(object sender, EventArgs e)
        {
            man.Checked = false;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (auto.Checked == true)
            {
                ocultar();
                automatizado.Visible = true;
            }
            else if (man.Checked == true) {
                ocultar();
                manual.Visible = true;
            }
        }

        private void button15_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true) {
                ocultar();
                autotiempo.Visible = true;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ocultar();
            allpedidos.Visible = true;
            cargarpedidos();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            ocultar();
            allpedidos.Visible = true;
            cargarpedidos();
        }

        private void colaproduccion(object sender, EventArgs e)
        {
            int error = 0;
            if (dataGridView5.Rows.Count <= 0)
            {
                MessageBox.Show("No puede encolar pedidos vacios", "Produccion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                error = 1;
            }
            else
            {
                //Produccion

                try
                {
                    using (SqlConnection cn = new SqlConnection("server=" + label12.Text + " ; database=" + label9.Text + " ; user id = sa; password='Valley';"))
                    {
                        using (SqlCommand cmd = new SqlCommand("ppedido", cn))
                        {
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.Parameters.Add("@id", SqlDbType.Int).Value = 1; //int.Parse(label13.Text);
                            cmd.Parameters.Add("@cod", SqlDbType.VarChar).Value = detpedidos;
                            cmd.Parameters.Add("@sucursal", SqlDbType.Int).Value = 1;
                            cmd.Parameters.Add("@estado", SqlDbType.VarChar).Value = 1;
                            cmd.Parameters.Add("@opcion", SqlDbType.Int).Value = 1;

                            cn.Open();
                            cmd.ExecuteNonQuery();
                            MessageBox.Show("Produccion puesta en cola", "Produccion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            //cargarusuarios();
                            ocultar();
                        }
                    }
                }
                catch
                {
                    MessageBox.Show("Ha sucedido un error al insertar", "Produccion", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    error = 1;
                }
                //Detalles del produccion

                for (int i = 0; i < dataGridView5.Rows.Count; i++)
                {
                    int panid = int.Parse(dataGridView5.Rows[i].Cells[1].Value.ToString());
                    int cantidad = int.Parse(dataGridView5.Rows[i].Cells[3].Value.ToString());
                    try
                    {
                        using (SqlConnection cn = new SqlConnection("server=" + label12.Text + " ; database=" + label9.Text + " ; user id = sa; password='Valley';"))
                        {
                            using (SqlCommand cmd = new SqlCommand("pdetpedido", cn))
                            {
                                cmd.CommandType = CommandType.StoredProcedure;
                                cmd.Parameters.Add("@id", SqlDbType.Int).Value = panid; //int.Parse(label13.Text);
                                cmd.Parameters.Add("@cod", SqlDbType.VarChar).Value = detpedidos;
                                cmd.Parameters.Add("@cantidad", SqlDbType.Int).Value = cantidad;
                                cmd.Parameters.Add("@estado", SqlDbType.VarChar).Value = 1;
                                cmd.Parameters.Add("@opcion", SqlDbType.Int).Value = 1;

                                cn.Open();
                                cmd.ExecuteNonQuery();
                                //MessageBox.Show("Se ha agregado una nuevo Pedido", "Detalle de Pedido", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                //cargarusuarios();
                                ocultar();
                            }
                        }
                    }
                    catch
                    {
                        MessageBox.Show("Ha sucedido un error al insertar", "Produccion", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        error = 1;
                    }
                }
                if (error == 0)
                {
                    //button4_Click(sender, e);
                }
                else
                {

                }


            }
        }
        private void button5_Click(object sender, EventArgs e)
        {

        }
    }
}
