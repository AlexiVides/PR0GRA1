using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace CapaDatos
{
    public class CD_Conexion
    {
        public SqlConnection Conexion = new SqlConnection("server = LAPTOP-G5GPCEC8;" + "DataBase = BarDb;" + "Integrated Security = SSPI;");

        public SqlConnection AbrirConexion()
        {
            if(Conexion.State == ConnectionState.Closed)
            {
                Conexion.Open();
            }
            
            return Conexion;
        }
        public SqlConnection CerrarConexion()
        {
            if (Conexion.State == ConnectionState.Closed)
            {
                Conexion.Close();

            }
            return Conexion;
            
        }
    }
}
