using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TP_ComidaRapida
{
    class Validaciones
    {
        /// <summary>
        /// Da formato a la cadena de texto.
        /// </summary>
        /// <param name="txt">Nombre del TextBox.</param>
        /// <param name="tipoFormato">"ToTitleCase" para poner la primera letra en mayúsculas/"ToLower" para poner todo en minúsculas.</param>
        /// <returns></returns>
        public string DarFormato(TextBox txt, string tipoFormato)
        {
            string textoFormateado = "";
            switch (tipoFormato)
            {
                case "ToTitleCase":
                    TextInfo formato = CultureInfo.CurrentCulture.TextInfo;
                    textoFormateado = formato.ToTitleCase(txt.Text.ToLower()); //Ej.: "jUAn paBLO" = "Juan Pablo"
                    break;
                case "ToLower":
                    textoFormateado = txt.Text.ToLower();
                    break;
            }
            return textoFormateado;
        }

        public bool TextoEnBlanco(Form formulario)
        {
            foreach (TextBox txt in formulario.Controls.OfType<TextBox>())
            {
                if (string.IsNullOrWhiteSpace(txt.Text))
                {
                    MessageBox.Show("Rellene todos los campos.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return true;
                }
            }
            return false;
        }

        public bool RepetidoEnBaseDeDatos(string columna, string tabla, TextBox txt)
        {
            ConexionSQL bd = new ConexionSQL();
            object repetido = bd.Select($"{columna}", $"{tabla}", $"{columna}='{txt.Text}' AND borradoLogico=0");
            if (repetido != null) //Si la consulta NO da NULL, encontró un usuario repetido.
            {
                MessageBox.Show($"El elemento '{txt.Text}' ya está en la base de datos. No puede repetirse.", "Advertencia", 
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return true;
            }
            return false;
        }

        public bool RepetidoEnBaseDeDatos(string columna, string tabla, TextBox txt, string excepto)
        {
            ConexionSQL bd = new ConexionSQL();
            if (excepto != txt.Text)
            {
                object repetido = bd.Select($"{columna}", $"{tabla}", $"{columna}='{txt.Text}' AND borradoLogico=0");
                if (repetido != null) //Si la consulta NO da NULL, encontró un usuario repetido.
                {
                    MessageBox.Show($"El elemento '{txt.Text}' ya está en la base de datos. No puede repetirse.", "Advertencia", 
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return true;
                }
            }
            return false;
        }
    }
}
