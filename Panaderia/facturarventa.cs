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
using System.IO;
using System.Drawing.Imaging;
using System.Drawing.Printing;

namespace Panaderia
{
    public partial class facturarventa : Form
    {
        PrintDocument printdoc1 = new PrintDocument();
        PrintPreviewDialog previewdlg = new PrintPreviewDialog();
        Panel pannel = null;
        public facturarventa()
        {
            InitializeComponent();
            printdoc1.PrintPage += new PrintPageEventHandler(printdoc1_PrintPage);
        }


        Bitmap MemoryImage;
        public void GetPrintArea(Panel pnl)
        {
            MemoryImage = new Bitmap(pnl.Width, pnl.Height);
            pnl.DrawToBitmap(MemoryImage, new Rectangle(0, 0, pnl.Width, pnl.Height));
        }
        protected override void OnPaint(PaintEventArgs e)
        {
            if (MemoryImage != null)
            {
                e.Graphics.DrawImage(MemoryImage, 0, 0);
                base.OnPaint(e);
            }
        }
        void printdoc1_PrintPage(object sender, PrintPageEventArgs e)
        {
            Rectangle pagearea = e.PageBounds;
            e.Graphics.DrawImage(MemoryImage, (pagearea.Width / 2) - (this.panel1.Width / 2), this.panel1.Location.Y);
        }
        public void Print(Panel pnl)
        {
            pannel = pnl;
            GetPrintArea(pnl);
            previewdlg.Document = printdoc1;
            previewdlg.ShowDialog();
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
                        cmd.Parameters.Add("@idsucur", SqlDbType.Int).Value = 1;
                        cmd.Parameters.Add("@opcion", SqlDbType.Int).Value = 6;
                        cn.Open();
                        cmd.ExecuteNonQuery();
                        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                        DataSet ds = new DataSet();
                        adapter.Fill(ds);
                        dataGridView1.DataSource = ds.Tables[0];
                        label17.Text = dataGridView1.Rows.Count.ToString();
                        //posicion(4);
                    }
                }
            }
            catch { MessageBox.Show("Ha sucedido un error", "Compras", MessageBoxButtons.OK, MessageBoxIcon.Error); }
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
                        cmd.Parameters.Add("@id", SqlDbType.Int).Value = 1; ; //int.Parse(label13.Text);
                        cmd.Parameters.Add("@codfact", SqlDbType.VarChar).Value = "1";
                        cmd.Parameters.Add("@idsucur", SqlDbType.Int).Value = 1;
                        cmd.Parameters.Add("@idpan", SqlDbType.Int).Value = detventas;
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
        private void pictureBox14_Click(object sender, EventArgs e)
        {
            cargarventa();
            dataGridView5.DataSource = null;
        }

        int detventas;
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            detventas = int.Parse(dataGridView1.CurrentRow.Cells[0].Value.ToString());
            cargardetventas();
            label37.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            label19.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            label18.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            label17.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
            allpedidos.Visible = false;
            factura.Visible = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            allpedidos.Visible = true;
            factura.Visible = false;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Print(this.factura);
        }

        private void facturarventa_Load(object sender, EventArgs e)
        {
            cargarventa();
        }

        private void button15_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
