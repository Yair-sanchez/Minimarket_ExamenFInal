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
    public partial class ClientesFrm : Form
    {
        int cliente_id = 0;
        public ClientesFrm()
        {
            InitializeComponent();
        }
        private void ClientesFrm_Load(object sender, EventArgs e)
        {
            dgDatos.DataSource = Clientes.obtener();
            if (dgDatos.Columns.Count > 0)
            {
                dgDatos.Columns["id_Cliente"].Visible = false;
            }
        }

        private void btnGuardar_Click_1(object sender, EventArgs e)
        {
            string nombre = txtNombre.Text;
            string dni_ruc = txtDNI_RUC.Text;
            string telefono = txtTelefono.Text;
            string email = txtEmail.Text;
            string direccion = txtDireccion.Text;
            decimal credito_disponible = decimal.Parse(txtCredito_disponible.Text);
            decimal credito_usado = decimal.Parse(txtCredito_usado.Text);
            string estado = txtEstado.Text;
            DateTime fecha_creacion = DateTime.Parse(txtFecha_creacion.Text);
            bool resultado = false;
            if (cliente_id == 0)
            {
                resultado = Clientes.Crear(nombre, dni_ruc, telefono, email, direccion, credito_disponible, credito_usado, estado, fecha_creacion);
            }
            else
            {
                resultado = Clientes.Editar(cliente_id, nombre, dni_ruc, telefono, email, direccion, credito_disponible, credito_usado, estado, fecha_creacion);
            }
            if (resultado)
            {
                MessageBox.Show("Operacion realizada correctamente");
            }
            dgDatos.DataSource = Clientes.obtener();
            Limpiar();
        }
        private void Limpiar()
        {
            txtNombre.Clear();
            txtDNI_RUC.Clear();
            txtTelefono.Clear();
            txtEmail.Clear();
            txtDireccion.Clear();
            txtCredito_disponible.Clear();
            txtCredito_usado.Clear();
            txtEstado.Clear();
            txtFecha_creacion.Clear();
            cliente_id = 0;
            txtNombre.Focus();
        }

        private void btnEditar_Click_1(object sender, EventArgs e)
        {
            txtNombre.Text = dgDatos.CurrentRow.Cells["nombre"].Value.ToString();
            txtDNI_RUC.Text = dgDatos.CurrentRow.Cells["dni_ruc"].Value.ToString();
            txtTelefono.Text = dgDatos.CurrentRow.Cells["telefono"].Value.ToString();
            txtEmail.Text = dgDatos.CurrentRow.Cells["email"].Value.ToString();
            txtDireccion.Text = dgDatos.CurrentRow.Cells["direccion"].Value.ToString();
            txtCredito_disponible.Text = dgDatos.CurrentRow.Cells["credito_disponible"].Value.ToString();
            txtCredito_usado.Text = dgDatos.CurrentRow.Cells["credito_usado"].Value.ToString();
            txtEstado.Text = dgDatos.CurrentRow.Cells["estado"].Value.ToString();
            txtFecha_creacion.Text = dgDatos.CurrentRow.Cells["fecha_creacion"].Value.ToString();
        }

        private void btnEliminar_Click_1(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(dgDatos.CurrentRow.Cells["id_cliente"].Value.ToString());
            bool resultado = Clientes.Eliminar(id);
            if (resultado)
            {
                MessageBox.Show("Cliente Eliminado Correctamente");
            }
            dgDatos.DataSource = Clientes.obtener();
            Limpiar();
        }
    }
}
