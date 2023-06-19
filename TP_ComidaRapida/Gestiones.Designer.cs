namespace TP_ComidaRapida
{
    partial class Gestiones
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
            this.btn_Agregar = new System.Windows.Forms.Button();
            this.btn_Modificar = new System.Windows.Forms.Button();
            this.btn_Eliminar = new System.Windows.Forms.Button();
            this.txt_Buscador = new System.Windows.Forms.TextBox();
            this.btn_Buscar = new System.Windows.Forms.Button();
            this.btn_Menu = new System.Windows.Forms.Button();
            this.btn_Login = new System.Windows.Forms.Button();
            this.toolTip_infoControles = new System.Windows.Forms.ToolTip(this.components);
            this.cmb_tablas = new System.Windows.Forms.ComboBox();
            this.btn_Imprimir = new System.Windows.Forms.Button();
            this.dgv_Tablas = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Tablas)).BeginInit();
            this.SuspendLayout();
            // 
            // btn_Agregar
            // 
            this.btn_Agregar.Location = new System.Drawing.Point(445, 37);
            this.btn_Agregar.Name = "btn_Agregar";
            this.btn_Agregar.Size = new System.Drawing.Size(41, 50);
            this.btn_Agregar.TabIndex = 1;
            this.btn_Agregar.Text = "+";
            this.toolTip_infoControles.SetToolTip(this.btn_Agregar, "Agregar nuevo empleado.");
            this.btn_Agregar.UseVisualStyleBackColor = true;
            this.btn_Agregar.Click += new System.EventHandler(this.btn_Agregar_Click);
            // 
            // btn_Modificar
            // 
            this.btn_Modificar.Location = new System.Drawing.Point(445, 93);
            this.btn_Modificar.Name = "btn_Modificar";
            this.btn_Modificar.Size = new System.Drawing.Size(41, 50);
            this.btn_Modificar.TabIndex = 1;
            this.btn_Modificar.Text = "O";
            this.toolTip_infoControles.SetToolTip(this.btn_Modificar, "Modificar empleado.");
            this.btn_Modificar.UseVisualStyleBackColor = true;
            this.btn_Modificar.Click += new System.EventHandler(this.btn_Modificar_Click);
            // 
            // btn_Eliminar
            // 
            this.btn_Eliminar.Location = new System.Drawing.Point(445, 149);
            this.btn_Eliminar.Name = "btn_Eliminar";
            this.btn_Eliminar.Size = new System.Drawing.Size(41, 50);
            this.btn_Eliminar.TabIndex = 1;
            this.btn_Eliminar.Text = "X";
            this.toolTip_infoControles.SetToolTip(this.btn_Eliminar, "Eliminar empleado.");
            this.btn_Eliminar.UseVisualStyleBackColor = true;
            this.btn_Eliminar.Click += new System.EventHandler(this.btn_Eliminar_Click);
            // 
            // txt_Buscador
            // 
            this.txt_Buscador.Location = new System.Drawing.Point(270, 11);
            this.txt_Buscador.Name = "txt_Buscador";
            this.txt_Buscador.Size = new System.Drawing.Size(168, 20);
            this.txt_Buscador.TabIndex = 2;
            this.toolTip_infoControles.SetToolTip(this.txt_Buscador, "Barra de búsqueda.");
            // 
            // btn_Buscar
            // 
            this.btn_Buscar.Location = new System.Drawing.Point(445, 10);
            this.btn_Buscar.Name = "btn_Buscar";
            this.btn_Buscar.Size = new System.Drawing.Size(41, 21);
            this.btn_Buscar.TabIndex = 3;
            this.btn_Buscar.Text = "Q";
            this.toolTip_infoControles.SetToolTip(this.btn_Buscar, "Busca un elemento.");
            this.btn_Buscar.UseVisualStyleBackColor = true;
            this.btn_Buscar.Click += new System.EventHandler(this.btn_Buscar_Click);
            // 
            // btn_Menu
            // 
            this.btn_Menu.Location = new System.Drawing.Point(60, 11);
            this.btn_Menu.Name = "btn_Menu";
            this.btn_Menu.Size = new System.Drawing.Size(41, 20);
            this.btn_Menu.TabIndex = 3;
            this.btn_Menu.Text = "->";
            this.toolTip_infoControles.SetToolTip(this.btn_Menu, "Ir al menú de comida.");
            this.btn_Menu.UseVisualStyleBackColor = true;
            this.btn_Menu.Click += new System.EventHandler(this.btn_Menu_Click);
            // 
            // btn_Login
            // 
            this.btn_Login.Location = new System.Drawing.Point(12, 11);
            this.btn_Login.Name = "btn_Login";
            this.btn_Login.Size = new System.Drawing.Size(42, 20);
            this.btn_Login.TabIndex = 3;
            this.btn_Login.Text = "<-";
            this.toolTip_infoControles.SetToolTip(this.btn_Login, "Vuelve al inicio de sesión.");
            this.btn_Login.UseVisualStyleBackColor = true;
            this.btn_Login.Click += new System.EventHandler(this.btn_Login_Click);
            // 
            // cmb_tablas
            // 
            this.cmb_tablas.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmb_tablas.Items.AddRange(new object[] {
            "Usuarios",
            "Comidas",
            "Tickets"});
            this.cmb_tablas.Location = new System.Drawing.Point(107, 10);
            this.cmb_tablas.Name = "cmb_tablas";
            this.cmb_tablas.Size = new System.Drawing.Size(157, 21);
            this.cmb_tablas.TabIndex = 4;
            this.toolTip_infoControles.SetToolTip(this.cmb_tablas, "Tablas.");
            this.cmb_tablas.SelectedIndexChanged += new System.EventHandler(this.cmb_tablas_SelectedIndexChanged);
            // 
            // btn_Imprimir
            // 
            this.btn_Imprimir.Enabled = false;
            this.btn_Imprimir.Location = new System.Drawing.Point(445, 205);
            this.btn_Imprimir.Name = "btn_Imprimir";
            this.btn_Imprimir.Size = new System.Drawing.Size(41, 50);
            this.btn_Imprimir.TabIndex = 1;
            this.btn_Imprimir.Text = "Imp";
            this.toolTip_infoControles.SetToolTip(this.btn_Imprimir, "Imprime el Ticket.");
            this.btn_Imprimir.UseVisualStyleBackColor = true;
            this.btn_Imprimir.Click += new System.EventHandler(this.btn_Imprimir_Click);
            // 
            // dgv_Tablas
            // 
            this.dgv_Tablas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_Tablas.Location = new System.Drawing.Point(12, 37);
            this.dgv_Tablas.Name = "dgv_Tablas";
            this.dgv_Tablas.Size = new System.Drawing.Size(426, 218);
            this.dgv_Tablas.TabIndex = 5;
            // 
            // Gestiones
            // 
            this.AcceptButton = this.btn_Buscar;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(499, 265);
            this.Controls.Add(this.dgv_Tablas);
            this.Controls.Add(this.cmb_tablas);
            this.Controls.Add(this.btn_Menu);
            this.Controls.Add(this.btn_Buscar);
            this.Controls.Add(this.txt_Buscador);
            this.Controls.Add(this.btn_Imprimir);
            this.Controls.Add(this.btn_Eliminar);
            this.Controls.Add(this.btn_Modificar);
            this.Controls.Add(this.btn_Agregar);
            this.Controls.Add(this.btn_Login);
            this.Name = "Gestiones";
            this.Text = "Gestionar Usuarios";
            this.Activated += new System.EventHandler(this.Gestiones_Activated);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.GestionarUsuarios_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Tablas)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btn_Agregar;
        private System.Windows.Forms.Button btn_Modificar;
        private System.Windows.Forms.Button btn_Eliminar;
        private System.Windows.Forms.TextBox txt_Buscador;
        private System.Windows.Forms.Button btn_Buscar;
        private System.Windows.Forms.Button btn_Menu;
        private System.Windows.Forms.Button btn_Login;
        private System.Windows.Forms.ToolTip toolTip_infoControles;
        private System.Windows.Forms.ComboBox cmb_tablas;
        private System.Windows.Forms.DataGridView dgv_Tablas;
        private System.Windows.Forms.Button btn_Imprimir;
    }
}