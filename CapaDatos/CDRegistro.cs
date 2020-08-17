using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace CapaDatos
{
    public class CDRegistro
    {
        private CDConexion Conexion = new CDConexion();
        private SqlDataReader leer;

        DataTable tabla = new DataTable();
        SqlCommand comando = new SqlCommand();

        public DataTable Mostrar()
        {
            comando.Connection = Conexion.AbrirConexion();
            comando.CommandText = "SPMostarVenta";
            comando.CommandType = CommandType.StoredProcedure;
            leer = comando.ExecuteReader();
            tabla.Load(leer);
            Conexion.CerrarConexion();
            return tabla;
        }



        public SqlDataReader RegistrarEvento(string DescripcionEvento, string Fecha, string ID_Empleado)//, string ID_Proveedor, string ID_Cliente, string ID_Venta)
        {
            SqlCommand comando = new SqlCommand("SPRegistros", Conexion.AbrirConexion());
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@DescripcionEvento", DescripcionEvento);
            comando.Parameters.AddWithValue("@Fecha", Fecha);
            comando.Parameters.AddWithValue("@ID_Empleado", ID_Empleado);
            //comando.Parameters.AddWithValue("@ID_Proveedor", ID_Proveedor);
           /// comando.Parameters.AddWithValue("@ID_Cliente", ID_Cliente);
           // comando.Parameters.AddWithValue("@ID_Venta", ID_Venta);

            leer = comando.ExecuteReader();
            return leer;
        }
    }
}
