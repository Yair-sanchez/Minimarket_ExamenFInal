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
    public partial class ComprasFrm : Form
    {
        int compra_id = 0;
        public ComprasFrm()
        {
            InitializeComponent();
        }

        private void ComprasFrm_Load(object sender, EventArgs e)
        {
            dgDatos.DataSource = Compras.obtener();
            if (dgDatos.Columns.Count > 0)
            {
                dgDatos.Columns["id_compra"].Visible = false;
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            string id_proveedor = txtid_proveedor.Text;
            DateTime fecha_hora = DateTime.Parse(txtFecha_hora.Text);
            decimal total = decimal.Parse(txtTotal.Text);
            string estado = txtEstado.Text;
            string numero_factura = txtNumero_factura.Text;
            string observaciones = txtObservaciones.Text;
            bool resultado = false;
            if (compra_id == 0)
            {
                resultado = Compras.Crear(id_proveedor, fecha_hora, total, estado, numero_factura, observaciones);
            }
            else
            {
              resultado = Compras.Editar(compra_id, id_proveedor, fecha_hora, total, estado, numero_factura, observaciones);
            }
            if (resultado)
            {
                MessageBox.Show("Operacion Realizada Correctamente");
            }
            dgDatos.DataSource = Compras.obtener();
            Limpiar();
        }
        private void Limpiar()
        {
            txtid_proveedor.Clear();
            txtFecha_hora.Clear();
            txtTotal.Clear();
            txtEstado.Clear();
            txtNumero_factura.Clear();
            txtObservaciones.Clear();
            compra_id = 0;
            txtid_proveedor.Focus();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            txtid_proveedor.Text = dgDatos.CurrentRow.Cells["id_proveedor"].Value.ToString();
            txtFecha_hora.Text = dgDatos.CurrentRow.Cells["fecha_hora"].Value.ToString();
            txtTotal.Text = dgDatos.CurrentRow.Cells["total"].Value.ToString();
            txtEstado.Text = dgDatos.CurrentRow.Cells["estado"].Value.ToString();
            txtNumero_factura.Text = dgDatos.CurrentRow.Cells["numero_factura"].Value.ToString();
            txtObservaciones.Text = dgDatos.CurrentRow.Cells["observaciones"].Value.ToString();
            compra_id = Convert.ToInt32(dgDatos.CurrentRow.Cells["id_compra"].Value.ToString());
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(dgDatos.CurrentRow.Cells["id_compra"].Value.ToString());
            bool resultado = Compras.Eliminar(id);
            if (resultado)
            {
                MessageBox.Show("Operacion Realizada Correctamente");
            }
            dgDatos.DataSource = Compras.obtener();
            Limpiar();
        }
    }
}
