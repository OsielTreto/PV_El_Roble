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
    public class CNProveedores
    {
        private CDProveedores objDatoProveedores = new CDProveedores();//instanciar a la capa datos de emppleado
        private String _nombre;
        private String _apellido_paterno;
        private String _apellido_materno;
        private String _direccion;
        private String _telefono;

        public DataTable MostrarProveedor()
        {
            DataTable tabla = new DataTable();
            tabla = objDatoProveedores.Mostrar();
            return tabla;
        }

        //constructor
        public CNProveedores() { }

        public String nombre, apellido_paterno, apellido_materno, direccion, telefono;
        //funciones o metodos
        public SqlDataReader RegistrarProveedor()
        {
            SqlDataReader Loguear;
            Loguear = objDatoProveedores.RegistrarProveedor(nombre, apellido_paterno, apellido_materno, direccion, telefono);

            return Loguear;
        }

        public void ModificarProveedor(string id, string nombre, string apellido_paterno, string apellido_materno, string direccion, string telefono)
        {
            objDatoProveedores.EditarProveedor(id, nombre, apellido_paterno, apellido_materno, direccion, telefono);
        }

        public void EliminarProveedor(string id)
        {
            objDatoProveedores.EliminarProveedor(id);
        }
    }
}
