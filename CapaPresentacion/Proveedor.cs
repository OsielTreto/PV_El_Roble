using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CapaNegocio;

namespace CapaPresentacion
{
    public partial class Proveedor : Form
    {
        public Proveedor()
        {
            InitializeComponent();
        }

        private void btnCer_Click(object sender, EventArgs e)
        {
            this.Close();

        }

        private void button6_Click(object sender, EventArgs e)
        {
            ProveedorAgregar objProveedor = new ProveedorAgregar();
            objProveedor.ShowDialog();
            CNProveedores objProveedors = new CNProveedores();
            tablaProveedor.DataSource = objProveedors.MostrarProveedor();
        }

        private void Proveedor_Load(object sender, EventArgs e)
        {
            CNProveedores objProveedor = new CNProveedores();
            tablaProveedor.DataSource = objProveedor.MostrarProveedor();
        }
        Boolean a = false;

        private void button2_Click(object sender, EventArgs e)
        {
            if (tablaProveedor.SelectedRows.Count > 0)
            {
                if (MessageBox.Show("¿Desea eliminar el proveedor?", "Eliminar proveedor", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    try
                    {
                        string idProveedor;
                        idProveedor = tablaProveedor.CurrentRow.Cells["ID Proveedor"].Value.ToString();
                        CNProveedores objProveedor = new CNProveedores();
                        objProveedor.EliminarProveedor(idProveedor);
                    }
                    catch (Exception x)
                    {
                        a = true;
                    }
                    if (a == true)
                    {
                        MessageBox.Show("No se pueden eliminar elementos relacionados con otras tablas");
                        a = false;
                        CNProveedores objProveedor = new CNProveedores();
                        tablaProveedor.DataSource = objProveedor.MostrarProveedor();
                    }
                    else
                    {
                        MessageBox.Show("Proveedor eliminado con exito");
                        a = false;
                        CNProveedores objProveedor = new CNProveedores();
                        tablaProveedor.DataSource = objProveedor.MostrarProveedor();
                    }
                }
            }
            else
            {
                MessageBox.Show("Es necesario seleccionar un proveedor");

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (tablaProveedor.SelectedRows.Count > 0)
            {
                ProveedorModificar objModProveedor = new ProveedorModificar();
                objModProveedor.lbId.Text = tablaProveedor.CurrentRow.Cells["ID Proveedor"].Value.ToString();
                objModProveedor.txtUser.Text = tablaProveedor.CurrentRow.Cells["Nombre"].Value.ToString();
                objModProveedor.txtApePa.Text = tablaProveedor.CurrentRow.Cells["Apellido Paterno"].Value.ToString();
                objModProveedor.txtApeMa.Text = tablaProveedor.CurrentRow.Cells["Apellido Materno"].Value.ToString();
                objModProveedor.txtDire.Text = tablaProveedor.CurrentRow.Cells["Direccion"].Value.ToString();
                objModProveedor.txtTel.Text = tablaProveedor.CurrentRow.Cells["Telefono"].Value.ToString();
                objModProveedor.ShowDialog();
                CNProveedores objProveedor = new CNProveedores();
                tablaProveedor.DataSource = objProveedor.MostrarProveedor();

            }
            else
            {
                MessageBox.Show("Es necesario seleccionar un cliente");
            }
        }
    }
}
