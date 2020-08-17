using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;

namespace CapaDatos
{
    public class CDProducto
    {
        private CDConexion Conexion = new CDConexion();
        private SqlDataReader leer;

        DataTable tabla = new DataTable();
        SqlCommand comando = new SqlCommand();

        public DataTable Mostrar()
        {
            comando.Connection = Conexion.AbrirConexion();
            comando.CommandText = "SPSelectProducto";
            comando.CommandType = CommandType.StoredProcedure;
            leer = comando.ExecuteReader();
            tabla.Load(leer);
            Conexion.CerrarConexion();
            return tabla;
        }

    

        public SqlDataReader RegistrarProducto(String codigo,string nombre, string cantidad,string precio_menudeo, string precio_mayoreo, string proveedor,string descripcion)
        {
            SqlCommand comando = new SqlCommand("SPRegistrarProducto", Conexion.AbrirConexion());
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@Nombre", nombre);
            comando.Parameters.AddWithValue("@Cantidad", cantidad);
            comando.Parameters.AddWithValue("@Precio_Menudeo", precio_menudeo);
            comando.Parameters.AddWithValue("@Precio_Mayoreo", precio_mayoreo);
            comando.Parameters.AddWithValue("@Id_Proveedor", proveedor);
            comando.Parameters.AddWithValue("@Codigo", codigo);
            comando.Parameters.AddWithValue("@Descripcion", descripcion);
            leer = comando.ExecuteReader();
            return leer;
        }


        public void EliminarProducto(string id)
        {
            comando.Connection = Conexion.AbrirConexion();
            comando.CommandText = "SPEliminarProducto";
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@IdProducto", id);
            comando.ExecuteNonQuery();
            comando.Parameters.Clear();

        }
        public System.Windows.Forms.ComboBox cbProveedor;


        public void EditarProducto(string id, string codigo, string nombre, string precio_menudeo, string precio_mayoreo, string cantidad, string id_proveedor, string descripcion)
        {
            comando.Connection = Conexion.AbrirConexion();
            comando.CommandText = "SPModificarProducto";
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@Id_Producto", id);
            comando.Parameters.AddWithValue("@Nombre", nombre);
            comando.Parameters.AddWithValue("@Precio_Menudeo", precio_menudeo);
            comando.Parameters.AddWithValue("@Precio_Mayoreo", precio_mayoreo);
            comando.Parameters.AddWithValue("@Cantidad", cantidad);
            comando.Parameters.AddWithValue("@Id_Proveedor", id_proveedor);
            comando.Parameters.AddWithValue("@Codigo", codigo);
            comando.Parameters.AddWithValue("@Descripcion", descripcion);
            comando.ExecuteNonQuery();
            comando.Parameters.Clear();
        }

        public void AutocompletarProductos(TextBox tbBuscar)
        {
            try
            {
                comando.Connection = Conexion.AbrirConexion();
                comando.CommandText = "Select * from Productos where Cantidad > 0";
                comando.CommandType = CommandType.Text;
                SqlDataReader dr = comando.ExecuteReader();
                while (dr.Read())
                {
                    tbBuscar.AutoCompleteCustomSource.Add(dr["Nombre"].ToString());
                    tbBuscar.AutoCompleteCustomSource.Add(dr["Codigo"].ToString());

                }
                dr.Close();
            }
            catch(Exception x)
            {
                MessageBox.Show("Error en "+ x);
            }
        }

        public void AutocompletarCliente(TextBox tbCliente)
        {
            try
            {
                comando.Connection = Conexion.AbrirConexion();
                comando.CommandText = "Select * from Cliente";
                comando.CommandType = CommandType.Text;
                SqlDataReader dr = comando.ExecuteReader();
                while (dr.Read())
                {
                    tbCliente.AutoCompleteCustomSource.Add(dr["Nombre"].ToString()+" "+ dr["Apellido Paterno"].ToString() + " " + dr["Apellido Materno"].ToString() + " " + dr["Direccion"].ToString());

                }
                dr.Close();
            }
            catch (Exception x)
            {
                MessageBox.Show("Error en " + x);
            }
        }
    }
}
