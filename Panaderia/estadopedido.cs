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

        int estados;

        private void restaurar()
        {
            pictureBox1.ImageLocation = "resources\\enviadoi.png";
            pictureBox3.ImageLocation = "resources\\recibidoi.png";
            pictureBox5.ImageLocation = "resources\\produccioni.png";
            pictureBox7.ImageLocation = "resources\\finalizadoi.png";
            pictureBox9.ImageLocation = "resources\\enviadosi.png";
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
                        cmd.Parameters.Add("@opcion", SqlDbType.Int).Value = 6;
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
            cargarpedidos();
            limpiar();
            allpedidos.Visible = true;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            cargarpedidos();
            limpiar();
            allpedidos.Visible = true;
        }

        private void pictureBox14_Click(object sender, EventArgs e)
        {
            cargarpedidos();
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            estados = int.Parse(dataGridView1.CurrentRow.Cells[4].Value.ToString());
            reviewestados();
            
        }

        private void reviewestados() {
            restaurar();
            if (estados == 1) {
                pictureBox1.ImageLocation = "resources\\enviado.png";
                limpiar();
                estado.Visible = true;
            }
            if (estados == 1007) {
                pictureBox1.ImageLocation = "resources\\enviado.png";
                pictureBox3.ImageLocation = "resources\\recibido.png";
                limpiar();
                estado.Visible = true;
            }
            if (estados == 1008) {
                pictureBox1.ImageLocation = "resources\\enviado.png";
                pictureBox3.ImageLocation = "resources\\recibido.png";
                pictureBox5.ImageLocation = "resources\\produccion.png";
                limpiar();
                estado.Visible = true;
            }
            if (estados == 1009) {
                pictureBox1.ImageLocation = "resources\\enviado.png";
                pictureBox3.ImageLocation = "resources\\recibido.png";
                pictureBox5.ImageLocation = "resources\\produccion.png";
                pictureBox7.ImageLocation = "resources\\finalizado.png";
                limpiar();
                estado.Visible = true;
            }
            if (estados == 1010) {
                pictureBox1.ImageLocation = "resources\\enviado.png";
                pictureBox3.ImageLocation = "resources\\recibido.png";
                pictureBox5.ImageLocation = "resources\\produccion.png";
                pictureBox7.ImageLocation = "resources\\finalizado.png";
                pictureBox9.ImageLocation = "resources\\enviados.png";
                limpiar();
                estado.Visible = true;
            }
            if (estados == 1006) {
                limpiar();
                fin.Visible = true;
                label18.Text = "Completado";
                label19.Text = "Su orden ha sido completada";
            }
            if (estados == 1003) {
                limpiar();
                fin.Visible = true;
                label18.Text = "Cancelado";
                label19.Text = "Su orden no ha podido ser procesada";
            }
        }
    }
}
