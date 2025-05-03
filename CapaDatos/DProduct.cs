using CapaEntidad;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos
{
    public class DProduct
    {
        public List<Product> Listar()
        {
            var lista = new List<Product>();
            using var connection = Conexion.ObtenerConexion();
            using var command = new SqlCommand("SELECT * FROM products WHERE active = 1", connection);
            connection.Open();

            using var reader = command.ExecuteReader();
            while (reader.Read())
            {
                lista.Add(new Product
                {
                    ProductId = (int)reader["product_id"],
                    Name = reader["name"].ToString()!,
                    Price = Convert.ToDecimal(reader["price"]),
                    Stock = Convert.ToInt32(reader["stock"]),
                    Active = Convert.ToBoolean(reader["active"])
                });
            }

            return lista;
        }

        public List<Product> BuscarPorNombre(string nombre)
        {
            var lista = new List<Product>();
            using var connection = Conexion.ObtenerConexion();
            using var command = new SqlCommand("sp_ListarProductosPorNombre", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@Nombre", nombre);

            connection.Open();
            using var reader = command.ExecuteReader();
            while (reader.Read())
            {
                lista.Add(new Product
                {
                    ProductId = (int)reader["product_id"],
                    Name = reader["name"].ToString()!,
                    Price = Convert.ToDecimal(reader["price"]),
                    Stock = Convert.ToInt32(reader["stock"]),
                    Active = Convert.ToBoolean(reader["active"])
                });
            }
            return lista;
        }
    }
}
