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
            this.txt_password = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.checkBox_recordarSesion = new System.Windows.Forms.CheckBox();
            this.btn_MostrarPassword = new System.Windows.Forms.Button();
            this.toolTip_infoControles = new System.Windows.Forms.ToolTip(this.components);
            this.cmb_usuario = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // btn_Ingresar
            // 
            this.btn_Ingresar.Location = new System.Drawing.Point(80, 140);
            this.btn_Ingresar.Name = "btn_Ingresar";
            this.btn_Ingresar.Size = new System.Drawing.Size(108, 30);
            this.btn_Ingresar.TabIndex = 3;
            this.btn_Ingresar.Text = "Ingresar";
            this.btn_Ingresar.UseVisualStyleBackColor = false;
            this.btn_Ingresar.Click += new System.EventHandler(this.btn_Ingresar_Click);
            // 
            // btn_Registrarse
            // 
            this.btn_Registrarse.Location = new System.Drawing.Point(80, 176);
            this.btn_Registrarse.Name = "btn_Registrarse";
            this.btn_Registrarse.Size = new System.Drawing.Size(108, 30);
            this.btn_Registrarse.TabIndex = 4;
            this.btn_Registrarse.Text = "Registrarse";
            this.btn_Registrarse.UseVisualStyleBackColor = true;
            this.btn_Registrarse.Click += new System.EventHandler(this.btn_Registrarse_Click);
            // 
            // txt_password
            // 
            this.txt_password.Location = new System.Drawing.Point(89, 63);
            this.txt_password.Name = "txt_password";
            this.txt_password.Size = new System.Drawing.Size(122, 20);
            this.txt_password.TabIndex = 1;
            this.txt_password.UseSystemPasswordChar = true;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
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
            this.label2.Location = new System.Drawing.Point(7, 63);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(76, 20);
            this.label2.TabIndex = 3;
            this.label2.Text = "Contraseña:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // checkBox_recordarSesion
            // 
            this.checkBox_recordarSesion.BackColor = System.Drawing.Color.Transparent;
            this.checkBox_recordarSesion.ForeColor = System.Drawing.Color.Transparent;
            this.checkBox_recordarSesion.Location = new System.Drawing.Point(80, 100);
            this.checkBox_recordarSesion.Name = "checkBox_recordarSesion";
            this.checkBox_recordarSesion.Size = new System.Drawing.Size(131, 34);
            this.checkBox_recordarSesion.TabIndex = 2;
            this.checkBox_recordarSesion.Text = "Recordar sesión";
            this.checkBox_recordarSesion.UseVisualStyleBackColor = false;
            // 
            // btn_MostrarPassword
            // 
            this.btn_MostrarPassword.Location = new System.Drawing.Point(217, 62);
            this.btn_MostrarPassword.Name = "btn_MostrarPassword";
            this.btn_MostrarPassword.Size = new System.Drawing.Size(21, 21);
            this.btn_MostrarPassword.TabIndex = 1;
            this.toolTip_infoControles.SetToolTip(this.btn_MostrarPassword, "Ocultar la contraseña.");
            this.btn_MostrarPassword.UseVisualStyleBackColor = true;
            // 
            // cmb_usuario
            // 
            this.cmb_usuario.FormattingEnabled = true;
            this.cmb_usuario.Location = new System.Drawing.Point(89, 21);
            this.cmb_usuario.Name = "cmb_usuario";
            this.cmb_usuario.Size = new System.Drawing.Size(149, 21);
            this.cmb_usuario.TabIndex = 7;
            this.cmb_usuario.SelectedIndexChanged += new System.EventHandler(this.cmb_usuario_SelectedIndexChanged);
            this.cmb_usuario.TextChanged += new System.EventHandler(this.cmb_usuario_TextChanged);
            // 
            // Login
            // 
            this.AcceptButton = this.btn_Ingresar;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(252, 218);
            this.Controls.Add(this.cmb_usuario);
            this.Controls.Add(this.btn_MostrarPassword);
            this.Controls.Add(this.checkBox_recordarSesion);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txt_password);
            this.Controls.Add(this.btn_Registrarse);
            this.Controls.Add(this.btn_Ingresar);
            this.Name = "Login";
            this.Text = "Login";
            this.Load += new System.EventHandler(this.Login_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_Ingresar;
        private System.Windows.Forms.Button btn_Registrarse;
        private System.Windows.Forms.TextBox txt_password;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox checkBox_recordarSesion;
        private System.Windows.Forms.Button btn_MostrarPassword;
        private System.Windows.Forms.ToolTip toolTip_infoControles;
        private System.Windows.Forms.ComboBox cmb_usuario;
    }
}

