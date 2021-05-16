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
    public partial class tipoplanilla : Form
    {
        public tipoplanilla()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            try {
                using (SqlConnection cn = new SqlConnection("server=LEVINE-PC ; database=panaderia ; integrated security = true"))
                {
                    using (SqlCommand cmd = new SqlCommand("TipoPlanillaE", cn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.Add("@tlp_nombre", SqlDbType.VarChar).Value = nombrepg.Text;
                        cn.Open();
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Se ha agregado un nuevo tipo de planilla");
                    }
                }
            } catch {
                MessageBox.Show("Ha sucedido un error");
            }
           
        }

        private void button15_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
