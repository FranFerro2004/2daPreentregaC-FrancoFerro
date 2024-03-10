using Microsoft.AspNetCore.Mvc;
using SistemaGestionBusiness;
using SistemaGestionEntidades;

namespace ApiC_.Controllers
{

    [ApiController]
    [Route("api/ProductoVendido")]

    public class ProductoVendidoController : Controller
    {
        [HttpGet("/ListarProductosVendidos")]
        public List<ProductoVendido> ListarProductosVendidos()        
        {

            return ProductoVendidoBusiness.ListarProductosVendidos();
           
        }

    }
}
