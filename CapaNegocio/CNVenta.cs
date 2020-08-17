using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDatos;
using System.Data.SqlClient;
using System.Data;

namespace CapaNegocio
{
    public class CNVenta
    {
        private CDVenta objDatoVenta = new CDVenta();

        public CNVenta() { }
        public string IdProducto, IdEmpleado, Fecha, Costo,  IdCliente, Cantidad, CostoFinal;

        public void RegistrarVenta(string IdProducto, string IdEmpleado, string Fecha, string Costo, string IdCliente, string Cantidad, string CostoFinal, string TipoPrecio)
        {
            //SqlDataReader Loguear;
           objDatoVenta.RegistrarVenta(IdProducto, IdEmpleado, Fecha, Costo, IdCliente, Cantidad, CostoFinal, TipoPrecio);

            //return Loguear;
        }

        public void ActualizarStock(string id, string cantidad)
        {
            objDatoVenta.ActualizarStock(id, cantidad);
        }
    }
}
