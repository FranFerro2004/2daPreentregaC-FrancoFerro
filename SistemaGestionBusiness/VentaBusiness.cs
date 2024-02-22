using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SistemaGestionData;
using SistemaGestionEntidades;

namespace SistemaGestionBusiness
{
    public static class VentaBusiness
    {
        public static List<Venta> ObtenerVenta(int IdVenta)
        {
            return VentaData.ObtenerVenta(IdVenta);
        }

        public static List<Venta> ListarVentas()
        {
            return VentaData.ListarVentas();
        }

        public static void CrearVenta(Venta venta)
        {
            VentaData.CrearVenta(venta);
        }

        public static void ModificarVenta(Venta venta)
        {
            VentaData.ModificarVenta(venta);
        }

        public static void EliminarVenta(int IdVenta)
        {
            VentaData.EliminarVenta(new Venta { ID = IdVenta });

        }
    }
}