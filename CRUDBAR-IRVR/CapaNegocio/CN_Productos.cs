using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using CapaDatos;

namespace CapaNegocio
{
    public class CN_Productos
    {
       
        private CD_Productos objetoCD = new CD_Productos(); 

        public DataTable LeerProd()
        {
            DataTable tabla = new DataTable();
            tabla = objetoCD.Mostar();
            return tabla;
        }

        public void InsProd(string nomPorod, string desc, string precio, string cantidad, string estado)
        {
            objetoCD.Insertar(nomPorod, desc, Convert.ToDouble(precio), Convert.ToInt32(cantidad), Convert.ToInt32(estado));

        }

        public void ActProd(string nomPorod, string desc, string precio, string cantidad, string estado, string idProd)
        {
            objetoCD.Actualizar(nomPorod, desc, Convert.ToDouble(precio), Convert.ToInt32(cantidad), Convert.ToInt32(estado), Convert.ToInt32(idProd));

        }

        public void EliProd(string idProd)
        {
            objetoCD.Borrar(Convert.ToInt32(idProd));
        }
    }
}
