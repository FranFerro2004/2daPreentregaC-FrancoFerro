using Microsoft.AspNetCore.Mvc;
using SistemaGestionBusiness;
using SistemaGestionEntidades;


namespace ApiC_.Controllers
{
    [ApiController]
    [Route("api/Usuarios")]

    public class UsuariosController : Controller
    {

        [HttpGet("/ListarUsuarios")]
        public List<Usuario> ListarTodosUsuarios()
        {

            return UsuarioBusiness.ListarUsuarios();

        }

        [HttpGet("/ObtenerUsuario/{id}")]

        public IActionResult ObtenerUsuarioPorId(int IdUsuario)
        {
            var usuario = UsuarioBusiness.ObtenerUsuario(IdUsuario);

            if (usuario == null)
            {
                return NotFound();
            }

            return Ok(usuario);
        }

        [HttpDelete ("/BorrarUsuarioPorId/{id}")]

        public void BorrarUsuarioPorId(int id)
        {

            UsuarioBusiness.EliminarUsuario(id);

        }

        [HttpPut("/ModificarUsuario")]
        public IActionResult ModificarUsuario(Usuario usuario)
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

        [HttpPost("/CrearUsuario")]
        public IActionResult CrearProducto(Usuario usuario)
        {
            if (usuario == null)
            {
                return BadRequest("Datos de producto no válidos");
            }

            UsuarioBusiness.CrearUsuario(usuario);

            return CreatedAtAction(nameof(ObtenerUsuarioPorId), new { id = usuario.Id }, usuario);
        }


    }
}
