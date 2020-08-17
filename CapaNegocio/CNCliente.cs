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
    public class CNCliente
    {
        private CDCliente objDatoCliente = new CDCliente();//instanciar a la capa datos de emppleado
        private String _nombre;
        private String _apellido_paterno;
        private String _apellido_materno;
        private String _direccion;
        private String _telefono;

        public DataTable MostrarCliente()
        {
            DataTable tabla = new DataTable();
            tabla = objDatoCliente.Mostrar();
            return tabla;
        }

        //constructor
        public CNCliente() { }

        public String nombre, apellido_paterno, apellido_materno, direccion, telefono;
        //funciones o metodos

        public SqlDataReader RegistrarClientes()
        {
            SqlDataReader Loguear;
            Loguear = objDatoCliente.RegistrarCliente(nombre, apellido_paterno, apellido_materno, direccion, telefono);

            return Loguear;
        }

        public void ModificarCliente(string id, string nombre, string apellido_paterno, string apellido_materno, string direccion, string telefono)
        {
            objDatoCliente.EditarCliente(id, nombre, apellido_paterno,apellido_materno, direccion, telefono);
        }

        public void EliminarCliente(string id)
        {
            objDatoCliente.EliminarCliente(id);
        }
    }
}

