using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;


namespace TP_ComidaRapida
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
            ConexionSQL bd = new ConexionSQL();
            bd.RellenarControl(combo_User, "usuario", "Usuario", "borradoLogico=0");
            Controladores cs = new Controladores();
            cs.ActualizarControles(this);
            btn_MostrarPassword.Click += (sender, e) => cs.MostrarOcultarPassword(sender, e, txt_passwordUser);
        }

        static string usuarioActual, password;
        static bool admin;
        static int idUsuario;

        #region Getters:

        public static string GetUsuarioActual()
        {
            return usuarioActual;
        }

        public static bool GetAdmin()
        {
            return admin;
        }

        public static int GetIdUsuario()
        {
            return idUsuario;
        }
        #endregion

        private void btn_Ingresar_Click(object sender, EventArgs e)
        {
            ConexionSQL bd = new ConexionSQL(); //Se crea un objeto de la clase ConexionSQL.
            //SELECT usuario FROM Usuario WHERE usuario='combo_User.Text';
            usuarioActual = Convert.ToString(bd.Select("usuario", "Usuario", $"usuario='{combo_User.Text}' AND borradoLogico=0"));
            //SELECT pass FROM Usuario WHERE pass='txt_passwordUser.Text' AND usuario='combo_User.Text';
            password = Convert.ToString(bd.Select("pass", "Usuario",
                $"pass='{txt_passwordUser.Text}' AND usuario='{combo_User.Text}' AND borradoLogico=0"));
            //SELECT administrador FROM Usuario WHERE usuario='combo_User.Text';
            admin = Convert.ToBoolean(bd.Select("administrador", "Usuario", $"usuario='{combo_User.Text}' AND borradoLogico=0"));

            Controladores cs = new Controladores();
            if (!cs.TextoEnBlanco(this))
            {
                if (combo_User.Text == usuarioActual && txt_passwordUser.Text == password)
                {
                    idUsuario = Convert.ToInt32(bd.Select("id", "Usuario", $"usuario='{usuarioActual}'"));
                    string fechaInvertida = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss");
                    bd.InsertInto("Sesion", "idUsuario,ingresoSesion,salidaSesion",
                        $"'{idUsuario}','{fechaInvertida}','2000/01/01 00:00:00'");

                    if (admin)
                    {
                        this.Hide();
                        Gestiones gs = new Gestiones();
                        gs.Show();
                    }
                    else
                    {
                        this.Hide();
                        Menu mu = new Menu();
                        mu.Show();
                    }
                }
                else
                {
                    MessageBox.Show("Usuario o contraseña incorrecto.");
                }
            }
        }

        private void btn_Registrarse_Click(object sender, EventArgs e)
        {
            this.Hide();
            Registrarse registrarse = new Registrarse();
            registrarse.Show();
        }

        private void Login_FormClosing(object sender, FormClosingEventArgs e)
        {
            //El evento se produce al intentar cerrar el formulario.
            if (MessageBox.Show("¿Desea cerrar la aplicación?", "Aviso",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                Application.ExitThread();
            else
                e.Cancel = true; //Se cancela el evento, el formulario no se cierra.
        }
    }
}
