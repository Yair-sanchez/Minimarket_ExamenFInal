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
    internal class Proveedor
    {
        public static DataTable obtener()
        {
            Conexion cnn = new Conexion();
            try
            {
                cnn.Conectar();
                String consulta = "SELECT * FROM Proveedores order by id_proveedor desc";
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
        public static bool Crear(string nombre, string ruc_dni, string telefono, string email, string direccion, string estado, DateTime fecha_creacion)
        {
            Conexion cnn = new Conexion();
            try
            {
                cnn.Conectar();
                string consulta = "INSERT INTO Proveedores (nombre,ruc_dni,telefono,email,direccion,estado,fecha_creacion) VALUES (@nombre,@ruc_dni,@telefono,@email,@direccion,@estado,@fecha_creacion)";
                SqlCommand Comando = new SqlCommand(consulta, cnn.ObtenerConexion());
                Comando.Parameters.AddWithValue("@nombre", nombre);
                Comando.Parameters.AddWithValue("@ruc_dni", ruc_dni);
                Comando.Parameters.AddWithValue("@telefono", telefono);
                Comando.Parameters.AddWithValue("@email", email);
                Comando.Parameters.AddWithValue("@direccion", direccion);
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
        public static bool Editar(int id_proveedor, string nombre, string ruc_dni, string telefono, string email, string direccion, string estado, DateTime fecha_creacion)
        {
            Conexion cnn = new Conexion();
            try
            {
                cnn.Conectar();
                string consulta = "UPDATE Proveedores SET nombre=@nombre, ruc_dni=@ruc_dni, telefono=@telefono, email=@email, direccion=@direccion, estado=@estado, fecha_creacion=@fecha_creacion WHERE id_proveedor=@id_proveedor";
                SqlCommand Comando = new SqlCommand(consulta, cnn.ObtenerConexion());
                Comando.Parameters.AddWithValue("@id_proveedor", id_proveedor);
                Comando.Parameters.AddWithValue("@nombre", nombre);
                Comando.Parameters.AddWithValue("@ruc_dni", ruc_dni);
                Comando.Parameters.AddWithValue("@telefono", telefono);
                Comando.Parameters.AddWithValue("@email", email);
                Comando.Parameters.AddWithValue("@direccion", direccion);
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
                string consulta = "DELETE FROM Proveedores WHERE id_proveedor=@id_proveedor";
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
