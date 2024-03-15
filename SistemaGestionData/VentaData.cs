using SistemaGestionEntidades;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;

namespace SistemaGestionData
{
    public static class VentaData
    {
        public static List<Venta> ObtenerVenta(int IdVenta)
        {
            List<Venta> lista = new List<Venta>();

            string connectionString = @"Server=localhost\SQLEXPRESS;Database=coderhouse;Trusted_Connection=True;";
            var query = "SELECT Id, Comentarios, IdUsuario FROM Venta WHERE Id = @IdVenta";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                using (SqlCommand comando = new SqlCommand(query, connection))
                {
                    var parametro = new SqlParameter();
                    parametro.ParameterName = "IdVenta";
                    parametro.SqlDbType = SqlDbType.Int;
                    parametro.Value = IdVenta;

                    comando.Parameters.Add(parametro);

                    using (SqlDataReader dr = comando.ExecuteReader())
                    {
                        if (dr.HasRows)
                        {
                            while (dr.Read())
                            {
                                var venta = new Venta();
                                venta.ID = Convert.ToInt32(dr["Id"]);
                                venta.Comentarios = dr["Comentarios"].ToString();
                                venta.IDUsuario = Convert.ToInt32(dr["IdUsuario"]);
                                lista.Add(venta);
                            }
                        }
                    }
                }

                connection.Close();
            }

            return lista;
        }

        public static List<Venta> ListarVentasPorIdDeUsuario(int idUsuario)
        {
            List<Venta> lista = new List<Venta>();
            string connectionString = @"Server=localhost\SQLEXPRESS;Database=coderhouse;Trusted_Connection=True;";
            var query = "SELECT Id, Comentarios, IdUsuario FROM Venta WHERE IdUsuario = @Idusuario";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                using (SqlCommand comando = new SqlCommand(query, connection))
                {
                    comando.Parameters.Add(new SqlParameter("@IdUsuario", SqlDbType.Int)  {Value = idUsuario });


                    using (SqlDataReader dr = comando.ExecuteReader())
                    {
                        if (dr.HasRows)
                        {
                            while (dr.Read())
                            {
                                var venta = new Venta();
                                venta.ID = Convert.ToInt32(dr["Id"]);
                                venta.Comentarios = dr["Comentarios"].ToString();
                                venta.IDUsuario = Convert.ToInt32(dr["IdUsuario"]);
                                lista.Add(venta);
                            }
                        }
                    }
                }

                connection.Close();
            }

            return lista;
        }


        public static int CrearVenta(int idUsuario, List<Producto> productos)
        {
            string connectionString = @"Server=localhost\SQLEXPRESS;Database=coderhouse;Trusted_Connection=True;";
            var query = "INSERT INTO Venta (Comentarios, IdUsuario) VALUES (@Comentarios, @IdUsuario); SELECT SCOPE_IDENTITY();";

            string nombreProductos = string.Join(" // ", productos.Select(p => p.Descripciones));

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                using (SqlCommand comando = new SqlCommand(query, connection))
                {
                    comando.Parameters.Add(new SqlParameter("@Comentarios", SqlDbType.VarChar) { Value = nombreProductos });
                    comando.Parameters.Add(new SqlParameter("@IdUsuario", SqlDbType.Int) { Value = idUsuario });

                    
                    int idVenta = Convert.ToInt32(comando.ExecuteScalar());

                   
                    ProductoVendidoData.CrearProductoVendido(idVenta, productos);

                    return idVenta; 
                }
            }
        }



        public static void ModificarVenta(Venta venta)
        {
            string connectionString = @"Server=localhost\SQLEXPRESS;Database=coderhouse;Trusted_Connection=True;";
            var query = "UPDATE Venta SET Comentarios = @Comentarios, IdUsuario = @IdUsuario WHERE Id = @Id";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                using (SqlCommand comando = new SqlCommand(query, connection))
                {
                    comando.Parameters.Add(new SqlParameter("@Id", SqlDbType.Int) { Value = venta.ID });
                    comando.Parameters.Add(new SqlParameter("@Comentarios", SqlDbType.VarChar) { Value = venta.Comentarios });
                    comando.Parameters.Add(new SqlParameter("@IdUsuario", SqlDbType.Int) { Value = venta.IDUsuario });

                    comando.ExecuteNonQuery();
                }

                connection.Close();
            }
        }

        public static void EliminarVenta(Venta venta)
        {
            string connectionString = @"Server=localhost\SQLEXPRESS;Database=coderhouse;Trusted_Connection=True;";
            var query = "DELETE FROM Venta WHERE Id = @Id";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                using (SqlCommand comando = new SqlCommand(query, connection))
                {
                    comando.Parameters.Add(new SqlParameter("Id", SqlDbType.Int) { Value = venta.ID });

                    comando.ExecuteNonQuery();
                }

                connection.Close();
            }
        }
    }
}
