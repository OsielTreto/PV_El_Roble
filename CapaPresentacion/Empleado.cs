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
    public partial class Empleado : Form
    {
        public Empleado()
        {
            InitializeComponent();
            CN_Empleado obj_Empleado = new CN_Empleado();
            tablaEmpleado.DataSource = obj_Empleado.MostrarEmpleado();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            tablaEmpleado.Columns[0].Width = 200;
            tablaEmpleado.Columns[1].Width = 862;
            tablaEmpleado.Columns[2].Width = 10;
            tablaEmpleado.Columns[3].Width = 200;
        }

        private void btnCer_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            EmpleadoAgregar objAgregarEmpleado = new EmpleadoAgregar();
            objAgregarEmpleado.ShowDialog();
            CN_Empleado obj_Empleado = new CN_Empleado();
            tablaEmpleado.DataSource = obj_Empleado.MostrarEmpleado();
        }
        private void Empleado_Load(object sender, EventArgs e)
        {
            CN_Empleado obj_Empleado = new CN_Empleado();
            tablaEmpleado.DataSource = obj_Empleado.MostrarEmpleado();
        }
        public String CargoEmpleado;
        private void button1_Click(object sender, EventArgs e)
        {
            if (tablaEmpleado.SelectedRows.Count > 0)
            {
                EmpleadoModificar objModEmpleado = new EmpleadoModificar();
                objModEmpleado.lbId.Text = tablaEmpleado.CurrentRow.Cells["ID Empleado"].Value.ToString();
                objModEmpleado.txtNombre.Text = tablaEmpleado.CurrentRow.Cells["Nombre"].Value.ToString();
                objModEmpleado.txtApePa.Text = tablaEmpleado.CurrentRow.Cells["Apellido Paterno"].Value.ToString();
                objModEmpleado.txtApeMa.Text = tablaEmpleado.CurrentRow.Cells["Apellido Materno"].Value.ToString();
                objModEmpleado.txtUsuario.Text = tablaEmpleado.CurrentRow.Cells["Usuario"].Value.ToString();
                objModEmpleado.txtEmail.Text = tablaEmpleado.CurrentRow.Cells["Email"].Value.ToString();
                //objModEmpleado.txtConfPass.Text = tablaEmpleado.CurrentRow.Cells["Contraseña"].Value.ToString();
                objModEmpleado.cbPuesto2.Text = tablaEmpleado.CurrentRow.Cells["Cargo"].Value.ToString();
                objModEmpleado.lbUsuarioActual.Text = tablaEmpleado.CurrentRow.Cells["Usuario"].Value.ToString();
                objModEmpleado.lbEmailActual.Text = tablaEmpleado.CurrentRow.Cells["Email"].Value.ToString();



                objModEmpleado.ShowDialog();
                CN_Empleado obj_Empleado = new CN_Empleado();
                tablaEmpleado.DataSource = obj_Empleado.MostrarEmpleado();

            }
            else
            {
                MessageBox.Show("Es necesario seleccionar un empleado");
            }
        }
        Boolean a = false;

        private void button2_Click(object sender, EventArgs e)
        {
            if (tablaEmpleado.SelectedRows.Count > 0)
            {
                if (MessageBox.Show("¿Desea eliminar el empleado?", "Eliminar cliente cliente", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    try
                    {
                        string idEmpleado;
                        idEmpleado = tablaEmpleado.CurrentRow.Cells["ID Empleado"].Value.ToString();
                        CN_Empleado obj_Empleado = new CN_Empleado();
                        obj_Empleado.EliminarEmpleado(idEmpleado);
                    }
                    catch (Exception x)
                    {
                        a = true;
                    }
                    if (a == true)
                    {
                        MessageBox.Show("No se pueden eliminar elementos relacionados con otras tablas");
                        a = false;
                        CN_Empleado obj_Empleado = new CN_Empleado();
                        tablaEmpleado.DataSource = obj_Empleado.MostrarEmpleado();

                    }
                    else
                    {
                        MessageBox.Show("Empleado eliminado con exito");
                        a = false;
                        CN_Empleado obj_Empleado = new CN_Empleado();
                        tablaEmpleado.DataSource = obj_Empleado.MostrarEmpleado();

                    }
                }
            }
            else
            {
                MessageBox.Show("Es necesario seleccionar un empleado");

            }
        }
    }
}
