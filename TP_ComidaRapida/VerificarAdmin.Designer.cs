namespace TP_ComidaRapida
{
    partial class VerificarAdmin
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
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txt_passwordAdmin = new System.Windows.Forms.TextBox();
            this.btn_Ingresar = new System.Windows.Forms.Button();
            this.txt_UserAdmin = new System.Windows.Forms.TextBox();
            this.btn_MostrarPassword = new System.Windows.Forms.Button();
            this.toolTip_MostrarPassword = new System.Windows.Forms.ToolTip(this.components);
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(12, 57);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(76, 20);
            this.label2.TabIndex = 8;
            this.label2.Text = "Contraseña:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(76, 20);
            this.label1.TabIndex = 9;
            this.label1.Text = "Usuario:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txt_passwordAdmin
            // 
            this.txt_passwordAdmin.Location = new System.Drawing.Point(94, 57);
            this.txt_passwordAdmin.Name = "txt_passwordAdmin";
            this.txt_passwordAdmin.Size = new System.Drawing.Size(106, 20);
            this.txt_passwordAdmin.TabIndex = 7;
            this.txt_passwordAdmin.UseSystemPasswordChar = true;
            // 
            // btn_Ingresar
            // 
            this.btn_Ingresar.Location = new System.Drawing.Point(67, 102);
            this.btn_Ingresar.Name = "btn_Ingresar";
            this.btn_Ingresar.Size = new System.Drawing.Size(100, 30);
            this.btn_Ingresar.TabIndex = 6;
            this.btn_Ingresar.Text = "Ingresar";
            this.btn_Ingresar.UseVisualStyleBackColor = true;
            this.btn_Ingresar.Click += new System.EventHandler(this.btn_Ingresar_Click);
            // 
            // txt_UserAdmin
            // 
            this.txt_UserAdmin.Location = new System.Drawing.Point(94, 15);
            this.txt_UserAdmin.Name = "txt_UserAdmin";
            this.txt_UserAdmin.Size = new System.Drawing.Size(133, 20);
            this.txt_UserAdmin.TabIndex = 7;
            // 
            // btn_MostrarPassword
            // 
            this.btn_MostrarPassword.Location = new System.Drawing.Point(206, 56);
            this.btn_MostrarPassword.Name = "btn_MostrarPassword";
            this.btn_MostrarPassword.Size = new System.Drawing.Size(21, 21);
            this.btn_MostrarPassword.TabIndex = 10;
            this.toolTip_MostrarPassword.SetToolTip(this.btn_MostrarPassword, "Oculta la contraseña.");
            this.btn_MostrarPassword.UseVisualStyleBackColor = true;
            // 
            // VerificarAdmin
            // 
            this.AcceptButton = this.btn_Ingresar;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(239, 144);
            this.Controls.Add(this.btn_MostrarPassword);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txt_UserAdmin);
            this.Controls.Add(this.txt_passwordAdmin);
            this.Controls.Add(this.btn_Ingresar);
            this.Name = "VerificarAdmin";
            this.Text = "Administrador";
            this.toolTip_MostrarPassword.SetToolTip(this, "Oculta la contraseña");
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.VerificarAdmin_FormClosed);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txt_passwordAdmin;
        private System.Windows.Forms.Button btn_Ingresar;
        private System.Windows.Forms.TextBox txt_UserAdmin;
        private System.Windows.Forms.Button btn_MostrarPassword;
        private System.Windows.Forms.ToolTip toolTip_MostrarPassword;
    }
}