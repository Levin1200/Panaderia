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
    public partial class adrecetas : Form
    {
        public adrecetas()
        {
            InitializeComponent();
        }

        private void adrecetas_Load(object sender, EventArgs e)
        {
            cargarrecetasinactivas();
        }


        private void cargarrecetasactivas()
        {
            try
            {
                using (SqlConnection cn = new SqlConnection("server=" + label12.Text + " ; database=" + label9.Text + " ; user id = sa; password='Valley';"))
                {
                    using (SqlCommand cmd = new SqlCommand("precetas", cn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@id_pan", SqlDbType.Int).Value = 1;
                        cmd.Parameters.Add("@nombrer", SqlDbType.VarChar).Value = "";
                        cmd.Parameters.Add("@codigo", SqlDbType.VarChar).Value = "1";
                        cmd.Parameters.Add("@estador", SqlDbType.Int).Value = int.Parse(label15.Text);
                        cmd.Parameters.Add("@opcion", SqlDbType.Int).Value = 4;
                        cmd.Parameters.Add("@iid", SqlDbType.Int).Value = 1;
                        cmd.Parameters.Add("@tpan", SqlDbType.Int).Value = 1;
                        cn.Open();
                        cmd.ExecuteNonQuery();
                        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                        DataSet ds = new DataSet();
                        adapter.Fill(ds);
                        dataGridView2.DataSource = ds.Tables[0];
                        // posicion(3);
                    }
                }
            }
            catch { MessageBox.Show("Ha sucedido un error", "Recetas", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }


        private void cargarrecetasinactivas()
        {
            try
            {
                using (SqlConnection cn = new SqlConnection("server=" + label12.Text + " ; database=" + label9.Text + " ; user id = sa; password='Valley';"))
                {
                    using (SqlCommand cmd = new SqlCommand("precetas", cn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@id_pan", SqlDbType.Int).Value = 1;
                        cmd.Parameters.Add("@nombrer", SqlDbType.VarChar).Value = "";
                        cmd.Parameters.Add("@codigo", SqlDbType.VarChar).Value = "1";
                        cmd.Parameters.Add("@estador", SqlDbType.Int).Value = int.Parse(label13.Text);
                        cmd.Parameters.Add("@opcion", SqlDbType.Int).Value = 4;
                        cmd.Parameters.Add("@iid", SqlDbType.Int).Value = 1;
                        cmd.Parameters.Add("@tpan", SqlDbType.Int).Value = 1;
                        cn.Open();
                        cmd.ExecuteNonQuery();
                        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                        DataSet ds = new DataSet();
                        adapter.Fill(ds);
                        dataGridView4.DataSource = ds.Tables[0];
                        // posicion(3);
                    }
                }
            }
            catch { MessageBox.Show("Ha sucedido un error", "Recetas", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private void cargardetrecetasinactivas()
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
                        cmd.Parameters.Add("@estado", SqlDbType.Int).Value = int.Parse(label13.Text);
                        cmd.Parameters.Add("@iid", SqlDbType.Int).Value = 1;
                        cmd.Parameters.Add("@totalpedido", SqlDbType.Decimal).Value = 1;
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

        private void cargardetrecetasactivas()
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
                        cmd.Parameters.Add("@estado", SqlDbType.Int).Value = int.Parse(label5.Text);
                        cmd.Parameters.Add("@iid", SqlDbType.Int).Value = 1;
                        cmd.Parameters.Add("@totalpedido", SqlDbType.Decimal).Value = 1;
                        cmd.Parameters.Add("@opcion", SqlDbType.Int).Value = 4;
                        cn.Open();
                        cmd.ExecuteNonQuery();
                        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                        DataSet ds = new DataSet();
                        adapter.Fill(ds);
                        dataGridView1.DataSource = ds.Tables[0];
                        //label17.Text = dataGridView1.Rows.Count.ToString();
                        //posicion(3);
                    }
                }
            }
            catch { MessageBox.Show("Ha sucedido un error", "Detalle Recetas", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }


        int detrecetas;
        private void dataGridView4_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            detrecetas = int.Parse(dataGridView4.CurrentRow.Cells[0].Value.ToString());
            cargardetrecetasinactivas();
        }

        private void ocultar() {
            activas.Visible = false;
            inactivas.Visible = false;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            ocultar();
            inactivas.Visible = true;
            cargarrecetasactivas();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ocultar();
            activas.Visible = true;
        }

        private void dataGridView4_CellContextMenuStripNeeded(object sender, DataGridViewCellContextMenuStripNeededEventArgs e)
        {

        }

        private void dataGridView2_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            detrecetas = int.Parse(dataGridView4.CurrentRow.Cells[0].Value.ToString());
            cargardetrecetasactivas();
        }
    }
}
