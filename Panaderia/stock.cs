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
    public partial class stock : Form
    {
        public stock()
        {
            InitializeComponent();
        }

        private void cargarstock()
        {
            try
            {
                using (SqlConnection cn = new SqlConnection("server=" + label12.Text + " ; database=" + label9.Text + " ; user id = sa; password='Valley';"))
                {
                    using (SqlCommand cmd = new SqlCommand("pstock", cn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@id", SqlDbType.VarChar).Value = "1";
                        cmd.Parameters.Add("@cantidad", SqlDbType.VarChar).Value = textBox8.Text;
                        cmd.Parameters.Add("@bodega", SqlDbType.VarChar).Value = "1";
                        cmd.Parameters.Add("@sucursal", SqlDbType.Int).Value = int.Parse(label60.Text);
                        cmd.Parameters.Add("@opcion", SqlDbType.Int).Value = 2;
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
        private void pictureBox14_Click(object sender, EventArgs e)
        {
            cargarstock();
        }

        private void button15_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void stock_Load(object sender, EventArgs e)
        {
            cargarstock();
        }
    }
}
