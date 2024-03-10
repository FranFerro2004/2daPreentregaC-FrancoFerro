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

        public static List<Venta> ListarVentasPorIdDeUsuario(int idUsuario)
        {
            return VentaData.ListarVentasPorIdDeUsuario(idUsuario);
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

        public static bool CrearVenta(int idUsuario, List<Producto> productos) 
        {
            try
            {

                VentaData.CrearVenta(idUsuario, productos);
                return true;
            }
            catch
            {

                return false;

            }
        
        }
        
        


    }
}