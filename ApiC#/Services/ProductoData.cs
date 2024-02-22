
using System.Data.SqlClient;
using System.Data;
using ApiC_.Models;

namespace ProductoData
{

    public static class ProductoData
    {
        public static List<Producto> ObtenerProducto(int IdProducto)
        {
            List<Producto> lista = new List<Producto>();

            string connectionString = @"Server=localhost\SQLEXPRESS;Database=master;Trusted_Connection=True;";
            var query = "SELECT Id, Descripcion, Costo, PrecioVenta, Stock, Idusuario FROM Productos WHERE Id =@IdProducto; ";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                using (SqlCommand comando = new SqlCommand(query, connection))
                {

                    var parametro = new SqlParameter();
                    parametro.ParameterName = "IdProducto";
                    parametro.SqlDbType = SqlDbType.Int;
                    parametro.Value = IdProducto;

                    comando.Parameters.Add(parametro);

                    using (SqlDataReader dr = comando.ExecuteReader())
                    {
                        if (dr.HasRows)
                        {

                            while (dr.Read())
                            {
                                var producto = new Producto();
                                producto.Id = Convert.ToInt32(dr["Id"]);
                                producto.Descripcion = dr["Descripcion"].ToString();
                                producto.Costo = Convert.ToDouble(dr["Costo"]);
                                producto.PrecioVenta = Convert.ToInt32(dr["PrecioVenta"]);
                                producto.Stock = Convert.ToInt32(dr["Stock"]);
                                producto.IdUsuario = Convert.ToInt32(dr["IdUsuario"]);
                                lista.Add(producto);

                            }

                        }

                    }

                }
                connection.Close();
            }
            return lista;
        }



        public static List<Producto> ListarProductos()
        {

            List<Producto> lista = new List<Producto>();
            string connectionString = @"Server=localhost\SQLEXPRESS;Database=master;Trusted_Connection=True;";
            var query = "SELECT Id, Descripcion, Costo, PrecioVenta, Stock, IdUsuario FROM Productos";

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
                                var producto = new Producto();
                                producto.Id = Convert.ToInt32(dr["Id"]);
                                producto.Descripcion = dr["Descripcion"].ToString();
                                producto.Costo = Convert.ToDouble(dr["Costo"]);
                                producto.PrecioVenta = Convert.ToInt32(dr["PrecioVenta"]);
                                producto.Stock = Convert.ToInt32(dr["Stock"]);
                                producto.IdUsuario = Convert.ToInt32(dr["IdUsuario"]);
                                lista.Add(producto);

                            }

                        }

                    }

                }
                connection.Close();

            }
            return lista;

        }



        public static void CrearProducto(Producto producto)
        {
            string connectionString = @"Server=localhost\SQLEXPRESS;Database=master;Trusted_Connection=True;";
            var query = "INSERT INTO Productos (Descripcion,Costo,PrecioVenta,Stock,IdUsuario)" +
                        "Values(@Descripcion,@Costo,@PrecioVenta,@Stock,@IdUsuario)";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                using (SqlCommand comando = new SqlCommand(query, connection))
                {
                    comando.Parameters.Add(new SqlParameter("Descripcion", SqlDbType.VarChar) { Value = producto.Descripcion });
                    comando.Parameters.Add(new SqlParameter("Costo", SqlDbType.Float) { Value = producto.Costo });
                    comando.Parameters.Add(new SqlParameter("PrecioVenta", SqlDbType.Float) { Value = producto.PrecioVenta });
                    comando.Parameters.Add(new SqlParameter("Stock", SqlDbType.BigInt) { Value = producto.Stock });
                    comando.Parameters.Add(new SqlParameter("IdUsuario", SqlDbType.BigInt) { Value = producto.IdUsuario });

                    comando.ExecuteNonQuery();
                }

                connection.Close();

            }

        }


        public static bool ModificarProducto(Producto producto)
        {
            try
            {
                string connectionString = @"Server=localhost\SQLEXPRESS;Database=master;Trusted_Connection=True;";
                var query = "UPDATE Productos " +
                            "SET Descripcion = @Descripcion, " +
                            "Costo = @Costo, " +
                            "PrecioVenta = @PrecioVenta, " +
                            "Stock = @Stock, " +
                            "IdUsuario = @IdUsuario " +
                            "WHERE Id = @Id";

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    using (SqlCommand comando = new SqlCommand(query, connection))
                    {
                        comando.Parameters.Add(new SqlParameter("@Id", SqlDbType.Int) { Value = producto.Id });
                        comando.Parameters.Add(new SqlParameter("@Descripcion", SqlDbType.VarChar) { Value = producto.Descripcion });
                        comando.Parameters.Add(new SqlParameter("@Costo", SqlDbType.Float) { Value = producto.Costo });
                        comando.Parameters.Add(new SqlParameter("@PrecioVenta", SqlDbType.Float) { Value = producto.PrecioVenta });
                        comando.Parameters.Add(new SqlParameter("@Stock", SqlDbType.BigInt) { Value = producto.Stock });
                        comando.Parameters.Add(new SqlParameter("@IdUsuario", SqlDbType.BigInt) { Value = producto.IdUsuario });

                        comando.ExecuteNonQuery();
                    }

                    connection.Close();
                }

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }




        public static void EliminarProducto(Producto Producto)
        {
            string connectionString = @"Server=localhost\SQLEXPRESS;Database=master;Trusted_Connection=True;";
            var query = "DELETE FROM Productos WHERE id = @id";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                using (SqlCommand comando = new SqlCommand(query, connection))
                {
                    comando.Parameters.Add(new SqlParameter("Id", SqlDbType.BigInt) { Value = Producto.Id });

                    comando.ExecuteNonQuery();
                }
                connection.Close();
            }

        }

    }

}
