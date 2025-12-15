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
    public partial class VentasFrm : Form
    {
        int venta_id = 0;
        public VentasFrm()
        {
            InitializeComponent();
        }

        private void VentasFrm_Load(object sender, EventArgs e)
        {
            dgDatos.DataSource = Ventas.Obtener();
            if (dgDatos.Columns.Count > 0)
            {
                dgDatos.Columns["id_venta"].Visible = false;
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            string id_cliente = txtID_cliente.Text;
            DateTime fecha_hora = DateTime.Parse(txtFecha_hora.Text);
            Decimal subtotal = Decimal.Parse(txtSubtotal.Text);
            Decimal descuento = Decimal.Parse(txtDescuento.Text);
            Decimal total = Decimal.Parse(txtTotal.Text);
            string estado = txtEstado.Text;
            string tipo_comprobante = txtTipo_comprobante.Text;
            string numero_comprobante = txtNumero_comprobante.Text;
            bool resultado = false;
            if (venta_id == 0)
            {
                resultado = Ventas.Crear(id_cliente, fecha_hora, subtotal, descuento, total, estado, tipo_comprobante, numero_comprobante);
            }
            else
            {
                resultado = Ventas.Editar(venta_id, id_cliente, fecha_hora, subtotal, descuento, total, estado, tipo_comprobante, numero_comprobante);
            }
            if (resultado)
            {
                MessageBox.Show("Operación Realizada Correctamente");
            }
            dgDatos.DataSource = Ventas.Obtener();
            Limpiar();
        }
        private void Limpiar()
        {
            txtID_cliente.Clear();
            txtFecha_hora.Clear();
            txtSubtotal.Clear();
            txtDescuento.Clear();
            txtTotal.Clear();
            txtEstado.Clear();
            txtTipo_comprobante.Clear();
            txtNumero_comprobante.Clear();
            venta_id = 0;
            txtID_cliente.Focus();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            txtID_cliente.Text = dgDatos.CurrentRow.Cells["id_cliente"].Value.ToString();
            txtFecha_hora.Text = dgDatos.CurrentRow.Cells["fecha_hora"].Value.ToString();
            txtSubtotal.Text = dgDatos.CurrentRow.Cells["subtotal"].Value.ToString();
            txtDescuento.Text = dgDatos.CurrentRow.Cells["descuento"].Value.ToString();
            txtTotal.Text = dgDatos.CurrentRow.Cells["total"].Value.ToString();
            txtEstado.Text = dgDatos.CurrentRow.Cells["estado"].Value.ToString();
            txtTipo_comprobante.Text = dgDatos.CurrentRow.Cells["tipo_comprobante"].Value.ToString();
            txtNumero_comprobante.Text = dgDatos.CurrentRow.Cells["numero_comprobante"].Value.ToString();
            venta_id = Convert.ToInt32(dgDatos.CurrentRow.Cells["id_venta"].Value.ToString());
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(dgDatos.CurrentRow.Cells["id_venta"].Value.ToString());
            bool resultado = Ventas.Eliminar(id);
            if (resultado)
            {
                MessageBox.Show("Venta Eliminada Correctamente");
            }
            dgDatos.DataSource = Ventas.Obtener();
            Limpiar();
        }
    }
}
