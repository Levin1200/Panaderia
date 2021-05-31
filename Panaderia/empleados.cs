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
    public partial class empleados : Form
    {
        public empleados()
        {
            InitializeComponent();
        }

        private void button19_Click(object sender, EventArgs e)
        {
            if (label13.Text == "0")
            {
                if (textBox19.Text == "" || textBox2.Text == "" || textBox3.Text == "" || textBox4.Text == "" || textBox5.Text == "" || textBox6.Text == "" || textBox7.Text == "" || textBox8.Text == "") { MessageBox.Show("Debe llenar todos los campos", "Empleados", MessageBoxButtons.OK, MessageBoxIcon.Warning); }
                else
                {
                    try
                    {
                        using (SqlConnection cn = new SqlConnection("server= " + label21.Text + " ; database=" + label15.Text + " ; user id = sa; password='Valley';"))
                        {
                            using (SqlCommand cmd = new SqlCommand("proempleados", cn))
                            {
                                cmd.CommandType = CommandType.StoredProcedure;
                                cmd.Parameters.Add("@ecodemp", SqlDbType.VarChar).Value = textBox19.Text;
                                cmd.Parameters.Add("@enom", SqlDbType.VarChar).Value = textBox2.Text;
                                cmd.Parameters.Add("@eape1", SqlDbType.VarChar).Value = textBox3.Text;
                                cmd.Parameters.Add("@eape2", SqlDbType.VarChar).Value = textBox4.Text;
                                cmd.Parameters.Add("@edir", SqlDbType.VarChar).Value = textBox5.Text;
                                cmd.Parameters.Add("@edpi", SqlDbType.VarChar).Value = textBox6.Text;
                                cmd.Parameters.Add("@epuesto", SqlDbType.Int).Value = int.Parse(textBox7.Text);
                                cmd.Parameters.Add("@esexo", SqlDbType.VarChar).Value = textBox8.Text;
                                cmd.Parameters.Add("@eestado", SqlDbType.Int).Value = 1;
                                cmd.Parameters.Add("@opcion", SqlDbType.Int).Value = 1;
                                cmd.Parameters.Add("@eid", SqlDbType.Int).Value = int.Parse(label13.Text);
                                cmd.Parameters.Add("@numerot", SqlDbType.VarChar).Value = "1";
                                cmd.Parameters.Add("@compañiat", SqlDbType.VarChar).Value = "1";
                                cmd.Parameters.Add("@estadot", SqlDbType.Int).Value = 1;

                                cn.Open();
                                cmd.ExecuteNonQuery();
                                MessageBox.Show("Se ha agregado un nuevo Empleado", "Empleados", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                cargarempleados();
                                limpiar();
                            }
                        }
                    }
                    catch
                    {
                        MessageBox.Show("Ha sucedido un error al insertar", "Empleados", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                if (textBox19.Text == "" || textBox2.Text == "" || textBox3.Text == "" || textBox4.Text == "" || textBox5.Text == "" || textBox6.Text == "" || textBox7.Text == "" || textBox8.Text == "" || textBox9.Text == "") { MessageBox.Show("Debe llenar todos los campos", "Empleados", MessageBoxButtons.OK, MessageBoxIcon.Warning); }
                else
                {
                    try
                    {

                        using (SqlConnection cn = new SqlConnection("server=" + label21.Text + " ; database=" + label15.Text + " ; user id = sa; password='Valley';"))
                        {
                            using (SqlCommand cmd = new SqlCommand("proempleados", cn))
                            {
                                cmd.CommandType = CommandType.StoredProcedure;
                                cmd.Parameters.Add("@ecodemp", SqlDbType.VarChar).Value = textBox19.Text;
                                cmd.Parameters.Add("@enom", SqlDbType.VarChar).Value = textBox2.Text;
                                cmd.Parameters.Add("@eape1", SqlDbType.VarChar).Value = textBox3.Text;
                                cmd.Parameters.Add("@eape2", SqlDbType.VarChar).Value = textBox4.Text;
                                cmd.Parameters.Add("@edir", SqlDbType.VarChar).Value = textBox5.Text;
                                cmd.Parameters.Add("@edpi", SqlDbType.VarChar).Value = textBox6.Text;
                                cmd.Parameters.Add("@epuesto", SqlDbType.Int).Value = int.Parse(textBox7.Text);
                                cmd.Parameters.Add("@esexo", SqlDbType.VarChar).Value = textBox8.Text;
                                cmd.Parameters.Add("@eestado", SqlDbType.Int).Value = int.Parse(textBox9.Text);
                                cmd.Parameters.Add("@opcion", SqlDbType.Int).Value = 2;
                                cmd.Parameters.Add("@eid", SqlDbType.Int).Value = int.Parse(label13.Text);
                                cmd.Parameters.Add("@numerot", SqlDbType.VarChar).Value = "1";
                                cmd.Parameters.Add("@compañiat", SqlDbType.VarChar).Value = "1";
                                cmd.Parameters.Add("@estadot", SqlDbType.Int).Value = 1;

                                cn.Open();
                                cmd.ExecuteNonQuery();
                                MessageBox.Show("Empleado actualizado", "Empleados", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                button19.Text = "Agregar";
                                cargarempleados();
                                limpiar();
                            }
                        }
                    }
                    catch
                    {
                        MessageBox.Show("Ha sucedido un error al actualizar", "Empleados", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void empleados_Load(object sender, EventArgs e)
        {
            cargarempleados();
        }
        private void ocultar()
        {
            panel1.Visible = false;
            panel3.Visible = false;
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
        private void cargarempleados()
        {
            try
            {

                using (SqlConnection cn = new SqlConnection("server=" + label21.Text + " ; database=" + label15.Text + " ; user id = sa; password='Valley';"))
                {
                    using (SqlCommand cmd = new SqlCommand("proempleados", cn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@ecodemp", SqlDbType.VarChar).Value = "1";
                        cmd.Parameters.Add("@enom", SqlDbType.VarChar).Value = textBox1.Text;
                        cmd.Parameters.Add("@eape1", SqlDbType.VarChar).Value = "1";
                        cmd.Parameters.Add("@eape2", SqlDbType.VarChar).Value = "1";
                        cmd.Parameters.Add("@edir", SqlDbType.VarChar).Value = "1";
                        cmd.Parameters.Add("@edpi", SqlDbType.VarChar).Value = "1";
                        cmd.Parameters.Add("@epuesto", SqlDbType.Int).Value = 1;
                        cmd.Parameters.Add("@esexo", SqlDbType.VarChar).Value = "1";
                        cmd.Parameters.Add("@eestado", SqlDbType.Int).Value = 1;
                        cmd.Parameters.Add("@opcion", SqlDbType.Int).Value = 3;
                        cmd.Parameters.Add("@eid", SqlDbType.Int).Value = 1;
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
                        posicion(9);
                    }
                }
            }
            catch { MessageBox.Show("Ha sucedido un error", "Empleados", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }
        private void limpiar()
        {
            textBox19.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            textBox6.Text = "";
            textBox7.Text = "";
            textBox8.Text = "";
            textBox9.Text = "1";
            textBox9.Enabled = false;
            label13.Text = "0";
            button19.Text = "Agregar";
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            button19.Text = "Actualizar";
            textBox19.Text = "" + dataGridView1.CurrentRow.Cells[1].Value;
            textBox2.Text = "" + dataGridView1.CurrentRow.Cells[2].Value;
            textBox3.Text = "" + dataGridView1.CurrentRow.Cells[3].Value;
            textBox4.Text = "" + dataGridView1.CurrentRow.Cells[4].Value;
            textBox5.Text = "" + dataGridView1.CurrentRow.Cells[5].Value;
            textBox6.Text = "" + dataGridView1.CurrentRow.Cells[6].Value;
            textBox7.Text = "" + dataGridView1.CurrentRow.Cells[7].Value;
            textBox8.Text = "" + dataGridView1.CurrentRow.Cells[8].Value;
            textBox9.Text = "" + dataGridView1.CurrentRow.Cells[9].Value;
            textBox9.Enabled = true;
            label13.Text = "" + dataGridView1.CurrentRow.Cells[0].Value;
            ocultar();
            panel1.Visible = true;
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            limpiar();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            cargarempleados();
        }

        private void button15_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ocultar();
            panel1.Visible = true;
        }

        private void button8_Click(object sender, EventArgs e)
        {
            ocultar();
            panel3.Visible = true;
        }
    }
}
