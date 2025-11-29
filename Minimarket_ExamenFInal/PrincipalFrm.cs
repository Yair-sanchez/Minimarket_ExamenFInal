using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Minimarket_ExamenFInal
{
    public partial class PrincipalFrm : Form
    {
        public PrincipalFrm()
        {
            InitializeComponent();
        }

        private void btnProveedor_Click(object sender, EventArgs e)
        {
            ProveedorFrm frm = new ProveedorFrm();
            frm.MdiParent = this;
            frm.Show();
        }

        private void btnProductos_Click(object sender, EventArgs e)
        {
            ProductosFrm frm = new ProductosFrm();
            frm.MdiParent = this;
            frm.Show();
        }

        private void btnCategoria_Click(object sender, EventArgs e)
        {
            CategoriaFrm frm = new CategoriaFrm();
            frm.MdiParent = this;
            frm.Show();
        }

        private void btnCliente_Click(object sender, EventArgs e)
        {
            ClienteFrm frm = new ClienteFrm();
            frm.MdiParent = this;
            frm.Show();
        }
    }
}
