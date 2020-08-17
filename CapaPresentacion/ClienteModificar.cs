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
using System.Data.SqlClient;
using CapaDatos;

namespace CapaPresentacion
{
    public partial class ClienteModificar : Form
    {
        public ClienteModificar()
        {
            InitializeComponent();

        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            
            lbMensaje.Visible = false;

            try
            {

                if (txtNombre.Text == "NOMBRE")
                {
                    lbMensaje.Text = "Ingrese nombre";
                    lbMensaje.Visible = true;
                }
                else
                {
                    lbMensaje.Visible = false;
                    if (txtApePa.Text == "APELLIDO PATERNO")
                    {
                        lbMensaje.Text = "Ingrese apellido paterno";
                        lbMensaje.Visible = true;
                    }
                    else
                    {
                        lbMensaje.Visible = false;
                        if (txtApeMa.Text == "APELLIDO MATERNO")
                        {
                            lbMensaje.Text = "Ingrese apellido materno";
                            lbMensaje.Visible = true;
                        }
                        else
                        {
                            lbMensaje.Visible = false;
                            if (txtDire.Text == "DIRECCIÓN")
                            {
                                lbMensaje.Text = "Ingrese dirección";
                                lbMensaje.Visible = true;
                            }
                            else
                            {
                                lbMensaje.Visible = false;
                                if (txtTel.Text == "TELEFONO")
                                {
                                    lbMensaje.Text = "Ingrese telefono";
                                    lbMensaje.Visible = true;
                                }
                                else
                                {

                                   

                                    if (MessageBox.Show("¿Desea continuar?", "Actualizar cliente", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question) == DialogResult.Yes)
                                    {
                                        CNCliente objCliente = new CNCliente();
                                        objCliente.ModificarCliente(lbId.Text, txtNombre.Text, txtApePa.Text, txtApeMa.Text, txtDire.Text, txtTel.Text);

                                        MessageBox.Show("Cliente actualizado con exito");
                                        /*
                                        txtNombre.Text = "NOMBRE";
                                        txtApePa.Text = "APELLIDO PATERNO";
                                        txtApeMa.Text = "APELLIDO MATERNO";
                                        txtDire.Text = "DIRECCIÓN";
                                        txtTel.Text = "TELEFONO";*/

                                        txtNombre.ForeColor = Color.DarkGray;
                                        txtApePa.ForeColor = Color.DarkGray;
                                        txtApeMa.ForeColor = Color.DarkGray;
                                        txtDire.ForeColor = Color.DarkGray;
                                        txtTel.ForeColor = Color.DarkGray;
                                        this.Close();
                                    }
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ha ocurrido un error" + ex, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        CDValidacion validacion = new CDValidacion();

        private void btnMin_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;

        }

        private void btnCer_Click(object sender, EventArgs e)
        {
            this.Close();

        }

        private void txtNombre_Enter(object sender, EventArgs e)
        {
            if (txtNombre.Text == "NOMBRE")
            {
                txtNombre.Text = "";
                txtNombre.ForeColor = Color.DimGray;

            }
        }

        private void txtNombre_Leave(object sender, EventArgs e)
        {
            if (txtNombre.Text == "")
            {
                txtNombre.Text = "NOMBRE";
                txtNombre.ForeColor = Color.DarkGray;
            }
        }

        private void txtApePa_Enter(object sender, EventArgs e)
        {
            if (txtApePa.Text == "APELLIDO PATERNO")
            {
                txtApePa.Text = "";
                txtApePa.ForeColor = Color.DimGray;

            }
        }

        private void txtApePa_Leave(object sender, EventArgs e)
        {
            if (txtApePa.Text == "")
            {
                txtApePa.Text = "APELLIDO PATERNO";
                txtApePa.ForeColor = Color.DarkGray;
            }
        }

        private void txtApeMa_Enter(object sender, EventArgs e)
        {
            if (txtApeMa.Text == "APELLIDO MATERNO")
            {
                txtApeMa.Text = "";
                txtApeMa.ForeColor = Color.DimGray;

            }
        }

        private void txtApeMa_Leave(object sender, EventArgs e)
        {
            if (txtApeMa.Text == "")
            {
                txtApeMa.Text = "APELLIDO MATERNO";
                txtApeMa.ForeColor = Color.DarkGray;
            }
        }

        private void txtDire_Enter(object sender, EventArgs e)
        {
            if (txtDire.Text == "DIRECCIÓN")
            {
                txtDire.Text = "";
                txtDire.ForeColor = Color.DimGray;

            }
        }

        private void txtDire_Leave(object sender, EventArgs e)
        {
            if (txtDire.Text == "")
            {
                txtDire.Text = "DIRECCIÓN";
                txtDire.ForeColor = Color.DarkGray;
            }
        }

        private void txtTel_Enter(object sender, EventArgs e)
        {
            if (txtTel.Text == "TELEFONO")
            {
                txtTel.Text = "";
                txtTel.ForeColor = Color.DimGray;

            }
        }

        private void txtTel_Leave(object sender, EventArgs e)
        {
            if (txtTel.Text == "")
            {
                txtTel.Text = "TELEFONO";
                txtTel.ForeColor = Color.DarkGray;
            }
        }

        private void txtNombre_KeyPress(object sender, KeyPressEventArgs e)
        {
            validacion.soloLetras(e);

        }

        private void txtApePa_KeyPress(object sender, KeyPressEventArgs e)
        {
            validacion.soloLetras(e);

        }

        private void txtApeMa_KeyPress(object sender, KeyPressEventArgs e)
        {
            validacion.soloLetras(e);

        }

        private void txtDire_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void txtTel_KeyPress(object sender, KeyPressEventArgs e)
        {
            validacion.soloNumeros(e);

        }

        private void ClienteModificar_Load(object sender, EventArgs e)
        {
            txtNombre.ForeColor = Color.DimGray;
            txtApePa.ForeColor = Color.DimGray;
            txtApeMa.ForeColor = Color.DimGray;
            txtDire.ForeColor = Color.DimGray;
            txtTel.ForeColor = Color.DimGray;
        }

        int posY = 0;
        int posX = 0;
        private void BarraSuperior_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left)
            {
                posX = e.X;
                posY = e.Y;
            }
            else
            {
                Left = Left + (e.X - posX);
                Top = Top + (e.Y - posY);
            }
        }
    }
}
