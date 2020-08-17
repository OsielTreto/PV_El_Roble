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
    public partial class Devolucion : Form
    {
        private SqlConnection Conexion = new SqlConnection("server=LAPTOP\\SQLEXPRESS; Database=Punto de venta; Integrated Security=true");
        SqlCommand global;
        SqlDataReader lectura;
        public Devolucion()
        {
            InitializeComponent();
        }

        private void btnMin_Click(object sender, EventArgs e)
        {

        }

        private void btnCer_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        string ventaTotal;
        private void Devolucion_Load(object sender, EventArgs e)
        {
            DateTime fechas = DateTime.Now;
            string fechaConsulta = fechas.ToShortDateString();

            Conexion.Open();
            String cadena2 = "select SUM ([Costo Final]) as Total from Venta where   Fecha  like '%" + fechaConsulta + "%'";
            global = new SqlCommand(cadena2, Conexion);
            lectura = global.ExecuteReader();
            if (lectura.Read() == true)
                ventaTotal = lectura["Total"].ToString();

            Conexion.Close();

            lbTotalPagar.Text = ventaTotal;
            // MessageBox.Show("Ventas totales fecha: " + fechaConsulta + " = " + ventaTotal);

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            lbFecha.Text = DateTime.Now.ToLongDateString();
        }

        private void btnCobrar_Click(object sender, EventArgs e)
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
    }
}
