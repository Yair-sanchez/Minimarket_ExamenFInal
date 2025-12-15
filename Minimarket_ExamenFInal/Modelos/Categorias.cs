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
    internal class Categorias
    {
        public static DataTable obtener()
        {
            Conexion cnn = new Conexion();
            try
            {
                cnn.Conectar();
                String consulta = "SELECT * FROM Categorias order by id_cat desc";
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
        public static bool Crear(string nombre, string descripcion, string estado, string fecha_creacion)
        {
            Conexion cnn = new Conexion();
            try
            {
                cnn.Conectar();
                string consulta = "INSERT INTO Categorias (nombre,descripcion,estado,fecha_creacion) VALUES (@nombre,@descripcion,@estado,@fecha_creacion)";
                SqlCommand Comando = new SqlCommand(consulta, cnn.ObtenerConexion());
                Comando.Parameters.AddWithValue("@nombre", nombre);
                Comando.Parameters.AddWithValue("@descripcion", descripcion);
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
        public static bool Editar(int id, string nombre, string descripcion, string estado, string fecha_creacion)
        {
            Conexion cnn = new Conexion();
            try
            {
                cnn.Conectar();
                string consulta = "UPDATE Categorias set nombre=@nombre, descripcion=@descripcion, estado=@estado, fecha_creacion=@fecha_creacion WHERE id_cat=@id_cat";
                SqlCommand comando = new SqlCommand(consulta,cnn.ObtenerConexion());
                comando.Parameters.AddWithValue("@id_cat", id);
                comando.Parameters.AddWithValue("@nombre", nombre);
                comando.Parameters.AddWithValue("@descripcion", descripcion);
                comando.Parameters.AddWithValue("@estado", estado);
                comando.Parameters.AddWithValue("@fecha_creacion", fecha_creacion);
                comando.ExecuteNonQuery();
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
                string consulta = "DELETE FROM Categorias WHERE id_cat=@id";
                SqlCommand comando = new SqlCommand(consulta, cnn.ObtenerConexion());
                comando.Parameters.AddWithValue("@id", id);
                comando.ExecuteNonQuery();
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
