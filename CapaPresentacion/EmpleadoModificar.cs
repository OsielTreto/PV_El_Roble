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
    public partial class EmpleadoModificar : Form
    {
        private SqlConnection Conexion = new SqlConnection("server=LAPTOP\\SQLEXPRESS; Database=Punto de venta; Integrated Security=true");
        SqlCommand global;
        SqlDataReader lectura;

        public EmpleadoModificar()
        {
            InitializeComponent();
            cbPuesto2.Items.Add("Administrador");
            cbPuesto2.Items.Add("Empleado");
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            lbMensaje.Visible = false;
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
                        if (cbPuesto2.Text != "Administrador" && cbPuesto2.Text != "Empleado")
                        {
                            lbMensaje.Text = "Seleccione un cargo";
                            lbMensaje.Visible = true;
                        }
                        else { 
                            lbMensaje.Visible = false;
                            if (txtUsuario.Text == "USUARIO")
                            {
                                lbMensaje.Text = "Ingrese usuario";
                                lbMensaje.Visible = true;
                            }
                            else
                            {
                                lbMensaje.Visible = false;
                                if (txtEmail.Text == "EMAIL")
                                {
                                    lbMensaje.Text = "Ingrese email";
                                    lbMensaje.Visible = true;
                                }
                                else
                                {
                                    lbMensaje.Visible = false;
                                    if (txtPass.Text == "CONTRASEÑA")
                                    {
                                        lbMensaje.Text = "Ingrese contraseña";
                                        lbMensaje.Visible = true;
                                    }
                                    else
                                    {
                                        lbMensaje.Visible = false;
                                        if (txtConfPass.Text != txtPass.Text)
                                        {
                                            lbMensaje.Text = "Las contraseñas no coinciden";
                                            lbMensaje.Visible = true;
                                        }
                                        else
                                        {
                                            lbMensaje.Visible = false;

                                            bool banderaAux = false, banderaAux2 = false, banderaAux3 = false, banderaAux4 = false;

                                            if (txtUsuario.Text == lbUsuarioActual.Text)
                                            {
                                                banderaAux4 = true;
                                            }

                                            if (banderaAux4 == true)
                                            {

                                            }
                                            else { 

                                            Conexion.Open();
                                            String cadena2;
                                            cadena2 = "Select * from Empleado";
                                            global = new SqlCommand(cadena2, Conexion);
                                            lectura = global.ExecuteReader();
                                            while (lectura.Read())
                                            {
                                                if (txtUsuario.Text.Equals(lectura.GetString(5)))
                                                {
                                                    banderaAux = true;
                                                }
                                            }
                                            Conexion.Close();

                                        }
                                            if (banderaAux == true)
                                            {
                                                lbMensaje.Text = "El usuario no esta disponible";
                                                lbMensaje.Visible = true;
                                            }
                                            //
                                            else
                                            {
                                                lbMensaje.Visible = false;

                                                if (txtEmail.Text == lbEmailActual.Text)
                                                {
                                                    banderaAux3 = true;
                                                }

                                                if (banderaAux3 == true)
                                                {

                                                }
                                                else { 
                                                Conexion.Open();
                                                String cadena3;
                                                cadena3 = "Select * from Empleado";
                                                global = new SqlCommand(cadena3, Conexion);
                                                lectura = global.ExecuteReader();
                                                while (lectura.Read())
                                                {
                                                    if (txtEmail.Text.Equals(lectura.GetString(6)))
                                                    {
                                                        banderaAux2 = true;
                                                    }
                                                }
                                                Conexion.Close();
                                            }
                                                if (banderaAux2 == true)
                                                {
                                                    lbMensaje.Text = "Este email ya esta en uso";
                                                    lbMensaje.Visible = true;
                                                }
                                                else
                                                {
                                                    lbMensaje.Visible = false;


                                                    if (validacion.email_bien_escrito(txtEmail.Text) == true)
                                                    {
                                                        lbMensaje.Visible = false;
                                                        if (MessageBox.Show("¿Desea continuar?", "Actualizar empleado", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question) == DialogResult.Yes)
                                                        {
                                                            CN_Empleado objEmpleado = new CN_Empleado();
                                                            objEmpleado.ModificarEmpleado(lbId.Text, txtNombre.Text, txtApePa.Text, txtApeMa.Text, cbPuesto2.Text, txtUsuario.Text, txtEmail.Text, txtConfPass.Text);
                                                            MessageBox.Show("Empleado actualizado con exito");

                                                            txtPass.UseSystemPasswordChar = false;
                                                            txtConfPass.UseSystemPasswordChar = false;

                                                            /*
                                                                txtNombre.Text = "NOMBRE";
                                                                txtApePa.Text = "APELLIDO PATERNO";
                                                                txtApeMa.Text = "APELLIDO MATERNO";
                                                                txtUsuario.Text = "USUARIO";
                                                                txtEmail.Text = "EMAIL";
                                                                txtPass.Text = "CONTRASEÑA";
                                                                txtConfPass.Text = "CONFIRMAR CONTRASEÑA";*/

                                                            txtNombre.ForeColor = Color.DarkGray;
                                                            txtApePa.ForeColor = Color.DarkGray;
                                                            txtApeMa.ForeColor = Color.DarkGray;
                                                            txtUsuario.ForeColor = Color.DarkGray;
                                                            txtEmail.ForeColor = Color.DarkGray;
                                                            txtPass.ForeColor = Color.DarkGray;
                                                            txtConfPass.ForeColor = Color.DarkGray;

                                                            this.Close();
                                                        }
                                                    }
                                                    else
                                                    {
                                                        lbMensaje.Text = "Ingrese un correo valido";
                                                        lbMensaje.Visible = true;
                                                    }
                                                        
                                        }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }

        private void btnMin_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;

        }

        private void btnCer_Click(object sender, EventArgs e)
        {
            this.Close();

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

        private void txtUsuario_Enter(object sender, EventArgs e)
        {
            if (txtUsuario.Text == "USUARIO")
            {
                txtUsuario.Text = "";
                txtUsuario.ForeColor = Color.DimGray;

            }
        }

        private void txtUsuario_Leave(object sender, EventArgs e)
        {
            if (txtUsuario.Text == "")
            {
                txtUsuario.Text = "USUARIO";
                txtUsuario.ForeColor = Color.DarkGray;
            }
        }

        private void txtEmail_Enter(object sender, EventArgs e)
        {
            if (txtEmail.Text == "EMAIL")
            {
                txtEmail.Text = "";
                txtEmail.ForeColor = Color.DimGray;

            }
        }

        private void txtEmail_Leave(object sender, EventArgs e)
        {
            if (txtEmail.Text == "")
            {
                txtEmail.Text = "EMAIL";
                txtEmail.ForeColor = Color.DarkGray;
            }
        }

        private void txtPass_Enter(object sender, EventArgs e)
        {
            if (txtPass.Text == "CONTRASEÑA")
            {
                txtPass.Text = "";
                txtPass.ForeColor = Color.DimGray;
                txtPass.UseSystemPasswordChar = true;


            }
        }

        private void txtPass_Leave(object sender, EventArgs e)
        {
            if (txtPass.Text == "")
            {
                txtPass.Text = "CONTRASEÑA";
                txtPass.ForeColor = Color.DarkGray;
                txtPass.UseSystemPasswordChar = false;

            }
        }

        private void txtConfPass_Enter(object sender, EventArgs e)
        {
            if (txtConfPass.Text == "CONFIRMAR CONTRASEÑA")
            {
                txtConfPass.Text = "";
                txtConfPass.ForeColor = Color.DimGray;
                txtConfPass.UseSystemPasswordChar = true;


            }
        }

        private void txtConfPass_Leave(object sender, EventArgs e)
        {
            if (txtConfPass.Text == "")
            {
                txtConfPass.Text = "CONFIRMAR CONTRASEÑA";
                txtConfPass.ForeColor = Color.DarkGray;
                txtConfPass.UseSystemPasswordChar = false;

            }
        }
        CDValidacion validacion = new CDValidacion();

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

        private void txtUsuario_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void txtEmail_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void txtPass_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void txtConfPass_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void txtPass_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
