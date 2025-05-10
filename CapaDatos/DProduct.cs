using CapaEntidad;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;

namespace CapaDatos
{
    public class DProduct
    {
        public List<Product> Listar()
        {
            var lista = new List<Product>();

            using var connection = Conexion.ObtenerConexion();
            using var command = new SqlCommand("ListarProductosActivos", connection);
            command.CommandType = CommandType.StoredProcedure;

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
                    Active = true // ya se filtran activos desde el SP
                });
            }
            return lista;
        }

        public List<Product> BuscarPorNombre(string nombre)
        {
            var lista = new List<Product>();

            using var connection = Conexion.ObtenerConexion();
            using var command = new SqlCommand("BuscarProductosPorNombre", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@name", nombre);

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
                    Active = true
                });
            }
            return lista;
        }

        public bool Insertar(Product producto)
        {
            using var connection = Conexion.ObtenerConexion();
            using var command = new SqlCommand("InsertarProducto", connection);
            command.CommandType = CommandType.StoredProcedure;

            command.Parameters.AddWithValue("@name", producto.Name);
            command.Parameters.AddWithValue("@price", producto.Price);
            command.Parameters.AddWithValue("@stock", producto.Stock);

            connection.Open();
            int filasAfectadas = command.ExecuteNonQuery();
            return filasAfectadas > 0;
        }

        public bool Actualizar(Product producto)
        {
            using var connection = Conexion.ObtenerConexion();
            using var command = new SqlCommand("ActualizarProducto", connection);
            command.CommandType = CommandType.StoredProcedure;

            command.Parameters.AddWithValue("@product_id", producto.ProductId);
            command.Parameters.AddWithValue("@name", producto.Name);
            command.Parameters.AddWithValue("@price", producto.Price);
            command.Parameters.AddWithValue("@stock", producto.Stock);

            connection.Open();
            int filasAfectadas = command.ExecuteNonQuery();
            return filasAfectadas > 0;
        }

        public bool Eliminar(int productId)
        {
            using var connection = Conexion.ObtenerConexion();
            using var command = new SqlCommand("EliminarProducto", connection);
            command.CommandType = CommandType.StoredProcedure;

            command.Parameters.AddWithValue("@product_id", productId);

            connection.Open();
            int filasAfectadas = command.ExecuteNonQuery();
            return filasAfectadas > 0;
        }
    }
}
