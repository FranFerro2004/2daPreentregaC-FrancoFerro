using SistemaGestionEntidades;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace SistemaGestionData
{
    public static class VentaData
    {
        public static List<Venta> ObtenerVenta(int IdVenta)
        {
            List<Venta> lista = new List<Venta>();

            string connectionString = @"Server=localhost\SQLEXPRESS;Database=master;Trusted_Connection=True;";
            var query = "SELECT Id, Comentarios, IdUsuario FROM Ventas WHERE Id = @IdVenta";

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

        public static List<Venta> ListarVentas()
        {
            List<Venta> lista = new List<Venta>();
            string connectionString = @"Server=localhost\SQLEXPRESS;Database=master;Trusted_Connection=True;";
            var query = "SELECT Id, Comentarios, IdUsuario FROM Ventas";

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

        public static void CrearVenta(Venta venta)
        {
            string connectionString = @"Server=localhost\SQLEXPRESS;Database=master;Trusted_Connection=True;";
            var query = "INSERT INTO Ventas (Comentarios, IdUsuario) VALUES (@Comentarios, @IdUsuario)";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                using (SqlCommand comando = new SqlCommand(query, connection))
                {
                    comando.Parameters.Add(new SqlParameter("Comentarios", SqlDbType.VarChar) { Value = venta.Comentarios });
                    comando.Parameters.Add(new SqlParameter("IdUsuario", SqlDbType.Int) { Value = venta.IDUsuario });

                    comando.ExecuteNonQuery();
                }

                connection.Close();
            }
        }

        public static void ModificarVenta(Venta venta)
        {
            string connectionString = @"Server=localhost\SQLEXPRESS;Database=master;Trusted_Connection=True;";
            var query = "UPDATE Ventas SET Comentarios = @Comentarios, IdUsuario = @IdUsuario WHERE Id = @Id";

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
            string connectionString = @"Server=localhost\SQLEXPRESS;Database=master;Trusted_Connection=True;";
            var query = "DELETE FROM Ventas WHERE Id = @Id";

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
