using Microsoft.AspNetCore.Mvc;
using SistemaGestionBusiness;
using SistemaGestionEntidades;


namespace ApiC_.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    
    public class UsuariosController : Controller
    {

        [HttpGet("/ListarUsuarios")]
        public List<Usuario> ListarTodosUsuarios()
        {

            return UsuarioBusiness.ListarUsuarios();

        }

        [HttpGet("{NombreUsuario}")]

        public IActionResult ObtenerUsuarioPorNombreDeUsuario(string nombrUsuario)
        {
            var usuario = UsuarioBusiness.ObtenerUsuarioPorNombreDeUsuario(nombrUsuario);

            if (usuario == null)
            {
                return NotFound();
            }

            return Ok(usuario);
        }


        [HttpGet("{usuario}/{password}")]
        public IActionResult ObtenerUsuarioPorUsuarioYPassword(string usuario, string password)
        {
            try
            {
                if (string.IsNullOrEmpty(usuario) || string.IsNullOrEmpty(password))
                {
                    return BadRequest("Usuario o Password están vacíos");
                }

                var usuarioObtenido = UsuarioBusiness.ObtenerUsuarioPorUsuarioYPassword(usuario, password);

                if (usuarioObtenido != null)
                {
                    return Ok(usuarioObtenido);
                }
                else
                {
                    return NotFound("Usuario no encontrado");
                }
            }
            catch (Exception ex)
            {
               
                Console.WriteLine($"Error en la solicitud: {ex.Message}");
                return StatusCode(500, "Error interno del servidor");
            }
        }


        [HttpDelete ("/BorrarUsuarioPorId/{id}")]

        public void BorrarUsuarioPorId(int id)
        {

            UsuarioBusiness.EliminarUsuario(id);

        }

        [HttpPut]
        public IActionResult ActualizarUsuario([FromBody] Usuario usuario)
        {
            if (usuario == null || usuario.Id <= 0)
            {
                return BadRequest("Datos de usuario no válidos");
            }

            bool modificacionExitosa = UsuarioBusiness.ModificarUsuario(usuario);

            if (modificacionExitosa)
            {
                return Ok("Usuario modificado exitosamente");
            }
            else
            {
                return StatusCode(500, "Error durante la modificación del usuario");
            }  
        }

        [HttpPost]
        public IActionResult CrearUsuario([FromBody] Usuario usuario)
        {
            if (usuario == null)
            {
                return BadRequest("Datos de producto no válidos");
            }

            UsuarioBusiness.CrearUsuario(usuario);

            return Ok("Usuario credo exitosamente");
        }

        
    }
}
