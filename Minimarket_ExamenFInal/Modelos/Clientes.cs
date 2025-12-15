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
    internal class Clientes
    {
        public static DataTable obtener()
        {
            Conexion cnn = new Conexion();
            try
            {
                cnn.Conectar();
                String consulta = "SELECT *FROM Clientes order by id_cliente desc";
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
        public static bool Crear(string nombre, string dni_ruc, string telefono, string email, string direccion, decimal credito_disponible, decimal credito_usado, string estado, DateTime fecha_creacion)
        {
            Conexion cnn = new Conexion();
            try
            {
                cnn.Conectar();
                string consulta = "INSERT INTO Clientes (nombre,dni_ruc,telefono,email,direccion,credito_disponible,credito_usado,estado,fecha_creacion) VALUES (@nombre,@dni_ruc,@telefono,@email,@direccion,@credito_disponible,@credito_usado,@estado,@fecha_creacion)";
                SqlCommand Comando = new SqlCommand(consulta, cnn.ObtenerConexion());
                Comando.Parameters.AddWithValue("@nombre", nombre);
                Comando.Parameters.AddWithValue("@dni_ruc", dni_ruc);
                Comando.Parameters.AddWithValue("@telefono", telefono);
                Comando.Parameters.AddWithValue("@email", email);
                Comando.Parameters.AddWithValue("@direccion", direccion);
                Comando.Parameters.AddWithValue("@credito_disponible", credito_disponible);
                Comando.Parameters.AddWithValue("@credito_usado", credito_usado);
                Comando.Parameters.AddWithValue("@estado", estado);
                Comando.Parameters.AddWithValue("@fecha_creacion", fecha_creacion);
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
        public static bool Editar(int id, string nombre, string dni_ruc, string telefono, string email, string direccion, decimal credito_disponible, decimal credito_usado, string estado, DateTime fecha_creacion)
        {
            Conexion cnn = new Conexion();
            try
            {
                cnn.Conectar ();
                string consulta = "UPDATE clientes set nombre=@nombre, dni_ruc=@dni_ruc, telefono=@telefono, email=@email, direccion=@direccion, credito_disponible=@credito_disponible, credito_usado=@credito_usado, estado=@estado, fecha_creacion=@fecha_creacion WHERE id_cliente=@id_cliente";
                SqlCommand Comando = new SqlCommand(consulta, cnn.ObtenerConexion());
                Comando.Parameters.AddWithValue("@id_cliente", id);
                Comando.Parameters.AddWithValue("@nombre", nombre);
                Comando.Parameters.AddWithValue("@dni_ruc", dni_ruc);
                Comando.Parameters.AddWithValue("@telefono", telefono);
                Comando.Parameters.AddWithValue("@email", email);
                Comando.Parameters.AddWithValue("@direccion", direccion);
                Comando.Parameters.AddWithValue("@credito_disponible", credito_disponible);
                Comando.Parameters.AddWithValue("@credito_usado", credito_usado);
                Comando.Parameters.AddWithValue("@estado", estado);
                Comando.Parameters.AddWithValue("@fecha_creacion", fecha_creacion);
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
                string consulta = "DELETE FROM Clientes WHERE id_cliente=@id_cliente";
                SqlCommand Comando = new SqlCommand(consulta, cnn.ObtenerConexion());
                Comando.Parameters.AddWithValue("@id", id);
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
