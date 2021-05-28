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
    public partial class proveedores : Form
    {
        public proveedores()
        {
            InitializeComponent();
        }

        private void proveedores_Load(object sender, EventArgs e)
        {
            cargarproveedor();
        }

        private void button15_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void posicion(int pos)
        {
            try
            {
                if (dataGridView1.Rows.Count <= 0)
                {
                    pictureBox9.Size = new Size(0, 10);
                    pictureBox10.Size = new Size(0, 10);
                }
                else
                {
                    //texto2.Text = "" + dataGridView1.CurrentRow.Cells[2].Value;
                    string estado = "";
                    int total = 0;
                    for (int i = 0; i < dataGridView1.Rows.Count; i++) { estado = "" + dataGridView1.Rows[i].Cells[pos].Value.ToString(); if (estado == "1") { total += 1; } }
                    double tt = (total * 100) / int.Parse(dataGridView1.Rows.Count.ToString());
                    double ttt = tt * 1.5;
                    int t4 = int.Parse(Math.Round(ttt, MidpointRounding.AwayFromZero).ToString());
                    pictureBox9.Size = new Size(t4, 10);
                    pictureBox10.Size = new Size(150 - t4, 10);
                }
            }
            catch { }

        }
        private void cargarproveedor()
        {
            try
            {
                using (SqlConnection cn = new SqlConnection("server=" + label12.Text + " ; database=" + label9.Text + " ; user id = sa; password='Valley';"))
                {
                    using (SqlCommand cmd = new SqlCommand("pproveedor", cn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@nombrep", SqlDbType.VarChar).Value = textBox1.Text;
                        cmd.Parameters.Add("@nitp", SqlDbType.VarChar).Value = "1";
                        cmd.Parameters.Add("@direccionp", SqlDbType.VarChar).Value = "1";
                        cmd.Parameters.Add("@codigop", SqlDbType.VarChar).Value = "1";
                        cmd.Parameters.Add("@opcion", SqlDbType.Int).Value = 3;
                        cmd.Parameters.Add("@iid", SqlDbType.Int).Value = 1;
                        cmd.Parameters.Add("@numerot", SqlDbType.VarChar).Value = "1";
                        cmd.Parameters.Add("@compañiat", SqlDbType.VarChar).Value = "1";
                        cmd.Parameters.Add("@estadot", SqlDbType.Int).Value = 1;

                        cn.Open();
                        cmd.ExecuteNonQuery();
                        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                        DataSet ds = new DataSet();
                        adapter.Fill(ds);
                        dataGridView1.DataSource = ds.Tables[0];
                        label17.Text = dataGridView1.Rows.Count.ToString();
                        posicion(5);
                    }
                }
            }
            catch { MessageBox.Show("Ha sucedido un error", "Proveedor", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }
        private void button19_Click(object sender, EventArgs e)
        {
            if (label13.Text == "0")
            {
                if (textBox19.Text == "" || textBox2.Text == "" || textBox3.Text == "" || textBox4.Text == "") { MessageBox.Show("Debe llenar todos los campos", "Proveedores", MessageBoxButtons.OK, MessageBoxIcon.Warning); }
                else
                {
                    try
                    {
                        using (SqlConnection cn = new SqlConnection("server=" + label12.Text + " ; database=" + label9.Text + " ; user id = sa; password='Valley';"))
                        {
                            using (SqlCommand cmd = new SqlCommand("pproveedor", cn))
                            {
                                cmd.CommandType = CommandType.StoredProcedure;
                                cmd.Parameters.Add("@nombrep", SqlDbType.VarChar).Value = textBox19.Text;
                                cmd.Parameters.Add("@nitp", SqlDbType.VarChar).Value = textBox2.Text;
                                cmd.Parameters.Add("@direccionp", SqlDbType.VarChar).Value = textBox3.Text;
                                cmd.Parameters.Add("@codigop", SqlDbType.VarChar).Value = textBox4.Text;
                                cmd.Parameters.Add("@opcion", SqlDbType.Int).Value = 1;
                                cmd.Parameters.Add("@iid", SqlDbType.Int).Value = 1;
                                cmd.Parameters.Add("@numerot", SqlDbType.VarChar).Value = "1";
                                cmd.Parameters.Add("@compañiat", SqlDbType.VarChar).Value = "1";
                                cmd.Parameters.Add("@estadot", SqlDbType.Int).Value = 1;

                                cn.Open();
                                cmd.ExecuteNonQuery();
                                MessageBox.Show("Se ha agregado una nuevo Proveedor", "Proveedores", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                cargarproveedor();
                                limpiar();
                            }
                        }
                    }
                    catch
                    {
                        MessageBox.Show("Ha sucedido un error al insertar", "Proveedores", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                if (textBox19.Text == "" || textBox2.Text == "" || textBox3.Text == "" || textBox4.Text == "" || textBox5.Text == "") { MessageBox.Show("Debe llenar todos los campos", "Proveedores", MessageBoxButtons.OK, MessageBoxIcon.Warning); }
                else
                {
                    try
                    {
                        using (SqlConnection cn = new SqlConnection("server=" + label12.Text + " ; database=" + label9.Text + " ; user id = sa; password='Valley';"))
                        {
                            using (SqlCommand cmd = new SqlCommand("pproveedor", cn))
                            {
                                cmd.CommandType = CommandType.StoredProcedure;
                                cmd.Parameters.Add("@nombrep", SqlDbType.VarChar).Value = textBox19.Text;
                                cmd.Parameters.Add("@nitp", SqlDbType.VarChar).Value = textBox2.Text;
                                cmd.Parameters.Add("@direccionp", SqlDbType.VarChar).Value = textBox3.Text;
                                cmd.Parameters.Add("@codigop", SqlDbType.VarChar).Value = textBox4.Text;
                                cmd.Parameters.Add("@opcion", SqlDbType.Int).Value = 2;
                                cmd.Parameters.Add("@iid", SqlDbType.Int).Value = int.Parse(label13.Text);
                                cmd.Parameters.Add("@numerot", SqlDbType.VarChar).Value = "1";
                                cmd.Parameters.Add("@compañiat", SqlDbType.VarChar).Value = "1";
                                cmd.Parameters.Add("@estadot", SqlDbType.Int).Value = int.Parse(textBox5.Text);
                                cn.Open();
                                cmd.ExecuteNonQuery();
                                MessageBox.Show("Proveedor actualizado", "Proveedores", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                button19.Text = "Agregar";
                                cargarproveedor();
                                limpiar();
                            }
                        }
                    }
                    catch
                    {
                        MessageBox.Show("Ha sucedido un error al actualizar", "Proveedores", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void limpiar()
        {
            textBox19.Text = "";
            textBox4.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox5.Text = "";
            label13.Text = "0";
            button19.Text = "Agregar";
            textBox5.Enabled = false;

        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            button19.Text = "Actualizar";
            textBox19.Text = "" + dataGridView1.CurrentRow.Cells[1].Value;
            textBox4.Text = "" + dataGridView1.CurrentRow.Cells[4].Value;
            textBox2.Text = "" + dataGridView1.CurrentRow.Cells[2].Value;
            textBox3.Text = "" + dataGridView1.CurrentRow.Cells[3].Value;
            textBox5.Text = "" + dataGridView1.CurrentRow.Cells[5].Value;
            textBox5.Enabled = true;
            label13.Text = "" + dataGridView1.CurrentRow.Cells[0].Value;
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            cargarproveedor();
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            limpiar();
        }
    }
}
