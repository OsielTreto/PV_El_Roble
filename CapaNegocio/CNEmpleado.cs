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
    public class CNEmpleado
    {
        //Encapsular variables
        private CDEmpleados objDato = new CDEmpleados();//instanciar a la capa datos de emppleado
        private String _Usuario;
        private String _Contraseña;
        // variables
        //metodos GET y SET
        public string Usuario
        {
            set {
                if (value == "USUARIO") { _Usuario = "Ingrese usuario"; }
                else { _Usuario = value; }
            }
            get { return _Usuario; }
        }

        public String Contraseña
        {
            set
            {
                if (value == "CONTRASEÑA") _Contraseña = "Ingrese contraseña";
                else _Contraseña = value;
                                 }
            get { return _Contraseña; }
        }

        //constructor
        public CNEmpleado() { }

        //funciones o metodos
        public SqlDataReader IniciarSesión()
        {
            SqlDataReader Loguear;
            Loguear = objDato.iniciarSesion(Usuario,Contraseña);
            return Loguear;
        }
    }
}
