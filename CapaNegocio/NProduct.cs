using CapaDatos;
using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocio
{
    public class NProduct
    {
        private readonly DProduct ProductData = new DProduct();

        public List<Product> ObtenerProductosActivos()
        {
            return ProductData.Listar();
        }

        public List<Product> BuscarProductosPorNombre(string nombre)
        {
            var productos = ProductData.Listar();

            var resultado = productos.Where(x => x.Name.Contains(nombre)).ToList();
            return resultado;
        }
    }
}
