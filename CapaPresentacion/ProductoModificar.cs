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
    public partial class ProductoModificar : Form
    {
        public ProductoModificar()
        {
            InitializeComponent();
        }

        private SqlConnection Conexion = new SqlConnection("server=LAPTOP\\SQLEXPRESS; Database=Punto de venta; Integrated Security=true");
        SqlCommand global;
        SqlDataReader lectura;
        string ID = "";
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

        private void txtCantidad_Enter(object sender, EventArgs e)
        {
            if (txtCantidad.Text == "CANTIDAD")
            {
                txtCantidad.Text = "";
                txtCantidad.ForeColor = Color.DimGray;

            }
        }

        private void txtCantidad_Leave(object sender, EventArgs e)
        {
            if (txtCantidad.Text == "" || Convert.ToInt32(txtCantidad.Text) <= 0)
            {
                txtCantidad.Text = "CANTIDAD";
                txtCantidad.ForeColor = Color.DarkGray;
            }
        }

        private void txtPreMen_Enter(object sender, EventArgs e)
        {
            if (txtPreMen.Text == "PRECIO MENUDEO")
            {
                txtPreMen.Text = "";
                txtPreMen.ForeColor = Color.DimGray;

            }
        }

        private void txtPreMen_Leave(object sender, EventArgs e)
        {
            if (txtPreMen.Text == ".")
            {
                txtPreMen.Text = "PRECIO MENUDEO";
                txtPreMen.ForeColor = Color.DarkGray;
            }
            else
            if (txtPreMen.Text == "" || Convert.ToDecimal(txtPreMen.Text) <= 0)
            {
                txtPreMen.Text = "PRECIO MENUDEO";
                txtPreMen.ForeColor = Color.DarkGray;
            }
        }

        private void txtPreMay_Enter(object sender, EventArgs e)
        {
            if (txtPreMay.Text == "PRECIO MAYOREO")
            {
                txtPreMay.Text = "";
                txtPreMay.ForeColor = Color.DimGray;

            }
        }

        private void txtPreMay_Leave(object sender, EventArgs e)
        {
            if (txtPreMay.Text == ".")
            {
                txtPreMay.Text = "PRECIO MAYOREO";
                txtPreMay.ForeColor = Color.DarkGray;
            }
            else
            if (txtPreMay.Text == "" || Convert.ToDecimal(txtPreMay.Text) <= 0)
            {
                txtPreMay.Text = "PRECIO MAYOREO";
                txtPreMay.ForeColor = Color.DarkGray;
            }
        }
        CDValidacion validacion = new CDValidacion();

        private void txtNombre_KeyPress(object sender, KeyPressEventArgs e)
        {
            validacion.soloLetras(e);
        }

        private void txtCantidad_KeyPress(object sender, KeyPressEventArgs e)
        {
            validacion.soloNumeros(e);
        }

        private void txtPreMen_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = validacion.Precios(Convert.ToInt32(e.KeyChar), txtPreMen);
        }

        private void txtPreMay_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = validacion.Precios(Convert.ToInt32(e.KeyChar), txtPreMay);
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            lbMensaje.Visible = true;
            if (txtCodigo.Text == "CODIGO")
            {
                lbMensaje.Text = "Ingrese codigo";
                lbMensaje.Visible = true;
            }
            else
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
                    if (txtCantidad.Text == "CANTIDAD")
                    {
                        lbMensaje.Text = "Ingrese cantidad";
                        lbMensaje.Visible = true;
                    }
                    else
                    {
                        lbMensaje.Visible = false;
                        if (txtPreMen.Text == "PRECIO MENUDEO")
                        {
                            lbMensaje.Text = "Ingrese precio menudeo";
                            lbMensaje.Visible = true;
                        }
                        else
                        {
                            lbMensaje.Visible = false;
                            if (txtPreMay.Text == "PRECIO MAYOREO")
                            {
                                lbMensaje.Text = "Ingrese precio mayoreo";
                                lbMensaje.Visible = true;
                            }
                            else
                            {
                                lbMensaje.Visible = false;
                                if (cbProveedor.Text.Length == 0)
                                {
                                    lbMensaje.Text = "Seleccione proveedor";
                                    lbMensaje.Visible = true;
                                }
                                else
                                {
                                    lbMensaje.Visible = false;
                                    if (tbDescripcion.Text == "DESCRIPCIÓN")
                                    {
                                        lbMensaje.Text = "Ingrese descripción";
                                        lbMensaje.Visible = true;
                                    }
                                    else
                                    {
                                        lbMensaje.Visible = false;

                                        bool banderaAux = false, banderaAux2 = false;

                                        if (txtCodigo.Text == label3.Text)
                                        {
                                            banderaAux2 = true;
                                        }


                                        if (banderaAux2 == true) {
                                        }
                                        else { 

                                        Conexion.Open();
                                        String cadena2;
                                        cadena2 = "Select * from Productos";
                                        global = new SqlCommand(cadena2, Conexion);
                                        lectura = global.ExecuteReader();
                                        while (lectura.Read())
                                        {
                                            if (txtCodigo.Text.Equals(lectura.GetString(6)))
                                            {
                                                banderaAux = true;
                                            }
                                        }
                                        Conexion.Close();
                                        //AQUIIII
                                    }

                                        if (banderaAux == true)
                                        {
                                                lbMensaje.Text = "El codigo ya ha sido registrado";
                                                lbMensaje.Visible = true;
                                            }
                                        else
                                        {
                                            lbMensaje.Visible = false;

                                            //ID Proveedor
                                            Conexion.Open();
                                    String cadena = "select * from Proveedores";
                                    global = new SqlCommand(cadena, Conexion);
                                    lectura = global.ExecuteReader();
                                    string idProveedor = "";
                                    while (lectura.Read())
                                    {
                                        if ((lectura.GetString(1) + " " + lectura.GetString(2) + " " + lectura.GetString(3)).Equals(cbProveedor.Text))
                                        {
                                            idProveedor = lectura.GetValue(0).ToString();
                                        }
                                    }
                                    Conexion.Close();

                                            if (MessageBox.Show("¿Desea continuar?", "Actualizar producto", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question) == DialogResult.Yes)
                                            {
                                                CNProducto objProducto = new CNProducto();

                                                objProducto.ModificarProducto(lbId.Text, txtCodigo.Text, txtNombre.Text, txtPreMen.Text, txtPreMay.Text, txtCantidad.Text, idProveedor, tbDescripcion.Text);
                                                MessageBox.Show("Producto actualizado con exito");
                                                /*
                                                txtNombre.Text = "NOMBRE";
                                                txtApePa.Text = "APELLIDO PATERNO";
                                                txtApeMa.Text = "APELLIDO MATERNO";
                                                txtDire.Text = "DIRECCIÓN";
                                                txtTel.Text = "TELEFONO";*/
                                                txtCodigo.ForeColor = Color.DarkGray;
                                                txtNombre.ForeColor = Color.DarkGray;
                                                txtPreMen.ForeColor = Color.DarkGray;
                                                txtPreMay.ForeColor = Color.DarkGray;
                                                tbDescripcion.ForeColor = Color.DarkGray;
                                                txtCantidad.ForeColor = Color.DarkGray;
                                                this.Close();
                                            
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

        private void ProductoModificar_Load(object sender, EventArgs e)
        {
            Conexion.Open();
            String cadena = "select * from Proveedores";
            global = new SqlCommand(cadena, Conexion);
            lectura = global.ExecuteReader();


            while (lectura.Read())
            {
                cbProveedor.Items.Add(lectura.GetString(1) + " " + lectura.GetString(2) + " " + lectura.GetString(3));
            }
            Conexion.Close();

            try
            {
                cbProveedor.SelectedIndex = 0;

            }
            catch (Exception x)
            {
                MessageBox.Show("Necesita registrar almenos un proveedor para registar un producto");
                this.Close();
            }
        }

        private void txtCodigo_Enter(object sender, EventArgs e)
        {
            if (txtCodigo.Text == "CODIGO")
            {
                txtCodigo.Text = "";
                txtCodigo.ForeColor = Color.DimGray;

            }
        }

        private void txtCodigo_Leave(object sender, EventArgs e)
        {
            if (txtCodigo.Text == "")
            {
                txtCodigo.Text = "CODIGO";
                txtCodigo.ForeColor = Color.DarkGray;
            }
        }

        private void txtCodigo_KeyPress(object sender, KeyPressEventArgs e)
        {
            validacion.soloNumeros(e);
        }

        private void tbDescripcion_Enter(object sender, EventArgs e)
        {
            if (tbDescripcion.Text == "DESCRIPCIÓN")
            {
                tbDescripcion.Text = "";
                tbDescripcion.ForeColor = Color.DimGray;

            }
        }

        private void tbDescripcion_Leave(object sender, EventArgs e)
        {
            if (tbDescripcion.Text == "")
            {
                tbDescripcion.Text = "DESCRIPCIÓN";
                tbDescripcion.ForeColor = Color.DarkGray;
            }
        }

        private void tbDescripcion_KeyPress(object sender, KeyPressEventArgs e)
        {
        }
    }
}
