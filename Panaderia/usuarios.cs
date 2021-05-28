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
    public partial class usuarios : Form
    {
        public usuarios()
        {
            InitializeComponent();
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

        private void cargarusuarios()
        {
            try
            {
                using (SqlConnection cn = new SqlConnection("server=" + label12.Text + " ; database=" + label9.Text + " ; user id = sa; password='Valley';"))
                {
                    using (SqlCommand cmd = new SqlCommand("RegistrarUsuario", cn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@iid", SqlDbType.Int).Value = 1;//int.Parse(label13.Text);
                        cmd.Parameters.Add("@codeusu", SqlDbType.VarChar).Value = "1";
                        cmd.Parameters.Add("@empleado", SqlDbType.Int).Value = 1;
                        cmd.Parameters.Add("@nombres", SqlDbType.VarChar).Value = textBox1.Text;
                        cmd.Parameters.Add("@estadou", SqlDbType.Int).Value = 1;
                        cmd.Parameters.Add("@opcion", SqlDbType.Int).Value = 3;
                        cmd.Parameters.Add("@passwords", SqlDbType.VarChar).Value = "1";

                        cn.Open();
                        cmd.ExecuteNonQuery();
                        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                        DataSet ds = new DataSet();
                        adapter.Fill(ds);
                        dataGridView1.DataSource = ds.Tables[0];
                        label17.Text = dataGridView1.Rows.Count.ToString();
                        posicion(4);
                    }
                }
            }
            catch { MessageBox.Show("Ha sucedido un error", "Usuario", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private void limpiar()
        {
            textBox19.Text = "";
            textBox3.Text = "";
            textBox5.Text = "";
            textBox4.Text = "";
            textBox2.Text = "";
            label13.Text = "0";
            button19.Text = "Agregar";
            textBox2.Enabled = false;

        }

        private void button19_Click(object sender, EventArgs e)
        {
            if (label13.Text == "0")
            {
                if (textBox19.Text == "" || textBox3.Text == "" || textBox5.Text == "" || textBox4.Text == "") { MessageBox.Show("Debe llenar todos los campos", "Proveedores", MessageBoxButtons.OK, MessageBoxIcon.Warning); }
                else
                {
                    try
                    {
                        using (SqlConnection cn = new SqlConnection("server=" + label12.Text + " ; database=" + label9.Text + " ; user id = sa; password='Valley';"))
                        {
                            using (SqlCommand cmd = new SqlCommand("RegistrarUsuario", cn))
                            {
                                cmd.CommandType = CommandType.StoredProcedure;
                                cmd.Parameters.Add("@iid", SqlDbType.Int).Value = 1; //int.Parse(label13.Text);
                                cmd.Parameters.Add("@codeusu", SqlDbType.VarChar).Value = textBox19.Text;
                                cmd.Parameters.Add("@empleado", SqlDbType.Int).Value = int.Parse(textBox3.Text);
                                cmd.Parameters.Add("@nombres", SqlDbType.VarChar).Value = textBox5.Text;
                                cmd.Parameters.Add("@estadou", SqlDbType.Int).Value = 1;
                                cmd.Parameters.Add("@opcion", SqlDbType.Int).Value = 1;
                                cmd.Parameters.Add("@passwords", SqlDbType.VarChar).Value = textBox4.Text;

                                cn.Open();
                                cmd.ExecuteNonQuery();
                                MessageBox.Show("Se ha agregado una nuevo Usuario", "Usuarios", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                cargarusuarios();
                                limpiar();
                            }
                        }
                    }
                    catch
                    {
                        MessageBox.Show("Ha sucedido un error al insertar", "Usuarios", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                if (textBox19.Text == "" || textBox3.Text == "" || textBox5.Text == "" || textBox4.Text == "" || textBox2.Text == "") { MessageBox.Show("Debe llenar todos los campos", "Usuario", MessageBoxButtons.OK, MessageBoxIcon.Warning); }
                else
                {
                    try
                    {
                        using (SqlConnection cn = new SqlConnection("server=" + label12.Text + " ; database=" + label9.Text + " ; user id = sa; password='Valley';"))
                        {
                            using (SqlCommand cmd = new SqlCommand("RegistrarUsuario", cn))
                            {
                                cmd.CommandType = CommandType.StoredProcedure;
                                cmd.Parameters.Add("@iid", SqlDbType.Int).Value = int.Parse(label13.Text);
                                cmd.Parameters.Add("@codeusu", SqlDbType.VarChar).Value = textBox19.Text;
                                cmd.Parameters.Add("@empleado", SqlDbType.Int).Value = int.Parse(textBox3.Text);
                                cmd.Parameters.Add("@nombres", SqlDbType.VarChar).Value = textBox5.Text;
                                cmd.Parameters.Add("@estadou", SqlDbType.Int).Value =int.Parse(textBox2.Text);
                                cmd.Parameters.Add("@opcion", SqlDbType.Int).Value = 2;
                                cmd.Parameters.Add("@passwords", SqlDbType.VarChar).Value = textBox4.Text;


                                cn.Open();
                                cmd.ExecuteNonQuery();
                                MessageBox.Show("Usuario actualizado", "Usuarios", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                button19.Text = "Agregar";
                                cargarusuarios();
                                limpiar();
                            }
                        }
                    }
                    catch
                    {
                        MessageBox.Show("Ha sucedido un error al actualizar", "Usuarios", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            button19.Text = "Actualizar";
            textBox19.Text = "" + dataGridView1.CurrentRow.Cells[1].Value;
            textBox3.Text = "" + dataGridView1.CurrentRow.Cells[2].Value;
            textBox5.Text = "" + dataGridView1.CurrentRow.Cells[3].Value;
            textBox2.Text = "" + dataGridView1.CurrentRow.Cells[4].Value;
            textBox2.Enabled = true;
            label13.Text = "" + dataGridView1.CurrentRow.Cells[0].Value;
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            limpiar();
        }

        private void usuarios_Load(object sender, EventArgs e)
        {
            cargarusuarios();
        }

        private void button15_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            cargarusuarios();
        }
    }
}
