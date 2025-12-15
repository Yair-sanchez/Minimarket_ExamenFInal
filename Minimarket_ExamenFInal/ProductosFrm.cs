using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Minimarket_ExamenFInal;
using Minimarket_ExamenFInal.Modelos;

namespace Minimarket_ExamenFInal
{
    public partial class ProductosFrm : Form
    {
        int producto_id = 0;
        public ProductosFrm()
        {
            InitializeComponent();
        }

        private void ProductosFrm_Load(object sender, System.EventArgs e)
        {
            dgDatos.DataSource = Productos.Obtener();
            if (dgDatos.Columns.Count > 0)
            {
                dgDatos.Columns["id_producto"].Visible = false;
            }
        }
        private void btnGuardar_Click(object sender, System.EventArgs e)
        {
            string codigo_barras = txtCodigo_barras.Text;
            string nombre =  txtNombre.Text;
            string descripcion = txtDescripcion.Text;
            string id_categoria = txtID_Categoria.Text;
            decimal precio_compra = decimal.Parse(txtPrecio_compra.Text);
            decimal precio_venta = decimal.Parse(txtPrecio_venta.Text);
            decimal stock_actual = decimal.Parse(txtStock_actual.Text);
            decimal stock_minimo = decimal.Parse(txtStock_minimo.Text);
            string unidad_medida = txtUnidad_medida.Text;
            string es_perecible = txtEs_perecible.Text;
            string fecha_vencimiento = txtFecha_vencimiento.Text;
            string estado = txtEstado.Text;
            string fecha_creacion = txtFecha_creacion.Text;
            bool resultado = false;
            if (producto_id == 0)
            {
                resultado = Productos.Crear(codigo_barras, nombre, descripcion, id_categoria, precio_compra, precio_venta, stock_actual, stock_minimo, unidad_medida, es_perecible, fecha_vencimiento, estado, fecha_creacion);
            }
            else
            {
              resultado = Productos.Editar(producto_id, codigo_barras, nombre, descripcion, id_categoria, precio_compra, precio_venta, stock_actual, stock_minimo, unidad_medida, es_perecible, fecha_vencimiento, estado, fecha_creacion);
            }
            if (resultado)
            {
                MessageBox.Show("Operacion Realizada Correctamente");
            }
            dgDatos.DataSource = Productos.Obtener();
            Limpiar();
        }
        private void Limpiar()
        {
            txtCodigo_barras.Clear();
            txtNombre.Clear();
            txtDescripcion.Clear();
            txtID_Categoria.Clear();
            txtPrecio_compra.Clear();
            txtPrecio_venta.Clear();
            txtStock_actual.Clear();
            txtStock_minimo.Clear();
            txtUnidad_medida.Clear();
            txtEs_perecible.Clear();
            txtFecha_vencimiento.Clear();
            txtEstado.Clear();
            txtFecha_creacion.Clear();
            producto_id = 0;
            txtCodigo_barras.Focus();
        }

        private void btnEditar_Click(object sender, System.EventArgs e)
        {
            txtCodigo_barras.Text = dgDatos.CurrentRow.Cells["codigo_barras"].Value.ToString();
            txtNombre.Text = dgDatos.CurrentRow.Cells["nombre"].Value.ToString();
            txtDescripcion.Text = dgDatos.CurrentRow.Cells["descripcion"].Value.ToString();
            txtID_Categoria.Text = dgDatos.CurrentRow.Cells["id_categoria"].Value.ToString();
            txtPrecio_compra.Text = dgDatos.CurrentRow.Cells["precio_compra"].Value.ToString();
            txtPrecio_venta.Text = dgDatos.CurrentRow.Cells["precio_venta"].Value.ToString();
            txtStock_actual.Text = dgDatos.CurrentRow.Cells["stock_actual"].Value.ToString();
            txtStock_minimo.Text = dgDatos.CurrentRow.Cells["stock_minimo"].Value.ToString();
            txtUnidad_medida.Text = dgDatos.CurrentRow.Cells["unidad_medida"].Value.ToString();
            txtEs_perecible.Text = dgDatos.CurrentRow.Cells["es_perecible"].Value.ToString();
            txtFecha_vencimiento.Text = dgDatos.CurrentRow.Cells["fecha_vencimiento"].Value.ToString();
            txtEstado.Text = dgDatos.CurrentRow.Cells["estado"].Value.ToString();
            txtFecha_creacion.Text = dgDatos.CurrentRow.Cells["fecha_creacion"].Value.ToString();
            producto_id = int.Parse(dgDatos.CurrentRow.Cells["id_producto"].Value.ToString());
        }

        private void btnEliminar_Click(object sender, System.EventArgs e)
        {
            int id_producto = int.Parse(dgDatos.CurrentRow.Cells["id_producto"].Value.ToString());
            bool resultado = Productos.Eliminar(id_producto);
            if (resultado)
            {
                MessageBox.Show("Registro Eliminado Correctamente");
            }
            dgDatos.DataSource = Productos.Obtener();
            Limpiar();
        }
    }
}
