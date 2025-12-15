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
    internal class Compras
    {
        public static DataTable obtener()
        {
            Conexion cnn = new Conexion();
            try
            {
                cnn.Conectar();
                String consulta = "SELECT * FROM Compras order by id_compra desc";
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
        public static bool Crear(string id_proveedor, DateTime fecha_hora, decimal total, string estado, string numero_factura, string observaciones)
        {
            Conexion cnn = new Conexion();
            try
            {
                cnn.Conectar();
                string consulta = "INSERT INTO Compras (id_proveedor,fecha_hora,total,estado,numero_factura,observaciones) VALUES (@proveedor_id,@fecha_hora,@total,@estado,@numero_factura,@observaciones)";
                SqlCommand Comando = new SqlCommand(consulta, cnn.ObtenerConexion());
                Comando.Parameters.AddWithValue("@id_proveedor", id_proveedor);
                Comando.Parameters.AddWithValue("@fecha_compra", fecha_hora);
                Comando.Parameters.AddWithValue("@total", total);
                Comando.Parameters.AddWithValue("@estado", estado);
                Comando.Parameters.AddWithValue("@numero_factura", numero_factura);
                Comando.Parameters.AddWithValue("@observaciones", observaciones);
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
        public static bool Editar(int id, string id_proveedor, DateTime fecha_hora, decimal total, string estado, string numero_factura, string observaciones)
        {
            Conexion cnn = new Conexion();
            try
            {
                cnn.Conectar();
                string consulta = "UPDATE Compras SET id_proveedor=@id_proveedor, fecha_hora=@fecha_hora, total=@total, estado=@estado, numero_factura=@numero_factura, observaciones=@observaciones WHERE id_compra=@id";
                SqlCommand Comando = new SqlCommand(consulta, cnn.ObtenerConexion());
                Comando.Parameters.AddWithValue("@id", id);
                Comando.Parameters.AddWithValue("@id_proveedor", id_proveedor);
                Comando.Parameters.AddWithValue("@fecha_hora", fecha_hora);
                Comando.Parameters.AddWithValue("@total", total);
                Comando.Parameters.AddWithValue("@estado", estado);
                Comando.Parameters.AddWithValue("@numero_factura", numero_factura);
                Comando.Parameters.AddWithValue("@observaciones", observaciones);
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
                string consulta = "DELETE FROM Compras WHERE id_compra=@id";
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
