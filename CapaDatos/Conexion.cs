using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos
{
    public static class Conexion
    {
        private static readonly string connectionString =
            "Server=LAB411-002\\SQLEXPRESS;Database=master;User Id=abner;Password=abner123;TrustServerCertificate=True;";

        public static SqlConnection ObtenerConexion()
        {
            return new SqlConnection(connectionString);
        }
    }
}
