using CapaEntidad;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos
{
    public class DInvoice
    {
        public List<Invoice> Listar()
        {
            var lista = new List<Invoice>();
            using var connection = Conexion.ObtenerConexion();
            using var command = new SqlCommand("SELECT * FROM invoices WHERE active = 1", connection);
            connection.Open();

            using var reader = command.ExecuteReader();
            while (reader.Read())
            {
                lista.Add(new Invoice
                {
                    InvoiceId = (int)reader["invoice_id"],
                    CustomerId = (int)reader["customer_id"],
                    Date = Convert.ToDateTime(reader["date"]),
                    Total = Convert.ToDecimal(reader["total"]),
                    Active = Convert.ToBoolean(reader["active"])
                });
            }

            return lista;
        }
    }
}
