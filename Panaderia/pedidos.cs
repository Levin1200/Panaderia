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
    public partial class pedidos : Form
    {
        public pedidos()
        {
            InitializeComponent();
        }

        string pedido;
        private void button15_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void limpiar() {
            textBox5.Text = "";
            textBox19.Text = "";
            textBox2.Text = "";
            button3.Enabled = false;
            label30.Text = "";
            label25.Text = "n/a";
            label26.Text = "n/a";
            label28.Text = "Seleccione un pan para el pedido";
            textBox6.Text = "";
        }

        private void liberar() {
            realizarpedido.Visible = false;
            panpedido.Visible = false;
            reviewpedido.Visible = false;
            panel3.Visible = false;
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            limpiar();
        }

        private void button19_Click(object sender, EventArgs e)
        {

            if (textBox19.Text == "" || textBox2.Text == "")
            {
                label30.Text = "#" + textBox19.Text;
                pedido = textBox19.Text;
                realizarpedido.Visible = false;
                panpedido.Visible = true;
                cargarpan();
            }
            else {
                MessageBox.Show("Debe llenar todos los campos", "Pedidos", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            limpiar();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            limpiar();
            panpedido.Visible = false;
            realizarpedido.Visible = true;
            dataGridView3.Rows.Clear();
          
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            cargarpan();
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
                        cmd.Parameters.Add("@pnom", SqlDbType.VarChar).Value = textBox5.Text;
                        cmd.Parameters.Add("@pprecio", SqlDbType.Decimal).Value = 1;
                        cmd.Parameters.Add("@pestado", SqlDbType.Int).Value = 1;
                        cmd.Parameters.Add("@opcion", SqlDbType.Int).Value = 4;
                        cmd.Parameters.Add("@pid", SqlDbType.Int).Value = 1;
                        cn.Open();
                        cmd.ExecuteNonQuery();
                        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                        DataSet ds = new DataSet();
                        adapter.Fill(ds);
                        dataGridView2.DataSource = ds.Tables[0];
                        label17.Text = dataGridView1.Rows.Count.ToString();
                    }
                }
            }
            catch { MessageBox.Show("Ha sucedido un error", "Pan", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private void pedidos_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView2_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            button3.Enabled = true;
            label25.Text = "" + dataGridView2.CurrentRow.Cells[0].Value;
            label28.Text = "" + dataGridView2.CurrentRow.Cells[1].Value;
            label26.Text = "" + dataGridView2.CurrentRow.Cells[2].Value;
        }

        private void button6_Click(object sender, EventArgs e)
        {
          
        }

        private void button9_Click(object sender, EventArgs e)
        {


            if (textBox6.Text == "" || label25.Text == "n/a" || label26.Text == "n/a" ||label28.Text == "Seleccione un pan para el pedido")
            {
                MessageBox.Show("Haga doble clic en un pan, antes", "Pedidos", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else {
                try
                {
                    int cantidad = int.Parse(textBox6.Text);
                    double precio = double.Parse(label26.Text);
                    double total = cantidad * precio;
                    dataGridView3.Rows.Add(pedido, label25.Text,label28.Text,""+cantidad,""+total);
                }
                catch
                {
                    MessageBox.Show("Error en la conversion", "Pedidos", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            
        }

        private void dataGridView3_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            eliminarcelda();
        }

        private void eliminarcelda() {
            if (dataGridView3.CurrentRow == null) { }
            else
            {
                dataGridView3.Rows.RemoveAt(dataGridView3.CurrentRow.Index);
            }
        }
        private void dataGridView3_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Back)
            {
                eliminarcelda();
            }
        }

        private void textBox19_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                button19_Click(sender, e);
                e.Handled = true;
            }
        }

        private void textBox5_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                cargarpan();
                e.Handled = true;
            }
        }
    }
}
