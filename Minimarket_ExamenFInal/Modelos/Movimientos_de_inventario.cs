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
    internal class Movimientos_de_inventario
    {
        public static DataTable Obtener()
        {
            Conexion cnn = new Conexion();
            try
            {
                cnn.Conectar();
                string consulta = "SELECT * FROM Movimientos_inventarios order by id_movimiento desc";
                SqlCommand comando = new SqlCommand(consulta, cnn.ObtenerConexion());
                SqlDataAdapter adaptador = new SqlDataAdapter(comando);
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
        public static bool Crear(string id_producto, string tipo_movimiento, string cantidad, DateTime fecha_hora, string referencia_id, string referencia_tipo, string motivo, string usuario, Decimal stock_anterior, Decimal stock_nuevo)
        {
            Conexion cnn = new Conexion();
            try
            {
                cnn.Conectar();
                string consulta = "INSERT INTO movimientos_inventarios (id_producto, tipo_movimeinto, cantidad, fecha_hora, referencia_id, referencia_tipo, motivo, usuario, stock_anterior, stock_nuevo) VALUES (@id_producto, @tipo_movimeinto, @cantidad, @fecha_hora, @referencia_id, @referencia_tipo, @motivo, @usuario, @stock_anterior, @stock_nuevo)";
                SqlCommand comando = new SqlCommand(consulta, cnn.ObtenerConexion());
                comando.Parameters.AddWithValue("@id_producto", id_producto);
                comando.Parameters.AddWithValue("@tipo_movimiento", tipo_movimiento);
                comando.Parameters.AddWithValue("@cantidad", cantidad);
                comando.Parameters.AddWithValue("@fecha_hora", fecha_hora);
                comando.Parameters.AddWithValue("@referencia_id", referencia_id);
                comando.Parameters.AddWithValue("@referencia_tipo", referencia_tipo);
                comando.Parameters.AddWithValue("@motivo", motivo);
                comando.Parameters.AddWithValue("@usuario", usuario);
                comando.Parameters.AddWithValue("@stock_anterior", stock_anterior);
                comando.Parameters.AddWithValue("@stock_nuevo", stock_nuevo);
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
        public static bool Editar(int id, string id_producto, string tipo_movimiento, string cantidad, DateTime fecha_hora, string referencia_id, string referencia_tipo, string motivo, string usuario, Decimal stock_anterior, Decimal stock_nuevo)
        {
            Conexion cnn = new Conexion();
            try
            {
                cnn.Conectar();
                string consulta = "UPDATE movimientos_inventarios set @id_producto=id_producto, @tipo_movimiento=tipo_movimiento, @cantidad=cantidad, @fecha_hora=fecha_hora, @referencia_id=referencia_id, @referencia_tipo=referencia_tipo, @motivo=@motivo, @usuario=usuario, @stock_anterior=stock_anterior, @stock_nuevo=stock_nuevo";
                SqlCommand comando = new SqlCommand(consulta, cnn.ObtenerConexion());
                comando.Parameters.AddWithValue("@id_movimiento", id);
                comando.Parameters.AddWithValue("@id_producto", id_producto);
                comando.Parameters.AddWithValue("@tipo_movimiento", tipo_movimiento);
                comando.Parameters.AddWithValue("@cantidad", cantidad);
                comando.Parameters.AddWithValue("@fecha_hora", fecha_hora);
                comando.Parameters.AddWithValue("@referencia_id", referencia_id);
                comando.Parameters.AddWithValue("@referencia_tipo", referencia_tipo);
                comando.Parameters.AddWithValue("@motivo", motivo);
                comando.Parameters.AddWithValue("@usuario", usuario);
                comando.Parameters.AddWithValue("@stock_anterior", stock_anterior);
                comando.Parameters.AddWithValue("@stock_nuevo", stock_nuevo);
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
                string consulta = "DELETE FROM movimientos_inventarios WHERE id_movimiento=@id_movimiento";
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
