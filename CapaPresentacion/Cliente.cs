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
    public partial class Cliente : Form
    {


        public Cliente()
        {
            InitializeComponent();
            CNCliente objCliente = new CNCliente();
            tablaCliente.DataSource = objCliente.MostrarCliente();
        }

        private void btnCer_Click(object sender, EventArgs e)
        {
            
            this.Close();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            ClienteAgregar objAgregarCliente = new ClienteAgregar();
            objAgregarCliente.ShowDialog();
            CNCliente objCliente = new CNCliente();
            tablaCliente.DataSource = objCliente.MostrarCliente();
        }

        private void tablaCliente_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Cliente_Load(object sender, EventArgs e)
        {
            CNCliente objCliente = new CNCliente();
            tablaCliente.DataSource = objCliente.MostrarCliente();
        }


        

        string ID;
        private void button2_Click(object sender, EventArgs e)
        {
           // ID = tablaCliente.Rows[e.RowIndex].Cells[0].Value.ToString();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            if (tablaCliente.SelectedRows.Count>0)
            {
                ClienteModificar objModCliente = new ClienteModificar();
                objModCliente.lbId.Text = tablaCliente.CurrentRow.Cells["ID Cliente"].Value.ToString();
                objModCliente.txtNombre.Text = tablaCliente.CurrentRow.Cells["Nombre"].Value.ToString();
                objModCliente.txtApePa.Text = tablaCliente.CurrentRow.Cells["Apellido Paterno"].Value.ToString();
                objModCliente.txtApeMa.Text = tablaCliente.CurrentRow.Cells["Apellido Materno"].Value.ToString();
                objModCliente.txtDire.Text = tablaCliente.CurrentRow.Cells["Direccion"].Value.ToString();
                objModCliente.txtTel.Text = tablaCliente.CurrentRow.Cells["Telefono"].Value.ToString();
                objModCliente.ShowDialog();
                CNCliente objCliente = new CNCliente();
                tablaCliente.DataSource = objCliente.MostrarCliente();

            }
            else
            {
                MessageBox.Show("Es necesario seleccionar un cliente");
            }
        }
        Boolean a = false;
        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (tablaCliente.SelectedRows.Count>0)
            {
                if (MessageBox.Show("¿Desea eliminar el cliente?", "Eliminar cliente", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    try
                    {
                        string idCliente;
                        idCliente = tablaCliente.CurrentRow.Cells["ID Cliente"].Value.ToString();
                        CNCliente objCliente = new CNCliente();
                        objCliente.EliminarCliente(idCliente);
                    }
                    catch (Exception x)
                    {
                        a = true;
                    }
                    if (a==true)
                    {
                        MessageBox.Show("No se pueden eliminar elementos relacionados con otras tablas");
                        a = false;
                        CNCliente objCliente = new CNCliente();
                        tablaCliente.DataSource = objCliente.MostrarCliente();

                    }
                    else
                    {
                        MessageBox.Show("Cliente eliminado con exito");
                        a = false;
                        CNCliente objCliente = new CNCliente();
                        tablaCliente.DataSource = objCliente.MostrarCliente();
                    }
                }
            }
            else
            {
                MessageBox.Show("Es necesario seleccionar un cliente");

            }
        }
    }
}
