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
    public partial class recetas : Form
    {
        public recetas()
        {
            InitializeComponent();
        }
        private void posicion(int pos)
        {
            try
            {
                if (dataGridView4.Rows.Count <= 0)
                {
                    pictureBox9.Size = new Size(0, 10);
                    pictureBox10.Size = new Size(0, 10);
                }
                else
                {
                    //texto2.Text = "" + dataGridView1.CurrentRow.Cells[2].Value;
                    string estado = "";
                    int total = 0;
                    for (int i = 0; i < dataGridView4.Rows.Count; i++) { estado = "" + dataGridView4.Rows[i].Cells[pos].Value.ToString(); if (estado == "1") { total += 1; } }
                    double tt = (total * 100) / int.Parse(dataGridView4.Rows.Count.ToString());
                    double ttt = tt * 1.5;
                    int t4 = int.Parse(Math.Round(ttt, MidpointRounding.AwayFromZero).ToString());
                    pictureBox9.Size = new Size(t4, 10);
                    pictureBox10.Size = new Size(150 - t4, 10);
                }
            }
            catch { }

        }

        private void cargarrecetas()
        {
            try
            {
                using (SqlConnection cn = new SqlConnection("server=" + label12.Text + " ; database=" + label9.Text + " ; user id = sa; password='Valley';"))
                {
                    using (SqlCommand cmd = new SqlCommand("precetas", cn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@id_pan", SqlDbType.Int).Value = 1;
                        cmd.Parameters.Add("@nombrer", SqlDbType.VarChar).Value = textBox8.Text;
                        cmd.Parameters.Add("@codigo", SqlDbType.VarChar).Value = "1";
                        cmd.Parameters.Add("@estador", SqlDbType.Int).Value = 1;
                        cmd.Parameters.Add("@opcion", SqlDbType.Int).Value = 3;
                        cmd.Parameters.Add("@iid", SqlDbType.Int).Value = 1;

                        cn.Open();
                        cmd.ExecuteNonQuery();
                        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                        DataSet ds = new DataSet();
                        adapter.Fill(ds);
                        dataGridView4.DataSource = ds.Tables[0];
                        label17.Text = dataGridView4.Rows.Count.ToString();
                        posicion(3);
                    }
                }
            }
            catch { MessageBox.Show("Ha sucedido un error", "Recetas", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }
        int detrecetas=0;
        private void cargardetrecetas()
        {
            try
            {
                using (SqlConnection cn = new SqlConnection("server=" + label12.Text + " ; database=" + label9.Text + " ; user id = sa; password='Valley';"))
                {
                    using (SqlCommand cmd = new SqlCommand("pdetrecetas", cn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@id_rece", SqlDbType.Int).Value = detrecetas;
                        cmd.Parameters.Add("@codigo", SqlDbType.VarChar).Value = "1";
                        cmd.Parameters.Add("@id_ingred", SqlDbType.Int).Value = 1;
                        cmd.Parameters.Add("@cantidad", SqlDbType.Decimal).Value = 1;
                        cmd.Parameters.Add("@estado", SqlDbType.Int).Value = 1;
                        cmd.Parameters.Add("@iid", SqlDbType.Int).Value = 1;
                        cmd.Parameters.Add("@opcion", SqlDbType.Int).Value = 4;
                        cn.Open();
                        cmd.ExecuteNonQuery();
                        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                        DataSet ds = new DataSet();
                        adapter.Fill(ds);
                        dataGridView5.DataSource = ds.Tables[0];
                        //label17.Text = dataGridView1.Rows.Count.ToString();
                        //posicion(3);
                    }
                }
            }
            catch { MessageBox.Show("Ha sucedido un error", "Detalle Recetas", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private void limpiar()
        {
            textBox3.Text = "";
            textBox7.Text = "";
            textBox19.Text = "";
            textBox2.Text = "1";
            label13.Text = "0";
            label30.Text = "";
        }

       
        private void cargarpan()
        {
            try
            {
                using (SqlConnection cn = new SqlConnection("server=" + label12.Text + " ; database=" + label9.Text + " ; user id = sa; password='Valley';"))
                {
                    using (SqlCommand cmd = new SqlCommand("propan", cn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@pcod", SqlDbType.Int).Value = 1;
                        cmd.Parameters.Add("@pnom", SqlDbType.VarChar).Value = textBox4.Text;
                        cmd.Parameters.Add("@pprecio", SqlDbType.Decimal).Value = 1;
                        cmd.Parameters.Add("@pestado", SqlDbType.Int).Value = 1;
                        cmd.Parameters.Add("@opcion", SqlDbType.Int).Value = 4;
                        cmd.Parameters.Add("@pid", SqlDbType.Int).Value = 1;

                        cn.Open();
                        cmd.ExecuteNonQuery();
                        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                        DataSet ds = new DataSet();
                        adapter.Fill(ds);
                        dataGridView1.DataSource = ds.Tables[0];
                        //label17.Text = dataGridView1.Rows.Count.ToString();
                        //posicion(4);
                    }
                }
            }
            catch { MessageBox.Show("Ha sucedido un error", "Pan", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }
        private void recetas_Load(object sender, EventArgs e)
        {
            cargarpan();
        }
        private void cargaringredientes()
        {
            try
            {
                using (SqlConnection cn = new SqlConnection("server=" + label12.Text + " ; database=" + label9.Text + " ; user id = sa; password='Valley';"))
                {
                    using (SqlCommand cmd = new SqlCommand("proingredientes", cn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@icod", SqlDbType.VarChar).Value = "1";
                        cmd.Parameters.Add("@inom", SqlDbType.VarChar).Value = textBox5.Text;
                        cmd.Parameters.Add("@imedida", SqlDbType.VarChar).Value = "1";
                        cmd.Parameters.Add("@iestado", SqlDbType.Int).Value = 1;
                        cmd.Parameters.Add("@opcion", SqlDbType.Int).Value = 4;
                        cmd.Parameters.Add("@iid", SqlDbType.Int).Value = 1;

                        cn.Open();
                        cmd.ExecuteNonQuery();
                        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                        DataSet ds = new DataSet();
                        adapter.Fill(ds);
                        dataGridView2.DataSource = ds.Tables[0];
                        //label17.Text = dataGridView2.Rows.Count.ToString();
                        //posicion(4);
                    }
                }
            }
            catch { MessageBox.Show("Ha sucedido un error", "Ingredientes", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }


        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox3.Text = "" + dataGridView1.CurrentRow.Cells[0].Value;
        }
        private void ocultar() {
            receta.Visible = false;
            ingredientesreceta.Visible = false;
            allrecetas.Visible = false;
        }

        string codereceta;

        private void button19_Click(object sender, EventArgs e)
        {
            if (textBox3.Text == "" || textBox2.Text == "" || textBox19.Text == "") { MessageBox.Show("Debe llenar todos los campos", "Pan", MessageBoxButtons.OK, MessageBoxIcon.Warning); }
            else {
                ocultar();
                ingredientesreceta.Visible = true;
                cargaringredientes();
                label30.Text = "#" + textBox7.Text;
                codereceta = textBox7.Text;
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            ocultar();
            receta.Visible = true;
            label25.Text = "n/a";
            label28.Text = "Seleccione una receta para el pedido";
            textBox6.Text = "";
            textBox5.Text = "";
            button3.Enabled = false;
            limpiar();
        }

        private void dataGridView2_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            label25.Text = "" + dataGridView2.CurrentRow.Cells[0].Value;
            label28.Text = "" + dataGridView2.CurrentRow.Cells[1].Value;
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            cargaringredientes();
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            cargarpan();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            if (textBox6.Text == "" || label25.Text == "n/a" ||label28.Text == "Seleccione un pan para el pedido")
            {
                MessageBox.Show("Haga doble clic en un ingrediente, antes", "Recetas", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                try
                {
                    int cantidad = int.Parse(textBox6.Text);
                    dataGridView3.Rows.Add(codereceta, label25.Text, label28.Text, cantidad);
                    button3.Enabled = true;
                }
                catch
                {
                    MessageBox.Show("Error en la conversion", "Recetas", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            label25.Text = "n/a";
            label28.Text = "Seleccione una receta para el pedido";
            textBox6.Text = "";
        }

        private void button15_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            finalizarreceta(sender, e);
        }

        private void finalizarreceta(object sender, EventArgs e)
        {
            int error = 0;
            if (dataGridView3.Rows.Count <= 0)
            {
                MessageBox.Show("No se puede generar una receta vacia", "Receta", MessageBoxButtons.OK, MessageBoxIcon.Information);
                error = 1;
            }
            else
            {
                //Pedido

                try
                {
                    using (SqlConnection cn = new SqlConnection("server=" + label12.Text + " ; database=" + label9.Text + " ; user id = sa; password='Valley';"))
                    {
                        using (SqlCommand cmd = new SqlCommand("precetas", cn))
                        {
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.Parameters.Add("@id_pan", SqlDbType.Int).Value = int.Parse(textBox3.Text);
                            cmd.Parameters.Add("@nombrer", SqlDbType.VarChar).Value = textBox19.Text;
                            cmd.Parameters.Add("@codigo", SqlDbType.VarChar).Value = textBox7.Text;
                            cmd.Parameters.Add("@estador", SqlDbType.Int).Value = 1; ;
                            cmd.Parameters.Add("@opcion", SqlDbType.Int).Value = 1;
                            cmd.Parameters.Add("@iid", SqlDbType.Int).Value = 1;

                            cn.Open();
                            cmd.ExecuteNonQuery();
                            MessageBox.Show("Se ha agregado una nueva receta", "Recetas", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            //cargarrecetas();
                            //limpiar();
                        }
                    }
                }
                catch
                {
                    MessageBox.Show("Ha sucedido un error al insertar", "Recetas", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    error = 1;
                }
                //Detalles de la receta

                for (int i = 0; i < dataGridView3.Rows.Count; i++)
                {
                    int ingreid = int.Parse(dataGridView3.Rows[i].Cells[1].Value.ToString());
                    int cantidad = int.Parse(dataGridView3.Rows[i].Cells[3].Value.ToString());
                    try
                    {
                        using (SqlConnection cn = new SqlConnection("server=" + label12.Text + " ; database=" + label9.Text + " ; user id = sa; password='Valley';"))
                        {
                            using (SqlCommand cmd = new SqlCommand("pdetrecetas", cn))
                            {
                                cmd.CommandType = CommandType.StoredProcedure;
                                cmd.Parameters.Add("@id_rece", SqlDbType.Int).Value = 1;
                                cmd.Parameters.Add("@codigo", SqlDbType.VarChar).Value = codereceta;
                                cmd.Parameters.Add("@id_ingred", SqlDbType.Int).Value = ingreid;
                                cmd.Parameters.Add("@cantidad", SqlDbType.Decimal).Value =cantidad;
                                cmd.Parameters.Add("@estado", SqlDbType.Int).Value = 1;
                                cmd.Parameters.Add("@iid", SqlDbType.Int).Value = 1;
                                cmd.Parameters.Add("@opcion", SqlDbType.Int).Value = 1;
                                cn.Open();
                                cmd.ExecuteNonQuery();
                                //MessageBox.Show("Se ha agregado un nuevo Detalle", "Recetas", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                //limpiar();
                            }
                        }
                    }
                    catch
                    {
                        MessageBox.Show("Ha sucedido un error al insertar", "Detalle Recetas", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        error = 1;
                    }
                }

                if (error == 0)
                {
                    button4_Click(sender, e);
                }
                else
                {

                }


            }
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            label8.Text = "Nueva receta";
            button4_Click(sender, e);
            ocultar();
            receta.Visible = true;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            cargarrecetas();
            label8.Text = "Todas las recetas";
            button4_Click(sender, e);
            ocultar();
            allrecetas.Visible = true;
            dataGridView5.DataSource = null;
            dataGridView4.AutoResizeColumns();
        }

        private void dataGridView4_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            detrecetas= int.Parse(dataGridView4.CurrentRow.Cells[0].Value.ToString());
            cargardetrecetas();
        }

        private void pictureBox14_Click(object sender, EventArgs e)
        {
            cargarrecetas();
        }
    }
}
