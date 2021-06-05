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
    public partial class facturarcompras : Form
    {
        public facturarcompras()
        {
            InitializeComponent();
        }

        private void facturarcompras_Load(object sender, EventArgs e)
        {
            cargarcompras();
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
                        //label17.Text = dataGridView1.Rows.Count.ToString();
                        //posicion(4);
                    }
                }
            }
            catch { MessageBox.Show("Ha sucedido un error", "Compras", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

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
        int detcompras;
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            detcompras = int.Parse(dataGridView1.CurrentRow.Cells[0].Value.ToString());
            cargardetcompras();
            label18.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            label19.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            label26.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            label35.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
            allpedidos.Visible = false;
            factura.Visible = true;
        }
    }
}
