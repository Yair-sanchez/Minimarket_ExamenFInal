using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Minimarket_ExamenFInal.Modelos
{
    internal class FormasPagos
    {
        public static DataTable Obtener()
        {
            Conexion cnn = new Conexion();
            try
            {
                cnn.Conectar();
                String consulta = "SELECT * FROM formas_pagos order by id_forma_pago desc";
                SqlCommand Comando = new SqlCommand(consulta, cnn.ObtenerConexion());
                SqlDataAdapter adaptador = new SqlDataAdapter(Comando);
                DataTable dt = new DataTable();
                adaptador.Fill(dt);
                return dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.ToString());
                return null;
            }
            finally
            {
                cnn.Desconectar();
            }
        }
        public static bool Crear(string nombre, string descripcion, string requiere_referencia, string estado)
        {
            Conexion cnn = new Conexion();
            try
            {
                cnn.Conectar();
                string consulta = "INSERT INTO formas_pagos(nombre, descripcion, requiere_referencia, estado) VALUES (@nombre, @descripcion, @requiere_referencia, @estado)";
                SqlCommand Comando = new SqlCommand(consulta, cnn.ObtenerConexion());
                Comando.Parameters.AddWithValue("@nombre", nombre);
                Comando.Parameters.AddWithValue("@descripcion", descripcion);
                Comando.Parameters.AddWithValue("@requiere_referencia", requiere_referencia);
                Comando.Parameters.AddWithValue("@estado", estado);
                Comando.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.ToString());
                return false;
            }
            finally
            {
                cnn.Desconectar();
            }
        }
        public static bool Editar(int id, string nombre, string descripcion, string requiere_referencia, string estado)
        {
            Conexion cnn = new Conexion();
            try
            {
                cnn.Conectar();
                string consulta = "UPDATE formas_pagos set nombre = @nombre, descripcion = @descripcion, requiere_referencia = @requiere_referencia, estado = @estado";
                SqlCommand Comando = new SqlCommand(consulta, cnn.ObtenerConexion());
                Comando.Parameters.AddWithValue("@id_forma_pago", id);
                Comando.Parameters.AddWithValue("@nombre", nombre);
                Comando.Parameters.AddWithValue("@descripcion", descripcion);
                Comando.Parameters.AddWithValue("@requiere_referencia", requiere_referencia);
                Comando.Parameters.AddWithValue("@estado", estado);
                Comando.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.ToString());
                return false;
            }
            finally
            {
                cnn.Desconectar();
            }
        }
        public static bool Eliminar(int id)
        {
            Conexion cnn = new Conexion();
            try
            {
                cnn.Conectar();
                string consulta = "DELETE FROM formas_pagos WHERE id_forma_pago=@id";
                SqlCommand Comando = new SqlCommand(consulta, cnn.ObtenerConexion());
                Comando.Parameters.AddWithValue("id", id);
                Comando.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.ToString());
                return false;
            }
            finally
            {
                cnn.Desconectar();
            }
        }
    }
}
