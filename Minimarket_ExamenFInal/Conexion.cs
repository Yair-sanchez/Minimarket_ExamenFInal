using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Minimarket_ExamenFInal
{
    internal class Conexion
    {
        SqlConnection Connection = new SqlConnection("Database=BD_Minimarket;Data Source=172.16.0.20; User Id=sa; Password=Hyp3r10nPr0_; TrustServerCertificate=True");
        public void Conectar()
        {
            if(Connection.State != System.Data.ConnectionState.Open)
            {
                Connection.Open();
            }
        }

        public void Desconectar()
        {
            if(Connection.State == System.Data.ConnectionState.Open)
            {
                Connection.Close();
            }
        }

        public SqlConnection ObtenerConexion()
        {
            return Connection;
        }
    }
}
