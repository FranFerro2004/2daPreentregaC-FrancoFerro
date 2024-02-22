using Microsoft.AspNetCore.Mvc;
using ProductoData;
using System.Collections.Generic;
using ApiC_.Models;

namespace ApiC_.Controllers
{
    [ApiController]
    [Route("api/Productos")]
    public class ProductosController : Controller
    {
        [HttpGet("/ListarProductos")]
        public List<Producto> ListarTodosProductos()
        {
            return ProductoData.ProductoData.ListarProductos();
        }

        [HttpGet("/ObtenerProducto/{id}")]
        public IActionResult ObtenerProductoPorId(int IdProducto)
        {
            var producto = ProductoData.ProductoData.ObtenerProducto(IdProducto);

            if (producto == null)
            {
                return NotFound(); 
            }

            return Ok(producto); 
        }

        [HttpDelete("/BorrarProductoPorId/{id}")]
        public IActionResult BorrarProductoPorId(int id)
        {
           
            ProductoData.ProductoData.EliminarProducto(new Producto { Id = id });

            
            return NoContent(); 
        }

        [HttpPut("/ModificarProducto")]
        public IActionResult ModificarProducto(Producto producto)
        {
            if (producto == null || producto.Id <= 0)
            {
                return BadRequest("Datos de producto no válidos");
            }

            bool modificacionExitosa = ProductoData.ProductoData.ModificarProducto(producto);

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

            ProductoData.ProductoData.CrearProducto(producto);

            return CreatedAtAction(nameof(ObtenerProductoPorId), new { id = producto.Id }, producto);
        }
    }
}

