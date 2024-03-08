using SistemaGestionData;
using SistemaGestionEntidades;

namespace SistemaGestionBusiness
{
    public static class ProductoBusiness
    {
        public static List<Producto> ObtenerProducto(int IdProducto)
        {
            return ProductoData.ObtenerProducto(IdProducto);
        }

        public static List<Producto> ListarProductosPorIdDeUsuario(int idUsuario)
        {
            return ProductoData.ListarProductosPorIdUsuario(idUsuario);
        }

        public static void CrearProducto(Producto producto)
        {
            ProductoData.CrearProducto(producto);
        }

        public static bool ModificarProducto(Producto producto)
        {
            try
            {
                ProductoData.ModificarProducto(producto);
                return true; 
            }
            catch (Exception)
            {
                return false; 
            }
        }

        public static void EliminarProducto(int IdProducto)
        {
            ProductoData.EliminarProducto(new Producto { Id = IdProducto });
        }
    }
}