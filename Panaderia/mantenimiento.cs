using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Panaderia
{
    public partial class mantenimiento : Form
    {
        public mantenimiento()
        {
            InitializeComponent();
        }

        private void button15_Click(object sender, EventArgs e)
        {
          
        }

        private void button12_Click(object sender, EventArgs e)
        {
            tipoplanilla tp = new tipoplanilla();
            tp.ShowDialog();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            
        }
    }
}
