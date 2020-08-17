using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace CapaDatos
{
    public class CDProveedores
    {
        private CDConexion Conexion = new CDConexion();
        private SqlDataReader leer;

        DataTable tabla = new DataTable();
        SqlCommand comando = new SqlCommand();

        public DataTable Mostrar()
        {
            comando.Connection = Conexion.AbrirConexion();
            comando.CommandText = "SPMostrarProveedor";
            comando.CommandType = CommandType.StoredProcedure;
            leer = comando.ExecuteReader();
            tabla.Load(leer);
            Conexion.CerrarConexion();
            return tabla;
        }

        public SqlDataReader RegistrarProveedor(string nombre, string apellido_paterno, string apellido_materno, string direccion, string telefono)
        {
            SqlCommand comando = new SqlCommand("SPRegistrarProveedor", Conexion.AbrirConexion());
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@Nombre", nombre);
            comando.Parameters.AddWithValue("@Apellido_Paterno", apellido_paterno);
            comando.Parameters.AddWithValue("@Apellido_Materno", apellido_materno);
            comando.Parameters.AddWithValue("@Direccion", direccion);
            comando.Parameters.AddWithValue("@Telefono", telefono);


            leer = comando.ExecuteReader();
            return leer;
        }

        public void EditarProveedor(string id, string nombre, string apellido_paterno, string apellido_materno, string direccion, string telefono)
        {
            comando.Connection = Conexion.AbrirConexion();
            comando.CommandText = "SPModificarProveedor";
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@IdProveedor", id);
            comando.Parameters.AddWithValue("@Nombre", nombre);
            comando.Parameters.AddWithValue("@ApellidoPaterno", apellido_paterno);
            comando.Parameters.AddWithValue("@ApellidoMaterno", apellido_materno);
            comando.Parameters.AddWithValue("@Direccion", direccion);
            comando.Parameters.AddWithValue("@Telefono", telefono);
            comando.ExecuteNonQuery();
            comando.Parameters.Clear();
        }

        public void EliminarProveedor(string id)
        {
            comando.Connection = Conexion.AbrirConexion();
            comando.CommandText = "SPEliminarProveedor";
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@IdProveedor", id);
            comando.ExecuteNonQuery();
            comando.Parameters.Clear();

        }
    }
}
