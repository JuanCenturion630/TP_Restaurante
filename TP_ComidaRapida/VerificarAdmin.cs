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

            Eventos ev = new Eventos();
            ev.ActualizarControles(this);
            btn_MostrarPassword.Click += (sender, e) => ev.Click_MostrarOcultarPassword(sender, e, txt_passwordAdmin);
        }

        static bool finCrearAdminConExito = false;

        public static bool GetFinCrearAdminConExito()
        {
            return finCrearAdminConExito;
        }

        public static void SetFinCrearAdminConExito(bool estado)
        {
            finCrearAdminConExito = estado;
        }

        private void btn_Ingresar_Click(object sender, EventArgs e)
        {
            Validaciones va = new Validaciones();
            object resultado = null;
            bool admin = false;

            try
            {
                if (!va.TextoEnBlanco(this))
                {
                    //Verificar los datos en la base de datos.
                    ConexionSQL bd = new ConexionSQL();
                    resultado = bd.Select("administrador", "Usuario",
                        $"usuario='{txt_UserAdmin.Text}' AND pass='{txt_passwordAdmin.Text}'");
                    admin = Convert.ToBoolean(resultado);

                    if (admin)
                    {
                        finCrearAdminConExito = true; //Certifica que se valídó un administrador antiguo.
                        //"Datos cargados con éxito" se refiere a los datos del formulario "Registrarse".
                        if (MessageBox.Show("Datos cargados con éxito", "Aviso", MessageBoxButtons.OK) == DialogResult.OK)
                            this.Close(); //Cierra este Form.
                    }
                    else
                        MessageBox.Show("El usuario no es administrador.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            } //Si "resultado" es nulo es porque no se encontró coincidencias con el usuario y contraseña escritos.
            catch (NullReferenceException)
            {
                MessageBox.Show("Usuario o contraseña incorrectos.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrió un error: " + ex.Message, "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void VerificarAdmin_FormClosed(object sender, FormClosedEventArgs e)
        {
            Registrarse registrarse = new Registrarse();
            registrarse.Activate();
        }
    }
}
