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


        int epedidocod;
        int detpedidos;
        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            label3.Text = ""+dataGridView1.CurrentRow.Cells[0].Value;
            detpedidos = int.Parse(dataGridView1.CurrentRow.Cells[0].Value.ToString());
            cargardetpedidos();
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
                            cmd.Parameters.Add("@id", SqlDbType.Int).Value = epedidocod; //int.Parse(label13.Text);
                            cmd.Parameters.Add("@cod", SqlDbType.VarChar).Value = "1";
                            cmd.Parameters.Add("@sucursal", SqlDbType.Int).Value = 1;
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
            epedidocod = int.Parse(label3.Text);
            estados = int.Parse(label14.Text);
            agregarpedido();
            label3.Text = "0";
            dataGridView5.DataSource = null;
            dataGridView2.DataSource = null;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            epedidocod = int.Parse(label3.Text);
            estados = int.Parse(label17.Text);
            agregarpedido();
            label3.Text = "0";
            dataGridView5.DataSource = null;
            dataGridView2.DataSource = null;
        }

        private void button15_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
