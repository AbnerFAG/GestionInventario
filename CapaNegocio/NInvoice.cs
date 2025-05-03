using CapaDatos;
using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocio
{
    public class NInvoice
    {
        private readonly DInvoice InvoiceData = new DInvoice();

        public List<Invoice> ObtenerFacturasActivas()
        {
            return InvoiceData.Listar();
        }
    }
}
