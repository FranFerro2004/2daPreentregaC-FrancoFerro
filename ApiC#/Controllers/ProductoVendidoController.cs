using Microsoft.AspNetCore.Mvc;
using SistemaGestionBusiness;
using SistemaGestionEntidades;

namespace ApiC_.Controllers
{

    [ApiController]
    [Route("api/ProductoVendido")]

    public class ProductoVendidoController : Controller
    {
        [HttpGet("{idUsuario}")]
        public List<ProductoVendido> ListarProductosVendidos(int idUsuario)        
        {

            return ProductoVendidoBusiness.ListarProductosVendidos(idUsuario);
           
        }

    }
}
