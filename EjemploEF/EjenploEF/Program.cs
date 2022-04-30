using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EjenploEF
{
    internal class Program
    {
        static void Main(string[] args)
        {
            using (BarDbEntities db = new BarDbEntities())
            {
                Producto oProducto = new Producto();

                Console.WriteLine("-----Menu----");
                Console.WriteLine("1- Ver registros");
                Console.WriteLine("2- Insertar nuevo registro");
                Console.WriteLine("3- Actualizar registro");
                Console.WriteLine("4- Eliminar registro");
                Console.WriteLine("5- Salir");
                Console.WriteLine("\nSolo puede Realizar un proceso, para selecionar otra opcion inicie el programa nuevamente");
                Console.WriteLine("Elija una opcion(1,2,3,4, o 5)");

                
                string opc = Console.ReadLine();


                if (opc == "1")
                {
                    Console.WriteLine("Id   Nombre");
                    var list = db.Producto;
                    foreach (var oProductos in list)
                    {
                        Console.WriteLine(oProductos.idProducto + "   " + oProductos.nomProd);
                     
                    }
                }

                else if (opc == "2")
                {
                    //---------------Insertar datos a la Db----------------

                    Console.WriteLine("Inserte los datos");

                    Console.WriteLine("Nombre");
                    oProducto.nomProd = Console.ReadLine();
                    Console.WriteLine("Descripcion");
                    oProducto.descripcion = Console.ReadLine();
                    Console.WriteLine("Precio");
                    oProducto.precio = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("Cantidad");
                    oProducto.cantidad = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("Estado");
                    oProducto.estado = Convert.ToInt32(Console.ReadLine());

                    db.Producto.Add(oProducto);
                    db.SaveChanges();
                }
                else if (opc == "3")
                {
                    //Actalizar/
                    Producto oproducto = db.Producto.Find(1);
                    Console.WriteLine("Inserte los datos");

                    Console.WriteLine("Actualice el nombre del id 1");
                    Console.WriteLine("Nombre");
                    oProducto.nomProd = Console.ReadLine();
                    db.Entry(oproducto).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();
                }
                else if (opc == "4")
                {
                    //-----------------borrar----------------//
                    
                    Console.WriteLine("Digite el id que desea eliminar");
                    Producto oproducto = db.Producto.Find(Console.ReadLine());
                    db.Producto.Remove(oproducto);
                    db.SaveChanges();
                }

                else if(opc == "5")
                {
                    Environment.Exit(0);
                }
                else
                {
                    Console.WriteLine("Esa opcion no existe");
                }

                Console.Read();

                
            }
        }
    }
}
