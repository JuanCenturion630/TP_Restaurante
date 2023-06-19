namespace TP_ComidaRapida
{
    partial class AgregarModificarUsuario
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
            this.btn_Modificar = new System.Windows.Forms.Button();
            this.btn_Agregar = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btn_InicioSesion
            // 
            this.btn_InicioSesion.FlatAppearance.BorderSize = 0;
            this.btn_InicioSesion.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Red;
            // 
            // btn_MostrarPassword
            // 
            this.btn_MostrarPassword.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Red;
            // 
            // btn_Registrarse
            // 
            this.btn_Registrarse.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Red;
            // 
            // btn_Modificar
            // 
            this.btn_Modificar.Location = new System.Drawing.Point(60, 227);
            this.btn_Modificar.Name = "btn_Modificar";
            this.btn_Modificar.Size = new System.Drawing.Size(131, 34);
            this.btn_Modificar.TabIndex = 11;
            this.btn_Modificar.Text = "Modificar";
            this.btn_Modificar.UseVisualStyleBackColor = true;
            this.btn_Modificar.Click += new System.EventHandler(this.btn_Modificar_Click);
            // 
            // btn_Agregar
            // 
            this.btn_Agregar.Location = new System.Drawing.Point(60, 227);
            this.btn_Agregar.Name = "btn_Agregar";
            this.btn_Agregar.Size = new System.Drawing.Size(131, 34);
            this.btn_Agregar.TabIndex = 12;
            this.btn_Agregar.Text = "Crear";
            this.btn_Agregar.UseVisualStyleBackColor = true;
            this.btn_Agregar.Click += new System.EventHandler(this.btn_Registrarse_Click);
            // 
            // AgregarModificarUsuario
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(260, 271);
            this.Controls.Add(this.btn_Modificar);
            this.Controls.Add(this.btn_Agregar);
            this.Name = "AgregarModificarUsuario";
            this.Text = "AgregarModificarUsuario";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Registrarse_FormClosing);
            this.Controls.SetChildIndex(this.btn_Registrarse, 0);
            this.Controls.SetChildIndex(this.btn_Agregar, 0);
            this.Controls.SetChildIndex(this.btn_Modificar, 0);
            this.Controls.SetChildIndex(this.label5, 0);
            this.Controls.SetChildIndex(this.btn_InicioSesion, 0);
            this.Controls.SetChildIndex(this.btn_MostrarPassword, 0);
            this.Controls.SetChildIndex(this.txt_Nombre, 0);
            this.Controls.SetChildIndex(this.txt_Apellido, 0);
            this.Controls.SetChildIndex(this.txt_Usuario, 0);
            this.Controls.SetChildIndex(this.txt_Password, 0);
            this.Controls.SetChildIndex(this.dtp_fechaNacimiento, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.label8, 0);
            this.Controls.SetChildIndex(this.label3, 0);
            this.Controls.SetChildIndex(this.label4, 0);
            this.Controls.SetChildIndex(this.check_Empleado, 0);
            this.Controls.SetChildIndex(this.check_Admin, 0);
            this.Controls.SetChildIndex(this.cmb_Turnos, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        public System.Windows.Forms.Button btn_Modificar;
        public System.Windows.Forms.Button btn_Agregar;
    }
}