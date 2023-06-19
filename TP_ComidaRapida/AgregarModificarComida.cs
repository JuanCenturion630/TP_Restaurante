using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TP_ComidaRapida
{
    public partial class AgregarModificarComida : Form
    {
        public AgregarModificarComida()
        {
            InitializeComponent();
            ModificarControles mc = new ModificarControles();
            mc.ActualizarControles(this);
        }

        ConexionSQL bd = new ConexionSQL();

        public bool TextoEnBlanco()
        {
            foreach (TextBox txt in Controls.OfType<TextBox>())
            {
                if (string.IsNullOrWhiteSpace(txt.Text))
                {
                    MessageBox.Show("Rellene todos los campos.");
                    return true;
                }
            }
            return false;
        }

        public bool Repetidos(string excepto)
        {
            if (excepto != txt_Comida.Text)
            {
                object comidaRepetida = bd.Select("nombre", "Comida", $"nombre='{txt_Comida.Text}'");
                if (comidaRepetida != null) //Si la consulta NO da NULL, encontró un usuario repetido.
                {
                    MessageBox.Show("El platillo ya fue registrado.");
                    return true;
                }
            }
            return false;
        }

        public string DarFormato()
        {
            //Convierte todo en minúsculas y luego le aplica ToTitleCase para colocar en mayúscula la primera letra.
            TextInfo formato = CultureInfo.CurrentCulture.TextInfo;
            string comida = formato.ToTitleCase(txt_Comida.Text.ToLower()); //Ej.: "haMbURguEsA chICa" = "Hamburguesa Chica"
            return comida;
        }

        private void btn_Agregar_Click(object sender, EventArgs e)
        {
            if (!TextoEnBlanco() && !Repetidos(comidaTruncada))
            {
                string plato = DarFormato();
                bd.InsertInto("Comida", "nombre,precio", $"'{plato}','{txt_Precio.Text}'");
                MessageBox.Show("Datos creados con éxito.");
                this.Hide();
            }
        }

        public string comidaTruncada;

        private void btn_Modificar_Click(object sender, EventArgs e)
        {
            if (!TextoEnBlanco() && !Repetidos(comidaTruncada))
            {
                string plato = DarFormato();
                bd.Update($"UPDATE Comida SET nombre='{plato}' WHERE nombre='{comidaTruncada}'");
                bd.Update($"UPDATE Comida SET precio='{txt_Precio.Text}' WHERE nombre='{comidaTruncada}'");
                MessageBox.Show("Datos actualizados con éxito.");
                this.Hide();
            }
        }

        private void txt_KeyPress(object sender, KeyPressEventArgs e)
        {
            TextBox txt = (TextBox)sender;
            if (txt == txt_Comida)
                if (!char.IsLetter(e.KeyChar) && e.KeyChar != '\b' && e.KeyChar != ' ')
                    e.Handled = true; //Cancela la tecla presionada.
            if (txt == txt_Precio)
                if (!char.IsNumber(e.KeyChar) && e.KeyChar != '\b' && e.KeyChar != '.')
                    e.Handled = true; //Cancela la tecla presionada.
        }
    }
}
