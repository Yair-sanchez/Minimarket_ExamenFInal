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
    internal class Ventas
    {
        public static DataTable Obtener()
        {
            Conexion cnn = new Conexion();
            try
            {
                cnn.Conectar();
                string consulta = "SELECT * FROM ventas order by id_venta desc";
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
        public static bool Crear(string id_cliente, DateTime fecha_hora, Decimal subtotal, Decimal descuento, Decimal total, string estado, string tipo_comprobante, string numero_comprobante)
        {
            Conexion cnn = new Conexion();
            try
            {
                cnn.Conectar();
                string consulta = "INSERT INTO ventas (id_cliente, Fecha_hora, subtotal, descuento, total, estado, tipo_comprobante, numero_comprobante) VALUES (@id_cliente, @fecha_hora, @subtotal, @descuento, @total, @estado, @tipo_comprobante, @numero_comprobante)";
                SqlCommand comando = new SqlCommand(consulta, cnn.ObtenerConexion());
                comando.Parameters.AddWithValue("@id_cliente", id_cliente);
                comando.Parameters.AddWithValue("@fecha_hora", fecha_hora);
                comando.Parameters.AddWithValue("@subtotal", subtotal);
                comando.Parameters.AddWithValue("@descuento", descuento);
                comando.Parameters.AddWithValue("@total", total);
                comando.Parameters.AddWithValue("@estado", estado);
                comando.Parameters.AddWithValue("@tipo_comprobante", tipo_comprobante);
                comando.Parameters.AddWithValue("@numero_comprobante", numero_comprobante);
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
        public static bool Editar(int id, string id_cliente, DateTime fecha_hora, Decimal subtotal, Decimal descuento, Decimal total, string estado, string tipo_comprobante, string numero_comprobante)
        {
            Conexion cnn = new Conexion();
            try
            {
                cnn.Conectar();
                string consulta = "UPDATE ventas SET id_cliente=@id_cliente, Fecha_hora=@fecha_hora, subtotal=@subtotal, descuento=@descuento, total=@total, estado=@estado, tipo_comprobante=@tipo_comprobante, numero_comprobante=@numero_comprobante WHERE id_venta=@id_venta";
                SqlCommand comando = new SqlCommand(consulta, cnn.ObtenerConexion());
                comando.Parameters.AddWithValue("@id_venta", id);
                comando.Parameters.AddWithValue("@id_cliente", id_cliente);
                comando.Parameters.AddWithValue("@fecha_hora", fecha_hora);
                comando.Parameters.AddWithValue("@subtotal", subtotal);
                comando.Parameters.AddWithValue("@descuento", descuento);
                comando.Parameters.AddWithValue("@total", total);
                comando.Parameters.AddWithValue("@estado", estado);
                comando.Parameters.AddWithValue("@tipo_comprobante", tipo_comprobante);
                comando.Parameters.AddWithValue("@numero_comprobante", numero_comprobante);
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
                string consulta = "DELETE FROM ventas WHERE id_venta=@id_venta";
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
