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
            pingresos.Visible = false;
            pbanco.Visible = false;
            psucursal.Visible = false;
            pbodega.Visible = false;
            ppuesto.Visible = false;
            ptpago.Visible = false;
            pestado.Visible = false;
            ptplanilla.Visible = false;
        }
        private void limpiar() {
            //Banco
            banconombre.Text = ""; texto2.Text = "1"; texto2.Enabled = false; label13.Text = "0"; button2.Text = "Agregar";
            //Sucursal
            textBox3.Enabled = false; button3.Text = "Agregar";  textBox2.Text=""; textBox3.Text ="1";
            //Puesto
            textBox5.Text = ""; textBox6.Text = ""; textBox7.Text = "1"; textBox7.Enabled = false; button4.Text = "Agregar";
            //Bodega
            textBox8.Text = ""; textBox9.Text = "1"; textBox9.Enabled = false; button5.Text = "Agregar";
            //Tipos de pago
            textBox10.Text = ""; textBox11.Text = "1"; textBox11.Enabled = false; button6.Text = "Agregar";
            //Estados
            textBox12.Text = ""; button7.Text = "Agregar";
            //Tipos de planilla
            textBox13.Text = ""; textBox14.Text = "1"; textBox14.Enabled=false; button17.Text = "Agregar";
            //Ingresos
            textBox15.Text = ""; textBox16.Text = ""; textBox17.Text = "1"; textBox17.Enabled = false; button18.Text = "Agregar";
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
                        using (SqlConnection cn = new SqlConnection("server=" + label12.Text + " ; database=" + label9.Text + "; user id = sa; password='Valley';"))
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
                        using (SqlConnection cn = new SqlConnection("server = " + label12.Text + " ; database = " + label9.Text + "; user id = sa; password='Valley';"))
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
                using (SqlConnection cn = new SqlConnection("server=" + label12.Text + " ; database=" + label9.Text + " ; user id = sa; password='Valley';"))
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
        private void cargarbodega()
        {
            try
            {
                using (SqlConnection cn = new SqlConnection("server=" + label12.Text + " ; database=" + label9.Text + " ; user id = sa; password='Valley';"))
                {
                    using (SqlCommand cmd = new SqlCommand("pbodega", cn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@bbodega", SqlDbType.VarChar).Value = textBox1.Text;
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
            catch { MessageBox.Show("Ha sucedido un error", "Bodega", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private void cargarsucursales()
        {
            try
            {
                using (SqlConnection cn = new SqlConnection("server=" + label12.Text + " ; database=" + label9.Text + " ; user id = sa; password='Valley';"))
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
                using (SqlConnection cn = new SqlConnection("server=" + label12.Text + " ; database=" + label9.Text + " ; user id = sa; password='Valley';"))
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

        private void cargaringresos()
        {
            try
            {
                using (SqlConnection cn = new SqlConnection("server=" + label12.Text + " ; database=" + label9.Text + " ; user id = sa; password='Valley';"))
                {
                    using (SqlCommand cmd = new SqlCommand("pingresos", cn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@iingresos", SqlDbType.VarChar).Value = textBox1.Text;
                        cmd.Parameters.Add("@iestado", SqlDbType.Int).Value = 1;
                        cmd.Parameters.Add("@ivalor", SqlDbType.Decimal).Value = 1;
                        cmd.Parameters.Add("@opcion", SqlDbType.Int).Value = 3;
                        cmd.Parameters.Add("@iid", SqlDbType.Int).Value = 1;
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
            catch { MessageBox.Show("Ha sucedido un error", "Ingresos", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }


        private void cargartpagos()
        {
            try
            {
                using (SqlConnection cn = new SqlConnection("server=" + label12.Text + " ; database=" + label9.Text + " ; user id = sa; password='Valley';"))
                {
                    using (SqlCommand cmd = new SqlCommand("ptpago", cn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@ttpago", SqlDbType.VarChar).Value = textBox1.Text;
                        cmd.Parameters.Add("@testado", SqlDbType.Int).Value = 1;
                        cmd.Parameters.Add("@opcion", SqlDbType.Int).Value = 3;
                        cmd.Parameters.Add("@tid", SqlDbType.Int).Value = 1;
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
            catch { MessageBox.Show("Ha sucedido un error", "Tipos de pago", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private void cargarestados()
        {
            try
            {
                using (SqlConnection cn = new SqlConnection("server=" + label12.Text + " ; database=" + label9.Text + " ; user id = sa; password='Valley';"))
                {
                    using (SqlCommand cmd = new SqlCommand("pestados", cn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@eestado", SqlDbType.VarChar).Value = textBox1.Text;
                        cmd.Parameters.Add("@opcion", SqlDbType.Int).Value = 3;
                        cmd.Parameters.Add("@tid", SqlDbType.Int).Value = 1;
                        cn.Open();
                        cmd.ExecuteNonQuery();
                        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                        DataSet ds = new DataSet();
                        adapter.Fill(ds);
                        dataGridView1.DataSource = ds.Tables[0];
                        label17.Text = dataGridView1.Rows.Count.ToString();
                        pictureBox9.Size = new Size(0, 10);
                        pictureBox10.Size = new Size(0, 10);
                    }
                }
            }
            catch { MessageBox.Show("Ha sucedido un error", "Estados", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private void cargartplanilla()
        {
            try
            {
                using (SqlConnection cn = new SqlConnection("server=" + label12.Text + " ; database=" + label9.Text + " ; user id = sa; password='Valley';"))
                {
                    using (SqlCommand cmd = new SqlCommand("ptipoplanilla", cn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@ttpago", SqlDbType.VarChar).Value = textBox1.Text;
                        cmd.Parameters.Add("@testado", SqlDbType.Int).Value = 1;
                        cmd.Parameters.Add("@opcion", SqlDbType.Int).Value = 3;
                        cmd.Parameters.Add("@tid", SqlDbType.Int).Value = 1;
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
            catch { MessageBox.Show("Ha sucedido un error", "Tipos de planilla", MessageBoxButtons.OK, MessageBoxIcon.Error); }
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
            button8_Click(sender,e);
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try {
                if (pbanco.Visible == true)
                {
                    button2.Text = "Actualizar";
                    banconombre.Text = "" + dataGridView1.CurrentRow.Cells[1].Value;
                    texto2.Text = "" + dataGridView1.CurrentRow.Cells[2].Value;
                    texto2.Enabled = true;
                    label13.Text = "" + dataGridView1.CurrentRow.Cells[0].Value;
                }
                else if (psucursal.Visible == true)
                {
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
                    textBox7.Text = "" + dataGridView1.CurrentRow.Cells[3].Value;
                    textBox7.Enabled = true;
                    label13.Text = "" + dataGridView1.CurrentRow.Cells[0].Value;
                }
                else if (pbodega.Visible == true)
                {
                    button5.Text = "Actualizar";
                    textBox8.Text = "" + dataGridView1.CurrentRow.Cells[1].Value;
                    textBox9.Text = "" + dataGridView1.CurrentRow.Cells[2].Value;
                    textBox3.Enabled = true;
                    label13.Text = "" + dataGridView1.CurrentRow.Cells[0].Value;
                }
                else if (ptpago.Visible == true)
                {
                    button6.Text = "Actualizar";
                    textBox10.Text = "" + dataGridView1.CurrentRow.Cells[1].Value;
                    textBox11.Text = "" + dataGridView1.CurrentRow.Cells[2].Value;
                    textBox11.Enabled = true;
                    label13.Text = "" + dataGridView1.CurrentRow.Cells[0].Value;
                }
                else if (pestado.Visible == true)
                {
                    button7.Text = "Actualizar";
                    textBox12.Text = "" + dataGridView1.CurrentRow.Cells[1].Value;
                    label13.Text = "" + dataGridView1.CurrentRow.Cells[0].Value;
                }
                else if (ptplanilla.Visible == true)
                {
                    button17.Text = "Actualizar";
                    textBox13.Text = "" + dataGridView1.CurrentRow.Cells[1].Value;
                    textBox14.Text = "" + dataGridView1.CurrentRow.Cells[2].Value;
                    textBox14.Enabled = true;
                    label13.Text = "" + dataGridView1.CurrentRow.Cells[0].Value;
                }
                else if (pingresos.Visible == true)
                {
                    button18.Text = "Actualizar";
                    textBox16.Text = "" + dataGridView1.CurrentRow.Cells[1].Value;
                    textBox15.Text = "" + dataGridView1.CurrentRow.Cells[2].Value;
                    textBox17.Text = "" + dataGridView1.CurrentRow.Cells[3].Value;
                    textBox17.Enabled = true;
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

            if (pbanco.Visible == true) { cargarbancos(); } else if (ppuesto.Visible == true) { cargarpuestos(); } else if (psucursal.Visible == true) { cargarsucursales(); } else if (pbodega.Visible == true) { cargarbodega(); }
            else if (pestado.Visible == true) { cargarestados(); } else if (ptpago.Visible == true) { cargartpagos(); }
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            limpiar();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
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
            textBox1.Text = "";
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
                        using (SqlConnection cn = new SqlConnection("server=" + label12.Text + " ; database=" + label9.Text + " ; user id = sa; password='Valley';"))
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
                        using (SqlConnection cn = new SqlConnection("server=" + label12.Text + " ; database=" + label9.Text + " ; user id = sa; password='Valley';"))
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
            textBox1.Text = "";
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

        private void button4_Click(object sender, EventArgs e)
        {
            //Puestos
            if (label13.Text == "0")
            {
                if (textBox6.Text == "" || textBox5.Text == "") { MessageBox.Show("Debe llenar todos los campos", "Puestos", MessageBoxButtons.OK, MessageBoxIcon.Warning); }
                else
                {
                    try
                    {
                        using (SqlConnection cn = new SqlConnection("server=" + label12.Text + " ; database=" + label9.Text + " ; user id = sa; password='Valley';"))
                        {
                            using (SqlCommand cmd = new SqlCommand("ppuestos", cn))
                            {
                                cmd.CommandType = CommandType.StoredProcedure;
                                cmd.Parameters.Add("@ppuesto", SqlDbType.VarChar).Value = textBox6.Text;
                                cmd.Parameters.Add("@pestado", SqlDbType.Int).Value = int.Parse(textBox7.Text);
                                cmd.Parameters.Add("@psalario", SqlDbType.Decimal).Value = double.Parse(textBox5.Text);
                                cmd.Parameters.Add("@opcion", SqlDbType.Int).Value = 1;
                                cmd.Parameters.Add("@pid", SqlDbType.Int).Value = int.Parse(label13.Text);
                                cn.Open();
                                cmd.ExecuteNonQuery();
                                MessageBox.Show("Se ha agregado un nuevo puesto", "Puestos", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                cargarpuestos();
                                limpiar();
                            }
                        }
                    }
                    catch
                    {
                        MessageBox.Show("Ha sucedido un error al insertar", "Puestos", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                if (textBox6.Text == "" || textBox5.Text == "" || textBox7.Text == "") { MessageBox.Show("Debe llenar todos los campos", "Puestos", MessageBoxButtons.OK, MessageBoxIcon.Warning); }
                else
                {
                    try
                    {
                        using (SqlConnection cn = new SqlConnection("server=" + label12.Text + " ; database=" + label9.Text + " ; user id = sa; password='Valley';"))
                        {
                            using (SqlCommand cmd = new SqlCommand("ppuestos", cn))
                            {
                                cmd.CommandType = CommandType.StoredProcedure;
                                cmd.Parameters.Add("@ppuesto", SqlDbType.VarChar).Value = textBox6.Text;
                                cmd.Parameters.Add("@pestado", SqlDbType.Int).Value = int.Parse(textBox7.Text);
                                cmd.Parameters.Add("@psalario", SqlDbType.Decimal).Value = double.Parse(textBox5.Text);
                                cmd.Parameters.Add("@opcion", SqlDbType.Int).Value = 2;
                                cmd.Parameters.Add("@pid", SqlDbType.Int).Value = int.Parse(label13.Text);
                                cn.Open();
                                cmd.ExecuteNonQuery();
                                MessageBox.Show("Puesto actualizada", "Puestos", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                button2.Text = "Agregar";
                                cargarpuestos();
                                limpiar();
                            }
                        }
                    }
                    catch
                    {
                        MessageBox.Show("Ha sucedido un error al actualizar", "Puestos", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void button11_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            liberar();
            label8.Text = "Bodega";
            pbodega.Visible = true;
            cargarbodega();
            panel3.Size = new Size(561, 295);
            panel3.Location = new Point(189, 281);
            dataGridView1.Size = new Size(527, 263);

        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            liberar();
            ptpago.Visible = true;
            label8.Text = "Tipos de pago";
            cargartpagos();
            panel3.Size = new Size(561, 295);
            panel3.Location = new Point(189, 281);
            dataGridView1.Size = new Size(527, 263);
        }

        private void button14_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            liberar();
            pestado.Visible = true;
            label8.Text = "Estados";
            cargarestados();
            panel3.Size = new Size(561, 295);
            panel3.Location = new Point(189, 281);
            dataGridView1.Size = new Size(527, 263);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (label13.Text == "0")
            {
                if (textBox8.Text == "" || textBox9.Text == "") { MessageBox.Show("Debe llenar todos los campos", "Bodega", MessageBoxButtons.OK, MessageBoxIcon.Warning); }
                else
                {
                    try
                    {
                        using (SqlConnection cn = new SqlConnection("server=" + label12.Text + " ; database=" + label9.Text + " ; user id = sa; password='Valley';"))
                        {
                            using (SqlCommand cmd = new SqlCommand("pbodega", cn))
                            {
                                cmd.CommandType = CommandType.StoredProcedure;
                                cmd.Parameters.Add("@bbodega", SqlDbType.VarChar).Value = textBox8.Text;
                                cmd.Parameters.Add("@bestado", SqlDbType.Int).Value = int.Parse(textBox9.Text);
                                cmd.Parameters.Add("@opcion", SqlDbType.Int).Value = 1;
                                cmd.Parameters.Add("@bid", SqlDbType.Int).Value = int.Parse(label13.Text);
                                cn.Open();
                                cmd.ExecuteNonQuery();
                                MessageBox.Show("Se ha agregado una nueva bodega", "Bodega", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                cargarbodega();
                                limpiar();
                            }
                        }
                    }
                    catch
                    {
                        MessageBox.Show("Ha sucedido un error", "Bodega", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                if (textBox8.Text == "" || textBox9.Text == "") { MessageBox.Show("Debe llenar todos los campos", "Bodega", MessageBoxButtons.OK, MessageBoxIcon.Warning); }
                else
                {
                    try
                    {
                        using (SqlConnection cn = new SqlConnection("server=" + label12.Text + " ; database=" + label9.Text + " ; user id = sa; password='Valley';"))
                        {
                            using (SqlCommand cmd = new SqlCommand("pbodega", cn))
                            {
                                cmd.CommandType = CommandType.StoredProcedure;
                                cmd.Parameters.Add("@bbodega", SqlDbType.VarChar).Value = textBox8.Text;
                                cmd.Parameters.Add("@bestado", SqlDbType.Int).Value = int.Parse(textBox9.Text);
                                cmd.Parameters.Add("@opcion", SqlDbType.Int).Value = 2;
                                cmd.Parameters.Add("@bid", SqlDbType.Int).Value = int.Parse(label13.Text);
                                cn.Open();
                                cmd.ExecuteNonQuery();
                                MessageBox.Show("Bodega actualizada", "Bodega", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                button2.Text = "Agregar";
                                cargarbodega();
                                limpiar();
                            }
                        }
                    }
                    catch
                    {
                        MessageBox.Show("Ha sucedido un error", "Bodega", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }

        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (label13.Text == "0")
            {
                if (textBox10.Text == "" || textBox11.Text == "") { MessageBox.Show("Debe llenar todos los campos", "Tipos de pago", MessageBoxButtons.OK, MessageBoxIcon.Warning); }
                else
                {
                    try
                    {
                        using (SqlConnection cn = new SqlConnection("server=" + label12.Text + " ; database=" + label9.Text + " ; user id = sa; password='Valley';"))
                        {
                            using (SqlCommand cmd = new SqlCommand("ptpago", cn))
                            {
                                cmd.CommandType = CommandType.StoredProcedure;
                                cmd.Parameters.Add("@ttpago", SqlDbType.VarChar).Value = textBox10.Text;
                                cmd.Parameters.Add("@testado", SqlDbType.Int).Value = int.Parse(textBox11.Text);
                                cmd.Parameters.Add("@opcion", SqlDbType.Int).Value = 1;
                                cmd.Parameters.Add("@tid", SqlDbType.Int).Value = int.Parse(label13.Text);
                                cn.Open();
                                cmd.ExecuteNonQuery();
                                MessageBox.Show("Se ha agregado un nuevo tipo de pago", "Tipos de pago", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                cargartpagos();
                                limpiar();
                            }
                        }
                    }
                    catch
                    {
                        MessageBox.Show("Ha sucedido un error", "Tipos de pago", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                if (textBox10.Text == "" || textBox11.Text == "") { MessageBox.Show("Debe llenar todos los campos", "Tipos de pago", MessageBoxButtons.OK, MessageBoxIcon.Warning); }
                else
                {
                    try
                    {
                        using (SqlConnection cn = new SqlConnection("server=" + label12.Text + " ; database=" + label9.Text + " ; user id = sa; password='Valley';"))
                        {
                            using (SqlCommand cmd = new SqlCommand("ptpago", cn))
                            {
                                cmd.CommandType = CommandType.StoredProcedure;
                                cmd.Parameters.Add("@ttpago", SqlDbType.VarChar).Value = textBox10.Text;
                                cmd.Parameters.Add("@testado", SqlDbType.Int).Value = int.Parse(textBox11.Text);
                                cmd.Parameters.Add("@opcion", SqlDbType.Int).Value = 2;
                                cmd.Parameters.Add("@tid", SqlDbType.Int).Value = int.Parse(label13.Text);
                                cn.Open();
                                cmd.ExecuteNonQuery();
                                MessageBox.Show("Tipos de pago actualizados", "Tipos de pago", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                button2.Text = "Agregar";
                                cargartpagos();
                                limpiar();
                            }
                        }
                    }
                    catch
                    {
                        MessageBox.Show("Ha sucedido un error", "Tipos de pago", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (label13.Text == "0")
            {
                if (textBox12.Text == "") { MessageBox.Show("Debe llenar todos los campos", "Estados", MessageBoxButtons.OK, MessageBoxIcon.Warning); }
                else
                {
                    try
                    {
                        using (SqlConnection cn = new SqlConnection("server=" + label12.Text + " ; database=" + label9.Text + " ; user id = sa; password='Valley';"))
                        {
                            using (SqlCommand cmd = new SqlCommand("pestados", cn))
                            {
                                cmd.CommandType = CommandType.StoredProcedure;
                                cmd.Parameters.Add("@eestado", SqlDbType.VarChar).Value = textBox12.Text;
                                cmd.Parameters.Add("@opcion", SqlDbType.Int).Value = 1;
                                cmd.Parameters.Add("@tid", SqlDbType.Int).Value = int.Parse(label13.Text);
                                cn.Open();
                                cmd.ExecuteNonQuery();
                                MessageBox.Show("Se ha agregado un nuevo estado", "Estados", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                cargarestados();
                                limpiar();
                            }
                        }
                    }
                    catch
                    {
                        MessageBox.Show("Ha sucedido un error en los estados", "Estados", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                if (textBox12.Text == "") { MessageBox.Show("Debe llenar todos los campos", "Estados", MessageBoxButtons.OK, MessageBoxIcon.Warning); }
                else
                {
                    try
                    {
                        using (SqlConnection cn = new SqlConnection("server=" + label12.Text + " ; database=" + label9.Text + " ; user id = sa; password='Valley';"))
                        {
                            using (SqlCommand cmd = new SqlCommand("pestados", cn))
                            {
                                cmd.CommandType = CommandType.StoredProcedure;
                                cmd.Parameters.Add("@eestado", SqlDbType.VarChar).Value = textBox12.Text;
                                cmd.Parameters.Add("@opcion", SqlDbType.Int).Value = 2;
                                cmd.Parameters.Add("@tid", SqlDbType.Int).Value = int.Parse(label13.Text);
                                cn.Open();
                                cmd.ExecuteNonQuery();
                                MessageBox.Show("Estados actualizados", "Estados", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                button2.Text = "Agregar";
                                cargarestados();
                                limpiar();
                            }
                        }
                    }
                    catch
                    {
                        MessageBox.Show("Ha sucedido un error", "Estados", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void pictureBox2_MouseEnter(object sender, EventArgs e)
        {
            pictureBox2.ImageLocation = "C:\\Users\\Levin\\Downloads\\throbber.gif";
        }

        private void pictureBox2_MouseLeave(object sender, EventArgs e)
        {
            pictureBox2.ImageLocation = "C:\\Users\\Levin\\Downloads\\ss.png";

        }

        private void button12_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            liberar();
            ptplanilla.Visible = true;
            label8.Text = "Tipos de planilla";
            cargartplanilla();
            panel3.Size = new Size(561, 295);
            panel3.Location = new Point(189, 281);
            dataGridView1.Size = new Size(527, 263);
        }

        private void button13_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            liberar();
           pingresos.Visible = true;
            label8.Text = "Ingresos";
            cargaringresos();
            panel3.Size = new Size(561, 238);
            panel3.Location = new Point(189, 338);
            dataGridView1.Size = new Size(527, 209);
        }

        private void button16_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            liberar();
           pdescuentos.Visible = true;
            label8.Text = "Descuentos";
            cargarestados();
            panel3.Size = new Size(561, 295);
            panel3.Location = new Point(189, 281);
            dataGridView1.Size = new Size(527, 263);
        }

        private void button17_Click(object sender, EventArgs e)
        {
            if (label13.Text == "0")
            {
                if (textBox13.Text == "" || textBox14.Text == "") { MessageBox.Show("Debe llenar todos los campos", "Tipos de planilla", MessageBoxButtons.OK, MessageBoxIcon.Warning); }
                else
                {
                    try
                    {
                        using (SqlConnection cn = new SqlConnection("server=" + label12.Text + " ; database=" + label9.Text + " ; user id = sa; password='Valley';"))
                        {
                            using (SqlCommand cmd = new SqlCommand("ptipoplanilla", cn))
                            {
                                cmd.CommandType = CommandType.StoredProcedure;
                                cmd.Parameters.Add("@ttpago", SqlDbType.VarChar).Value = textBox13.Text;
                                cmd.Parameters.Add("@testado", SqlDbType.Int).Value = int.Parse(textBox14.Text);
                                cmd.Parameters.Add("@opcion", SqlDbType.Int).Value = 1;
                                cmd.Parameters.Add("@tid", SqlDbType.Int).Value = int.Parse(label13.Text);
                                cn.Open();
                                cmd.ExecuteNonQuery();
                                MessageBox.Show("Se ha agregado un nuevo tipo de planilla", "Tipos de planilla", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                cargartplanilla();
                                limpiar();
                            }
                        }
                    }
                    catch
                    {
                        MessageBox.Show("Ha sucedido un error", "Tipos de planilla", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                if (textBox13.Text == "" || textBox14.Text == "") { MessageBox.Show("Debe llenar todos los campos", "Tipos de planilla", MessageBoxButtons.OK, MessageBoxIcon.Warning); }
                else
                {
                    try
                    {
                        using (SqlConnection cn = new SqlConnection("server=" + label12.Text + " ; database=" + label9.Text + " ; user id = sa; password='Valley';"))
                        {
                            using (SqlCommand cmd = new SqlCommand("ptipoplanilla", cn))
                            {
                                cmd.CommandType = CommandType.StoredProcedure;
                                cmd.Parameters.Add("@ttpago", SqlDbType.VarChar).Value = textBox13.Text;
                                cmd.Parameters.Add("@testado", SqlDbType.Int).Value = int.Parse(textBox14.Text);
                                cmd.Parameters.Add("@opcion", SqlDbType.Int).Value = 2;
                                cmd.Parameters.Add("@tid", SqlDbType.Int).Value = int.Parse(label13.Text);
                                cn.Open();
                                cmd.ExecuteNonQuery();
                                MessageBox.Show("Tipos de planilla actualizados", "Tipos de planilla", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                button2.Text = "Agregar";
                                cargartplanilla();
                                limpiar();
                            }
                        }
                    }
                    catch
                    {
                        MessageBox.Show("Ha sucedido un error", "Tipos de planilla", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void button12_MouseEnter(object sender, EventArgs e)
        {
            button12.Text = "Tipos de planilla ➔";
        }

        private void button12_MouseLeave(object sender, EventArgs e)
        {
            button12.Text = "Tipos de planilla";
        }

        private void button13_MouseEnter(object sender, EventArgs e)
        {
            button13.Text = "Ingresos ➔";
        }

        private void button13_MouseLeave(object sender, EventArgs e)
        {
            button13.Text = "Ingresos";
        }

        private void button16_MouseEnter(object sender, EventArgs e)
        {
            button16.Text = "Descuentos ➔";
        }

        private void button16_MouseLeave(object sender, EventArgs e)
        {
            button16.Text = "Descuentos";
        }

        private void button18_Click(object sender, EventArgs e)
        {
            //ingresos
            if (label13.Text == "0")
            {
                if (textBox15.Text == "" || textBox16.Text == "" || textBox17.Text == "") { MessageBox.Show("Debe llenar todos los campos", "Ingresos", MessageBoxButtons.OK, MessageBoxIcon.Warning); }
                else
                {
                    try
                    {
                        using (SqlConnection cn = new SqlConnection("server=" + label12.Text + " ; database=" + label9.Text + " ;  user id = sa; password='Valley';"))
                        {
                            using (SqlCommand cmd = new SqlCommand("pingresos", cn))
                            {
                                cmd.CommandType = CommandType.StoredProcedure;
                                cmd.Parameters.Add("@iingresos", SqlDbType.VarChar).Value = textBox16.Text;
                                cmd.Parameters.Add("@iestado", SqlDbType.Int).Value = int.Parse(textBox17.Text);
                                cmd.Parameters.Add("@ivalor", SqlDbType.Decimal).Value = double.Parse(textBox15.Text);
                                cmd.Parameters.Add("@opcion", SqlDbType.Int).Value = 1;
                                cmd.Parameters.Add("@iid", SqlDbType.Int).Value = int.Parse(label13.Text);
                                cn.Open();
                                cmd.ExecuteNonQuery();
                                MessageBox.Show("Se ha agregado un nuevo Ingreso", "Ingresos", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                cargaringresos();
                                limpiar();
                            }
                        }
                    }
                    catch
                    {
                        MessageBox.Show("Ha sucedido un error al insertar", "Ingresos", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                if (textBox15.Text == "" || textBox16.Text == "" || textBox17.Text == "") { MessageBox.Show("Debe llenar todos los campos", "Ingresos", MessageBoxButtons.OK, MessageBoxIcon.Warning); }
                else
                {
                    try
                    {
                        using (SqlConnection cn = new SqlConnection("server=" + label12.Text + " ; database=" + label9.Text + " ;  user id = sa; password='Valley';"))
                        {
                            using (SqlCommand cmd = new SqlCommand("pingresos", cn))
                            {
                                cmd.CommandType = CommandType.StoredProcedure;
                                cmd.Parameters.Add("@iingresos", SqlDbType.VarChar).Value = textBox16.Text;
                                cmd.Parameters.Add("@iestado", SqlDbType.Int).Value = int.Parse(textBox17.Text);
                                cmd.Parameters.Add("@ivalor", SqlDbType.Decimal).Value = double.Parse(textBox15.Text);
                                cmd.Parameters.Add("@opcion", SqlDbType.Int).Value = 2;
                                cmd.Parameters.Add("@iid", SqlDbType.Int).Value = int.Parse(label13.Text);
                                cn.Open();
                                cmd.ExecuteNonQuery();
                                MessageBox.Show("Ingreso actualizado", "Ingresos", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                button2.Text = "Agregar";
                                cargaringresos();
                                limpiar();
                            }
                        }
                    }
                    catch
                    {
                        MessageBox.Show("Ha sucedido un error al actualizar", "Puestos", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void button19_Click(object sender, EventArgs e)
        {

        }
    }
}
