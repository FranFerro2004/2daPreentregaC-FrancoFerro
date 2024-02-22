using Microsoft.AspNetCore.Mvc;
using SistemaGestionData;
using System.Collections.Generic;
using ApiC_.Models;

namespace ApiC_.Controllers
{
    [ApiController]
    [Route("api/Ventas")]
    public class VentasController : Controller
    {
        [HttpGet("/ListarVentas")]
        public List<Venta> ListarTodasVentas()
        {
            return VentaData.ListarVentas();
        }

        [HttpGet("/ObtenerVenta/{id}")]
        public IActionResult ObtenerVentaPorId(int IdVenta)
        {
            var venta = VentaData.ObtenerVenta(IdVenta);

            if (venta == null)
            {
                return NotFound();
            }

            return Ok(venta);
        }

        [HttpDelete("/BorrarVentaPorId/{id}")]
        public IActionResult BorrarVentaPorId(int id)
        {
            VentaData.EliminarVenta(new Venta { ID = id });

            return NoContent();
        }

        [HttpPut("/ModificarVenta")]
        public IActionResult ModificarVenta(Venta venta)
        {
            if (venta == null || venta.ID <= 0)
            {
                return BadRequest("Datos de venta no válidos");
            }

            bool modificacionExitosa = VentaData.ModificarVenta(venta);

            if (modificacionExitosa)
            {
                return Ok("Venta modificada exitosamente");
            }
            else
            {
                return StatusCode(500, "Error durante la modificación de la venta");
            }
        }

        [HttpPost("/CrearVenta")]
        public IActionResult CrearVenta(Venta venta)
        {
            if (venta == null)
            {
                return BadRequest("Datos de venta no válidos");
            }

            VentaData.CrearVenta(venta);

            return CreatedAtAction(nameof(ObtenerVentaPorId), new { id = venta.ID }, venta);
        }
    }
}

