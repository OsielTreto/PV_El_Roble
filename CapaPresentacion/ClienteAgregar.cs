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
    public partial class ClienteAgregar : Form
    {

        public ClienteAgregar()
        {
            InitializeComponent();
        }


        private void btnMin_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;

        }

        private void btnMax_Click(object sender, EventArgs e)
        {
            btnMax.Visible = false;
            btnRest.Visible = true;
            this.WindowState = FormWindowState.Maximized;
        }

        private void btnCer_Click(object sender, EventArgs e)
        {
            this.Close();

        }

        private void btnRest_Click(object sender, EventArgs e)
        {
            btnRest.Visible = false;
            btnMax.Visible = true;
            this.WindowState = FormWindowState.Normal;
        }

        private void btnRest_Click_1(object sender, EventArgs e)
        {
            btnRest.Visible = false;
            btnMax.Visible = true;
            this.WindowState = FormWindowState.Normal;
        }

        private void ClienteAgregar_Load(object sender, EventArgs e)
        {

        }

        private void txtUser_Enter(object sender, EventArgs e)
        {
            if (txtUser.Text == "NOMBRE")
            {
                txtUser.Text = "";
                txtUser.ForeColor = Color.DimGray;

            }
        }

        private void txtUser_Leave(object sender, EventArgs e)
        {
            if (txtUser.Text == "")
            {
                txtUser.Text = "NOMBRE";
                txtUser.ForeColor = Color.DarkGray;
            }
        }

        private void textBox1_Enter(object sender, EventArgs e)
        {
            if (txtApePa.Text == "APELLIDO PATERNO")
            {
                txtApePa.Text = "";
                txtApePa.ForeColor = Color.DimGray;

            }
        }

        private void textBox1_Leave(object sender, EventArgs e)
        {
            if (txtApePa.Text == "")
            {
                txtApePa.Text = "APELLIDO PATERNO";
                txtApePa.ForeColor = Color.DarkGray;
            }
        }

        private void txtPass_Enter(object sender, EventArgs e)
        {
            if (txtApeMa.Text == "APELLIDO MATERNO")
            {
                txtApeMa.Text = "";
                txtApeMa.ForeColor = Color.DimGray;

            }
        }

        private void txtPass_Leave(object sender, EventArgs e)
        {
            if (txtApeMa.Text == "")
            {
                txtApeMa.Text = "APELLIDO MATERNO";
                txtApeMa.ForeColor = Color.DarkGray;
            }
        }

        private void textBox2_Enter(object sender, EventArgs e)
        {
            if (txtDire.Text == "DIRECCIÓN")
            {
                txtDire.Text = "";
                txtDire.ForeColor = Color.DimGray;

            }
        }

        private void textBox2_Leave(object sender, EventArgs e)
        {
            if (txtDire.Text == "")
            {
                txtDire.Text = "DIRECCIÓN";
                txtDire.ForeColor = Color.DarkGray;
            }
        }

        private void textBox3_Enter(object sender, EventArgs e)
        {
            if (txtTel.Text == "TELEFONO")
            {
                txtTel.Text = "";
                txtTel.ForeColor = Color.DimGray;

            }
        }

        private void textBox3_Leave(object sender, EventArgs e)
        {
            if (txtTel.Text == "")
            {
                txtTel.Text = "TELEFONO";
                txtTel.ForeColor = Color.DarkGray;
            }
        }

        private void txtApePa_Enter(object sender, EventArgs e)
        {

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

        private void btnAceptarr_Click(object sender, EventArgs e)
        {

        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            lbMensaje.Visible = false;

            try
            {

                if (txtUser.Text == "NOMBRE")
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
                                    //aqui
                                    CNCliente objCliente = new CNCliente();
                                    SqlDataReader Registrar;
                                    objCliente.nombre = txtUser.Text;
                                    objCliente.apellido_paterno = txtApePa.Text;
                                    objCliente.apellido_materno = txtApeMa.Text;
                                    objCliente.direccion = txtDire.Text;
                                    objCliente.telefono = txtTel.Text;

                                    if (MessageBox.Show("¿Desea continuar con el registro?", "Registro cliente", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question) == DialogResult.Yes)
                                    {
                                        Registrar = objCliente.RegistrarClientes();
                                        MessageBox.Show("Cliente registrado con exito");

                                        txtUser.Text = "NOMBRE";
                                        txtApePa.Text = "APELLIDO PATERNO";
                                        txtApeMa.Text = "APELLIDO MATERNO";
                                        txtDire.Text = "DIRECCIÓN";
                                        txtTel.Text = "TELEFONO";

                                        txtUser.ForeColor = Color.DarkGray;
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
                MessageBox.Show("Ha ocurrido un error"+ex,"Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        

        CDValidacion validacion = new CDValidacion();

        private void txtUser_KeyPress(object sender, KeyPressEventArgs e)
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

        private void lbMensaje_Click(object sender, EventArgs e)
        {

        }
        
    }
    }
    

