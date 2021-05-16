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
using System.Drawing.Drawing2D;

namespace Panaderia
{
    public partial class bancos : Form
    {
        public bancos()
        {
            InitializeComponent();
        }

        private void limpiar() {
            banconombre.Text = "";
            texto2.Text = "";
            texto2.Enabled = false;
            label13.Text = "0";
            button2.Text = "Agregar";

        }
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            if (label13.Text == "0")
            {
                if (banconombre.Text == "" || texto2.Text == "") { MessageBox.Show("Debe llenar todos los campos", "Bancos", MessageBoxButtons.OK, MessageBoxIcon.Warning); }
                else
                {
                    try
                    {
                        using (SqlConnection cn = new SqlConnection("server=LEVINE-PC ; database=panaderia ; integrated security = true"))
                        {
                            using (SqlCommand cmd = new SqlCommand("Bancos", cn))
                            {
                                cmd.CommandType = CommandType.StoredProcedure;
                                cmd.Parameters.Add("@bbanco", SqlDbType.VarChar).Value = banconombre.Text;
                                cmd.Parameters.Add("@bestado", SqlDbType.Int).Value = 1;
                                cmd.Parameters.Add("@opcion", SqlDbType.Int).Value = 1;
                                cmd.Parameters.Add("@bid", SqlDbType.Int).Value = 1;
                                cn.Open();
                                cmd.ExecuteNonQuery();
                                MessageBox.Show("Se ha agregado un nuevo banco","Bancos",MessageBoxButtons.OK,MessageBoxIcon.Information);
                                cargarbancos();
                                limpiar();
                            }
                        }
                    }
                    catch
                    {
                        MessageBox.Show("Ha sucedido un error", "Bancos", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else {
                if (banconombre.Text == "" || texto2.Text == "") { MessageBox.Show("Debe llenar todos los campos", "Bancos", MessageBoxButtons.OK, MessageBoxIcon.Warning); }
                else
                {
                    try
                    {
                        using (SqlConnection cn = new SqlConnection("server=LEVINE-PC ; database=panaderia ; integrated security = true"))
                        {
                            using (SqlCommand cmd = new SqlCommand("Bancos", cn))
                            {
                                cmd.CommandType = CommandType.StoredProcedure;
                                cmd.Parameters.Add("@bbanco", SqlDbType.VarChar).Value = banconombre.Text;
                                cmd.Parameters.Add("@bestado", SqlDbType.Int).Value = int.Parse(texto2.Text);
                                cmd.Parameters.Add("@opcion", SqlDbType.Int).Value = 2;
                                cmd.Parameters.Add("@bid", SqlDbType.Int).Value = int.Parse(label13.Text);
                                cn.Open();
                                cmd.ExecuteNonQuery();
                                MessageBox.Show("Banco actualizado", "Bancos", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                button2.Text = "Agregar";
                                cargarbancos();
                                limpiar();
                            }
                        }
                    }
                    catch
                    {
                        MessageBox.Show("Ha sucedido un error","Bancos",MessageBoxButtons.OK,MessageBoxIcon.Error);
                    }
                }
            }
           
           
        }

        private void button15_Click(object sender, EventArgs e)
        {

        }

        private void button15_Paint(object sender, PaintEventArgs e)
        {
           
        }

        private void cargarbancos() {
            try
            {
                using (SqlConnection cn = new SqlConnection("server=" + label12.Text + " ; database=" + label9.Text + " ; integrated security = true"))
                {
                    using (SqlCommand cmd = new SqlCommand("Bancos", cn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@bbanco", SqlDbType.VarChar).Value = textBox1.Text;
                        cmd.Parameters.Add("@bestado", SqlDbType.Int).Value = 1;
                        cmd.Parameters.Add("@opcion", SqlDbType.Int).Value = 3;
                        cmd.Parameters.Add("@bid", SqlDbType.Int).Value = 1;
                        cn.Open();
                        cmd.ExecuteNonQuery();
                        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                        DataSet ds = new DataSet();
                        adapter.Fill(ds);
                        dataGridView1.DataSource = ds.Tables[0];
                        label17.Text = dataGridView1.Rows.Count.ToString();
                        posicion(2);
                    }
                }
            }
            catch {MessageBox.Show("Ha sucedido un error", "Bancos", MessageBoxButtons.OK, MessageBoxIcon.Error);}
        }

        private void posicion(int pos) {
            try {
                if (dataGridView1.Rows.Count <= 0)
                {
                    pictureBox9.Size = new Size(0, 10);
                    pictureBox10.Size = new Size(0, 10);
                }
                else
                {
                    texto2.Text = "" + dataGridView1.CurrentRow.Cells[2].Value;
                    string estado = "";
                    int total = 0;
                    for (int i = 0; i < dataGridView1.Rows.Count; i++) { estado = "" + dataGridView1.Rows[i].Cells[pos].Value.ToString(); if (estado == "1") { total += 1; } }
                    double tt = (total * 100) / int.Parse(dataGridView1.Rows.Count.ToString());
                    double ttt = tt * 1.5;
                    int t4 = int.Parse(Math.Round(ttt, MidpointRounding.AwayFromZero).ToString());
                    pictureBox9.Size = new Size(t4, 10);
                    pictureBox10.Size = new Size(150 - t4, 10);
                }
            } catch { }
          
        }

        private void bancos_Load(object sender, EventArgs e)
        {
            cargarbancos();
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try {
                button2.Text = "Actualizar";
                banconombre.Text = "" + dataGridView1.CurrentRow.Cells[1].Value;
                texto2.Text = "" + dataGridView1.CurrentRow.Cells[2].Value;
                texto2.Enabled = true;
                label13.Text = "" + dataGridView1.CurrentRow.Cells[0].Value;
            } catch { }
    }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            cargarbancos();
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            limpiar();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            panel3.Size = new Size(561, 295);
            panel3.Location = new Point(189, 281);
            dataGridView1.Size= new Size(527, 263);
        }
    }
}
