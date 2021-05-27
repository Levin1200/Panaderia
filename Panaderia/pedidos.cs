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
    public partial class pedidos : Form
    {
        public pedidos()
        {
            InitializeComponent();
        }

        private void cargarpanes()
        {
            try
            {
                using (SqlConnection cn = new SqlConnection("server=" + label12.Text + " ; database=" + label9.Text + " ; user id = sa; password='Valley';"))
                {
                    using (SqlCommand cmd = new SqlCommand("pdescuentos", cn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@iingresos", SqlDbType.VarChar).Value = textBox5.Text;
                        cmd.Parameters.Add("@iestado", SqlDbType.Int).Value = 1;
                        cmd.Parameters.Add("@ivalor", SqlDbType.Decimal).Value = 1;
                        cmd.Parameters.Add("@opcion", SqlDbType.Int).Value = 3;
                        cmd.Parameters.Add("@iid", SqlDbType.Int).Value = 1;
                        cn.Open();
                        cmd.ExecuteNonQuery();
                        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                        DataSet ds = new DataSet();
                        adapter.Fill(ds);
                        dataGridView2.DataSource = ds.Tables[0];
                        label17.Text = dataGridView1.Rows.Count.ToString();
                        //posicion(3);
                    }
                }
            }
            catch { MessageBox.Show("Ha sucedido un error", "Descuentos", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }
        private void button15_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void limpiar() {
            textBox19.Text = "";
            textBox2.Text = "";
        }
        private void pictureBox6_Click(object sender, EventArgs e)
        {
            limpiar();
        }

        private void button19_Click(object sender, EventArgs e)
        {
            realizarpedido.Visible = false;
            panpedido.Visible = true;
            cargarpanes();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            limpiar();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            limpiar();
            panpedido.Visible = false;
            realizarpedido.Visible = true;
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            cargarpanes();
        }
    }
}
