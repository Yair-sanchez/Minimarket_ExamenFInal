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
    internal class Promociones
    {
        public static DataTable Obtener()
        {
            Conexion cnn = new Conexion();
            try
            {
                cnn.Conectar();
                string consulta = "SELECT * FROM Promociones order by id_promocion desc";
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
        public static bool Crear(string nombre, string descripcion, string tipo, Decimal valor_descuento, DateTime fecha_inicio, DateTime fecha_fin, string estado)
        {
            Conexion cnn = new Conexion();
            try
            {
                cnn.Conectar();
                string consulta = "INSERT INTO Promociones(nombre, descripcion, tipo, valor_descuento, fecha_inicio, fecha_fin, estado)";
                SqlCommand Comando = new SqlCommand(consulta, cnn.ObtenerConexion());
                Comando.Parameters.AddWithValue("@nombre", nombre);
                Comando.Parameters.AddWithValue("@descripcion", descripcion);
                Comando.Parameters.AddWithValue("@tipo", tipo);
                Comando.Parameters.AddWithValue("@valor_descuento", valor_descuento);
                Comando.Parameters.AddWithValue("@fecha_inicio", fecha_inicio);
                Comando.Parameters.AddWithValue("@fecha_fin", fecha_fin);
                Comando.Parameters.AddWithValue("@estado", estado);
                Comando.ExecuteNonQuery();
                return true;
            }
            catch(Exception ex)
            {
                MessageBox.Show("Error: " + ex.ToString());
                return false;
            }
            finally
            {
                cnn.Desconectar();
            }
        }
        public static bool Editar(int id, string nombre,  string descripcion, string tipo, Decimal valor_descuento, DateTime fecha_inicio, DateTime fecha_fin, string estado)
        {
            Conexion cnn = new Conexion();
            try
            {
                cnn.Conectar();
                string consulta = "UPDATE Promociones SET nombre=@nombre, descripcion=@descripcion, tipo=@tipo, valor_descuento=@valor_descuento, fecha_inicio=@fecha_inicio, fecha_fin=@fecha_fin, estado=@estado WHERE id_promocion=@id_promocion";
                SqlCommand Comando = new SqlCommand(consulta, cnn.ObtenerConexion());
                Comando.Parameters.AddWithValue("@id_promocion", id);
                Comando.Parameters.AddWithValue("@nombre", nombre);
                Comando.Parameters.AddWithValue("@descripcion", descripcion);
                Comando.Parameters.AddWithValue("@tipo", tipo);
                Comando.Parameters.AddWithValue("@valor_descuento", valor_descuento);
                Comando.Parameters.AddWithValue("@fecha_inicio", fecha_inicio);
                Comando.Parameters.AddWithValue("@fecha_fin", fecha_fin);
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
                string consulta = "DELETE FROM Promociones WHERE id_promocion=@id";
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
