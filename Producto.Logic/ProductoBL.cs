using System;
using System.Collections.Generic;
using Producto.Dominio;
using Producto.Data;



namespace Producto.Logic
{
    public static class ProductoBL
    {


        public static List<Productos> Listar()
        {
            var productoData = new ProductoData();
            return productoData.Listar();
        }


        public static Productos BuscarPorId(int id)
        {
             var prodData = new ProductoData();
            return prodData.BuscarPorId(id);
   

        }


        public static bool Insertar(Productos producto)
        {
            var prodData = new ProductoData();
            if (producto.Stock <=5)
            {

                producto.Stock = 0;

            }


            if (producto.Precio > 2500)
            {

                producto.Precio = 0;

            }
            else
            {
             
                return prodData.Insertar(producto);
            }


            return prodData.Insertar(producto);
        }

        public static bool Actualizar(Productos productos)
        {

            var prodData = new ProductoData();
            return prodData.Actualizar(productos);
        }

        public static bool Eliminar(int id)
        {
            var prodData = new ProductoData();
            return prodData.Eliminar(id);

        }

    }
}
