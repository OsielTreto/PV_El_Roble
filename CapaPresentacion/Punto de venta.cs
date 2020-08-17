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
    public partial class Punto_de_venta : Form
    {
        decimal V = Convert.ToDecimal(00.0000);
        private SqlConnection Conexion = new SqlConnection("server=LAPTOP\\SQLEXPRESS; Database=Punto de venta; Integrated Security=true");
        SqlCommand global;
        SqlDataReader lectura;
        decimal totalPagar = 0;
        bool banderaCliente = false;

        public Punto_de_venta()
        {
            InitializeComponent();
        }

        private void Restriccion()
        {
            lbUsuario.Text = Program.Usuario;
        }

        private void btnMin_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;

        }

        private void btnMax_Click(object sender, EventArgs e)
        {
            
            this.WindowState = FormWindowState.Maximized;
        }

        private void btnCer_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Desea salir del punto de venta?", "Cerrar punto de venta", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                this.Hide();
                Menu objMenu = new Menu();
                objMenu.Show(); 

            }
            //   Application.Exit();

        }

        private void btnRest_Click(object sender, EventArgs e)
        {
            
            this.WindowState = FormWindowState.Normal;
        }
        int posY = 0;
        int posX = 0;
        private void panel1_MouseMove(object sender, MouseEventArgs e)
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

        private void panel3_MouseMove(object sender, MouseEventArgs e)
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

        private void timer1_Tick(object sender, EventArgs e)
        {
            lbHora.Text = DateTime.Now.ToLongTimeString();
            lbFecha.Text = DateTime.Now.ToLongDateString();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            


        }
       

        private void Punto_de_venta_Load(object sender, EventArgs e)
        {
            tablaVenta.Columns.Add("articulo", "Articulo");
            tablaVenta.Columns.Add("codigo", "Codigo");
            tablaVenta.Columns.Add("descripción", "Descripción");
            tablaVenta.Columns.Add("costo", "Costo");
            tablaVenta.Columns.Add("cantidad", "Cantidad");
            tablaVenta.Columns.Add("costofinal", "Costo final");
            tablaVenta.Columns.Add("tipoprecio", "Tipo Precio");

            tablaRegistrar.Columns.Add("idproducto", "Id Producto");
            tablaRegistrar.Columns.Add("idempleado", "Id Empleado");
            tablaRegistrar.Columns.Add("fecha", "Fecha");
            tablaRegistrar.Columns.Add("costo", "Costo");
            tablaRegistrar.Columns.Add("idcliente", "Cliente");
            tablaRegistrar.Columns.Add("cantidad", "Cantidad");
            tablaRegistrar.Columns.Add("costofinal", "Costo final");
            tablaRegistrar.Columns.Add("stockactual", "Stock Actual");
            tablaRegistrar.Columns.Add("tipoprecio", "Tipo Precio");


            lbNumeroProductos.Text = Convert.ToString(tablaVenta.Rows.Count);

            Conexion.Open();
            tbProducto.Text = "";
            CDProducto objProd = new CDProducto();
            objProd.AutocompletarProductos(tbProducto);
            objProd.AutocompletarCliente(tbCliente);
            Restriccion();
            Conexion.Close();


            tablaVenta.Columns[0].Width = 200;
            tablaVenta.Columns[1].Width = 150;
            tablaVenta.Columns[2].Width = 300;
            tablaVenta.Columns[3].Width = 200;
            tablaVenta.Columns[4].Width = 100;
            tablaVenta.Columns[5].Width = 200;
            tablaVenta.Columns[6].Width = 180;

        }

        private void tbBuscar_TextChanged(object sender, EventArgs e)
        {

        }
        CDValidacion validacion = new CDValidacion();

        private void tbBuscar_KeyPress(object sender, KeyPressEventArgs e)
        {
        }

        private void tbCantidad_KeyPress(object sender, KeyPressEventArgs e)
        {
            
                validacion.soloNumeros(e);
            
            }

        private void tbCliente_KeyPress(object sender, KeyPressEventArgs e)
        {
            validacion.soloLetras(e);
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            //AGREGAR VENTA A TABLA
            if (tbProducto.Text == "")
            {
                MessageBox.Show("Seleccione un producto");
            }
            else
            {
                if (tbCantidad.Text == "")
                {
                    MessageBox.Show("Ingrese la cantidad");
                }
                else if (Convert.ToInt32( tbCantidad.Text) <= 0)
                {
                    MessageBox.Show("Ingrese otra cantidad");
                }
                else{
                     
                        //OPERACION AGREGAR VENTA
                        String idProducto="", idEmpleado="", Fecha="", idCliente="",Descripcion="", Nombre="", Codigo="", TipoPrecio="";
                        decimal Cantidad = 0, Costo=0, CostoFinal=0, stock=0;
                        
                        bool bandera1=false, bandera2=false, banderaActCliente = false;

                        idEmpleado = Program.ID_Empleado;
                        Cantidad = Convert.ToDecimal(tbCantidad.Text);

                    if (cbCliente.Checked == true)
                    {
                        banderaActCliente = true;
                    }
                    

                        Conexion.Open();
                        String cadena1 = "select * from Productos";
                        global = new SqlCommand(cadena1, Conexion);
                        lectura = global.ExecuteReader();
                        Int32 TipoPrecioPosicion=0;

                        while (lectura.Read())
                        {
                            if ((lectura.GetString(1)).Equals(tbProducto.Text) || (lectura.GetString(6)).Equals(tbProducto.Text))
                            {
                                idProducto = lectura.GetValue(0).ToString();
                                stock = Convert.ToDecimal(lectura.GetValue(4).ToString());
                                    if (cbCliente.Checked==true)
                                    {
                                        Costo = Convert.ToDecimal(lectura.GetValue(3).ToString());
                                        TipoPrecio = "Mayoreo";
                                        TipoPrecioPosicion = 3;
                                    }
                                    else 
                                    {
                                        Costo = Convert.ToDecimal(lectura.GetValue(2).ToString());
                                        TipoPrecio = "Menudeo";
                                        TipoPrecioPosicion = 2;
                                    }

                                    CostoFinal = (Convert.ToDecimal( lectura.GetValue(TipoPrecioPosicion))) * Cantidad;
                                Descripcion = lectura.GetValue(7).ToString();
                                Nombre = lectura.GetValue(1).ToString();
                                Codigo = lectura.GetValue(6).ToString();
                                bandera1 = true;
                            }
                        }
                        Conexion.Close();

                        if (banderaActCliente == true)
                        {
                        if (tbCliente.Text == "")
                        {
                            MessageBox.Show("Ingrese cliente");
                        }
                        else
                        {
                            Conexion.Open();
                            String cadena2 = "select * from Cliente";
                            global = new SqlCommand(cadena2, Conexion);
                            lectura = global.ExecuteReader();

                            while (lectura.Read())
                            {
                                if ((lectura.GetString(1) + " " + lectura.GetString(2) + " " + lectura.GetString(3) + " " + lectura.GetString(4)).Equals(tbCliente.Text))
                                {
                                    idCliente = lectura.GetString(1) + " " + lectura.GetString(2) + " " + lectura.GetString(3) + " " + lectura.GetString(4);
                                    bandera2 = true;
                                }
                            }
                            Conexion.Close();
                        }
                    }
                    else
                    {
                        bandera2 = true;
                        idCliente = "Sin registrar";
                    }

                       


                        if (bandera1 == false)
                        {
                            MessageBox.Show("El producto no se encuentra registrado");
                        }
                        else if (Cantidad > stock)
                        {
                            MessageBox.Show("Solo se cuentan con " + stock + " productos disponibles");
                        }
                        else if (bandera2 == false)
                        {
                            MessageBox.Show("El cliente no se encuentra registrado");
                        }
                        else
                        {
                            //tbCliente.Text = "";

                            if (tablaVenta.Rows.Count <= 0)
                            {
                                tbCliente.Enabled = true;
                            }

                            bool existe = false, StockDisponible = false;
                            decimal a, b, CANT = 0, FINAL = 0;
                            int posicion = 0;

                            if (tablaVenta.RowCount > 0)
                            {
                                for (int i = 0; i < tablaVenta.RowCount; i++)
                                {
                                    if (Convert.ToString(tablaVenta.Rows[i].Cells["articulo"].Value).Equals(Nombre) &&
                                        Convert.ToString(tablaVenta.Rows[i].Cells["codigo"].Value).Equals(Codigo.ToString()) &&
                                        Convert.ToString(tablaVenta.Rows[i].Cells["descripción"].Value).Equals(Descripcion) &&
                                        Convert.ToString(tablaVenta.Rows[i].Cells["costo"].Value).Equals(Costo.ToString())
                                        )
                                        
                                        //Convert.ToString(tablaVenta.Rows[i].Cells["cantidad"].Value).Equals(Cantidad.ToString()) &&
                                        //Convert.ToString(tablaVenta.Rows[i].Cells["costofinal"].Value).Equals(CostoFinal.ToString())
                                        
                                    {
                                        //MessageBox.Show("Se ha encontrado el producto   i = " + i);
                                        existe = true;
                                        a = Convert.ToDecimal(tablaVenta.Rows[i].Cells["cantidad"].Value);
                                        b = Convert.ToDecimal(tablaVenta.Rows[i].Cells["costofinal"].Value);

                                        CANT = (a + Cantidad);
                                        FINAL = (b + CostoFinal);
                                        posicion = i;
                                        break;
                                    }
                                }
                            }


                            if (existe == true)
                            {
                                if (CANT > stock)
                                {
                                    MessageBox.Show("Solo se cuentan con "+ stock+ " productos en existencia");
                                }
                                else
                                {
                                    tablaVenta.Rows[posicion].Cells["cantidad"].Value = CANT;
                                    tablaVenta.Rows[posicion].Cells["costofinal"].Value = FINAL;

                                    tablaRegistrar.Rows[posicion].Cells["cantidad"].Value = CANT;
                                    tablaRegistrar.Rows[posicion].Cells["costofinal"].Value = FINAL;
                                        tbCliente.Enabled = false;
                                        //rbMayoreo.Checked = false;
                                        //rbMenudeo.Checked = false;
                                        tbProducto.Text = "";
                                        tbCantidad.Text = "";
                                    }
                            }
                            else
                            {
                                Fecha = Convert.ToString(DateTime.Now);
                                tablaVenta.Rows.Add(Nombre, Codigo, Descripcion, Costo, Cantidad, CostoFinal,TipoPrecio);
                                tablaRegistrar.Rows.Add(idProducto, idEmpleado, Fecha, Costo, idCliente, Cantidad, CostoFinal, stock,TipoPrecio);
                                    tbCliente.Enabled = false;
                                    //rbMayoreo.Checked = false;
                                    //rbMenudeo.Checked = false;
                                    cbCliente.Enabled = false;
                                    tbProducto.Text = "";
                                    tbCantidad.Text = "";
                                }


                            lbNumeroProductos.Text = Convert.ToString(tablaVenta.Rows.Count);
                            decimal totalPagar = 0;
                            foreach (DataGridViewRow row in tablaVenta.Rows)
                            {
                                if (row.Cells["costofinal"].Value != null)
                                {
                                    totalPagar += (decimal)row.Cells["costofinal"].Value;
                                }
                                lbTotalPagar.Text = Convert.ToString(totalPagar);
                            }

                            //tablaRegistrar.Columns.Add("idproducto", "Id Producto");
                            //tablaRegistrar.Columns.Add("idempleado", "Id Empleado");
                            //tablaRegistrar.Columns.Add("fecha", "Fecha");
                            //tablaRegistrar.Columns.Add("costo", "Costo");
                            //tablaRegistrar.Columns.Add("idcliente", "Id Cliente");
                            //tablaRegistrar.Columns.Add("cantidad", "Cantidad");
                            //tablaRegistrar.Columns.Add("costofinal", "Costo final");

                            //tablaVenta.Columns.Add("articulo", "Articulo");
                            //tablaVenta.Columns.Add("codigo", "Codigo");
                            //tablaVenta.Columns.Add("descripción", "Descripción");
                            //tablaVenta.Columns.Add("costo", "Costo");
                            //tablaVenta.Columns.Add("cantidad", "Cantidad");
                            //tablaVenta.Columns.Add("costofinal", "Costo final");

                            /*MessageBox.Show("DATOS A REGISTRAR EN VENTAS    " + "Id Producto: " + idProducto.ToString() +
                                          "  Id Empleado: " + idEmpleado.ToString() +
                                          "  Fecha: " + Fecha.ToString() +
                                          "  Id Cliente: " + idCliente.ToString() +
                                          "  Cantidad: " + Cantidad.ToString() +
                                          "  Monto: " + CostoFinal.ToString() +
                                          "  Stock: " + stock.ToString());
                                          */
                        }   
                        
                    
                }
            }

        }

        private void textBox3_Enter(object sender, EventArgs e)
        {
            if (tbMontoRecibido.Text == "00.00")
            {
                tbMontoRecibido.Text = "";
                tbMontoRecibido.ForeColor = Color.Black;
            }
        }

        private void textBox3_Leave(object sender, EventArgs e)
        {
            if (tbMontoRecibido.Text == "")
            {
                tbMontoRecibido.Text = "00.00";
                tbMontoRecibido.ForeColor = Color.Black;
            }
        }

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            
            if (tbMontoRecibido.Text == "0")
            {
                tbMontoRecibido.Text = "";
            }
            else
            {
                e.Handled = validacion.Precios(Convert.ToInt32(e.KeyChar), tbMontoRecibido);
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
                if (tablaVenta.SelectedRows.Count > 0)
                {
                    tablaVenta.Rows.RemoveAt(tablaVenta.CurrentRow.Index);
                try
                {
                    tablaRegistrar.Rows.RemoveAt(tablaVenta.CurrentRow.Index);
                }
                catch (Exception x)
                {
                    tablaRegistrar.Rows.RemoveAt(0);
                    tbCliente.Text = "";
                    tbProducto.Text = "";
                    tbCantidad.Text = "";
                    //rbMayoreo.Checked = false;
                    //rbMenudeo.Checked = false;
                    tbCliente.Enabled = true;
                    cbCliente.Enabled = true;
                    cbCliente.Checked = false;
                }
                lbNumeroProductos.Text = Convert.ToString(tablaVenta.Rows.Count);

                    foreach (DataGridViewRow row in tablaVenta.Rows)
                    {
                        if (row.Cells["costofinal"].Value != null)
                        {
                            totalPagar += (decimal)row.Cells["costofinal"].Value;
                        }
                        lbTotalPagar.Text = Convert.ToString(totalPagar);
                    }
                    if (tablaVenta.Rows.Count == 0)
                    {
                        lbTotalPagar.Text = "00.00";
                    }
                }
                else
                {
                    //MessageBox.Show("Es necesario seleccionar un producto");
                }
        }

        private void btnCobrar_Click(object sender, EventArgs e)
        {
                if (Convert.ToDecimal(lbTotalPagar.Text) == Convert.ToDecimal(0.0000))
                {
                    MessageBox.Show("Agrege un producto");
                }
                else
                {
                    if (Convert.ToDecimal(lbTotalPagar.Text) > Convert.ToDecimal(tbMontoRecibido.Text))
                    {
                        MessageBox.Show("No cuenta con dinero suficiente");
                    }
                    else
                    {
                    if (MessageBox.Show("¿Desea continuar con la venta?", "Compra", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        Compra objTicket = new Compra();
                        objTicket.lbTotalPagar.Text = "$ " + lbTotalPagar.Text;
                        objTicket.lbMontoRecibido.Text = "$ " + tbMontoRecibido.Text;
                        objTicket.lbCambio.Text = "$ " + Convert.ToString(Convert.ToDecimal(tbMontoRecibido.Text) - Convert.ToDecimal(lbTotalPagar.Text));

                        
                        SqlDataReader Registrar;
                        //REGISTRAR EN BD VENTAS
                        Int64 StockFinal=0;
                        foreach (DataGridViewRow row in tablaRegistrar.Rows)
                        {
                            CNVenta objVenta = new CNVenta();
                            objVenta.RegistrarVenta(row.Cells["idproducto"].Value.ToString(),
                                row.Cells["idempleado"].Value.ToString(),
                                row.Cells["fecha"].Value.ToString(),
                                row.Cells["costo"].Value.ToString(),
                                row.Cells["idcliente"].Value.ToString(),
                                row.Cells["cantidad"].Value.ToString(),
                                row.Cells["costofinal"].Value.ToString(),
                                row.Cells["tipoprecio"].Value.ToString());

                            //ACTUALIZAR STOCK PRODUCTOS
                            StockFinal = (Convert.ToInt64(row.Cells["stockactual"].Value) - Convert.ToInt64( row.Cells["cantidad"].Value.ToString()));
                            //MessageBox.Show(Convert.ToString(StockFinal));
                            objVenta.ActualizarStock(row.Cells["idproducto"].Value.ToString(), Convert.ToString(StockFinal));
                        }
                        
                        objTicket.ShowDialog();

                        cbCliente.Enabled = true;
                        tbProducto.Text = "";
                        tbCantidad.Text = "";
                        tbCliente.Text = "";
                        tbCliente.Enabled = true;
                        cbCliente.Enabled = true;
                        cbCliente.Checked = false;
                        //rbMayoreo.Checked = false;
                        //rbMenudeo.Checked = false;
                        tbMontoRecibido.Text = "00.00";
                        lbTotalPagar.Text = "00.00";
                        tablaVenta.Rows.Clear();
                        tablaRegistrar.Rows.Clear();
                        Conexion.Open();
                        tbProducto.Text = "";
                        tbProducto.Clear();
                        CDProducto objProd = new CDProducto();
                        objProd.AutocompletarProductos(tbProducto);
                        objProd.AutocompletarCliente(tbCliente);
                        Restriccion();
                        Conexion.Close();
                    }
                }
            }
        }

        private void btnNuevaCompra_Click(object sender, EventArgs e)
        {
            cbCliente.Enabled = true;
            //rbMayoreo.Checked = false;
            //rbMenudeo.Checked = false;
            tbProducto.Text = "";
            tbCantidad.Text = "";
            tbCliente.Text = "";
            tbCliente.Enabled = true;
            tbMontoRecibido.Text = "00.00";
            lbTotalPagar.Text = "00.00";
            tablaVenta.Rows.Clear();
            tablaRegistrar.Rows.Clear();
        }

        private void cbCliente_CheckedChanged(object sender, EventArgs e)
        {
            if (cbCliente.Checked == true)
            {
                Conexion.Open();
                String cadena = "select * from Cliente";
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
                }
                catch (Exception x)
                {
                    MessageBox.Show("Error: " + x);
                }

                Conexion.Close();
                if (bandera == true)
                {
                    label4.Visible = true;
                    tbCliente.Visible = true;
                    tbCliente.Enabled = true;
                    bandera = false;
                }
                else
                {
                    MessageBox.Show("No hay clientes registrados");
                    cbCliente.Checked = false;
                    bandera = false;
                }
                
            }
            else
            {
                label4.Visible = false;
                tbCliente.Visible = false;
                tbCliente.Enabled = false;
            }
        }
        String ventaTotal;


        private void btnCorteCaja_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Desea realizar el corte de caja?, una vez que realice el corte no podra hacer mas ventas", "corte de caja", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                btnAgregar.Enabled = false;
                Devolucion objDev = new Devolucion();
                objDev.ShowDialog();
            }


                

            
            
        }

        private void btnBuscarProducto_Click(object sender, EventArgs e)
        {
            MostrarProductos objMostrar = new MostrarProductos();
            objMostrar.ShowDialog();
        }


        /*
private void textBox1_TextChanged(object sender, EventArgs e)
{
if (tbBuscar.Text!= "")
{
tablaVenta.CurrentCell = null;
foreach (DataGridViewRow r in tablaVenta.Rows)
{
r.Visible = false;
}
foreach (DataGridViewRow r in tablaVenta.Rows)
{
foreach (DataGridViewCell c in r.Cells)
{
if ((c.Value.ToString().ToUpper()).IndexOf(tbBuscar.Text.ToUpper())==0)
{
r.Visible = true;
break;
}

}
}
}
else
{
CNProducto objProd = new CNProducto();
tablaVenta.DataSource = objProd.MostrarProducto();
}


}*/
    }
}
