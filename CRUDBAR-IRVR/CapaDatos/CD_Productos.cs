using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace CapaDatos
{
    public class CD_Productos
    {
        public CD_Conexion conexion = new CD_Conexion();

        SqlDataReader leer;
        DataTable tablar = new DataTable();
        SqlCommand comando = new SqlCommand();

        public DataTable Mostar()
        {
            comando.Connection = conexion.AbrirConexion();
            comando.CommandText = "LeerProductos";
            comando.CommandType = CommandType.StoredProcedure;
            leer = comando.ExecuteReader();
            tablar.Load(leer);
            conexion.CerrarConexion();
            return tablar;  

        }

        public void Insertar(string nombre, string desc, double precio,int cantidad, int estado)
        {
            //Insertar datos a la Db

            comando.Connection = conexion.AbrirConexion();
            comando.CommandText = "InsertarProductos";
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@nomprod", nombre);
            comando.Parameters.AddWithValue("@descripcion", desc);
            comando.Parameters.AddWithValue("@precio", precio);
            comando.Parameters.AddWithValue("@cantidad", cantidad);
            comando.Parameters.AddWithValue("@estado", estado);

            comando.ExecuteNonQuery();
            comando.Parameters.Clear(); 

        }

        public void Actualizar(string nombre, string desc, double precio, int cantidad, int estado, int idProducto)
        {
            //Actualizar datos en la Db

            comando.Connection = conexion.AbrirConexion();
            comando.CommandText = "ActualizarProductos";
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@idproducto", idProducto);
            comando.Parameters.AddWithValue("@nomprod", nombre);
            comando.Parameters.AddWithValue("@descripcion", desc);
            comando.Parameters.AddWithValue("@precio", precio);
            comando.Parameters.AddWithValue("@cantidad", cantidad);
            comando.Parameters.AddWithValue("@estado", estado);
            

            comando.ExecuteNonQuery();
            comando.Parameters.Clear();

        }

        public void Borrar(int idProducto)
        {
            //Actualizar datos en la Db

            comando.Connection = conexion.AbrirConexion();
            comando.CommandText = "EliminarProductos";
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@idprod", idProducto);

            comando.ExecuteNonQuery();
            comando.Parameters.Clear();

        }
    }
}
