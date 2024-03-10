using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Data.SqlClient;

namespace ApiC_.Controllers
{
    [ApiController]
    [Route("api/Nombre")]
    
    public class NombreController : ControllerBase
    {
        [HttpGet("{nombreUsuario}")]
        public IActionResult TraerNombre(string nombreUsuario)
        {
          
            string nombreCompleto = BuscarNombre(nombreUsuario);

            
            if (!string.IsNullOrEmpty(nombreCompleto))
            {
                
                return Ok(nombreCompleto);
            }
            else
            {
                
                return NotFound("Nombre no encontrado");
            }
        }

        public static string BuscarNombre(string nombreUsuario)
        {
            string connectionString = @"Server=localhost\SQLEXPRESS;Database=coderhouse;Trusted_Connection=True;";
            var query = "SELECT Nombre, Apellido FROM Usuario WHERE NombreUsuario = @nombreUsuario";

            string nombre = null;

            using (SqlConnection conexion = new SqlConnection(connectionString))
            {
                conexion.Open();

                using (SqlCommand comando = new SqlCommand(query, conexion))
                {
                    var parametro = new SqlParameter("@nombreUsuario", SqlDbType.VarChar) { Value = nombreUsuario };
                    comando.Parameters.Add(parametro);

                    using (SqlDataReader dr = comando.ExecuteReader())
                    {
                        if (dr.HasRows)
                        {
                            dr.Read();
                            string nombreBuscado = dr["Nombre"].ToString();
                            string apellidoBuscado = dr["Apellido"].ToString();
                            nombre = $"{nombreBuscado} {apellidoBuscado}";
                        }
                    }
                }
            }

            return nombre;
        }
    }
}
