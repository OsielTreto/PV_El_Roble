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
    public partial class Menu : Form
    {
        public Menu()
        {
            InitializeComponent();
        }

        private void Menu_Load(object sender, EventArgs e)
        {
            lbNombre.Text = Program.Nombre;
            lbApellido.Text = Program.Apellido;
            lbUsuario.Text = Program.Usuario;
            lbCargo.Text = Program.Cargo;
            PrivilegioUsuario();
        }
        private void PrivilegioUsuario()
        {
            //Deshabilitar btn
            if (Program.Cargo != "Administrador")
            {
                btnRegistro.Visible = false;
                btnCliente.Visible = false;
                btnEmpleado.Visible = false;
                btnProveedor.Visible = false;
            }
            //ocultar btn

            //bloquear en el evento del boton
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
            if (MessageBox.Show("¿Desea salir del sistema?", "Salir", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                this.Hide();
                FormLogin objLogin = new FormLogin();
                objLogin.Show();

            }

        }

        private void btnRest_Click(object sender, EventArgs e)
        {

            btnRest.Visible = false;
            btnMax.Visible = true;
            this.WindowState = FormWindowState.Normal;

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

        private void btnRest_Click_1(object sender, EventArgs e)
        {
            btnRest.Visible = false;
            btnMax.Visible = true;
            this.WindowState = FormWindowState.Normal;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();//Ocultar form actual
            Punto_de_venta Punto_de_venta = new Punto_de_venta();
            Punto_de_venta.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (panelMenu.Width == 200)
            {
                tmOcultarMenu.Enabled = true;
            }
            else if (panelMenu.Width == 60)
            {
                tmMostrarMenu.Enabled = true;
            }
        }

        private void tmOcultarMenu_Tick(object sender, EventArgs e)
        {
            if (panelMenu.Width <= 60)
            {
                this.tmOcultarMenu.Enabled = false;
            }
            else
            {
                this.panelMenu.Width = panelMenu.Width - 20;
            }
        }

        private void tmMostrarMenu_Tick(object sender, EventArgs e)
        {
            if (panelMenu.Width >= 200)
            {
                this.tmMostrarMenu.Enabled = false;
            }
            else
            {
                this.panelMenu.Width = panelMenu.Width + 20;
            }
        }

        private void tiHora_Tick(object sender, EventArgs e)
        {
            //lbHora.Text = DateTime.Now.ToString("hh:mm:ss");
            lbHora.Text = DateTime.Now.ToLongTimeString();
            Fecha.Text = DateTime.Now.ToLongDateString();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            AbrirForm<Empleado>();
            
        }
        public void AbrirForm<Forms>() where Forms : Form, new()
        {
            Form formulario;
            formulario = PanelPrincipal.Controls.OfType<Forms>().FirstOrDefault();
            if (formulario == null)
            {
                formulario = new Forms();
                formulario.TopLevel = false;
                formulario.FormBorderStyle = FormBorderStyle.None;
                formulario.Dock = DockStyle.Fill;
                PanelPrincipal.Controls.Add(formulario);
                PanelPrincipal.Tag = formulario;
                formulario.Show();

                formulario.BringToFront();
            }
            else
            {
                formulario.BringToFront();
                if (formulario.WindowState == FormWindowState.Minimized)
                {
                    formulario.WindowState = FormWindowState.Normal;
                }
            }
        }

        private void btnProducto_Click(object sender, EventArgs e)
        {
            AbrirForm<Producto>();
            

        }

        private void btnCliente_Click(object sender, EventArgs e)
        {
            AbrirForm<Cliente>();


        }

        private void btnRegistro_Click(object sender, EventArgs e)
        {
            AbrirForm<Registros>();

           

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            AbrirForm<Proveedor>();
           
        }
        private SqlConnection Conexion = new SqlConnection("server=LAPTOP\\SQLEXPRESS; Database=Punto de venta; Integrated Security=true");
        SqlCommand global;
        SqlDataReader lectura;

        private void btnVenta_Click(object sender, EventArgs e)
        {
            Conexion.Open();
            String cadena = "select * from Productos";
            global = new SqlCommand(cadena, Conexion);
            lectura = global.ExecuteReader();
            bool bandera = false;
            try
            {
                if (lectura.Read())
                {
                    bandera = true;
                }
                else
                {
                    bandera = false;
                }
            }catch(Exception x)
            {
                MessageBox.Show("Error: "+ x);
            }

            Conexion.Close();

            if (bandera == true)
            {
                this.Hide();
                Punto_de_venta objVenta = new Punto_de_venta();
                objVenta.WindowState = FormWindowState.Maximized;
                objVenta.Show();
                bandera = false;
            }
            else
            {
                MessageBox.Show("No hay productos registrados");
                bandera = false;
            }

            

        }
    }
       
}
