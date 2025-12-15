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
    public partial class Movimientos_de_inventarioFrm : Form
    {
        int movimiento_inventario_id = 0;
        public Movimientos_de_inventarioFrm()
        {
            InitializeComponent();
        }

        private void Movimientos_de_inventarioFrm_Load(object sender, EventArgs e)
        {
            dgDatos.DataSource = Modelos.Movimientos_de_inventario.Obtener();
            if(dgDatos.Columns.Count > 0)
            {
                dgDatos.Columns["id_movimiento"].Visible = false;
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            string id_producto = txtID_producto.Text;
            string tipo_movimiento = txtTipo_movimiento.Text;
            string cantidad = txtCantidad.Text;
            DateTime fecha_hora = DateTime.Parse(txtFecha_hora.Text);
            string referencia_id = txtReferencia_id.Text;
            string referencia_tipo = txtReferencia_tipo.Text;
            string motivo = txtMotivo.Text;
            string usuario = txtUsuario.Text;
            Decimal stock_anterior = Decimal.Parse(txtStock_anterior.Text);
            Decimal stock_nuevo = Decimal.Parse(txtStock_nuevo.Text);
            bool resultado = false;
            if(movimiento_inventario_id == 0)
            {
                resultado = Movimientos_de_inventario.Crear(id_producto, tipo_movimiento, cantidad, fecha_hora, referencia_id, referencia_tipo, motivo, usuario, stock_anterior, stock_nuevo);
            }
            else
            {
                resultado = Movimientos_de_inventario.Editar(movimiento_inventario_id, id_producto, tipo_movimiento, cantidad, fecha_hora, referencia_id, referencia_tipo, motivo, usuario, stock_anterior, stock_nuevo);
            }
            if (resultado)
            {
                MessageBox.Show("Operacion Realizada Correctamente");
            }
            dgDatos.DataSource = Movimientos_de_inventario.Obtener();
            Limpiar();
        }
        private void Limpiar()
        {
            txtID_producto.Clear();
            txtTipo_movimiento.Clear();
            txtCantidad.Clear();
            txtFecha_hora.Clear();
            txtReferencia_id.Clear();
            txtReferencia_tipo.Clear();
            txtMotivo.Clear();
            txtUsuario.Clear();
            txtStock_anterior.Clear();
            txtStock_nuevo.Clear();
            movimiento_inventario_id = 0;
            txtID_producto.Focus();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            txtID_producto.Text = dgDatos.CurrentRow.Cells["id_producto"].Value.ToString();
            txtTipo_movimiento.Text = dgDatos.CurrentRow.Cells["tipo_movimiento"].Value.ToString();
            txtCantidad.Text = dgDatos.CurrentRow.Cells["cantidad"].Value.ToString();
            txtFecha_hora.Text = dgDatos.CurrentRow.Cells["fecha_hora"].Value.ToString();
            txtReferencia_id.Text = dgDatos.CurrentRow.Cells["referencia_id"].Value.ToString();
            txtReferencia_tipo.Text = dgDatos.CurrentRow.Cells["referencia_tipo"].Value.ToString();
            txtMotivo.Text = dgDatos.CurrentRow.Cells["motivo"].Value.ToString();
            txtUsuario.Text = dgDatos.CurrentRow.Cells["usuario"].Value.ToString();
            txtStock_anterior.Text = dgDatos.CurrentRow.Cells["stock_anterior"].Value.ToString();
            txtStock_nuevo.Text = dgDatos.CurrentRow.Cells["stock_nuevo"].Value.ToString();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(dgDatos.CurrentRow.Cells["id_movimiento"].Value.ToString());
            bool resultado = Movimientos_de_inventario.Eliminar(id);
            if (resultado)
            {
                MessageBox.Show("Operacion Realizada Correctamente");
            }
            dgDatos.DataSource = Movimientos_de_inventario.Obtener();
            Limpiar();
        }
    }
}
