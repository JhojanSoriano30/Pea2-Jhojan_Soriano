using System;

namespace Producto.Dominio
{
    public class Productos
    {        
        
        
        public int ID { get; set; }
        public string Nombres { get; set; }
        public string Marca { get; set; }
        public double Precio { get; set; }
        public int Stock { get; set; }
        public string Categoriaa { get; set; }
        public string Observacion { get; set; }
        public string Foto { get; set; }
        public int IdCategoria { get; set; }

    }
}
