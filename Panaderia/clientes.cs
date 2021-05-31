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
    public partial class clientes : Form
    {
        public clientes()
        {
            InitializeComponent();
        }

        private void button19_Click(object sender, EventArgs e)
        {
            if (label13.Text == "0")
            {
                if (txt_codigo.Text == "" || txt_nombre.Text == "" || txt_nit.Text == "" || txt_tele.Text == "" || txt_direccion.Text == "" || text_credito.Text == "") { MessageBox.Show("Debe llenar todos los campos", "Clientes", MessageBoxButtons.OK, MessageBoxIcon.Warning); }
                else
                {

                    using (SqlConnection cn = new SqlConnection("server=" + label21.Text + " ; database=" + label15.Text + " ; user id = sa; password='Valley';"))
                    {
                        using (SqlCommand cmd = new SqlCommand("proclientes", cn))
                        {

                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.Parameters.Add("@ccod", SqlDbType.VarChar).Value = txt_codigo.Text;
                            cmd.Parameters.Add("@cnom", SqlDbType.VarChar).Value = txt_nombre.Text;
                            cmd.Parameters.Add("@cnit", SqlDbType.VarChar).Value = txt_nit.Text;
                            cmd.Parameters.Add("@ctel", SqlDbType.VarChar).Value = txt_tele.Text;
                            cmd.Parameters.Add("@cdir", SqlDbType.VarChar).Value = txt_direccion.Text;
                            cmd.Parameters.Add("@ccred", SqlDbType.Decimal).Value = text_credito.Text;
                            cmd.Parameters.Add("@cestado", SqlDbType.Int).Value = 1;
                            cmd.Parameters.Add("@opcion", SqlDbType.Int).Value = 1;
                            cmd.Parameters.Add("@cid", SqlDbType.Int).Value = 1;
                            cmd.Parameters.Add("@numerot", SqlDbType.VarChar).Value = "1";
                            cmd.Parameters.Add("@compañiat", SqlDbType.VarChar).Value = "1";
                            cmd.Parameters.Add("@estadot", SqlDbType.Int).Value = 1;
                            cmd.Parameters.Add("@apellidos", SqlDbType.VarChar).Value = textBox2.Text;

                            cn.Open();
                            cmd.ExecuteNonQuery();
                            MessageBox.Show("Se ha agregado un nuevo Empleado", "Clientes", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            cargarclientes();
                            limpiar();
                        }
                    }

                }
            }
            else
            {
                if (txt_codigo.Text == "" || txt_nombre.Text == "" || txt_nit.Text == "" || txt_tele.Text == "" || txt_direccion.Text == "" || text_credito.Text == "" || txt_estado.Text == "") { MessageBox.Show("Debe llenar todos los campos", "Clientes", MessageBoxButtons.OK, MessageBoxIcon.Warning); }
                else
                {
                    try
                    {
                        using (SqlConnection cn = new SqlConnection("server=" + label21.Text + " ; database=" + label15.Text + " ; user id = sa; password='Valley';"))
                        {
                            using (SqlCommand cmd = new SqlCommand("proclientes", cn))
                            {
                                cmd.CommandType = CommandType.StoredProcedure;
                                cmd.Parameters.Add("@ccod", SqlDbType.VarChar).Value = txt_codigo.Text;
                                cmd.Parameters.Add("@cnom", SqlDbType.VarChar).Value = txt_nombre.Text;
                                cmd.Parameters.Add("@cnit", SqlDbType.VarChar).Value = txt_nit.Text;
                                cmd.Parameters.Add("@ctel", SqlDbType.VarChar).Value = txt_tele.Text;
                                cmd.Parameters.Add("@cdir", SqlDbType.VarChar).Value = txt_direccion.Text;
                                cmd.Parameters.Add("@ccred", SqlDbType.Decimal).Value = text_credito.Text;
                                cmd.Parameters.Add("@cestado", SqlDbType.Int).Value = txt_estado.Text;
                                cmd.Parameters.Add("@opcion", SqlDbType.Int).Value = 2;
                                cmd.Parameters.Add("@cid", SqlDbType.Int).Value = label13.Text;
                                cmd.Parameters.Add("@numerot", SqlDbType.VarChar).Value = "1";
                                cmd.Parameters.Add("@compañiat", SqlDbType.VarChar).Value = "1";
                                cmd.Parameters.Add("@estadot", SqlDbType.Int).Value = txt_estado.Text;
                                cmd.Parameters.Add("@apellidos", SqlDbType.VarChar).Value = textBox2.Text;

                                cn.Open();
                                cmd.ExecuteNonQuery();
                                MessageBox.Show("Cliente actualizado", "Clientes", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                button19.Text = "Agregar";
                                cargarclientes();
                                limpiar();
                            }
                        }
                    }
                    catch
                    {
                        MessageBox.Show("Ha sucedido un error al actualizar", "Clientes", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }
        private void limpiar()
        {
            txt_codigo.Text = "";
            txt_nombre.Text = "";
            txt_nit.Text = "";
            txt_tele.Text = "";
            txt_direccion.Text = "";
            text_credito.Text = "";
            txt_estado.Text = "";
            textBox2.Text = ""; ;
            txt_estado.Enabled = false;
            label13.Text = "0";
            button19.Text = "Agregar";
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
        private void cargarclientes()
        {
            try
            {

                using (SqlConnection cn = new SqlConnection("server=" + label21.Text + " ; database=" + label15.Text + " ; user id = sa; password='Valley';"))
                {
                    using (SqlCommand cmd = new SqlCommand("proclientes", cn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@ccod", SqlDbType.VarChar).Value = "1";
                        cmd.Parameters.Add("@cnom", SqlDbType.VarChar).Value = textBox1.Text;
                        cmd.Parameters.Add("@cnit", SqlDbType.VarChar).Value = "1";
                        cmd.Parameters.Add("@ctel", SqlDbType.VarChar).Value = "1";
                        cmd.Parameters.Add("@cdir", SqlDbType.VarChar).Value = "1";
                        cmd.Parameters.Add("@ccred", SqlDbType.Decimal).Value = 1;
                        cmd.Parameters.Add("@cestado", SqlDbType.Int).Value = 1;
                        cmd.Parameters.Add("@opcion", SqlDbType.Int).Value = 3;
                        cmd.Parameters.Add("@cid", SqlDbType.Int).Value = 1;
                        cmd.Parameters.Add("@numerot", SqlDbType.VarChar).Value = "1";
                        cmd.Parameters.Add("@compañiat", SqlDbType.VarChar).Value = "1";
                        cmd.Parameters.Add("@estadot", SqlDbType.Int).Value = 1;
                        cmd.Parameters.Add("@apellidos", SqlDbType.VarChar).Value = textBox2.Text;

                        cn.Open();
                        cmd.ExecuteNonQuery();
                        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                        DataSet ds = new DataSet();
                        adapter.Fill(ds);
                        dataGridView1.DataSource = ds.Tables[0];
                        label17.Text = dataGridView1.Rows.Count.ToString();
                        posicion(8);
                    }
                }
            }
            catch { MessageBox.Show("Ha sucedido un error", "Clientes", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            button19.Text = "Actualizar";
            txt_codigo.Text = "" + dataGridView1.CurrentRow.Cells[1].Value;
            txt_nombre.Text = "" + dataGridView1.CurrentRow.Cells[2].Value;
            textBox2.Text = "" + dataGridView1.CurrentRow.Cells[3].Value;
            txt_nit.Text = "" + dataGridView1.CurrentRow.Cells[4].Value;
            txt_tele.Text = "" + dataGridView1.CurrentRow.Cells[5].Value;
            txt_direccion.Text = "" + dataGridView1.CurrentRow.Cells[6].Value;
            text_credito.Text = "" + dataGridView1.CurrentRow.Cells[7].Value;
            txt_estado.Text = "" + dataGridView1.CurrentRow.Cells[8].Value;
            txt_estado.Enabled = true;
            label13.Text = "" + dataGridView1.CurrentRow.Cells[0].Value;
            ocultar();
            panel1.Visible = true;
        }

        private void button15_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            limpiar();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            cargarclientes();
        }

        private void clientes_Load(object sender, EventArgs e)
        {
            cargarclientes();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        private void ocultar() {
            panel1.Visible = false;
            panel3.Visible = false;
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
