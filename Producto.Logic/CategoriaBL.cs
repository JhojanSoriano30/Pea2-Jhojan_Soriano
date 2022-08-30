using System;
using System.Collections.Generic;
using System.Text;
using Producto.Dominio;
using Producto.Data;

namespace Producto.Logic
{
    public static class CategoriaBL
    {

        public static List<Categoria> Listar()
        {
            var tipoCatData = new CategoriaData();
            return tipoCatData.Listar();
        }
    }
}
