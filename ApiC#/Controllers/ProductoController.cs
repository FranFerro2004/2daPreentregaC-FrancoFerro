using Microsoft.AspNetCore.Mvc;
using SistemaGestionData;
using SistemaGestionEntidades;
using SistemaGestionBusiness;

namespace ApiC_.Controllers
{
    [ApiController]
    [Route("api/Producto")]
    
    public class ProductosController : Controller
    {
        [HttpGet("{idUsuario}")]
        public ActionResult <List<Producto>> ObtenerProductosPorIdDeUsuario(int idUsuario)
        {
            try
            {
                if (idUsuario <= 0)
                {
                    return BadRequest("Id no puede ser menos o igual a 0");
                }

                var productos = ProductoBusiness.ListarProductosPorIdDeUsuario(idUsuario);

                if (productos.Count == 0)
                {
                    return NotFound($"No se encontraron productos para el usuario con ID {idUsuario}");
                }

                return productos;
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error interno: {ex.Message}");
            }


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

        [HttpDelete("{id}")]
        public IActionResult BorrarProductoPorId(int Id)
        {
           
            ProductoBusiness.EliminarProducto(Id);

            
            return NoContent(); 
        }

        [HttpPut]
        public IActionResult ActualizarProducto( [FromBody] Producto producto)
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

        [HttpPost]
        public IActionResult CrearNuevoProducto( [FromBody] Producto producto)
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

