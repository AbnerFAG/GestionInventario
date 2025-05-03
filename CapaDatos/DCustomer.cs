using CapaEntidad;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos
{
    public class DCustomer
    {
        public List<Customer> Listar()
        {
            var lista = new List<Customer>();
            using var connection = Conexion.ObtenerConexion();
            using var command = new SqlCommand("SELECT * FROM customers WHERE active = 1", connection);
            connection.Open();

            using var reader = command.ExecuteReader();
            while (reader.Read())
            {
                lista.Add(new Customer
                {
                    CustomerId = (int)reader["customer_id"],
                    Name = reader["name"].ToString()!,
                    Address = reader["address"].ToString(),
                    Phone = reader["phone"].ToString(),
                    Active = Convert.ToBoolean(reader["active"])
                });
            }

            return lista;
        }
    }
}
