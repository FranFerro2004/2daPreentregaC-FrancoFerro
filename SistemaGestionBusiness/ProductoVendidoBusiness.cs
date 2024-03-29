﻿using SistemaGestionData;
using SistemaGestionEntidades;


namespace SistemaGestionBusiness
{
    public static class ProductoVendidoBusiness
    {
        public static List<ProductoVendido> ObtenerProductoVendido(int IdProductoVendido)
        {
            return ProductoVendidoData.ObtenerProductoVendido(IdProductoVendido);
        }

        public static List<ProductoVendido> ListarProductosVendidos(int idUsuario)
        {
            return ProductoVendidoData.ListarProductosVendidos(idUsuario);
        }

        

        public static void ModificarProductoVendido(ProductoVendido productoVendido)
        {
            ProductoVendidoData.ModificarProductoVendido(productoVendido);
        }

        public static void EliminarProductoVendido(int IdProductoVendido)
        {
            ProductoVendidoData.EliminarProductoVendido(new ProductoVendido { ID = IdProductoVendido });
        }
    }
}