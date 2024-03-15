using System.Data.SqlClient;
using System.Data;
using SistemaGestionEntidades;
using System;

namespace SistemaGestionData
{
    public static class ProductoVendidoData
    {
        public static List<ProductoVendido> ObtenerProductoVendido(int IdProductoVendido)
        {
            List<ProductoVendido> lista = new List<ProductoVendido>();

            string connectionString = @"Server=localhost\SQLEXPRESS;Database=coderhouse;Trusted_Connection=True;";
            var query = "SELECT Id, IdProducto, Stock, IdVenta FROM ProductoVendido WHERE Id = @IdProductoVendido";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                using (SqlCommand comando = new SqlCommand(query, connection))
                {
                    var parametro = new SqlParameter();
                    parametro.ParameterName = "IdProductoVendido";
                    parametro.SqlDbType = SqlDbType.Int;
                    parametro.Value = IdProductoVendido;

                    comando.Parameters.Add(parametro);

                    using (SqlDataReader dr = comando.ExecuteReader())
                    {
                        if (dr.HasRows)
                        {
                            while (dr.Read())
                            {
                                var productoVendido = new ProductoVendido();
                                productoVendido.ID = Convert.ToInt32(dr["Id"]);
                                productoVendido.IdProducto = Convert.ToInt32(dr["IdProducto"]);
                                productoVendido.Stock = Convert.ToInt32(dr["Stock"]);
                                productoVendido.IDVenta = Convert.ToInt32(dr["IdVenta"]);
                                lista.Add(productoVendido);
                            }
                        }
                    }
                }
                connection.Close();
            }
            return lista;
        }

        public static List<ProductoVendido> ListarProductosVendidos(int idUsuario)
        {
            List<ProductoVendido> lista = new List<ProductoVendido>();

            string connectionString = @"Server=localhost\SQLEXPRESS;Database=coderhouse;Trusted_Connection=True;";
            var query = @"SELECT ProductoVendido.Id, ProductoVendido.IdProducto, ProductoVendido.Stock, ProductoVendido.IdVenta 
                        FROM ProductoVendido
                        INNER JOIN Venta ON ProductoVendido.IdVenta = Venta.Id
                        WHERE Venta.IdUsuario = @idUsuario";


            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                using (SqlCommand comando = new SqlCommand(query, connection))
                {

                    comando.Parameters.Add(new SqlParameter("@idUsuario", SqlDbType.Int) { Value = idUsuario });


                    using (SqlDataReader dr = comando.ExecuteReader())
                    {
                        if (dr.HasRows)
                        {
                            while (dr.Read())
                            {
                                var productoVendido = new ProductoVendido();
                                productoVendido.ID = Convert.ToInt32(dr["Id"]);
                                productoVendido.IdProducto = Convert.ToInt32(dr["IdProducto"]);
                                productoVendido.Stock = Convert.ToInt32(dr["Stock"]);
                                productoVendido.IDVenta = Convert.ToInt32(dr["IdVenta"]);
                                lista.Add(productoVendido);
                            }
                        }
                    }
                }
                connection.Close();
            }
            return lista;
        }

        public static void CrearProductoVendido(int idVenta, List<Producto> productos)
        {
            string connectionString = @"Server=localhost\SQLEXPRESS;Database=coderhouse;Trusted_Connection=True;";
            var query = "INSERT INTO ProductoVendido (IdProducto, Stock, IdVenta) VALUES (@IdProducto, @Stock, @IdVenta)";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                foreach (var producto in productos)
                {
                    using (SqlCommand comando = new SqlCommand(query, connection))
                    {
                        comando.Parameters.Add(new SqlParameter("@IdProducto", SqlDbType.Int) { Value = producto.Id });
                        comando.Parameters.Add(new SqlParameter("@Stock", SqlDbType.Int) { Value = producto.Stock });
                        comando.Parameters.Add(new SqlParameter("@IdVenta", SqlDbType.Int) { Value = idVenta });

                        comando.ExecuteNonQuery();
                    }
                }

                connection.Close();
            }
        }



        public static void ModificarProductoVendido(ProductoVendido productoVendido)
        {
            string connectionString = @"Server=localhost\SQLEXPRESS;Database=coderhouse;Trusted_Connection=True;";
            var query = "UPDATE ProductoVendido SET IdProducto = @IdProducto, Stock = @Stock, IdVenta = @IdVenta WHERE Id = @Id";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                using (SqlCommand comando = new SqlCommand(query, connection))
                {
                    comando.Parameters.Add(new SqlParameter("@Id", SqlDbType.Int) { Value = productoVendido.ID });
                    comando.Parameters.Add(new SqlParameter("@IdProducto", SqlDbType.Int) { Value = productoVendido.IdProducto });
                    comando.Parameters.Add(new SqlParameter("@Stock", SqlDbType.Int) { Value = productoVendido.Stock });

                    comando.ExecuteNonQuery();
                }

                connection.Close();
            }
        }

        public static void EliminarProductoVendido(ProductoVendido productoVendido)
        {
            string connectionString = @"Server=localhost\SQLEXPRESS;Database=coderhouse;Trusted_Connection=True;";
            var query = "DELETE FROM ProductosVendidos WHERE Id = @Id";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                using (SqlCommand comando = new SqlCommand(query, connection))
                {
                    comando.Parameters.Add(new SqlParameter("@Id", SqlDbType.Int) { Value = productoVendido.ID });

                    comando.ExecuteNonQuery();
                }
                connection.Close();
            }
        }
    }

}