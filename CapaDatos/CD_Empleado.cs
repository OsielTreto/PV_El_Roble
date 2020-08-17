using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace CapaDatos
{
    public class CD_Empleado
    {
        private CDConexion Conexion = new CDConexion();
        private SqlDataReader leer;

        DataTable tabla = new DataTable();
        SqlCommand comando = new SqlCommand();

        public DataTable Mostrar()
        {
            comando.Connection = Conexion.AbrirConexion();
            comando.CommandText = "SpSelectEmpleado";
            comando.CommandType = CommandType.StoredProcedure;
            leer = comando.ExecuteReader();
            tabla.Load(leer);
            Conexion.CerrarConexion();
            return tabla;
        }

        public SqlDataReader RegistrarEmpleado(string nombre, string apellido_paterno, string apellido_materno,
            string cargo, string usuario, string email, string contraseña)
        {
            SqlCommand comando = new SqlCommand("SPRegistrarEmpleado", Conexion.AbrirConexion());
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@Nombre", nombre);
            comando.Parameters.AddWithValue("@Apellido_Paterno", apellido_paterno);
            comando.Parameters.AddWithValue("@Apellido_Materno", apellido_materno);
            comando.Parameters.AddWithValue("@Cargo", cargo);
            comando.Parameters.AddWithValue("@Usuario", usuario);
            comando.Parameters.AddWithValue("@Email", email);
            comando.Parameters.AddWithValue("@Contraseña", contraseña);

            leer = comando.ExecuteReader();
            return leer;
        }

        public void EditarEmpleado(string id, string nombre, string apellido_paterno, string apellido_materno,
            string cargo, string usuario, string email, string contraseña)
        {
            comando.Connection = Conexion.AbrirConexion();
            comando.CommandText = "SPModificarEmpleado";
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@IdEmpleado", id);
            comando.Parameters.AddWithValue("@Nombre", nombre);
            comando.Parameters.AddWithValue("@ApellidoPaterno", apellido_paterno);
            comando.Parameters.AddWithValue("@ApellidoMaterno", apellido_materno);
            comando.Parameters.AddWithValue("@Cargo", cargo);
            comando.Parameters.AddWithValue("@Usuario", usuario);
            comando.Parameters.AddWithValue("@Email", email);
            comando.Parameters.AddWithValue("@Contraseña", contraseña);


            comando.ExecuteNonQuery();
            comando.Parameters.Clear();
        }

        public void EliminarEmpleado(string id)
        {
            comando.Connection = Conexion.AbrirConexion();
            comando.CommandText = "SPEliminarEmpleado";
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@IdEmpleado", id);
            comando.ExecuteNonQuery();
            comando.Parameters.Clear();

        }
    }
}
