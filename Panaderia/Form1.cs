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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            sesion se = new sesion();
            se.ShowDialog();
           principal bc = new principal();
            bc.MdiParent = this;
            bc.Show();
            Region rg;
            System.Drawing.Drawing2D.GraphicsPath gp = new System.Drawing.Drawing2D.GraphicsPath();
            gp.AddEllipse(0, 0, pictureBox47.Width - 1, pictureBox47.Height - 1);
            rg = new Region(gp);
            pictureBox47.Region = rg;

        }

        private void button4_Click(object sender, EventArgs e)
        {
            SqlConnection conexion = new SqlConnection("server=LEVINE-PC ; database=panaderia ; integrated security = true");
            conexion.Open();
            MessageBox.Show("Se abrió la conexión con el servidor SQL Server y se seleccionó la base de datos");
            conexion.Close();
            MessageBox.Show("Se cerró la conexión.");
        }

        private void button5_Click(object sender, EventArgs e)
        {
           
        }

        private void button10_Click(object sender, EventArgs e)
        {
           
        }

        private void pictureBox47_Click(object sender, EventArgs e)
        {
            if (panel1.Visible == true)
            {
                panel1.Visible = false;
            }
            else {
                panel1.Visible = true;
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {
            Application.Restart();
        }

        private void label3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
