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
    public partial class recibirpedido : Form
    {
        public recibirpedido()
        {
            InitializeComponent();
        }

        private void recibirpedido_Load(object sender, EventArgs e)
        {
            cargarproduccion();
        }

        private void cargarproduccion()
        {
            try
            {
                using (SqlConnection cn = new SqlConnection("server=" + label12.Text + " ; database=" + label9.Text + " ; user id = sa; password='Valley';"))
                {
                    using (SqlCommand cmd = new SqlCommand("pproduccion", cn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@id", SqlDbType.Int).Value = int.Parse(label17.Text); //int.Parse(label13.Text);
                        cmd.Parameters.Add("@cod", SqlDbType.VarChar).Value = textBox8.Text;
                        cmd.Parameters.Add("@total", SqlDbType.Decimal).Value = 1;
                        cmd.Parameters.Add("@estado", SqlDbType.VarChar).Value = int.Parse(label13.Text);
                        cmd.Parameters.Add("@estados", SqlDbType.VarChar).Value = int.Parse(label13.Text);
                        cmd.Parameters.Add("@tipo", SqlDbType.Int).Value = 1;
                        cmd.Parameters.Add("@opcion", SqlDbType.Int).Value = 9;
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

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
           
            if (dataGridView1.RowCount>0)
            {
                label3.Text = "" + dataGridView1.CurrentRow.Cells[1].Value;

            }
        }


        private void finalizarproduccion()
        {

            if (label3.Text == "0")
            {
                MessageBox.Show("Seleccione una produccion antes", "Produccion", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                try
                {
                    using (SqlConnection cn = new SqlConnection("server=" + label12.Text + " ; database=" + label9.Text + " ; user id = sa; password='Valley';"))
                    {
                        using (SqlCommand cmd = new SqlCommand("pproduccion", cn))
                        {
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.Parameters.Add("@id", SqlDbType.Int).Value = int.Parse(label3.Text); //int.Parse(label13.Text);
                            cmd.Parameters.Add("@cod", SqlDbType.VarChar).Value = "1";
                            cmd.Parameters.Add("@total", SqlDbType.Decimal).Value = 1;
                            cmd.Parameters.Add("@estado", SqlDbType.VarChar).Value = int.Parse(label5.Text);
                            cmd.Parameters.Add("@estados", SqlDbType.VarChar).Value = int.Parse(label5.Text);
                            cmd.Parameters.Add("@tipo", SqlDbType.Int).Value = 3;
                            cmd.Parameters.Add("@opcion", SqlDbType.Int).Value = 5;

                            cn.Open();
                            cmd.ExecuteNonQuery();
                            MessageBox.Show("Produccion enviada a sucursal", "Produccion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            cargarproduccion();
                            label3.Text = "0";
                        }
                    }
                }
                catch
                {
                    MessageBox.Show("Ha sucedido un error al enviar", "Sucursal", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

        }

        private void button6_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("¿Desea recibir el pedido producido?", "Produccion", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                finalizarproduccion();
            }
            else
            {
                MessageBox.Show("Operacion cancelada", "Produccion", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void button15_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
