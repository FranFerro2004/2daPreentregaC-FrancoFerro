using SistemaGestionEntidades;
using System.Data;
using System.Data.SqlClient;

namespace SistemaGestionData
{
    public static class UsuarioData
    {
        public static List<Usuario> ObtenerUsuario(int IdUsuario)
        {
            List<Usuario> lista = new List<Usuario>();

            string connectionString = @"Server=localhost\SQLEXPRESS;Database=coderhouse;Trusted_Connection=True;";
            var query = "SELECT Id, Nombre, Apellido, NombreUsuario, Contraseña, Mail FROM Usuario WHERE Id = @IdUsuario";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                using (SqlCommand comando = new SqlCommand(query, connection))
                {
                    var parametro = new SqlParameter("@IdUsuario", SqlDbType.Int) { Value = IdUsuario };
                    comando.Parameters.Add(parametro);

                    using (SqlDataReader dr = comando.ExecuteReader())
                    {
                        if (dr.HasRows)
                        {
                            while (dr.Read())
                            {
                                var usuario = new Usuario();
                                usuario.Id = Convert.ToInt32(dr["Id"]);
                                usuario.Nombre = dr["Nombre"].ToString();
                                usuario.Apellido = dr["Apellido"].ToString();
                                usuario.NombreUsuario = dr["NombreUsuario"].ToString();
                                usuario.Contrasena = dr["Contraseña"].ToString();
                                usuario.Mail = dr["Mail"].ToString();
                                lista.Add(usuario);
                            }
                        }
                    }
                }

                connection.Close();
            }

            return lista;
        }

        public static List<Usuario> ListarUsuarios()
        {
            List<Usuario> lista = new List<Usuario>();

            string connectionString = @"Server=localhost\SQLEXPRESS;Database=coderhouse;Trusted_Connection=True;";
            var query = "SELECT Id, Nombre, Apellido, NombreUsuario, Contraseña, Mail FROM Usuario";

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
                                var usuario = new Usuario();
                                usuario.Id = Convert.ToInt32(dr["Id"]);
                                usuario.Nombre = dr["Nombre"].ToString();
                                usuario.Apellido = dr["Apellido"].ToString();
                                usuario.NombreUsuario = dr["NombreUsuario"].ToString();
                                usuario.Contrasena = dr["Contraseña"].ToString();
                                usuario.Mail = dr["Mail"].ToString();
                                lista.Add(usuario);
                            }
                        }
                    }
                }

                connection.Close();
            }

            return lista;
        }

        public static void CrearUsuario(Usuario usuario)
        {
            string connectionString = @"Server=localhost\SQLEXPRESS;Database=coderhouse;Trusted_Connection=True;";
            var query = "INSERT INTO Usuario (Nombre, Apellido, NombreUsuario, Contraseña, Mail)" +
                        "VALUES (@Nombre, @Apellido, @NombreUsuario, @Contraseña, @Mail)";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                using (SqlCommand comando = new SqlCommand(query, connection))
                {
                    comando.Parameters.Add(new SqlParameter("@Nombre", SqlDbType.VarChar) { Value = usuario.Nombre });
                    comando.Parameters.Add(new SqlParameter("@Apellido", SqlDbType.VarChar) { Value = usuario.Apellido });
                    comando.Parameters.Add(new SqlParameter("@NombreUsuario", SqlDbType.VarChar) { Value = usuario.NombreUsuario });
                    comando.Parameters.Add(new SqlParameter("@Contraseña", SqlDbType.VarChar) { Value = usuario.Contrasena });
                    comando.Parameters.Add(new SqlParameter("@Mail", SqlDbType.VarChar) { Value = usuario.Mail });
                    


                    comando.ExecuteNonQuery();
                }

                connection.Close();
            }
        }

        public static void ModificarUsuario(Usuario usuario)
        {
            string connectionString = @"Server=localhost\SQLEXPRESS;Database=coderhouse;Trusted_Connection=True;";
            var query = "UPDATE Usuario " +
                        "SET Nombre = @Nombre, " +
                        "Apellido = @Apellido, " +
                        "NombreUsuario = @NombreUsuario, " +
                        "Contraseña = @Contrasena, " +
                        "Mail = @Mail " +
                        "WHERE Id = @Id";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                using (SqlCommand comando = new SqlCommand(query, connection))
                {
                    comando.Parameters.Add(new SqlParameter("@Id", SqlDbType.Int) { Value = usuario.Id });
                    comando.Parameters.Add(new SqlParameter("@Nombre", SqlDbType.VarChar) { Value = usuario.Nombre });
                    comando.Parameters.Add(new SqlParameter("@Apellido", SqlDbType.VarChar) { Value = usuario.Apellido });
                    comando.Parameters.Add(new SqlParameter("@NombreUsuario", SqlDbType.VarChar) { Value = usuario.NombreUsuario });
                    comando.Parameters.Add(new SqlParameter("@Contrasena", SqlDbType.VarChar) { Value = usuario.Contrasena });
                    comando.Parameters.Add(new SqlParameter("@Mail", SqlDbType.VarChar) { Value = usuario.Mail });

                    comando.ExecuteNonQuery();
                }

                connection.Close();
            }
        }



        public static void EliminarUsuario(Usuario usuario)
        {
            string connectionString = @"Server=localhost\SQLEXPRESS;Database=coderhouse;Trusted_Connection=True;";
            var query = "DELETE FROM Usuario WHERE Id = @Id";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                using (SqlCommand comando = new SqlCommand(query, connection))
                {
                    comando.Parameters.Add(new SqlParameter("@Id", SqlDbType.Int) { Value = usuario.Id });

                    comando.ExecuteNonQuery();
                }

                connection.Close();
            }
        }
    }
}
