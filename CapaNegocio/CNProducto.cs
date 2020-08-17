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
    public class CNProducto
    {
        private CDProducto objDatoProducto = new CDProducto();//instanciar a la capa datos de emppleado
        private String _nombre;
        private String _cantidad;
        private String _producto_menudeo;
        private String _producto_mayoreo;
        private String _proveedor;

        public DataTable MostrarProducto()
        {
            DataTable tabla = new DataTable();
            tabla = objDatoProducto.Mostrar();
            return tabla;
        }

        //constructor
        public CNProducto() { }
        public String id,nombre, cantidad, precio_menudeo, precio_mayoreo, proveedor,codigo,descripcion;

        

        //funciones o metodos
        public SqlDataReader RegistrarProducto()
        {
            SqlDataReader Loguear;
            Loguear = objDatoProducto.RegistrarProducto(codigo,nombre, cantidad, precio_menudeo, precio_mayoreo, proveedor, descripcion);
            return Loguear;
        }


        public void EliminarProducto(string id)
        {
            objDatoProducto.EliminarProducto(id);
        }

        public void ModificarProducto(string id, string codigo,string nombre, string precio_menudeo, string precio_mayoreo, string cantidad, string id_proveedor, string descripcion)
        {
            objDatoProducto.EditarProducto(id, codigo, nombre, precio_menudeo, precio_mayoreo, cantidad, id_proveedor,descripcion);
        }
    }
}
