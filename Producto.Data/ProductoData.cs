using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using Producto.Dominio;

namespace Producto.Data
{
    public class ProductoData
    {

        string cadenaConexion = "server=PC303\\PAREDES; Database=Parcial; Integrated Security = true";
        public List<Productos> Listar()
        {
            var listado = new List<Productos>();
            using (var conexion = new SqlConnection(cadenaConexion))
            {
                conexion.Open();
                using (var comando = new SqlCommand("select Producto.IdProducto, Producto.Nombre, Marca, precio,  Categoria.Nombre as Categoría," +
                    " Stock from Producto inner join Categoria on Producto.IdCategoria = Categoria.IdCategoria", conexion))
                {
                    using (var lector = comando.ExecuteReader())
                    {
                        if (lector != null && lector.HasRows)
                        {
                            Productos producto;
                            while (lector.Read())
                            {
                                producto = new Productos();
                                producto.ID = int.Parse(lector[0].ToString());
                                producto.Nombres = lector[1].ToString();
                                producto.Marca = lector[2].ToString();
                                producto.Precio = double.Parse(lector[3].ToString());
                               producto.Categoriaa = lector[4].ToString();
                                producto.Stock = int.Parse(lector[5].ToString());
                                //producto.Observacion = lector[6].ToString();
                                //producto.Foto = lector[7].ToString();
                                //producto.IdCategoria = int.Parse(lector[8].ToString());

                                listado.Add(producto);
                            }
                        }
                    }
                }
            }
            return listado;
        }








        public Productos BuscarPorId(int id)
        {
            var producto = new Productos();


            using (var conexion = new SqlConnection(cadenaConexion))
            {

                conexion.Open();
                using (var comando = new SqlCommand("Select * from Producto where IdProducto = @id", conexion))
                {

                    comando.Parameters.AddWithValue("@id", id);
                    using (var lector = comando.ExecuteReader())
                    {

                        if (lector != null && lector.HasRows)
                        {
                            lector.Read();
                            //producto = new Productos();


                            producto = new Productos();
                            producto.ID = int.Parse(lector[0].ToString());
                            producto.Nombres = lector[1].ToString();
                            producto.Marca = lector[2].ToString();
                            producto.Precio = double.Parse(lector[3].ToString());
                          //  producto.Categoriaa = lector[4].ToString();
                            producto.Stock = int.Parse(lector[4].ToString());
                            producto.Observacion = lector[5].ToString();
                            producto.Foto = lector[6].ToString();
                            producto.IdCategoria = int.Parse(lector[7].ToString());




                        }
                    }

                }

            }
            return producto;
        }









        public bool Insertar(Productos cliente)
        {
            int filasInsertadas = 0;
            using (var conexion = new SqlConnection(cadenaConexion))
            {
                conexion.Open();
                var sql = "INSERT INTO Producto(Nombre, marca, Precio, Stock, IdCategoria)" +
                    "VALUES(@Nombre,@marca, @precio, @stock,@IdCategoria)";

                using (var comando = new SqlCommand(sql, conexion))
                {

                    comando.Parameters.AddWithValue("@Nombre", cliente.Nombres);
                    comando.Parameters.AddWithValue("@marca", cliente.Marca);
                    comando.Parameters.AddWithValue("@precio", cliente.Precio);
                    comando.Parameters.AddWithValue("@stock", cliente.Stock);
                    //comando.Parameters.AddWithValue("@observacion", cliente.Observacion);
                    //comando.Parameters.AddWithValue("@foto", cliente.Foto);
                    comando.Parameters.AddWithValue("@IdCategoria", cliente.IdCategoria);
                 
                    filasInsertadas = comando.ExecuteNonQuery();

                }

            }

            return filasInsertadas > 0;
        }





        public bool Actualizar(Productos cliente)
        {
            int filasActualizadas = 0;
            using (var conexion = new SqlConnection(cadenaConexion))
            {
                conexion.Open();
                var sql = "UPDATE Producto SET Nombre = @Nombres, marca = @marca, " +
                    "Precio = @precio, Stock = @stock, " +
                    "IdCategoria = @idCat WHERE IdProducto = @idPr";
                using (var comando = new SqlCommand(sql, conexion))
                {

                    comando.Parameters.AddWithValue("@Nombres", cliente.Nombres);
                    comando.Parameters.AddWithValue("@marca", cliente.Marca);
                    comando.Parameters.AddWithValue("@precio", cliente.Precio);
                    comando.Parameters.AddWithValue("@stock", cliente.Stock);
                    //comando.Parameters.AddWithValue("@observ", cliente.Observacion);
                    //comando.Parameters.AddWithValue("@foto", cliente.Foto);
                    comando.Parameters.AddWithValue("@idCat", cliente.IdCategoria);
                    comando.Parameters.AddWithValue("@idPr", cliente.ID);

                    filasActualizadas = comando.ExecuteNonQuery();

                }

            }
            return filasActualizadas > 0;
        }








        public bool Eliminar(int id)
        {

            int filasEliminadas = 0;
            using (var conexion = new SqlConnection(cadenaConexion))
            {
                conexion.Open();
                var sql = "DELETE FROM Producto where IdProducto = @id";
                using (var comando = new SqlCommand(sql, conexion))
                {

                    comando.Parameters.AddWithValue("@id", id);
                    filasEliminadas = comando.ExecuteNonQuery();

                }
            }

            return filasEliminadas > 0;
        }





    }
}
