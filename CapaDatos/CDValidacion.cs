using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace CapaDatos
{
    public class CDValidacion
    {
        public void soloLetras(KeyPressEventArgs e)
        {
            try
            {
                if (Char.IsLetter(e.KeyChar))
                {
                    e.Handled = false;
                }
                else if (Char.IsControl(e.KeyChar))
                {
                    e.Handled = false;

                }
                else if (Char.IsSeparator(e.KeyChar))
                {
                    e.Handled = false;

                }
                else
                {
                    e.Handled = true;
                    //MessageBox.Show("Solo puede ingresar letras");

                }
            }
            catch (Exception ex)
            {

            }
        }

        public void soloNumeros(KeyPressEventArgs e)
        {
            try
            {
                if (Char.IsNumber(e.KeyChar))
                {
                    e.Handled = false;
                }
                else if (Char.IsControl(e.KeyChar))
                {
                    e.Handled = false;
                }
                else
                {
                    e.Handled = true;
                    //MessageBox.Show("Solo puede ingresar números");
                }
            }
            catch (Exception ex)
            {
            }
        }

        public bool Precios(int code, TextBox uti)
        {
            bool resultado;
            if (code == 46 && uti.Text.Contains("."))
            {
                resultado = true;
                //MessageBox.Show("Solo puede ingresar un punto decimal");
            }
            else if ((((code >= 48)&& (code <= 57)) || (code == 8) || code == 46))
            {
                resultado = false;
            }
            else
            {
                resultado = true;
                //MessageBox.Show("Solo puede ingresar números");
            }
            return resultado;
        }


        public Boolean email_bien_escrito(String email)
        {
            String expresion;
            expresion = "\\w+([-+.']\\w+)*@\\w+([-.]\\w+)*\\.\\w+([-.]\\w+)*";
            if (Regex.IsMatch(email, expresion))
            {
                if (Regex.Replace(email, expresion, String.Empty).Length == 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }
    }
}
