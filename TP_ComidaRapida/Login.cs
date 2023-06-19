﻿using System;
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
            bd.RellenarControl(combo_User,"usuario","Usuario");
            ModificarControles mc = new ModificarControles();
            mc.ActualizarControles(this);
            //bd.InsertInto("Usuario", "administrador,nombre,apellido,usuario,pass,fechaNacimiento,edad,horaIngreso,horaSalida", "1,'Diego','Hidalgo','dhidalgo23','11111111','2000-03-06',23,'08:00:00','16:00:00'");
        }

        string user, password;
        public static bool admin;

        private void btn_Ingresar_Click(object sender, EventArgs e)
        {
            ConexionSQL bd = new ConexionSQL(); //Se crea un objeto de la clase ConexionSQL.
            //Se realizan SELECT usando como WHERE a los Controles del Form (usando parámetros dinámicos).

            //SELECT usuario FROM Usuario WHERE usuario='combo_User.Text';
            user = Convert.ToString(bd.Select("usuario", "Usuario", $"usuario='{combo_User.Text}'"));
            //SELECT pass FROM Usuario WHERE pass='txt_passwordUser.Text' AND usuario='combo_User.Text';
            password = Convert.ToString(bd.Select("pass", "Usuario", $"pass='{txt_passwordUser.Text}' AND usuario='{combo_User.Text}'"));
            //SELECT administrador FROM Usuario WHERE usuario='combo_User.Text';
            admin = Convert.ToBoolean(bd.Select("administrador", "Usuario", $"usuario='{combo_User.Text}'"));

            //Si los TextBox son nulos o espacios en blanco entonces...
            if (string.IsNullOrWhiteSpace(combo_User.Text) || string.IsNullOrWhiteSpace(txt_passwordUser.Text))
            {
                MessageBox.Show("Coloque todos los datos.");
                return; //En el evento Click el return vacío detiene el código, lo posterior no se ejecuta.
            }

            if (combo_User.Text == user && txt_passwordUser.Text == password)
            {
                if (admin == true)
                {
                    this.Hide();
                    Gestiones gu = new Gestiones();
                    gu.Show();
                }
                else
                {
                    this.Hide();
                    Menu menu = new Menu();
                    menu.Show();
                }
            }
            else
            {
                MessageBox.Show("Usuario o contraseña incorrecto.");
            }
        }

        private void btn_Registrarse_Click(object sender, EventArgs e)
        {
            this.Hide();
            Registrarse registrarse = new Registrarse();
            registrarse.Show();
        }

        private void btn_MostrarPassword_Click(object sender, EventArgs e)
        {
            //Si TextBox contraseña NO esta oculto entonces ocultar...
            if (!txt_passwordUser.UseSystemPasswordChar)
                txt_passwordUser.UseSystemPasswordChar = true;
            else
                txt_passwordUser.UseSystemPasswordChar = false;
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
