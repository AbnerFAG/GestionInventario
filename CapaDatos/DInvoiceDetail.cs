using CapaEntidad;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos
{
    public class DInvoiceDetail
    {
        public List<InvoiceDetail> Listar()
        {
            var lista = new List<InvoiceDetail>();
            using var connection = Conexion.ObtenerConexion();
            using var command = new SqlCommand("SELECT * FROM invoice_details WHERE active = 1", connection);
            connection.Open();

            using var reader = command.ExecuteReader();
            while (reader.Read())
            {
                lista.Add(new InvoiceDetail
                {
                    DetailId = (int)reader["detail_id"],
                    InvoiceId = (int)reader["invoice_id"],
                    ProductId = (int)reader["product_id"],
                    Quantity = Convert.ToInt32(reader["quantity"]),
                    Price = Convert.ToDecimal(reader["price"]),
                    Subtotal = Convert.ToDecimal(reader["subtotal"]),
                    Active = Convert.ToBoolean(reader["active"])
                });
            }

            return lista;
        }
    }
}
