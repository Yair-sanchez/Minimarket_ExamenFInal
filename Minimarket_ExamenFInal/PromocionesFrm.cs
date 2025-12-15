using System;
using System.Collections.Generic;
using System.ComponentModel;
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
    public partial class PromocionesFrm : Form
    {
        int promocion_id = 0;
        public PromocionesFrm()
        {
            InitializeComponent();
        }

        private void PromocionesFrm_Load(object sender, EventArgs e)
        {
            dgDatos.DataSource = Promociones.Obtener();
            if (dgDatos.Columns.Count > 0)
            {
                dgDatos.Columns["id_promocion"].Visible = false;
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            string nombre = txtNombre.Text;
            string descripcion = txtDescripcion.Text;
            string tipo = txtTipo.Text;
            Decimal valor_descuento = Decimal.Parse(txtValor_descuento.Text);
            DateTime fecha_inicio = DateTime.Parse(txtFecha_inicio.Text);
            DateTime fecha_fin = DateTime.Parse(txtFecha_fin.Text);
            string estado = txtEstado.Text;
            bool resultado = false;
            if (promocion_id == 0)
            {
                resultado = Promociones.Crear(nombre, descripcion, tipo, valor_descuento, fecha_inicio, fecha_fin, estado);
            }
            else
            {
                resultado = Promociones.Editar(promocion_id, nombre, descripcion, tipo, valor_descuento, fecha_inicio, fecha_fin, estado);
            }
            if (resultado)
            {
                MessageBox.Show("Operacion Realizada Correctamente");
            }
            dgDatos.DataSource = Promociones.Obtener();
            Limpiar();
        }
        private void Limpiar()
        {
            txtNombre.Clear();
            txtDescripcion.Clear();
            txtTipo.Clear();
            txtValor_descuento.Clear();
            txtFecha_inicio.Clear();
            txtFecha_fin.Clear();
            txtEstado.Clear();
            promocion_id = 0;
            txtNombre.Focus();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            txtNombre.Text = dgDatos.CurrentRow.Cells["nombre"].Value.ToString();
            txtDescripcion.Text = dgDatos.CurrentRow.Cells["descripcion"].Value.ToString();
            txtTipo.Text = dgDatos.CurrentRow.Cells["tipo"].Value.ToString();
            txtValor_descuento.Text = dgDatos.CurrentRow.Cells["valor_descuento"].Value.ToString();
            txtFecha_inicio.Text = dgDatos.CurrentRow.Cells["fecha_inicio"].Value.ToString();
            txtFecha_fin.Text = dgDatos.CurrentRow.Cells["fecha_fin"].Value.ToString();
            txtEstado.Text = dgDatos.CurrentRow.Cells["estado"].Value.ToString();
            promocion_id = Convert.ToInt32(dgDatos.CurrentRow.Cells["id_promocion"].Value.ToString());
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(dgDatos.CurrentRow.Cells["id_promocion"].Value.ToString());
            bool resultado = Promociones.Eliminar(id);
            if (resultado)
            {
                MessageBox.Show("Promocion Eliminada Correctamente");
            }
            dgDatos.DataSource = Promociones.Obtener();
            Limpiar();
        }
    }
}
