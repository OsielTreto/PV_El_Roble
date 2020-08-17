using System;
using System.Collections.Generic;
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
    public partial class Registros : Form
    {
        public Registros()
        {
            InitializeComponent();
            CNRegistro objRegistro = new CNRegistro();
            tablaRegistro.DataSource = objRegistro.MostrarEvento();
        }

        private void btnCer_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Registros_Load(object sender, EventArgs e)
        {

        }
    }
}
