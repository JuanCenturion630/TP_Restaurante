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
            ModificarControles mc = new ModificarControles();
            mc.ActualizarControles(this);
        }

        public string usuarioTruncado;

        protected bool Repetidos(string excepto)
        {
            if (excepto != txt_Usuario.Text)
            {
                usuarioRepetido = bd.Select("usuario", "Usuario", $"usuario='{txt_Usuario.Text}'");
                if (usuarioRepetido != null) //Si la consulta NO da NULL, encontró un usuario repetido.
                {
                    MessageBox.Show("El nombre de usuario ya esta en uso.");
                    return true;
                }
            }
            return false;
        }

        private void btn_Modificar_Click(object sender, EventArgs e)
        {
            if (!TextoEnBlanco() && !Repetidos(usuarioTruncado))
            {
                resultado = CalcularEdad();
                bool adminCheck;
                string ingreso, egreso;
                fechaVolteada = dtp_fechaNacimiento.Value.Date.ToString("yyyy/MM/dd");

                if (check_Admin.Checked) adminCheck = true;
                else adminCheck = false;

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
                bd.Update($"UPDATE Usuario SET administrador={adminCheck} WHERE usuario='{usuarioTruncado}'");
                bd.Update($"UPDATE Usuario SET nombre='{txt_Nombre.Text}' WHERE usuario='{usuarioTruncado}'");
                bd.Update($"UPDATE Usuario SET apellido='{txt_Apellido.Text}' WHERE usuario='{usuarioTruncado}'");
                bd.Update($"UPDATE Usuario SET usuario='{txt_Usuario.Text}' WHERE usuario='{usuarioTruncado}'");
                bd.Update($"UPDATE Usuario SET pass='{txt_Password.Text}' WHERE usuario='{usuarioTruncado}'");
                bd.Update($"UPDATE Usuario SET fechaNacimiento='{fechaVolteada}' WHERE usuario='{usuarioTruncado}'");
                bd.Update($"UPDATE Usuario SET edad='{resultado}' WHERE usuario='{usuarioTruncado}'");
                bd.Update($"UPDATE Usuario SET horaIngreso='{ingreso}' WHERE usuario='{usuarioTruncado}'");
                bd.Update($"UPDATE Usuario SET horaSalida='{egreso}' WHERE usuario='{usuarioTruncado}'");

                MessageBox.Show("Datos actualizados con éxito.");
                this.Hide();
            }
        }

        //Redefición del método pero ahora asociado al botón Agregar.
        protected new void btn_Registrarse_Click(object sender, EventArgs e)
        {
            base.btn_Registrarse_Click(btn_Agregar, e);
            if (check_Admin.Checked && btnEjecucionExitosa)
                MessageBox.Show("Usuario creado con éxito.");
            if (btnEjecucionExitosa)
                this.Hide();
        }

        protected override void Registrarse_FormClosing(object sender, FormClosingEventArgs e)
        {
            //Sobreescribo el método para que no haga nada. Evita el mensaje exigiendo confirmación de cierre, ya no es necesario.
        }
    }
}
