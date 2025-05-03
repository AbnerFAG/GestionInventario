using CapaDatos;
using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocio
{
    public class NCustomer
    {
        private readonly DCustomer CustomerData = new DCustomer();

        public List<Customer> ObtenerClientesActivos()
        {
            return CustomerData.Listar();
        }
    }
}
