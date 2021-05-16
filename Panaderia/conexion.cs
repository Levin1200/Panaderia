using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Panaderia
{
    class conexion
    {
        public SqlConnection con = new SqlConnection("server=LEVINE-PC ; database=panaderia ; integrated security = true");
        public String cone = "server=LEVINE-PC ; database=panaderia ; integrated security = true";
        public string Conex()
        {
            return cone;
        }

    }

    
}
