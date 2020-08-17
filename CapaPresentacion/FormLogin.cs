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

namespace CapaPresentacion
{
    public partial class FormLogin : Form
    {
        public FormLogin()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Opacity = 100;
            btnMax.Visible = false;
            btnRest.Visible = true;
            this.WindowState = FormWindowState.Maximized;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            btnRest.Visible = false;
            btnMax.Visible = true;
            this.WindowState = FormWindowState.Normal;
            this.Opacity = 10;
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

        private void button4_Click(object sender, EventArgs e)
        {


            CNEmpleado objEmpleado = new CNEmpleado();
            SqlDataReader Loguear;
            objEmpleado.Usuario = txtUser.Text;
            objEmpleado.Contraseña = txtPass.Text;

            if (objEmpleado.Usuario == txtUser.Text)
            {
                lbErrorUsuario.Visible = false;
                lbErrorLogin.Visible = false;
                lbErrorContraseña.Visible = false;


                if (objEmpleado.Contraseña == txtPass.Text)
                {
                    lbErrorContraseña.Visible = false;
                    lbErrorLogin.Visible = false;

                    Loguear = objEmpleado.IniciarSesión();
                    if (Loguear.Read() == true)
                    {
                        this.Hide();
                        Menu objMENU = new Menu();
                        Program.Cargo = Loguear["Cargo"].ToString();
                        Program.Nombre = Loguear["Nombre"].ToString();
                        Program.Apellido = Loguear["Apellido Paterno"].ToString();
                        Program.Usuario = Loguear["Usuario"].ToString();
                        Program.ID_Empleado = Loguear["ID Empleado"].ToString();


                        objMENU.Show();

                    }
                    else
                    {
                        lbErrorLogin.Text = "Usuario o contraseña incorrecto";
                        lbErrorLogin.Visible = true;
                        txtPass.Text = "";
                        txtPass_Leave(null, e);
                        txtUser.Focus();
                    }
                }
                else
                {
                    lbErrorContraseña.Text = objEmpleado.Contraseña;
                    lbErrorContraseña.Visible = true;
                }
            }
            else
            {
                lbErrorUsuario.Text = objEmpleado.Usuario;
                lbErrorUsuario.Visible = true;
                lbErrorLogin.Visible = false;
                lbErrorContraseña.Visible = false;
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void txtUser_Enter(object sender, EventArgs e)
        {
            if (txtUser.Text == "USUARIO")
            {
                txtUser.Text = "";
                txtUser.ForeColor = Color.DimGray;

            }
        }

        private void txtUser_Leave(object sender, EventArgs e)
        {
            if (txtUser.Text=="")
            {
                txtUser.Text = "USUARIO";
                txtUser.ForeColor = Color.DarkGray;
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

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Mensaje objMensaje = new Mensaje();
            objMensaje.ShowDialog();
        }
    }
}
