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
            cmb_usuario.Items.Add("");
            CargarUsuariosRecordados();
            Controladores cs = new Controladores();
            cs.ActualizarControles(this);
            cmb_usuario.KeyPress += (sender, e) => cs.AlfanumericoMenorA(sender, e, 24);
            btn_MostrarPassword.Click += (sender, e) => cs.MostrarOcultarPassword(sender, e, txt_password);
            txt_password.KeyPress += (sender, e) => cs.AlfanumericoMenorA(sender, e, 15);
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

        private void RecordarLogin(bool recordar)
        {
            string estado = "0";
            if (recordar) estado = "1";
            ConexionSQL bd = new ConexionSQL();
            bd.Update("Usuario", "recordarSesion", $"{estado}", $"usuario='{cmb_usuario.Text}' AND borradoLogico=0");
        }

        private void CargarUsuariosRecordados()
        {
            ConexionSQL bd = new ConexionSQL();
            bd.RellenarComboBox(cmb_usuario, "usuario", "Usuario", "borradoLogico=0 AND recordarSesion=1");
        }

        private void btn_Ingresar_Click(object sender, EventArgs e)
        {
            ConexionSQL bd = new ConexionSQL(); //Se crea un objeto de la clase ConexionSQL.
            //SELECT usuario FROM Usuario WHERE usuario='combo_User.Text';
            usuarioActual = Convert.ToString(bd.Select("usuario", "Usuario", $"usuario='{cmb_usuario.Text}' AND borradoLogico=0"));
            //SELECT pass FROM Usuario WHERE pass='txt_passwordUser.Text' AND usuario='combo_User.Text';
            password = Convert.ToString(bd.Select("pass", "Usuario",
                $"pass='{txt_password.Text}' AND usuario='{cmb_usuario.Text}' AND borradoLogico=0"));
            //SELECT administrador FROM Usuario WHERE usuario='combo_User.Text';
            admin = Convert.ToBoolean(bd.Select("administrador", "Usuario", $"usuario='{cmb_usuario.Text}' AND borradoLogico=0"));

            Controladores cs = new Controladores();
            if (!cs.TextoEnBlanco(this))
            {
                if (cmb_usuario.Text == usuarioActual && txt_password.Text == password)
                {
                    idUsuario = Convert.ToInt32(bd.Select("id", "Usuario", $"usuario='{usuarioActual}'"));
                    string fechaInvertida = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss");
                    bd.InsertInto("Sesion", "idUsuario,ingresoSesion,salidaSesion",
                        $"'{idUsuario}','{fechaInvertida}','2000/01/01 00:00:00'");
                    RecordarLogin(checkBox_recordarSesion.Checked);

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

        private void cmb_usuario_SelectedIndexChanged(object sender, EventArgs e)
        {
            txt_password.Text = "";
            if (cmb_usuario.SelectedIndex != 0)
            {
                ConexionSQL bd = new ConexionSQL();
                txt_password.Text = (string)bd.Select("pass", "Usuario",
                    $"usuario='{cmb_usuario.Text}' AND borradoLogico=0 AND recordarSesion=1");
                cmb_usuario.BackColor = Color.Gold;
                txt_password.BackColor = Color.Gold;
            }
        }

        private void cmb_usuario_TextChanged(object sender, EventArgs e)
        {
            cmb_usuario.BackColor = Color.White;
            txt_password.BackColor = Color.White;
        }

        private void Login_Load(object sender, EventArgs e)
        {
            cmb_usuario.DropDownStyle = ComboBoxStyle.DropDown;
            cmb_usuario.AutoCompleteMode = AutoCompleteMode.Suggest;
            cmb_usuario.AutoCompleteSource = AutoCompleteSource.ListItems;
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
