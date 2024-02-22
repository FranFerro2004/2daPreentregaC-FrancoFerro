using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

        public static List<Producto> ListarProductos()
        {
            return ProductoData.ListarProductos();
        }

        public static void CrearProducto(Producto producto)
        {
            ProductoData.CrearProducto(producto);
        }

        public static void ModificarProducto(Producto producto)
        {
            ProductoData.ModificarProducto(producto);
        }

        public static void EliminarProducto(int IdProducto)
        {
            ProductoData.EliminarProducto(new Producto { Id = IdProducto });
        }
    }
}
