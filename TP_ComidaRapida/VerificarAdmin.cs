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
    public partial class VerificarAdmin : Form
    {
        public VerificarAdmin()
        {
            InitializeComponent();
            ModificarControles mc = new ModificarControles();
            mc.ActualizarControles(this);
        }

        private void btn_Ingresar_Click(object sender, EventArgs e)
        {
            try
            {
                //Verifica que los TextBox no sean nulos ni vacíos.
                if (string.IsNullOrWhiteSpace(txt_UserAdmin.Text) || string.IsNullOrWhiteSpace(txt_passwordAdmin.Text))
                {
                    MessageBox.Show("Coloque todos los datos.");
                    return; //En el evento Click un return vacío detiene el código. No se ejecuta lo siguiente.
                }

                //Verificar los datos en la base de datos.
                ConexionSQL bd = new ConexionSQL();
                object resp = bd.Select("administrador", "Usuario",
                    $"usuario='{txt_UserAdmin.Text}' AND pass='{txt_passwordAdmin.Text}'");

                if (resp == null)
                    MessageBox.Show("Usuario o contraseña incorrectos.");
                else
                {
                    if (Convert.ToBoolean(resp)) //Validación implícita. Si la respuesta es un "true" entonces es administrador.
                    {
                        finCrearAdminConExito = true; //Certifica que se valídó un administrador antiguo.
                        //"Datos cargados con éxito" se refiere a los datos del formulario "Registrarse".
                        if (MessageBox.Show("Datos cargados con éxito", "Aviso", MessageBoxButtons.OK) == DialogResult.OK)
                            this.Close(); //Cierra este Form.
                    }
                    else
                        MessageBox.Show("El usuario no es administrador. Intente con otro.");
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show("Ocurrió un error: " + ex.Message);
            }
        }

        private void btn_MostrarPassword_Click(object sender, EventArgs e)
        {
            //Si TextBox contraseña NO esta oculto entonces ocultar...
            if (!txt_passwordAdmin.UseSystemPasswordChar)
                txt_passwordAdmin.UseSystemPasswordChar = true;
            else
                txt_passwordAdmin.UseSystemPasswordChar = false;
        }

        public static bool finCrearAdminConExito = false;

        private void VerificarAdmin_FormClosed(object sender, FormClosedEventArgs e)
        {
            Registrarse registrarse = new Registrarse();
            registrarse.Activate();
        }
    }
}
