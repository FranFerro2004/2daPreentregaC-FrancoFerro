using Microsoft.AspNetCore.Mvc;
using SistemaGestionBusiness;
using SistemaGestionEntidades;

namespace ApiC_.Controllers
{
    [ApiController]
    [Route("api/Venta")]
    public class VentasController : Controller
    {
        [HttpGet("{idUsuario}")]
        public ActionResult<List<Venta>> ObtenerVentaPorIdDeUsuario(int idUsuario)
        {
            try
            {
                if (idUsuario <= 0)
                {
                    return BadRequest("Id no puede ser menos o igual a 0");
                }

                var lista = VentaBusiness.ListarVentasPorIdDeUsuario(idUsuario);

                if (lista.Count == 0)            
                {
                    return NotFound($"No se encontraron productos para el usuario con ID {idUsuario}");
                }

                return lista;
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error interno: {ex.Message}");
            }


        }


        [HttpDelete("/BorrarVentaPorId/{id}")]
        public IActionResult BorrarVentaPorId(int id)
        {
            VentaBusiness.EliminarVenta(id);

            return NoContent();
        }

        [HttpPut("/ModificarVenta")]
        public IActionResult ModificarVenta(Venta venta)
        {
            if (venta == null || venta.ID <= 0)
            {
                return BadRequest("Datos de venta no válidos");
            }

            bool modificacionExitosa = VentaBusiness.ModificarVenta(venta);

            if (modificacionExitosa)
            {
                return Ok("Venta modificada exitosamente");
            }
            else
            {
                return StatusCode(500, "Error durante la modificación de la venta");
            }
        }


        [HttpPost("{idUsuario}")]
        public IActionResult CrearVenta(int idUsuario, [FromBody] List<Producto> productos)
        {
            if (productos.Count == 0)
            {
                return BadRequest("No se recibieron productos");
            }

            try
            {
                bool resultado = VentaBusiness.CrearVenta(idUsuario, productos);

                if (resultado)
                {
                    return Ok("Venta creada exitosamente");
                }
                else
                {
                    return StatusCode(500, "Error al crear la venta");
                }
            }
            catch (Exception ex)
            {

                return StatusCode(500, $"Error interno del servidor: {ex.Message}");
            }
        }



    }
}

