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
    public partial class estadopedido : Form
    {
        public estadopedido()
        {
            InitializeComponent();
        }

        private void estadopedido_Load(object sender, EventArgs e)
        {
            cargarpedidos();
        }


        private void cargarpedidos()
        {
            try
            {
                using (SqlConnection cn = new SqlConnection("server=" + label26.Text + " ; database=" + label25.Text + " ; user id = sa; password='Valley';"))
                {
                    using (SqlCommand cmd = new SqlCommand("ppedido", cn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@id", SqlDbType.Int).Value = 1; //int.Parse(label13.Text);
                        cmd.Parameters.Add("@cod", SqlDbType.VarChar).Value = textBox8.Text;
                        cmd.Parameters.Add("@sucursal", SqlDbType.Int).Value = 1;
                        cmd.Parameters.Add("@estado", SqlDbType.VarChar).Value = 1;
                        cmd.Parameters.Add("@opcion", SqlDbType.Int).Value = 4;
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
        private void limpiar() {
            allpedidos.Visible = false;
            estado.Visible = false;
            fin.Visible = false;
        }

        private void button15_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            limpiar();
            estado.Visible = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            limpiar();
            fin.Visible = true;
        }

        private void button19_Click(object sender, EventArgs e)
        {
            limpiar();
            allpedidos.Visible = true;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            limpiar();
            allpedidos.Visible = true;
        }

        private void pictureBox14_Click(object sender, EventArgs e)
        {
            cargarpedidos();
        }
    }
}
