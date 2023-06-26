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
            Controladores cs = new Controladores();
            cs.ActualizarControles(this);
            btn_MostrarPassword.Click += (sender, e) => cs.MostrarOcultarPassword(sender, e, txt_passwordAdmin);
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
            Controladores cs = new Controladores();
            try
            {
                if (!cs.TextoEnBlanco(this))
                {
                    //Verificar los datos en la base de datos.
                    ConexionSQL bd = new ConexionSQL();
                    object resultado = bd.Select("administrador", "Usuario",
                        $"usuario='{txt_UserAdmin.Text}' AND pass='{txt_passwordAdmin.Text}'");

                    if (resultado == null)
                        MessageBox.Show("Usuario o contraseña incorrectos.");
                    else
                    {
                        bool admin = Convert.ToBoolean(resultado);
                        if (admin)
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
            }
            catch(Exception ex)
            {
                MessageBox.Show("Ocurrió un error: " + ex.Message);
            }
        }

        private void VerificarAdmin_FormClosed(object sender, FormClosedEventArgs e)
        {
            Registrarse registrarse = new Registrarse();
            registrarse.Activate();
        }
    }
}
