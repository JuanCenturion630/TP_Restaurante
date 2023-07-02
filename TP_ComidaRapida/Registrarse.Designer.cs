namespace TP_ComidaRapida
{
    partial class Registrarse
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.txt_Nombre = new System.Windows.Forms.TextBox();
            this.txt_Apellido = new System.Windows.Forms.TextBox();
            this.txt_Password = new System.Windows.Forms.TextBox();
            this.dtp_fechaNacimiento = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.btn_Registrarse = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.btn_MostrarPassword = new System.Windows.Forms.Button();
            this.toolTip_infoControles = new System.Windows.Forms.ToolTip(this.components);
            this.check_Empleado = new System.Windows.Forms.RadioButton();
            this.check_Admin = new System.Windows.Forms.RadioButton();
            this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.btn_InicioSesion = new System.Windows.Forms.Button();
            this.txt_Usuario = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.cmb_Turnos = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // txt_Nombre
            // 
            this.txt_Nombre.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_Nombre.Location = new System.Drawing.Point(108, 15);
            this.txt_Nombre.Name = "txt_Nombre";
            this.txt_Nombre.Size = new System.Drawing.Size(134, 21);
            this.txt_Nombre.TabIndex = 0;
            // 
            // txt_Apellido
            // 
            this.txt_Apellido.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_Apellido.Location = new System.Drawing.Point(108, 42);
            this.txt_Apellido.Name = "txt_Apellido";
            this.txt_Apellido.Size = new System.Drawing.Size(134, 21);
            this.txt_Apellido.TabIndex = 1;
            // 
            // txt_Password
            // 
            this.txt_Password.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_Password.Location = new System.Drawing.Point(108, 96);
            this.txt_Password.Name = "txt_Password";
            this.txt_Password.Size = new System.Drawing.Size(106, 21);
            this.txt_Password.TabIndex = 3;
            this.txt_Password.UseSystemPasswordChar = true;
            // 
            // dtp_fechaNacimiento
            // 
            this.dtp_fechaNacimiento.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtp_fechaNacimiento.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtp_fechaNacimiento.Location = new System.Drawing.Point(108, 123);
            this.dtp_fechaNacimiento.Name = "dtp_fechaNacimiento";
            this.dtp_fechaNacimiento.Size = new System.Drawing.Size(134, 21);
            this.dtp_fechaNacimiento.TabIndex = 4;
            this.toolTip_infoControles.SetToolTip(this.dtp_fechaNacimiento, "No se permiten fechas de nacimiento que sean de menores de edad.");
            this.dtp_fechaNacimiento.Value = new System.DateTime(2023, 6, 14, 0, 0, 0, 0);
            this.dtp_fechaNacimiento.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.dtp_fechaNacimiento_KeyPress);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 15);
            this.label1.TabIndex = 2;
            this.label1.Text = "Nombre:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(12, 45);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(54, 15);
            this.label2.TabIndex = 2;
            this.label2.Text = "Apellido:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(12, 98);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(73, 15);
            this.label3.TabIndex = 2;
            this.label3.Text = "Contraseña:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(12, 128);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(73, 15);
            this.label4.TabIndex = 2;
            this.label4.Text = "Nacimiento:";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btn_Registrarse
            // 
            this.btn_Registrarse.Location = new System.Drawing.Point(60, 227);
            this.btn_Registrarse.Name = "btn_Registrarse";
            this.btn_Registrarse.Size = new System.Drawing.Size(131, 34);
            this.btn_Registrarse.TabIndex = 8;
            this.btn_Registrarse.Text = "Registrarse";
            this.btn_Registrarse.UseVisualStyleBackColor = false;
            this.btn_Registrarse.Click += new System.EventHandler(this.btn_Registrarse_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(12, 151);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(42, 15);
            this.label5.TabIndex = 2;
            this.label5.Text = "Turno:";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btn_MostrarPassword
            // 
            this.btn_MostrarPassword.Location = new System.Drawing.Point(220, 96);
            this.btn_MostrarPassword.Name = "btn_MostrarPassword";
            this.btn_MostrarPassword.Size = new System.Drawing.Size(22, 21);
            this.btn_MostrarPassword.TabIndex = 3;
            this.toolTip_infoControles.SetToolTip(this.btn_MostrarPassword, "Oculta la contraseña");
            this.btn_MostrarPassword.UseVisualStyleBackColor = true;
            // 
            // check_Empleado
            // 
            this.check_Empleado.Location = new System.Drawing.Point(126, 186);
            this.check_Empleado.Name = "check_Empleado";
            this.check_Empleado.Size = new System.Drawing.Size(116, 24);
            this.check_Empleado.TabIndex = 7;
            this.check_Empleado.TabStop = true;
            this.check_Empleado.Text = "Empleado";
            this.check_Empleado.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.check_Empleado.UseVisualStyleBackColor = false;
            // 
            // check_Admin
            // 
            this.check_Admin.Location = new System.Drawing.Point(15, 186);
            this.check_Admin.Name = "check_Admin";
            this.check_Admin.Size = new System.Drawing.Size(104, 24);
            this.check_Admin.TabIndex = 6;
            this.check_Admin.TabStop = true;
            this.check_Admin.Text = "Administrador";
            this.check_Admin.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.check_Admin.UseVisualStyleBackColor = true;
            // 
            // errorProvider
            // 
            this.errorProvider.ContainerControl = this;
            // 
            // btn_InicioSesion
            // 
            this.btn_InicioSesion.FlatAppearance.BorderSize = 0;
            this.btn_InicioSesion.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_InicioSesion.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_InicioSesion.Location = new System.Drawing.Point(60, 267);
            this.btn_InicioSesion.Name = "btn_InicioSesion";
            this.btn_InicioSesion.Size = new System.Drawing.Size(131, 34);
            this.btn_InicioSesion.TabIndex = 9;
            this.btn_InicioSesion.Text = "Volver al inicio";
            this.btn_InicioSesion.UseVisualStyleBackColor = false;
            this.btn_InicioSesion.Click += new System.EventHandler(this.btn_InicioSesion_Click);
            this.btn_InicioSesion.MouseEnter += new System.EventHandler(this.btn_InicioSesion_MouseEnter);
            this.btn_InicioSesion.MouseLeave += new System.EventHandler(this.btn_InicioSesion_MouseLeave);
            // 
            // txt_Usuario
            // 
            this.txt_Usuario.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_Usuario.Location = new System.Drawing.Point(108, 69);
            this.txt_Usuario.Name = "txt_Usuario";
            this.txt_Usuario.Size = new System.Drawing.Size(134, 21);
            this.txt_Usuario.TabIndex = 2;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(12, 72);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(53, 15);
            this.label8.TabIndex = 2;
            this.label8.Text = "Usuario:";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // cmb_Turnos
            // 
            this.cmb_Turnos.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_Turnos.FormattingEnabled = true;
            this.cmb_Turnos.Items.AddRange(new object[] {
            "1º - 08:00 - 16:00.",
            "2º - 16:00 - 23:59."});
            this.cmb_Turnos.Location = new System.Drawing.Point(108, 150);
            this.cmb_Turnos.Name = "cmb_Turnos";
            this.cmb_Turnos.Size = new System.Drawing.Size(134, 21);
            this.cmb_Turnos.TabIndex = 5;
            // 
            // Registrarse
            // 
            this.AcceptButton = this.btn_Registrarse;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(260, 310);
            this.Controls.Add(this.cmb_Turnos);
            this.Controls.Add(this.check_Admin);
            this.Controls.Add(this.check_Empleado);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dtp_fechaNacimiento);
            this.Controls.Add(this.txt_Password);
            this.Controls.Add(this.txt_Usuario);
            this.Controls.Add(this.txt_Apellido);
            this.Controls.Add(this.txt_Nombre);
            this.Controls.Add(this.btn_MostrarPassword);
            this.Controls.Add(this.btn_InicioSesion);
            this.Controls.Add(this.btn_Registrarse);
            this.Controls.Add(this.label5);
            this.Name = "Registrarse";
            this.Text = "Registrarse";
            this.Activated += new System.EventHandler(this.Registrarse_Activated);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ToolTip toolTip_infoControles;
        private System.Windows.Forms.ErrorProvider errorProvider;
        protected System.Windows.Forms.Button btn_InicioSesion;
        protected System.Windows.Forms.TextBox txt_Nombre;
        protected System.Windows.Forms.TextBox txt_Apellido;
        protected System.Windows.Forms.TextBox txt_Password;
        protected System.Windows.Forms.DateTimePicker dtp_fechaNacimiento;
        protected System.Windows.Forms.Label label1;
        protected System.Windows.Forms.Label label2;
        protected System.Windows.Forms.Label label3;
        protected System.Windows.Forms.Label label4;
        protected System.Windows.Forms.Label label5;
        protected System.Windows.Forms.Button btn_MostrarPassword;
        protected System.Windows.Forms.RadioButton check_Empleado;
        protected System.Windows.Forms.RadioButton check_Admin;
        protected System.Windows.Forms.Label label8;
        protected System.Windows.Forms.TextBox txt_Usuario;
        protected System.Windows.Forms.ComboBox cmb_Turnos;
        protected System.Windows.Forms.Button btn_Registrarse;
    }
}