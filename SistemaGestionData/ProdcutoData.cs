using SistemaGestionEntidades;
using System.Data.SqlClient;
using System.Data;
using static SistemaGestionData.ProductoVendidoData;


namespace SistemaGestionData
{

    public static class ProductoData
    {
        public static List<Producto> ObtenerProducto(int IdProducto)
        {
            List<Producto> lista = new List<Producto>();

            string connectionString = @"Server=localhost\SQLEXPRESS;Database=coderhouse;Trusted_Connection=True;";
            var query = "SELECT Id, Descripciones, Costo, PrecioVenta, Stock, Idusuario FROM Producto WHERE Id =@IdProducto; ";

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
                                producto.Descripcion = dr["Descripciones"].ToString();
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



        public static List<Producto> ListarProductosPorIdUsuario(int idUsuario)
        {

            List<Producto> lista = new List<Producto>();
            string connectionString = @"Server=localhost\SQLEXPRESS;Database=coderhouse;Trusted_Connection=True;";
            var query = "SELECT Id, Descripciones, Costo, PrecioVenta, Stock, IdUsuario FROM Producto WHERE idUsuario = @idUsuario";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                using (SqlCommand comando = new SqlCommand(query, connection))

                {

                    var parametro = new SqlParameter();
                    parametro.ParameterName = "IdUsuario";
                    parametro.SqlDbType = SqlDbType.Int;
                    parametro.Value = idUsuario;

                    using (SqlDataReader dr = comando.ExecuteReader())
                    {
                        if (dr.HasRows)

                        {
                            while (dr.Read())
                            {
                                var producto = new Producto();
                                producto.Id = Convert.ToInt32(dr["Id"]);
                                producto.Descripcion = dr["Descripciones"].ToString();
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
            string connectionString = @"Server=localhost\SQLEXPRESS;Database=coderhouse;Trusted_Connection=True;";
            var query = "INSERT INTO Producto (Descripciones,Costo,PrecioVenta,Stock,IdUsuario)" +
                        "Values(@Descripciones,@Costo,@PrecioVenta,@Stock,@IdUsuario)";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                using (SqlCommand comando = new SqlCommand(query, connection))
                {
                    comando.Parameters.Add(new SqlParameter("Descripciones", SqlDbType.VarChar) { Value = producto.Descripcion });
                    comando.Parameters.Add(new SqlParameter("Costo", SqlDbType.Money) { Value = producto.Costo });
                    comando.Parameters.Add(new SqlParameter("PrecioVenta", SqlDbType.Money) { Value = producto.PrecioVenta });
                    comando.Parameters.Add(new SqlParameter("Stock", SqlDbType.Int) { Value = producto.Stock });
                    comando.Parameters.Add(new SqlParameter("IdUsuario", SqlDbType.Int) { Value = producto.IdUsuario });
                    comando.Parameters.Add(new SqlParameter("Id", SqlDbType.Int) { Value = producto.IdUsuario });


                    comando.ExecuteNonQuery();
                }

                connection.Close();

            }

        }


        public static void ModificarProducto(Producto producto)
        {
            string connectionString = @"Server=localhost\SQLEXPRESS;Database=coderhouse;Trusted_Connection=True;";
            var query = "UPDATE Producto " +
                        "SET Descripciones = @Descripciones, " +
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
                    comando.Parameters.Add(new SqlParameter("@Descripciones", SqlDbType.VarChar) { Value = producto.Descripcion });
                    comando.Parameters.Add(new SqlParameter("@Costo", SqlDbType.Money) { Value = producto.Costo });
                    comando.Parameters.Add(new SqlParameter("@PrecioVenta", SqlDbType.Money) { Value = producto.PrecioVenta });
                    comando.Parameters.Add(new SqlParameter("@Stock", SqlDbType.Int) { Value = producto.Stock });
                    comando.Parameters.Add(new SqlParameter("@IdUsuario", SqlDbType.Int) { Value = producto.IdUsuario });

                    comando.ExecuteNonQuery();
                }

                connection.Close();
            }
        }



        public static void EliminarProducto(Producto Producto)
        {
            string connectionString = @"Server=localhost\SQLEXPRESS;Database=coderhouse;Trusted_Connection=True;";

            var ProductosVendidosQuery = "DELETE FROM ProductoVendido WHERE IdProducto = @Id";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                using (SqlCommand comandoProductosVendidos = new SqlCommand(ProductosVendidosQuery, connection))
                {
                    comandoProductosVendidos.Parameters.Add(new SqlParameter("Id", SqlDbType.Int) { Value = Producto.Id });
                    comandoProductosVendidos.ExecuteNonQuery();
                }

                
                var deleteProductoQuery = "DELETE FROM Producto WHERE Id = @Id";

                using (SqlCommand comando = new SqlCommand(deleteProductoQuery, connection))
                {
                    comando.Parameters.Add(new SqlParameter("Id", SqlDbType.Int) { Value = Producto.Id });
                    comando.ExecuteNonQuery();
                }

                connection.Close();
            }
        }


    }

}