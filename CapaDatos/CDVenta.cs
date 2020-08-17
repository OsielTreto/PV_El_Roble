using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace CapaDatos
{
    public class CDVenta
    {
        private CDConexion Conexion = new CDConexion();
        private SqlDataReader leer;

        DataTable tabla = new DataTable();
        SqlCommand comando = new SqlCommand();

        public void RegistrarVenta(string IdProducto, string IdEmpleado, string Fecha, string Costo, string IdCliente, string Cantidad, string CostoFinal, string TipoPrecio)
        {
            SqlCommand comando = new SqlCommand("SPRegistrarVenta", Conexion.AbrirConexion());
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@IdProducto", IdProducto);
            comando.Parameters.AddWithValue("@IdEmpleado", IdEmpleado);
            comando.Parameters.AddWithValue("@Fecha", Fecha);
            comando.Parameters.AddWithValue("@Costo", Costo);
            comando.Parameters.AddWithValue("@IdCliente", IdCliente);
            comando.Parameters.AddWithValue("@Cantidad", Cantidad);
            comando.Parameters.AddWithValue("@CostoFinal", CostoFinal);
            comando.Parameters.AddWithValue("@TipoPrecio", TipoPrecio);
            comando.ExecuteNonQuery();
            comando.Parameters.Clear();
            //leer = comando.ExecuteReader();
            
            
            //return leer;
        }

        public void ActualizarStock(string id, string cantidad)
        {
            comando.Connection = Conexion.AbrirConexion();
            comando.CommandText = "SPActualizarStock";
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@IdProducto", id);
            comando.Parameters.AddWithValue("@Cantidad", cantidad);
            comando.ExecuteNonQuery();
            comando.Parameters.Clear();
        }
    }
}
