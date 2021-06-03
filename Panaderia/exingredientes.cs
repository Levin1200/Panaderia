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
    public partial class exingredientes : Form
    {
        public exingredientes()
        {
            InitializeComponent();
        }

        private void button15_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void exingredientes_Load(object sender, EventArgs e)
        {
            cargaringredientes();
        }

        private void dataGridView1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {

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
                        cmd.Parameters.Add("@inom", SqlDbType.VarChar).Value = textBox8.Text;
                        cmd.Parameters.Add("@imedida", SqlDbType.VarChar).Value = "1";
                        cmd.Parameters.Add("@iestado", SqlDbType.Int).Value = 1;
                        cmd.Parameters.Add("@opcion", SqlDbType.Int).Value = 3;
                        cmd.Parameters.Add("@iid", SqlDbType.Int).Value = 1;

                        cn.Open();
                        cmd.ExecuteNonQuery();
                        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                        DataSet ds = new DataSet();
                        adapter.Fill(ds);
                        dataGridView1.DataSource = ds.Tables[0];

                    }
                }
            }
            catch { MessageBox.Show("Ha sucedido un error", "Ingredientes", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        int deting;
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
                        cmd.Parameters.Add("@estado", SqlDbType.VarChar).Value = 1;
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
            catch { MessageBox.Show("Ha sucedido un error", "Inventario", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }
        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            label3.Text = "" + dataGridView1.CurrentRow.Cells[0].Value;
            label2.Text = "" + dataGridView1.CurrentRow.Cells[2].Value;
            deting = int.Parse(dataGridView1.CurrentRow.Cells[0].Value.ToString());
            cargardetingredientes();
        }

        private void pictureBox14_Click(object sender, EventArgs e)
        {
            cargaringredientes();
        }
    }
}
