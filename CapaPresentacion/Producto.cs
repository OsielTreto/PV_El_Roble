using System;
using System.Collections.Generic;
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
    public partial class Producto : Form
    {
        public Producto()
        {
            InitializeComponent();
            CNProducto objProducto = new CNProducto();
            tablaProducto.DataSource = objProducto.MostrarProducto();
        }



        private void Privilegios()
        {
            if (Program.Cargo!="Administrador")
            {
                Opciones.Visible = false;
                tablaProducto.Height =  604;
                tablaProducto.Width = 1030;
                btnCerrar2.Left = 1006;
            }
            else
            {
                btnCerrar2.Visible = false;
            }
        }

        private void btnCer_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            CNProveedores objProveedores = new CNProveedores();


            ProductoAgregar objAgrePro = new ProductoAgregar();
            objAgrePro.ShowDialog();
            CNProducto objProducto = new CNProducto();
            tablaProducto.DataSource = objProducto.MostrarProducto();
        }

        private void Producto_Load(object sender, EventArgs e)
        {
            Privilegios();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();

        }
        Boolean a = false;

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (tablaProducto.SelectedRows.Count > 0)
            {
                if (MessageBox.Show("¿Desea eliminar el producto?", "Eliminar producto", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    try
                    {
                        string idProducto;
                        idProducto = tablaProducto.CurrentRow.Cells["ID Producto"].Value.ToString();
                        CNProducto objProducto = new CNProducto();
                        objProducto.EliminarProducto(idProducto);
                    }
                    catch (Exception x)
                    {
                        a = true;
                    }
                    if (a == true)
                    {
                        MessageBox.Show("No se pueden eliminar elementos relacionados con otras tablas");
                        a = false;
                        CNProducto objProducto = new CNProducto();
                        tablaProducto.DataSource = objProducto.MostrarProducto();

                    }
                    else
                    {
                        MessageBox.Show("Cliente eliminado con exito");
                        a = false;
                        CNProducto objProducto = new CNProducto();
                        tablaProducto.DataSource = objProducto.MostrarProducto();
                    }
                }
            }
            else
            {
                MessageBox.Show("Es necesario seleccionar un producto");

            }
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            if (tablaProducto.SelectedRows.Count > 0)
            {
                ProductoModificar objProdMod = new ProductoModificar();
                objProdMod.txtCodigo.Text = tablaProducto.CurrentRow.Cells["Codigo"].Value.ToString();
                objProdMod.lbId.Text = tablaProducto.CurrentRow.Cells["ID Producto"].Value.ToString();
                objProdMod.txtNombre.Text = tablaProducto.CurrentRow.Cells["Nombre"].Value.ToString();
                objProdMod.txtPreMen.Text = tablaProducto.CurrentRow.Cells["Precio_Menudeo"].Value.ToString();
                objProdMod.txtPreMay.Text = tablaProducto.CurrentRow.Cells["Precio_Mayoreo"].Value.ToString();
                objProdMod.txtCantidad.Text = tablaProducto.CurrentRow.Cells["Cantidad"].Value.ToString();
                objProdMod.tbDescripcion.Text = tablaProducto.CurrentRow.Cells["Descripcion"].Value.ToString();
                objProdMod.label3.Text = tablaProducto.CurrentRow.Cells["Codigo"].Value.ToString();
                //objProdMod.cbProveedor.Text = tablaProducto.CurrentRow.Cells["Telefono"].Value.ToString();
                objProdMod.ShowDialog();
                CNProducto objProducto = new CNProducto();
                tablaProducto.DataSource = objProducto.MostrarProducto();

            }
            else
            {
                MessageBox.Show("Es necesario seleccionar un cliente");
            }
        }
    }
}
