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
    public partial class ventashoy : Form
    {
        public ventashoy()
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
        private void cargarventa()
        {
            try
            {
                using (SqlConnection cn = new SqlConnection("server=" + label12.Text + " ; database=" + label9.Text + " ; user id = sa; password='Valley';"))
                {
                    using (SqlCommand cmd = new SqlCommand("proventas", cn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@id", SqlDbType.Int).Value = 1; //int.Parse(label13.Text);
                        cmd.Parameters.Add("@codfact", SqlDbType.VarChar).Value = textBox8.Text;
                        cmd.Parameters.Add("@idcli", SqlDbType.Int).Value = 1;
                        cmd.Parameters.Add("@tpago", SqlDbType.Int).Value = 1;
                        cmd.Parameters.Add("@idusu", SqlDbType.Int).Value = int.Parse(label7.Text);
                        cmd.Parameters.Add("@tot", SqlDbType.Decimal).Value = 1;
                        cmd.Parameters.Add("@idsucur", SqlDbType.Int).Value = int.Parse(label60.Text);
                        cmd.Parameters.Add("@opcion", SqlDbType.Int).Value = 4;
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
            catch { MessageBox.Show("Ha sucedido un error", "Compras", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }
        private void ventashoy_Load(object sender, EventArgs e)
        {
            cargarventa();
        }
        private void cargardetventas()
        {
            try
            {
                using (SqlConnection cn = new SqlConnection("server=" + label12.Text + " ; database=" + label9.Text + " ; user id = sa; password='Valley';"))
                {
                    using (SqlCommand cmd = new SqlCommand("prodetventas", cn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@id", SqlDbType.Int).Value = detventas; //int.Parse(label13.Text);
                        cmd.Parameters.Add("@codfact", SqlDbType.VarChar).Value = "";
                        cmd.Parameters.Add("@idsucur", SqlDbType.Int).Value = int.Parse(label22.Text);
                        cmd.Parameters.Add("@idpan", SqlDbType.Int).Value = 1;
                        cmd.Parameters.Add("@cantidad", SqlDbType.Int).Value = 1;
                        cmd.Parameters.Add("@precio", SqlDbType.Decimal).Value = 1;
                        cmd.Parameters.Add("@opcion", SqlDbType.Int).Value = 4;
                        cmd.Parameters.Add("@bodeg", SqlDbType.Int).Value = 1;

                        cn.Open();
                        cmd.ExecuteNonQuery();
                        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                        DataSet ds = new DataSet();
                        adapter.Fill(ds);
                        dataGridView5.DataSource = ds.Tables[0];
                    }
                }
            }
            catch { MessageBox.Show("Ha sucedido un error", "Detalle Compras", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }
        int detventas;
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            detventas = int.Parse(dataGridView1.CurrentRow.Cells[0].Value.ToString());
            cargardetventas();
        }

        private void pictureBox14_Click(object sender, EventArgs e)
        {
            cargarventa();
        }

        private void button15_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
