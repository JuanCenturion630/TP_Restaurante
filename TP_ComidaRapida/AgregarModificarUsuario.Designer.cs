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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AgregarModificarUsuario));
            this.btn_Modificar = new System.Windows.Forms.Button();
            this.btn_Agregar = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btn_InicioSesion
            // 
            this.btn_InicioSesion.BackColor = System.Drawing.Color.Transparent;
            this.btn_InicioSesion.FlatAppearance.BorderSize = 0;
            this.btn_InicioSesion.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Red;
            this.btn_InicioSesion.ForeColor = System.Drawing.Color.White;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.ForeColor = System.Drawing.Color.White;
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.ForeColor = System.Drawing.Color.White;
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.ForeColor = System.Drawing.Color.White;
            // 
            // label4
            // 
            this.label4.ForeColor = System.Drawing.Color.White;
            // 
            // label5
            // 
            this.label5.ForeColor = System.Drawing.Color.White;
            // 
            // btn_MostrarPassword
            // 
            this.btn_MostrarPassword.BackColor = System.Drawing.Color.Transparent;
            this.btn_MostrarPassword.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Red;
            this.btn_MostrarPassword.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_MostrarPassword.ForeColor = System.Drawing.Color.White;
            this.btn_MostrarPassword.UseVisualStyleBackColor = false;
            // 
            // check_Empleado
            // 
            this.check_Empleado.BackColor = System.Drawing.Color.Transparent;
            this.check_Empleado.ForeColor = System.Drawing.Color.White;
            // 
            // check_Admin
            // 
            this.check_Admin.BackColor = System.Drawing.Color.Transparent;
            this.check_Admin.ForeColor = System.Drawing.Color.White;
            this.check_Admin.UseVisualStyleBackColor = false;
            // 
            // label8
            // 
            this.label8.BackColor = System.Drawing.Color.Transparent;
            this.label8.ForeColor = System.Drawing.Color.White;
            // 
            // btn_Registrarse
            // 
            this.btn_Registrarse.BackColor = System.Drawing.Color.Transparent;
            this.btn_Registrarse.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Red;
            this.btn_Registrarse.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Registrarse.ForeColor = System.Drawing.Color.White;
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
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(260, 271);
            this.Controls.Add(this.btn_Agregar);
            this.Controls.Add(this.btn_Modificar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "AgregarModificarUsuario";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "AgregarModificarUsuario";
            this.Controls.SetChildIndex(this.btn_Modificar, 0);
            this.Controls.SetChildIndex(this.btn_Registrarse, 0);
            this.Controls.SetChildIndex(this.btn_Agregar, 0);
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

        private System.Windows.Forms.Button btn_Modificar;
        private System.Windows.Forms.Button btn_Agregar;
    }
}