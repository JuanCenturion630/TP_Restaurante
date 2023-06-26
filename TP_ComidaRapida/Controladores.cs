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
    public class Controladores
    {
        public void ActualizarControles(Form formulario)
        {
            try
            {
                //Selecciona una imagen como fondo del Form:
                formulario.BackgroundImage = TP_ComidaRapida.Properties.Resources.Fondo;
                //Cambia las dimensiones de la imagen de fondo para ajustarla al Form:
                formulario.BackgroundImageLayout = ImageLayout.Stretch;
                //Hace que el Form siempre inicie en el centro de la pantalla.
                formulario.StartPosition = FormStartPosition.CenterScreen;
                //Desactiva el botón "maximizar" de los Form.
                formulario.MaximizeBox = false;
                //Desactiva la opción de redimensionar el Form durante la ejecución de la aplicación.
                formulario.FormBorderStyle = FormBorderStyle.FixedSingle;

                //Para cada Control de un Form individual:
                foreach (Control ctrl in formulario.Controls)
                {
                    //Si el Control es un ComboBox...
                    if (ctrl is ComboBox)
                    {
                        /* El Control activo pasa de clase Control a clase ComboBox para acceder 
                         * a sus métodos característicos: */
                        ComboBox cmb = (ComboBox)ctrl;
                        cmb.DropDownStyle = ComboBoxStyle.DropDownList; //Evita que se pueda escribir en el ComboBox.
                        cmb.SelectedIndex = 0;
                    }

                    //Si el Control es un botón...
                    if (ctrl is Button)
                    {
                        /* El Control activo pasa de clase Control a clase Button para acceder 
                         * a sus métodos característicos: */
                        Button btn = (Button)ctrl;
                        btn.FlatStyle = FlatStyle.Flat; //Cambia el grosor de los bordes del botón.
                        /*Cambia el color del botón cuando tiene el mouse encima, 
                        pero el FlatStyle debe ser Flat obligatoriamente. */
                        btn.FlatAppearance.MouseOverBackColor = Color.Red;
                    }

                    //Si el Control es un Label O un RadioButton O un Button...
                    if (ctrl is Label || ctrl is RadioButton || ctrl is Button)
                    {
                        ctrl.ForeColor = Color.White; //Cambia el color de las letras del Control.
                        ctrl.BackColor = Color.Transparent; //Cambia el color del fondo del Control.
                    }

                    //Si el Control es un DataGridView...
                    if (ctrl is DataGridView)
                    {
                        /* El Control activo pasa de clase Control a clase Button para acceder 
                         * a sus métodos característicos: */
                        DataGridView dgv = (DataGridView)ctrl;
                        dgv.AllowUserToAddRows = false; //No permite que el usuario cree filas nuevas.
                        //No permite que el usuario borre filas solo con funciones estéticas.
                        dgv.AllowUserToDeleteRows = false;
                        dgv.AllowUserToOrderColumns = true; //Permite al usuario reordenar las columnas a su gusto.
                        dgv.AllowUserToResizeRows = false; //No permite redimensionar el alto de las filas.
                        //Ajusta automáticamente el tamaño de las columnas en función de sus celdas.
                        dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                        dgv.DefaultCellStyle.SelectionBackColor = Color.Red; //Color al seleccionar una celda.
                        dgv.MultiSelect = false; //No permite seleccionar varias filas a la vez.
                        dgv.ReadOnly = true; //Celdas de solo lectura.
                        dgv.RowHeadersVisible = false; //Oculta la cabecera de las filas.
                        //Al seleccionar una celda, se selecciona toda la fila.
                        dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public bool TextoEnBlanco(Form formulario)
        {
            foreach (TextBox txt in formulario.Controls.OfType<TextBox>())
            {
                if (string.IsNullOrWhiteSpace(txt.Text))
                {
                    MessageBox.Show("Rellene todos los campos.");
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
                MessageBox.Show("El nombre del elemento ya esta en uso.");
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
                    MessageBox.Show("El nombre del elemento ya esta en uso.");
                    return true;
                }
            }
            return false;
        }

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

        public void SoloNumeros_LimitarCantDeDigitos(object sender, KeyPressEventArgs e, int maximo)
        {
            /* El objecto sender representa al Control que activó el evento y se convierte a la clase TextBox
             * para poder acceder a sus métodos */
            TextBox txt = (TextBox)sender;
            if (!char.IsNumber(e.KeyChar) && e.KeyChar != '\b' || txt.TextLength > maximo && e.KeyChar != '\b')
                e.Handled = true; //Cancela la tecla presionada.
        }

        public void SoloNumerosConComa_LimitarCantDeDigitos(object sender, KeyPressEventArgs e, int maximo)
        {
            /* El objecto sender representa al Control que activó el evento y se convierte a la clase TextBox
             * para poder acceder a sus métodos */
            TextBox txt = (TextBox)sender;
            if (!char.IsNumber(e.KeyChar) && e.KeyChar != '\b' && e.KeyChar != ',' || txt.TextLength > maximo && e.KeyChar != '\b')
                e.Handled = true; //Cancela la tecla presionada.
        }

        public void SoloTextoMenorA(object sender, KeyPressEventArgs e, int maximo)
        {
            /* El objecto sender representa al Control que activó el evento y se convierte a la clase TextBox
             * para poder acceder a sus métodos */
            TextBox txt = (TextBox)sender;
            if (!char.IsLetter(e.KeyChar) && e.KeyChar != '\b' && e.KeyChar != ' ' || txt.TextLength > maximo && e.KeyChar != '\b')
                e.Handled = true; //Cancela la tecla presionada.
        }

        public void AlfanumericoMenorA(object sender, KeyPressEventArgs e, int maximo)
        {
            TextBox txt = (TextBox)sender;
            if (txt.TextLength > maximo && e.KeyChar != '\b')
                e.Handled = true; //Cancela la tecla presionada.
        }

        public void CerrarFormulario(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("¿Desea cerrar la aplicación?", "Aviso",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                ConexionSQL bd = new ConexionSQL();
                int idUsuario = Login.GetIdUsuario();
                string fechaInvertida = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss");
                bd.Consulta($"CALL Registrar_Cierre_Sesion('{fechaInvertida}','{idUsuario}')");
                Application.ExitThread();
            }
            else
                e.Cancel = true; //Se cancela el evento, el formulario no se cierra.
        }

        public void MostrarOcultarPassword(object sender, EventArgs e, TextBox txt)
        {
            if (!txt.UseSystemPasswordChar)
                txt.UseSystemPasswordChar = true;
            else
                txt.UseSystemPasswordChar = false;
        }
    }
}
