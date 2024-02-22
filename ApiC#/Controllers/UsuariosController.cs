using Microsoft.AspNetCore.Mvc;
using SistemaGestionBusiness;

namespace ApiC_.Controllers
{
    [ApiController]
    [Route("api/Usuarios")]

    public class UsuariosController : Controller
    {
        [HttpGet("/ObtenerUsuarios")]
        public void ObtenerUsuarios()
        {

            UsuarioBusiness.ListarUsuarios();

        }
    }
}
