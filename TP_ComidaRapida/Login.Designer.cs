namespace TP_ComidaRapida
{
    partial class Login
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.btn_Ingresar = new System.Windows.Forms.Button();
            this.btn_Registrarse = new System.Windows.Forms.Button();
            this.txt_passwordUser = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.checkBox_recordarUsuario = new System.Windows.Forms.CheckBox();
            this.combo_User = new System.Windows.Forms.ComboBox();
            this.btn_MostrarPassword = new System.Windows.Forms.Button();
            this.toolTip_infoControles = new System.Windows.Forms.ToolTip(this.components);
            this.SuspendLayout();
            // 
            // btn_Ingresar
            // 
            this.btn_Ingresar.BackColor = System.Drawing.Color.Black;
            this.btn_Ingresar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Ingresar.ForeColor = System.Drawing.SystemColors.Control;
            this.btn_Ingresar.Location = new System.Drawing.Point(80, 140);
            this.btn_Ingresar.Name = "btn_Ingresar";
            this.btn_Ingresar.Size = new System.Drawing.Size(108, 30);
            this.btn_Ingresar.TabIndex = 4;
            this.btn_Ingresar.Text = "Ingresar";
            this.btn_Ingresar.UseVisualStyleBackColor = false;
            this.btn_Ingresar.Click += new System.EventHandler(this.btn_Ingresar_Click);
            // 
            // btn_Registrarse
            // 
            this.btn_Registrarse.Location = new System.Drawing.Point(80, 176);
            this.btn_Registrarse.Name = "btn_Registrarse";
            this.btn_Registrarse.Size = new System.Drawing.Size(108, 30);
            this.btn_Registrarse.TabIndex = 5;
            this.btn_Registrarse.Text = "Registrarse";
            this.btn_Registrarse.UseVisualStyleBackColor = true;
            this.btn_Registrarse.Click += new System.EventHandler(this.btn_Registrarse_Click);
            // 
            // txt_passwordUser
            // 
            this.txt_passwordUser.Location = new System.Drawing.Point(89, 63);
            this.txt_passwordUser.Name = "txt_passwordUser";
            this.txt_passwordUser.Size = new System.Drawing.Size(122, 20);
            this.txt_passwordUser.TabIndex = 0;
            this.txt_passwordUser.UseSystemPasswordChar = true;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.Control;
            this.label1.Location = new System.Drawing.Point(7, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(76, 20);
            this.label1.TabIndex = 3;
            this.label1.Text = "Usuario:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.Control;
            this.label2.Location = new System.Drawing.Point(7, 63);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(76, 20);
            this.label2.TabIndex = 3;
            this.label2.Text = "Contraseña:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // checkBox_recordarUsuario
            // 
            this.checkBox_recordarUsuario.BackColor = System.Drawing.Color.Transparent;
            this.checkBox_recordarUsuario.ForeColor = System.Drawing.Color.Transparent;
            this.checkBox_recordarUsuario.Location = new System.Drawing.Point(80, 100);
            this.checkBox_recordarUsuario.Name = "checkBox_recordarUsuario";
            this.checkBox_recordarUsuario.Size = new System.Drawing.Size(131, 34);
            this.checkBox_recordarUsuario.TabIndex = 3;
            this.checkBox_recordarUsuario.Text = "Recordar usuario";
            this.checkBox_recordarUsuario.UseVisualStyleBackColor = false;
            this.checkBox_recordarUsuario.Visible = false;
            // 
            // combo_User
            // 
            this.combo_User.FormattingEnabled = true;
            this.combo_User.Location = new System.Drawing.Point(89, 21);
            this.combo_User.Name = "combo_User";
            this.combo_User.Size = new System.Drawing.Size(149, 21);
            this.combo_User.TabIndex = 1;
            // 
            // btn_MostrarPassword
            // 
            this.btn_MostrarPassword.Location = new System.Drawing.Point(217, 62);
            this.btn_MostrarPassword.Name = "btn_MostrarPassword";
            this.btn_MostrarPassword.Size = new System.Drawing.Size(21, 21);
            this.btn_MostrarPassword.TabIndex = 11;
            this.toolTip_infoControles.SetToolTip(this.btn_MostrarPassword, "Ocultar la contraseña.");
            this.btn_MostrarPassword.UseVisualStyleBackColor = true;
            this.btn_MostrarPassword.Click += new System.EventHandler(this.btn_MostrarPassword_Click);
            // 
            // Login
            // 
            this.AcceptButton = this.btn_Ingresar;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::TP_ComidaRapida.Properties.Resources.Fondo;
            this.ClientSize = new System.Drawing.Size(250, 218);
            this.Controls.Add(this.btn_MostrarPassword);
            this.Controls.Add(this.combo_User);
            this.Controls.Add(this.checkBox_recordarUsuario);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txt_passwordUser);
            this.Controls.Add(this.btn_Registrarse);
            this.Controls.Add(this.btn_Ingresar);
            this.Name = "Login";
            this.Text = "Login";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Login_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_Ingresar;
        private System.Windows.Forms.Button btn_Registrarse;
        private System.Windows.Forms.TextBox txt_passwordUser;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox checkBox_recordarUsuario;
        private System.Windows.Forms.ComboBox combo_User;
        private System.Windows.Forms.Button btn_MostrarPassword;
        private System.Windows.Forms.ToolTip toolTip_infoControles;
    }
}

