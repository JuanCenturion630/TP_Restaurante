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
    public partial class Registrarse : Form
    {
        public Registrarse()
        {
            InitializeComponent();
            ModificarControles mc = new ModificarControles();
            mc.ActualizarControles(this);
            dtp_fechaNacimiento.MaxDate = DateTime.Now.AddYears(-18).AddDays(-1);
            cmb_Turnos.SelectedIndex = 0;
            check_Empleado.Select();
        }

        protected virtual void Registrarse_FormClosing(object sender, FormClosingEventArgs e)
        {
            //El evento se produce al intentar cerrar el formulario.
            if (MessageBox.Show("¿Desea cerrar la aplicación?", "Aviso",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                /* e.Cancel = false no cancela el evento, o sea, el formulario sí se cierra, 
                 * pero el mensaje de salida se repite al mezclarse con el mensaje de salida 
                 * del formulario Login, para evitarlo usar ExitThread() para matar todos los 
                 * procesos de la aplicación. */
                Application.ExitThread();
            }

            else
                e.Cancel = true; //Se cancela el evento, el formulario no se cierra.
        }

        protected object usuarioRepetido;
        /// <summary>
        /// Si "YaEsAdmin" es true significa que viene del Form VerificarAdmin o Gestiones (solo visto por administradores).
        /// </summary>
        public bool YaEsAdmin = false;
        /// <summary>
        /// Si se validan todos los datos en el botón Registrarse poner en true. Usar para la herencia en AgregarModificarUsuario, esperar a mejor solución.
        /// </summary>
        protected bool btnEjecucionExitosa=false;
        protected string fechaVolteada, nombre, apellido, usuario;
        protected double resultado;
        protected ConexionSQL bd = new ConexionSQL();

        /* Uso de lenguaje de marcado XML para escribir mensajes orientativos sobre los parámetros del método siguiente. */
        /// <summary>
        /// Realiza un INSERT IGNORE INTO con un usuario en la base de datos.
        /// </summary>
        /// <param name="admin">Determina el nivel del usuario a insertar. Formato: 0 (empleado) o 1 (administrador).</param>
        /// <param name="ingreso">Determina la hora de entrada laboral. Formato: 08:00:00.</param>
        /// <param name="egreso">Determina la hora de salida laboral. Formato: 16:00:00.</param>
        /// <returns>No devuelve nada.</returns>
        protected void ConsultaRepetitiva(int admin, double edad, string ingreso, string egreso)
        {
            bd.InsertInto("Usuario", "administrador,nombre,apellido,usuario,pass,fechaNacimiento,edad,horaIngreso,horaSalida",
            $"{admin},'{nombre}','{apellido}','{usuario}','{txt_Password.Text}','{fechaVolteada}',{edad},'{ingreso}','{egreso}'");
        }

        /// <summary>
        /// Evalúa que ningún TextBox este en blanco dentro del Form.
        /// </summary>
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

        /// <summary>
        /// Evalúa que el usuario que se desea insertar no sea igual a un usuario previo.
        /// </summary>
        public bool Repetidos()
        {
            usuarioRepetido = bd.Select("usuario", "Usuario", $"usuario='{txt_Usuario.Text}'");
            if (usuarioRepetido != null) //Si la consulta NO da NULL, encontró un usuario repetido.
            {
                MessageBox.Show("El nombre de usuario ya esta en uso.");
                return true;
            }
            return false;
        }

        /// <summary>
        /// Da el formato de primera letra mayúscula, resto en minúscula para nombre y apellido; y todo minúscula para el nombre de usuario.
        /// </summary>
        public void DarFormato()
        {
            //Convierte todo en minúsculas y luego le aplica ToTitleCase para colocar en mayúscula la primera letra.
            TextInfo formato = CultureInfo.CurrentCulture.TextInfo;
            nombre = formato.ToTitleCase(txt_Nombre.Text.ToLower()); //Ej.: "jUAn paBLO" = "Juan Pablo"
            apellido = formato.ToTitleCase(txt_Apellido.Text.ToLower());
            usuario = txt_Usuario.Text.ToLower();
        }

        protected double CalcularEdad()
        {
            //Lapso = fecha actual (DD/MM/YY) - fecha seleccionada en el DateTimePicker (DD/MM/YY).
            TimeSpan lapso = DateTime.Now.Date - dtp_fechaNacimiento.Value.Date;
            //Días = número de días en "tiempo". Ej.: 6.574 días = 18 años + 4 días por años bisiestos.
            double dias = Convert.ToDouble(lapso.Days);
            //Edad Usuario = días/365.25 (días reales de un año) y redondeado siempre hacia abajo. Ej.: 17.9 años como 17.
            double edadUsuario = Math.Floor(dias / 365.25);
            return edadUsuario;
        }

        protected void btn_Registrarse_Click(object sender, EventArgs e)
        {
            try
            {
                if (!TextoEnBlanco() && !Repetidos())
                {
                    DarFormato();
                    resultado = CalcularEdad();
                    /* dtp_fechaNacimiento devuelve un valor "10/6/2023" que no sirve para insertarlo en la BD
                     * así que se volteará a "2023/6/10" usando una sobrecarga del método ToString(). */
                    fechaVolteada = dtp_fechaNacimiento.Value.Date.ToString("yyyy/M/d");

                    if (check_Empleado.Checked)
                    {
                        if (cmb_Turnos.SelectedIndex == 0)
                            ConsultaRepetitiva(0, resultado, "08:00:00", "16:00:00");
                        else
                            ConsultaRepetitiva(0, resultado, "16:00:00", "23:59:59");
                        MessageBox.Show("Usuario creado con éxito.");
                        Limpiar(); //Limpiar los controles.
                    }
                    else
                    {
                        if (YaEsAdmin)
                        {
                            if (cmb_Turnos.SelectedIndex == 0)
                                ConsultaRepetitiva(1, resultado, "08:00:00", "16:00:00");
                            else
                                ConsultaRepetitiva(1, resultado, "16:00:00", "23:59:59");
                            Limpiar(); //Limpiar los controles.
                        }
                        else
                        {
                            /* Si se elige "administrador" debe aparecer un botón notificando que primero es necesario
                             * ingresar con una cuenta de adminitrador para crear otro, abrir un Form (CrearAdministrador). */
                            if (check_Admin.Checked && MessageBox.Show("Para crear un nuevo administrador debe ser uno.",
                                    "¿Iniciar sesión?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                            {
                                VerificarAdmin admin = new VerificarAdmin();
                                /* Trae el formulario para validar al administrador. Es "ShowDialog" para que la aplicación no me 
                                 * deje realizar más acciones hasta verificat el usuario administrador. */
                                admin.ShowDialog();
                                /* Luego de abrir el Form CrearAdministrador y validar un usuario administrador antiguo
                                 * se irá al evento Activated de este Form para generar un evento Click instántaneo que regrese
                                 * el programa a este segmento de código, entrando el if(YaEsAdmin) e insertando el nuevo admin. */
                            }
                        }
                    }
                    btnEjecucionExitosa = true;
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        protected void btn_MostrarPassword_Click(object sender, EventArgs e)
        {
            //Si TextBox contraseña NO esta oculto entonces ocultar...
            if (!txt_Password.UseSystemPasswordChar)
                txt_Password.UseSystemPasswordChar = true;
            else
                txt_Password.UseSystemPasswordChar = false;
        }

        protected void txt_KeyPress(object sender, KeyPressEventArgs e)
        {
            //El evento KeyPress ocurre cuando se escribe en el TextBox.

            /* El objecto sender representa al Control que activó el evento y se convierte a la clase TextBox
             * para poder acceder a sus métodos */
            TextBox txt = (TextBox)sender;

            /* e.KeyChar es la tecla presionada y TextLength para medir la longitud del TextBox cuenta todas
             * las teclas acaben escribiendo una letra o no, incluyendo "backspace" (borrar) por ello es necesario incluir !='\b' */
            //Si el TextBox que activó el evento es Nombre O Apellido entonces...
            if (txt == txt_Nombre || txt == txt_Apellido)
            {
                //Y si la tecla NO es una letra Y NO es backspace Y NO es espacio 
                //O la longitud de su texto es mayor a 24 Y NO es backspace...
                if (!char.IsLetter(e.KeyChar) && e.KeyChar != '\b' && e.KeyChar != ' ' || txt.TextLength > 24 && e.KeyChar != '\b')
                    e.Handled = true; //Cancela la tecla presionada.
            }
            //Si el TextBox que activó el evento es Usuario Y su longitud es mayor a 24 Y NO es backspace...
            if (txt == txt_Usuario && txt.TextLength > 24 && e.KeyChar != '\b')
                e.Handled = true; //Cancela la tecla presionada.
            //Si el TextBox que activó el evento es Password Y su longitud es mayor a 15 Y NO es backspace...
            if (txt == txt_Password && txt.TextLength > 15 && e.KeyChar != '\b')
                e.Handled = true; //Cancela la tecla presionada.
        }

        private void btn_InicioSesion_Click(object sender, EventArgs e)
        {
            this.Hide();
            Login login = new Login();
            login.Show();
        }

        private void btn_InicioSesion_MouseEnter(object sender, EventArgs e)
        {
            //El evento MouseEnter ocurre cuando el mouse se pone por encima del Control (Button en este caso).
            btn_InicioSesion.ForeColor = Color.Red;
            btn_InicioSesion.FlatAppearance.MouseOverBackColor = Color.Transparent;
        }

        private void dtp_fechaNacimiento_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void btn_InicioSesion_MouseLeave(object sender, EventArgs e)
        {
            //El evento MouseLeave ocurre cuando el mouse deja de estar encima del Control (Button en este caso).
            btn_InicioSesion.ForeColor = Color.White;
            btn_InicioSesion.FlatAppearance.MouseOverBackColor = Color.Red;
        }

        private void Registrarse_Activated(object sender, EventArgs e)
        {
            //El evento Activated ocurre cuando el Form, que estaba en segundo plano, vuelve a ser la ventana activa.
            //Validación implícita, es igual a "if(CrearAdministrador.finalizar==true)"
            if (VerificarAdmin.finCrearAdminConExito)
            {
                VerificarAdmin.finCrearAdminConExito = false; //Se pone el false para que ya no interfiera.
                YaEsAdmin = true; //Se valida que ya inició sesión con una antigua cuenta de admin.
                //Llama al evento Registrarse_Click sin hacer clic en ningún botón.
                btn_Registrarse_Click(btn_Registrarse, EventArgs.Empty);
            }
        }

        protected void Limpiar()
        {
            foreach (TextBox txt in Controls.OfType<TextBox>())
                txt.Text = "";
            dtp_fechaNacimiento.ResetText();
            //Fecha máxima del calendario: la fecha actual menos 18 años y un día, descartando a menores de edad.
            dtp_fechaNacimiento.MaxDate = DateTime.Now.AddYears(-18).AddDays(-1);
            cmb_Turnos.SelectedIndex = 0;
            check_Empleado.Select();
        }
    }
}
