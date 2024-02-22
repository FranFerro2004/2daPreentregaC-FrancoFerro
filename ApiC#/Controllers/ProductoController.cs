using Microsoft.AspNetCore.Mvc;
using SistemaGestionData;
using SistemaGestionEntidades;
using SistemaGestionBusiness;

namespace ApiC_.Controllers
{
    [ApiController]
    [Route("api/Productos")]
    public class ProductosController : Controller
    {
        [HttpGet("/ListarProductos")]
        public List<Producto> ListarTodosProductos()
        {
            return ProductoBusiness.ListarProductos();
        }

        [HttpGet("/ObtenerProducto/{id}")]
        public IActionResult ObtenerProductoPorId(int IdProducto)
        {
            var producto = ProductoBusiness.ObtenerProducto(IdProducto);

            if (producto == null)
            {
                return NotFound(); 
            }

            return Ok(producto); 
        }

        [HttpDelete("/BorrarProductoPorId/{id}")]
        public IActionResult BorrarProductoPorId(int IdProducto)
        {
           
            ProductoBusiness.EliminarProducto(IdProducto);

            
            return NoContent(); 
        }

        [HttpPut("/ModificarProducto")]
        public IActionResult ModificarProducto(Producto producto)
        {
            if (producto == null || producto.Id <= 0)
            {
                return BadRequest("Datos de producto no válidos");
            }

            bool modificacionExitosa = ProductoBusiness.ModificarProducto(producto);

            if (modificacionExitosa)
            {
                return Ok("Producto modificado exitosamente");
            }
            else
            {
                return StatusCode(500, "Error durante la modificación del producto");
            }
        }

        [HttpPost("/CrearProducto")]
        public IActionResult CrearProducto(Producto producto)
        {
            if (producto == null)
            {
                return BadRequest("Datos de producto no válidos");
            }

            ProductoBusiness.CrearProducto(producto);

            return CreatedAtAction(nameof(ObtenerProductoPorId), new { id = producto.Id }, producto);
        }
    }
}

