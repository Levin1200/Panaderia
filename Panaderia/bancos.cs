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

        private void liberar() {
            pbanco.Visible = false;
            psucursal.Visible = false;
            ppuesto.Visible = false;
        }
        private void limpiar() {
            //Banco
            banconombre.Text = ""; texto2.Text = "1"; texto2.Enabled = false; label13.Text = "0"; button2.Text = "Agregar";
            //Sucursal
            textBox3.Enabled = false; button3.Text = "Agregar";  textBox2.Text=""; textBox3.Text ="1";
            //Puesto
            textBox5.Text = ""; textBox6.Text = ""; textBox7.Text = "1"; textBox7.Enabled = false;

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
            this.Close();
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

        private void cargarsucursales()
        {
            try
            {
                using (SqlConnection cn = new SqlConnection("server=" + label12.Text + " ; database=" + label9.Text + " ; integrated security = true"))
                {
                    using (SqlCommand cmd = new SqlCommand("psucursales", cn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@ssucursal", SqlDbType.VarChar).Value = textBox1.Text;
                        cmd.Parameters.Add("@sestado", SqlDbType.Int).Value = 1;
                        cmd.Parameters.Add("@opcion", SqlDbType.Int).Value = 3;
                        cmd.Parameters.Add("@sid", SqlDbType.Int).Value = 1;
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
            catch { MessageBox.Show("Ha sucedido un error", "Sucursal", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private void cargarpuestos()
        {
            try
            {
                using (SqlConnection cn = new SqlConnection("server=" + label12.Text + " ; database=" + label9.Text + " ; integrated security = true"))
                {
                    using (SqlCommand cmd = new SqlCommand("ppuestos", cn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@ppuesto", SqlDbType.VarChar).Value = textBox1.Text;
                        cmd.Parameters.Add("@pestado", SqlDbType.Int).Value = 1;
                        cmd.Parameters.Add("@psalario", SqlDbType.Decimal).Value = 1;
                        cmd.Parameters.Add("@opcion", SqlDbType.Int).Value = 3;
                        cmd.Parameters.Add("@pid", SqlDbType.Int).Value = 1;
                        cn.Open();
                        cmd.ExecuteNonQuery();
                        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                        DataSet ds = new DataSet();
                        adapter.Fill(ds);
                        dataGridView1.DataSource = ds.Tables[0];
                        label17.Text = dataGridView1.Rows.Count.ToString();
                        posicion(3);
                    }
                }
            }
            catch { MessageBox.Show("Ha sucedido un error", "Puestos", MessageBoxButtons.OK, MessageBoxIcon.Error); }
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
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try {
                if (pbanco.Visible == true) {
                    button2.Text = "Actualizar";
                    banconombre.Text = "" + dataGridView1.CurrentRow.Cells[1].Value;
                    texto2.Text = "" + dataGridView1.CurrentRow.Cells[2].Value;
                    texto2.Enabled = true;
                    label13.Text = "" + dataGridView1.CurrentRow.Cells[0].Value;
                }
                else if (psucursal.Visible == true) {
                    button3.Text = "Actualizar";
                    textBox2.Text = "" + dataGridView1.CurrentRow.Cells[1].Value;
                    textBox3.Text = "" + dataGridView1.CurrentRow.Cells[2].Value;
                    textBox3.Enabled = true;
                    label13.Text = "" + dataGridView1.CurrentRow.Cells[0].Value;
                }

                else if (ppuesto.Visible == true)
                {
                    button4.Text = "Actualizar";
                    textBox6.Text = "" + dataGridView1.CurrentRow.Cells[1].Value;
                    textBox5.Text = "" + dataGridView1.CurrentRow.Cells[2].Value;
                    textBox6.Text = "" + dataGridView1.CurrentRow.Cells[3].Value;
                    textBox6.Enabled = true;
                    label13.Text = "" + dataGridView1.CurrentRow.Cells[0].Value;
                }

                /*
                banconombre.Text = "" + dataGridView1.CurrentRow.Cells[1].Value;
                texto2.Text = "" + dataGridView1.CurrentRow.Cells[2].Value;
                texto2.Enabled = true;
                label13.Text = "" + dataGridView1.CurrentRow.Cells[0].Value;*/
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
            liberar();
            pbanco.Visible = true;
            label8.Text = "Bancos";
            cargarbancos();
            panel3.Size = new Size(561, 295);
            panel3.Location = new Point(189, 281);
            dataGridView1.Size= new Size(527, 263);
        }

        private void button8_MouseEnter(object sender, EventArgs e)
        {
            button8.Text = "Sucursales ➔";
        }

        private void button9_MouseEnter(object sender, EventArgs e)
        {
            button9.Text = "Puestos ➔";
        }

        private void button11_MouseEnter(object sender, EventArgs e)
        {
            button11.Text = "Bodega ➔";
        }

        private void button10_MouseEnter(object sender, EventArgs e)
        {
            button10.Text = "Bancos ➔";
        }

        private void button1_MouseEnter(object sender, EventArgs e)
        {
            button1.Text = "Tipos de pago ➔";
        }

        private void button14_MouseEnter(object sender, EventArgs e)
        {
            button14.Text = "Estados ➔";
        }

        private void button8_Click(object sender, EventArgs e)
        {
            liberar();
            label8.Text = "Sucursales";
            psucursal.Visible = true;
            cargarsucursales();
            panel3.Size = new Size(561, 238);
            panel3.Location = new Point(189, 338);
            dataGridView1.Size = new Size(527, 209);
        }

        private void button8_MouseLeave(object sender, EventArgs e)
        {
            button8.Text = "Sucursales";
        }

        private void button9_MouseLeave(object sender, EventArgs e)
        {
            button9.Text = "Puestos";
        }

        private void button11_MouseLeave(object sender, EventArgs e)
        {
            button11.Text = "Bodega";
        }

        private void button10_MouseLeave(object sender, EventArgs e)
        {
            button10.Text = "Bancos";
        }

        private void button1_MouseLeave(object sender, EventArgs e)
        {
            button1.Text = "Tipos de pago";
        }

        private void button14_MouseLeave(object sender, EventArgs e)
        {
            button14.Text = "Estados";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (label13.Text == "0")
            {
                if (textBox2.Text == "" || textBox3.Text == "") { MessageBox.Show("Debe llenar todos los campos", "Sucursales", MessageBoxButtons.OK, MessageBoxIcon.Warning); }
                else
                {
                    try
                    {
                        using (SqlConnection cn = new SqlConnection("server=" + label12.Text + " ; database=" + label9.Text + " ; integrated security = true"))
                        {
                            using (SqlCommand cmd = new SqlCommand("psucursales", cn))
                            {
                                cmd.CommandType = CommandType.StoredProcedure;
                                cmd.Parameters.Add("@ssucursal", SqlDbType.VarChar).Value = textBox2.Text;
                                cmd.Parameters.Add("@sestado", SqlDbType.Int).Value = 1;
                                cmd.Parameters.Add("@opcion", SqlDbType.Int).Value = 1;
                                cmd.Parameters.Add("@sid", SqlDbType.Int).Value = int.Parse(textBox4.Text);
                                cn.Open();
                                cmd.ExecuteNonQuery();
                                MessageBox.Show("Se ha agregado una nueva Sucursal", "Sucursales", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                cargarsucursales();
                                limpiar();
                            }
                        }
                    }
                    catch
                    {
                        MessageBox.Show("Ha sucedido un error al insertar", "Sucursales", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                if (textBox2.Text == "" || textBox3.Text == "") { MessageBox.Show("Debe llenar todos los campos", "Sucursales", MessageBoxButtons.OK, MessageBoxIcon.Warning); }
                else
                {
                    try
                    {
                        using (SqlConnection cn = new SqlConnection("server=" + label12.Text + " ; database=" + label9.Text + " ; integrated security = true"))
                        {
                            using (SqlCommand cmd = new SqlCommand("psucursales", cn))
                            {
                                cmd.CommandType = CommandType.StoredProcedure;
                                cmd.Parameters.Add("@ssucursal", SqlDbType.VarChar).Value = textBox2.Text;
                                cmd.Parameters.Add("@sestado", SqlDbType.Int).Value = int.Parse(textBox3.Text);
                                cmd.Parameters.Add("@opcion", SqlDbType.Int).Value = 2;
                                cmd.Parameters.Add("@sid", SqlDbType.Int).Value = int.Parse(label13.Text);
                                cn.Open();
                                cmd.ExecuteNonQuery();
                                MessageBox.Show("Sucursal actualizada", "Sucursales", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                button2.Text = "Agregar";
                                cargarsucursales();
                                limpiar(); 
                            }
                        }
                    }
                    catch
                    {
                        MessageBox.Show("Ha sucedido un error al actualizar", "Sucursales", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            liberar();
            label8.Text = "Puestos";
            ppuesto.Visible = true;
            cargarpuestos();
            panel3.Size = new Size(561, 238);
            panel3.Location = new Point(189, 338);
            dataGridView1.Size = new Size(527, 209);
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
