using CapaDatos;
using CapaEntidad;
using System.Collections.Generic;

namespace CapaNegocio
{
    public class NProduct
    {
        private readonly DProduct productData = new DProduct();

        public List<Product> ObtenerProductosActivos()
        {
            return productData.Listar();
        }

        public List<Product> BuscarProductosPorNombre(string nombre)
        {
            return productData.BuscarPorNombre(nombre);
        }

        public bool InsertarProducto(Product producto)
        {
            return productData.Insertar(producto);
        }

        public bool ActualizarProducto(Product producto)
        {
            return productData.Actualizar(producto);
        }

        public bool EliminarProducto(int productId)
        {
            return productData.Eliminar(productId);
        }
    }
}
