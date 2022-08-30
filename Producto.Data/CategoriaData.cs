using System;
using System.Collections.Generic;
using Producto.Dominio;
using System.Text;
using System.Data.SqlClient;

namespace Producto.Data
{
    public class CategoriaData
    {

        string caddenaConexion = "server=PC303\\PAREDES; Database=Parcial; Integrated Security = true";

        public List<Categoria> Listar()
        {
            var listado = new List<Categoria>();

            using (var conexion = new SqlConnection(caddenaConexion))
            {
                conexion.Open();
                using (var comando = new SqlCommand("Select * from Categoria", conexion))
                {
                    using (var lector = comando.ExecuteReader())
                    {
                        if (lector != null && lector.HasRows)
                        {
                            Categoria tipo;
                            while (lector.Read())
                            {
                                tipo = new Categoria();
                                tipo.IDC = int.Parse(lector[0].ToString());
                                tipo.Nombre = lector[2].ToString();

                                listado.Add(tipo);

                            }

                        }

                    }

                }

            }

            return listado;
        }

        public Categoria BuscarPorId(int id)
        {
            var tipoCat = new Categoria();
            return tipoCat;
        }

        public bool Insertar()
        {
            return true;
        }


    }
}
