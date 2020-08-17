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
    public class CNRegistro
    {
        private CDRegistro objRegistro = new CDRegistro();//instanciar a la capa datos de emppleado
        private String _DescripcionEvento;
        private String _Fecha;
        private String _ID_Empleado;
       // private String _ID_Proveedor;
       // private String _ID_Cliente;
       // private String _ID_Venta;

        public DataTable MostrarEvento()
        {
            DataTable tabla = new DataTable();
            tabla = objRegistro.Mostrar();
            return tabla;
        }

        //constructor
        public CNRegistro() { }
        public String DescripcionEvento, Fecha, ID_Empleado;// ID_Proveedor, ID_Cliente, ID_Venta;


        //funciones o metodos
        public SqlDataReader RegistrarEvento()
        {
            SqlDataReader Loguear;
            Loguear = objRegistro.RegistrarEvento(DescripcionEvento, Fecha, ID_Empleado);//, ID_Proveedor, ID_Cliente, ID_Venta);
            return Loguear;
        }
    }
}
