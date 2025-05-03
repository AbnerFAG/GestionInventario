using CapaDatos;
using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocio
{
    public class NInvoiceDetail
    {
        private readonly DInvoiceDetail InvoiceDetailData = new DInvoiceDetail();

        public List<InvoiceDetail> ObtenerDetallesActivos()
        {
            return InvoiceDetailData.Listar();
        }
    }
}
