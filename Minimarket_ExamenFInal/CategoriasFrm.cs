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
    public partial class CategoriasFrm : Form
    {
        int categoria_id = 0;
        public CategoriasFrm()
        {
            InitializeComponent();
        }

        private void CategoriaFrm_Load(object sender, EventArgs e)
        {
            dgDatos.DataSource = Categorias.obtener();
            if (dgDatos.Columns.Count > 0 )
            {
                dgDatos.Columns["id_cat"].Visible = false;
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            string nombre = txtNombre.Text;
            string descripcion = txtDescripcion.Text;
            string estado = txtEstado.Text;
            string fecha_creacion = txtFecha_creacion.Text;
            bool resultado = false;
            if (categoria_id == 0) 
            {
                resultado = Categorias.Crear(nombre, descripcion, estado, fecha_creacion);
            }
            else
            {
                resultado = Categorias.Editar(categoria_id, nombre, descripcion, estado, fecha_creacion);
            }
            if (resultado)
            {
                MessageBox.Show("Operacion Realizada Correctamente");
            }
            dgDatos.DataSource = Categorias.obtener();
            Limpiar();

        }
        private void Limpiar()
        {
            txtNombre.Clear();
            txtDescripcion.Clear();
            txtEstado.Clear();
            txtFecha_creacion.Clear();
            categoria_id = 0;
            txtNombre.Focus();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            txtNombre.Text = dgDatos.CurrentRow.Cells["nombre"].Value.ToString();
            txtDescripcion.Text = dgDatos.CurrentRow.Cells["descripcion"].Value.ToString();
            txtEstado.Text = dgDatos.CurrentRow.Cells["estado"].Value.ToString();
            txtFecha_creacion.Text = dgDatos.CurrentRow.Cells["fecha_creacion"].Value.ToString();
            categoria_id = Convert.ToInt32(dgDatos.CurrentRow.Cells["id_cat"].Value.ToString());
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(dgDatos.CurrentRow.Cells["id_cat"].Value.ToString());
            bool resultado = Categorias.Eliminar(id);
            if (resultado)
            {
                MessageBox.Show("Categoria Eliminada Correctamente");
            }
            dgDatos.DataSource = Categorias.obtener();
            Limpiar();
        }
    }
}
