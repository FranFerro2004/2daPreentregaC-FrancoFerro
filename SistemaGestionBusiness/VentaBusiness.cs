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

        public static bool ModificarVenta(Venta venta)
        {
            try 
            {

                VentaData.ModificarVenta(venta);
                return true;

            }
            catch
            {
                return false;
            }
            
        }

        public static void EliminarVenta(int IdVenta)
        {
            VentaData.EliminarVenta(new Venta { ID = IdVenta });

        }
    }
}