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
            
            dtp_fechaNacimiento.MaxDate = DateTime.Now.AddYears(-18).AddDays(-1);
            cmb_Turnos.SelectedIndex = 0;
            rbtn_Empleado.Select();

            Eventos ev = new Eventos();
            ev.ActualizarControles(this);
            txt_Nombre.KeyPress += (sender, e) => ev.KeyPress_SoloTextoMenorA(sender, e, 24);
            txt_Apellido.KeyPress += (sender, e) => ev.KeyPress_SoloTextoMenorA(sender, e, 24);
            txt_Usuario.KeyPress += (sender, e) => ev.KeyPress_AlfanumericoMenorA(sender, e, 24);
            txt_Password.KeyPress += (sender, e) => ev.KeyPress_AlfanumericoMenorA(sender, e, 15);
            btn_MostrarPassword.Click += (sender, e) => ev.Click_MostrarOcultarPassword(sender, e, txt_Password);
            this.FormClosing += ev.FormClosing;
        }

        protected bool btnEjecucionExitosa = false;
        static bool esAdmin = false;

        public static bool GetEsAdmin()
        {
            return esAdmin;
        }

        public void SetEsAdmin(bool estado)
        {
            esAdmin = estado;
        }

        protected void InsertarUsuario(int admin, string nombre, string apellido, string usuario, string password, 
            string fechaVolteada, double edad, string ingreso, string egreso)
        {
            ConexionSQL bd = new ConexionSQL();
            bd.InsertInto("Usuario", 
            "administrador,nombre,apellido,usuario,pass,fechaNacimiento,edad,horaIngreso,horaSalida,borradoLogico",
            $"{admin},'{nombre}','{apellido}','{usuario}','{password}','{fechaVolteada}',{edad},'{ingreso}','{egreso}','0'");
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
            Validaciones va = new Validaciones();
            double edadCalc;
            try
            {
                if (!va.TextoEnBlanco(this) && !va.RepetidoEnBaseDeDatos("usuario", "Usuario", txt_Usuario))
                {
                    string nombre = va.DarFormato(txt_Nombre, "ToTitleCase");
                    string apellido = va.DarFormato(txt_Apellido, "ToTitleCase");
                    string usuario = va.DarFormato(txt_Usuario, "ToLower");
                    edadCalc = CalcularEdad();

                    /* dtp_fechaNacimiento devuelve un valor "10/6/2023" que no sirve para insertarlo en la BD
                     * así que se volteará a "2023/6/10" usando una sobrecarga del método ToString(). */
                    string fechaVolteada = dtp_fechaNacimiento.Value.Date.ToString("yyyy/M/d");

                    if (rbtn_Empleado.Checked)
                    {
                        if (cmb_Turnos.SelectedIndex == 0)
                            InsertarUsuario(0, nombre, apellido, usuario, txt_Password.Text, fechaVolteada, edadCalc, 
                                "08:00:00", "16:00:00");
                        else
                            InsertarUsuario(0, nombre, apellido, usuario, txt_Password.Text, fechaVolteada, edadCalc, 
                                "16:00:00", "23:59:59");
                        MessageBox.Show("Usuario creado con éxito.");
                        Limpiar(); //Limpiar los controles.
                    }
                    else
                    {
                        if (esAdmin)
                        {
                            if (cmb_Turnos.SelectedIndex == 0)
                                InsertarUsuario(1, nombre, apellido, usuario, txt_Password.Text, fechaVolteada, edadCalc, 
                                    "08:00:00", "16:00:00");
                            else
                                InsertarUsuario(1, nombre, apellido, usuario, txt_Password.Text, fechaVolteada, edadCalc, 
                                    "16:00:00", "23:59:59");
                            Limpiar(); //Limpiar los controles.
                        }
                        else
                        {
                            /* Si se elige "administrador" debe aparecer un botón notificando que primero es necesario
                             * ingresar con una cuenta de adminitrador para crear otro, abrir un Form (CrearAdministrador). */
                            if (rbtn_Admin.Checked && MessageBox.Show("Para crear un nuevo administrador debe ser uno.",
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

        private void btn_InicioSesion_Click(object sender, EventArgs e)
        {
            this.Hide();
            Login login = new Login();
            login.Show();
        }

        private void dtp_fechaNacimiento_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void btn_InicioSesion_MouseEnter(object sender, EventArgs e)
        {
            //El evento MouseEnter ocurre cuando el mouse se pone por encima del Control (Button en este caso).
            btn_InicioSesion.ForeColor = Color.Red;
            btn_InicioSesion.FlatAppearance.MouseOverBackColor = Color.Transparent;
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
            if (VerificarAdmin.GetFinCrearAdminConExito())
            {
                VerificarAdmin.SetFinCrearAdminConExito(false); //Se pone el false para que ya no interfiera.
                esAdmin = true; //Se valida que ya inició sesión con una antigua cuenta de admin.
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
            rbtn_Empleado.Select();
        }
    }
}
