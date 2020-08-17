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
    public class CN_Empleado
    {
        private CD_Empleado objDatoEmpleado = new CD_Empleado();//instanciar a la capa datos de emppleado
        private String _nombre;
        private String _apellido_paterno;
        private String _apellido_materno;
        private String _puesto;
        private String _Usuario;
        private String _email;
        private String _contraseña;

        public DataTable MostrarEmpleado()
        {
            DataTable tabla = new DataTable();
            tabla = objDatoEmpleado.Mostrar();
            return tabla;
        }

        //constructor
        public CN_Empleado() { }

        public String nombre, apellido_paterno, apellido_materno, puesto, usuario, email, contraseña;

        //funciones o metodos
        public SqlDataReader RegistrarEmpleado()
        {
            SqlDataReader Loguear;
            Loguear = objDatoEmpleado.RegistrarEmpleado(nombre, apellido_paterno, apellido_materno, puesto, usuario, email, contraseña);
            return Loguear;
        }

        public void ModificarEmpleado(string id, string nombre, string apellido_paterno, string apellido_materno,
            string cargo, string usuario, string email, string contraseña)
        {
            objDatoEmpleado.EditarEmpleado(id, nombre, apellido_paterno, apellido_materno, cargo, usuario,email,contraseña);
        }

        public void EliminarEmpleado(string id)
        {
            objDatoEmpleado.EliminarEmpleado(id);
        }
    }
}
