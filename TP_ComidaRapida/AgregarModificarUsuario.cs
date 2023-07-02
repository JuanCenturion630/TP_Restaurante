using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TP_ComidaRapida
{
    public partial class AgregarModificarUsuario : Registrarse
    {
        public AgregarModificarUsuario()
        {
            InitializeComponent();

            Eventos ev = new Eventos();
            ev.ActualizarControles(this);
        }

        string usuarioTruncado;

        public void SetUsuarioTruncado(string usuario)
        {
            usuarioTruncado = usuario;
        }

        #region Setters para botones:

        public void SetVisibleBtnRegistrarse(bool estado)
        {
            btn_Registrarse.Visible = estado;
        }

        public void SetVisibleBtnInicioSesion(bool estado)
        {
            btn_InicioSesion.Visible = estado;
        }

        public void SetVisibleBtnAgregar(bool estado)
        {
            btn_Agregar.Visible = estado;
        }

        public void SetAcceptButtonBtnAgregar()
        {
            AcceptButton = btn_Agregar;
        }

        public void SetVisibleBtnModificar(bool estado)
        {
            btn_Modificar.Visible = estado;
        }

        public void SetAcceptButtonBtnModificar()
        {
            AcceptButton = btn_Modificar;
        }
        #endregion

        #region Setters para RadioButtons:

        public void SetCheckedCheckAdmin(bool estado)
        {
            rbtn_Admin.Checked = estado;
        }

        public void SetCheckedCheckEmpleado(bool estado)
        {
            rbtn_Empleado.Checked = estado;
        }
        #endregion

        #region Setters para TextBoxs:

        public void SetTextTxtNombre(string contenido)
        {
            txt_Nombre.Text = contenido;
        }

        public void SetTextTxtApellido(string contenido)
        {
            txt_Apellido.Text = contenido;
        }

        public void SetTextTxtUsuario(string contenido)
        {
            txt_Usuario.Text = contenido;
        }

        public void SetTextTxtPassword(string contenido)
        {
            txt_Password.Text = contenido;
        }
        #endregion

        #region Setters para DateTimePickers:

        public void SetValueDtpFechaNacimiento(DateTime fecha)
        {
            dtp_fechaNacimiento.Value = fecha;
        }
        #endregion

        #region Setters para ComboBoxs:

        public void SetSelectedIndexCmbTurnos(int indice)
        {
            cmb_Turnos.SelectedIndex = indice;
        }
        #endregion

        private void btn_Modificar_Click(object sender, EventArgs e)
        {
            ConexionSQL bd = new ConexionSQL();
            Validaciones va = new Validaciones();
            if (!va.TextoEnBlanco(this) && !va.RepetidoEnBaseDeDatos("usuario", "Usuario", txt_Usuario, usuarioTruncado))
            {
                double edadCalc = CalcularEdad();
                string ingreso, egreso, fechaVolteada = dtp_fechaNacimiento.Value.Date.ToString("yyyy/MM/dd");

                if (cmb_Turnos.SelectedIndex == 0)
                {
                    ingreso = "08:00:00";
                    egreso = "16:00:00";
                }
                else
                {
                    ingreso = "16:00:00";
                    egreso = "23:59:59";
                }

                //Se intentó hacer una única llamada a bd.Update, pero no se pudo. Pendiente de edición.
                bd.Consulta($"UPDATE Usuario SET administrador={rbtn_Admin.Checked} WHERE usuario='{usuarioTruncado}'");
                bd.Consulta($"UPDATE Usuario SET nombre='{txt_Nombre.Text}' WHERE usuario='{usuarioTruncado}'");
                bd.Consulta($"UPDATE Usuario SET apellido='{txt_Apellido.Text}' WHERE usuario='{usuarioTruncado}'");
                bd.Consulta($"UPDATE Usuario SET usuario='{txt_Usuario.Text}' WHERE usuario='{usuarioTruncado}'");
                bd.Consulta($"UPDATE Usuario SET pass='{txt_Password.Text}' WHERE usuario='{usuarioTruncado}'");
                bd.Consulta($"UPDATE Usuario SET fechaNacimiento='{fechaVolteada}' WHERE usuario='{usuarioTruncado}'");
                bd.Consulta($"UPDATE Usuario SET edad='{edadCalc}' WHERE usuario='{usuarioTruncado}'");
                bd.Consulta($"UPDATE Usuario SET horaIngreso='{ingreso}' WHERE usuario='{usuarioTruncado}'");
                bd.Consulta($"UPDATE Usuario SET horaSalida='{egreso}' WHERE usuario='{usuarioTruncado}'");

                MessageBox.Show("Usuario actualizado con éxito.");
                this.Hide();
            }
        }

        //Redefición del método pero ahora asociado al botón Agregar.
        protected new void btn_Registrarse_Click(object sender, EventArgs e)
        {
            base.btn_Registrarse_Click(btn_Agregar, e);
            if (rbtn_Admin.Checked && btnEjecucionExitosa)
                MessageBox.Show("Usuario creado con éxito.");
            if (btnEjecucionExitosa)
                this.Hide();
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            //Se deja en blanco para sobreescribir el FormClosing heredado con nada, así el Form se cierre sin pedir confirmación.
        }
    }
}
