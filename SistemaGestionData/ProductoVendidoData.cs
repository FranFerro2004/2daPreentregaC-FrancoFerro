using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SistemaGestionEntidades;

namespace SistemaGestionData
{
    public static class ProductoVendidoData
    {
        public static List<ProductoVendido> ObtenerProductoVendido(int IdProductoVendido)
        {
            List<ProductoVendido> lista = new List<ProductoVendido>();

            string connectionString = @"Server=localhost\SQLEXPRESS;Database=master;Trusted_Connection=True;";
            var query = "SELECT Id, IdProducto, Stock, IdVenta FROM ProductosVendidos WHERE Id = @IdProductoVendido";

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

        public static List<ProductoVendido> ListarProductosVendidos()
        {
            List<ProductoVendido> lista = new List<ProductoVendido>();

            string connectionString = @"Server=localhost\SQLEXPRESS;Database=master;Trusted_Connection=True;";
            var query = "SELECT Id, IdProducto, Stock, IdVenta FROM ProductosVendidos";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                using (SqlCommand comando = new SqlCommand(query, connection))
                {
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

        public static void CrearProductoVendido(ProductoVendido productoVendido)
        {
            string connectionString = @"Server=localhost\SQLEXPRESS;Database=master;Trusted_Connection=True;";
            var query = "INSERT INTO ProductosVendidos (IdProducto, Stock, IdVenta) VALUES (@IdProducto, @Stock, @IdVenta)";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                using (SqlCommand comando = new SqlCommand(query, connection))
                {
                    comando.Parameters.Add(new SqlParameter("@IdProducto", SqlDbType.Int) { Value = productoVendido.IdProducto });
                    comando.Parameters.Add(new SqlParameter("@Stock", SqlDbType.Int) { Value = productoVendido.Stock });

                    comando.ExecuteNonQuery();
                }

                connection.Close();
            }
        }

        public static void ModificarProductoVendido(ProductoVendido productoVendido)
        {
            string connectionString = @"Server=localhost\SQLEXPRESS;Database=master;Trusted_Connection=True;";
            var query = "UPDATE ProductosVendidos SET IdProducto = @IdProducto, Stock = @Stock, IdVenta = @IdVenta WHERE Id = @Id";

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
            string connectionString = @"Server=localhost\SQLEXPRESS;Database=master;Trusted_Connection=True;";
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