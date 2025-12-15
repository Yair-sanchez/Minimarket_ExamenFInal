using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Minimarket_ExamenFInal.Modelos
{
    internal class Productos
    {
        public static DataTable Obtener()
        {
            Conexion cnn = new Conexion();
            try
            {
                cnn.Conectar();
                string consulta = "SELECT * FROM productos order by id_producto desc";
                SqlCommand Comando = new SqlCommand(consulta, cnn.ObtenerConexion());
                SqlDataAdapter adaptador = new SqlDataAdapter(Comando);
                DataTable dt = new DataTable();
                adaptador.Fill(dt);
                return dt;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.ToString());
                return null;
            }
            finally
            {
                cnn.Desconectar();
            }
        }
        public static bool Crear(string codigo_barras, string nombre, string descripcion, string id_categoria, decimal precio_compra, decimal precio_venta, decimal stock_actual, decimal stock_minimo, string unidad_medida, string es_perecible, string fecha_vencimiento, string estado, string fecha_creacion)
        {
            Conexion cnn = new Conexion();
            try
            {
                cnn.Conectar();
                string consulta = "INSERT INTO productos (codigo_barras, nombre, descripcion, id_categoria, precio_compra, precio_venta, stock_actual, stock_minimo, unidad_medida, es_perecible, fecha_vencimiento, estado, fecha_creacion) VALUES (@codigo_barras, @nombre, @descripcion, @id_categoria, @precio_compra, @precio_venta, @stock_actual, @stock_minimo, @unidad_medida, @es_perecible, @fecha_vencimiento, @estado, @fecha_creacion)";
                SqlCommand Comando = new SqlCommand(consulta, cnn.ObtenerConexion());
                Comando.Parameters.AddWithValue("@codigo_barras", codigo_barras);
                Comando.Parameters.AddWithValue("@nombre", nombre);
                Comando.Parameters.AddWithValue("@descripcion", descripcion);
                Comando.Parameters.AddWithValue("@id_categoria", id_categoria);
                Comando.Parameters.AddWithValue("@precio_compra", precio_compra);
                Comando.Parameters.AddWithValue("@precio_venta", precio_venta);
                Comando.Parameters.AddWithValue("@stock_actual", stock_actual);
                Comando.Parameters.AddWithValue("@stock_minimo", stock_minimo);
                Comando.Parameters.AddWithValue("@unidad_medida", unidad_medida);
                Comando.Parameters.AddWithValue("@es_perecible", es_perecible);
                Comando.Parameters.AddWithValue("@fecha_vencimiento", fecha_vencimiento);
                Comando.Parameters.AddWithValue("@estado", estado);
                Comando.Parameters.AddWithValue("@fecha_creacion", fecha_creacion);
                Comando.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.ToString());
                return false;
            }
            finally
            {
                cnn.Desconectar();
            }
        }
        public static bool Editar(int id, string codigo_barras, string nombre, string descripcion, string id_categoria, decimal precio_compra, decimal precio_venta, decimal stock_actual, decimal stock_minimo, string unidad_medida, string es_perecible, string fecha_vencimiento, string estado, string fecha_creacion)
        {
            Conexion cnn = new Conexion();
            try
            {
                cnn.Conectar();
                string consulta = "UPDATE productos SET codigo_barras=@codigo_barras, nombre=@nombre, descripcion=@descripcion, id_categoria=@id_categoria, precio_compra=@precio_compra, precio_venta=@precio_venta, stock_actual=@stock_actual, stock_minimo=@stock_minimo, unidad_medida=@unidad_medida, es_perecible=@es_perecible, fecha_vencimiento=@fecha_vencimiento, estado=@estado, fecha_creacion=@fecha_creacion WHERE id_producto=@id_producto";
                SqlCommand Comando = new SqlCommand(consulta, cnn.ObtenerConexion());
                Comando.Parameters.AddWithValue("@id_producto", id);
                Comando.Parameters.AddWithValue("@codigo_barras", codigo_barras);
                Comando.Parameters.AddWithValue("@nombre", nombre);
                Comando.Parameters.AddWithValue("@descripcion", descripcion);
                Comando.Parameters.AddWithValue("@id_categoria", id_categoria);
                Comando.Parameters.AddWithValue("@precio_compra", precio_compra);
                Comando.Parameters.AddWithValue("@precio_venta", precio_venta);
                Comando.Parameters.AddWithValue("@stock_actual", stock_actual);
                Comando.Parameters.AddWithValue("@stock_minimo", stock_minimo);
                Comando.Parameters.AddWithValue("@unidad_medida", unidad_medida);
                Comando.Parameters.AddWithValue("@es_perecible", es_perecible);
                Comando.Parameters.AddWithValue("@fecha_vencimiento", fecha_vencimiento);
                Comando.Parameters.AddWithValue("@estado", estado);
                Comando.Parameters.AddWithValue("@fecha_creacion", fecha_creacion);
                Comando.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.ToString());
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
                string consulta = "DELETE FROM productos WHERE id_producto=@id_producto";
                SqlCommand Comando = new SqlCommand(consulta, cnn.ObtenerConexion());
                Comando.Parameters.AddWithValue("@id", id);
                Comando.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.ToString());
                return false;
            }
            finally
            {
                cnn.Desconectar();
            }
        }
    }
}
