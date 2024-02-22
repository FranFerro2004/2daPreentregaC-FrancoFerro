using Microsoft.AspNetCore.Mvc;
using UsuarioData;
using System.Collections.Generic;
using ApiC_.Models;


namespace ApiC_.Controllers
{
    [ApiController]
    [Route("api/Usuarios")]

    public class UsuariosController : Controller
    {

        [HttpGet("/ListarUsuarios")]
        public List<Usuario> ListarTodosUsuarios()
        {

            return UsuarioData.UsuarioData.ListarUsuarios();

        }

        [HttpGet("/ObtenerUsuario/{id}")]

        public void ObtenerUsuarioPorId(int IdUsuario)
        {

            UsuarioData.UsuarioData.ObtenerUsuario(IdUsuario);

        }

        [HttpDelete ("/BorrarUsuarioPorId/{id}")]

        public void BorrarUsuarioPorId(Usuario usuario)
        {

            UsuarioData.UsuarioData.EliminarUsuario(usuario);

        }

        [HttpPut("/ModificarUsuario")]
        public IActionResult ModificarUsuario(Usuario usuario)
        {
            if (usuario == null || usuario.Id <= 0)
            {
                return BadRequest("Datos de usuario no válidos");
            }

            bool modificacionExitosa = UsuarioData.UsuarioData.ModificarUsuario(usuario);

            if (modificacionExitosa)
            {
                return Ok("Usuario modificado exitosamente");
            }
            else
            {
                return StatusCode(500, "Error durante la modificación del usuario");
            }
        }


    }
}
