namespace TP_ComidaRapida
{
    partial class Menu
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
            this.label10 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txt_cantHambGrande = new System.Windows.Forms.TextBox();
            this.txt_cantHambMedia = new System.Windows.Forms.TextBox();
            this.txt_cantHambChica = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.button7 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txt_cantPizzaGrande = new System.Windows.Forms.TextBox();
            this.txt_cantPizzaMedia = new System.Windows.Forms.TextBox();
            this.txt_cantPizzaChica = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.button11 = new System.Windows.Forms.Button();
            this.button9 = new System.Windows.Forms.Button();
            this.button8 = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.txt_cantGaseosaGrande = new System.Windows.Forms.TextBox();
            this.txt_cantGaseosaMedia = new System.Windows.Forms.TextBox();
            this.txt_cantGaseosaChica = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.button20 = new System.Windows.Forms.Button();
            this.button18 = new System.Windows.Forms.Button();
            this.button16 = new System.Windows.Forms.Button();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.txt_cantCarneGrande = new System.Windows.Forms.TextBox();
            this.txt_cantCarneMedia = new System.Windows.Forms.TextBox();
            this.txt_cantCarneChica = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.button26 = new System.Windows.Forms.Button();
            this.button27 = new System.Windows.Forms.Button();
            this.button29 = new System.Windows.Forms.Button();
            this.btn_Facturar = new System.Windows.Forms.Button();
            this.btn_Calcular = new System.Windows.Forms.Button();
            this.lbl_Venta = new System.Windows.Forms.Label();
            this.btn_CambiarSesion = new System.Windows.Forms.Button();
            this.btn_Volver = new System.Windows.Forms.Button();
            this.toolTip_infoControles = new System.Windows.Forms.ToolTip(this.components);
            this.btn_Configuracion = new System.Windows.Forms.Button();
            this.timer_Precio = new System.Windows.Forms.Timer(this.components);
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // label10
            // 
            this.label10.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.SystemColors.Control;
            this.label10.Location = new System.Drawing.Point(18, 27);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(96, 17);
            this.label10.TabIndex = 0;
            this.label10.Text = "Chica ($ 250)";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.Transparent;
            this.groupBox1.Controls.Add(this.txt_cantHambGrande);
            this.groupBox1.Controls.Add(this.txt_cantHambMedia);
            this.groupBox1.Controls.Add(this.txt_cantHambChica);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.button7);
            this.groupBox1.Controls.Add(this.button4);
            this.groupBox1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.ForeColor = System.Drawing.SystemColors.Control;
            this.groupBox1.Location = new System.Drawing.Point(12, 44);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(337, 167);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Hamburguesas";
            // 
            // txt_cantHambGrande
            // 
            this.txt_cantHambGrande.Location = new System.Drawing.Point(225, 131);
            this.txt_cantHambGrande.Name = "txt_cantHambGrande";
            this.txt_cantHambGrande.Size = new System.Drawing.Size(28, 20);
            this.txt_cantHambGrande.TabIndex = 5;
            this.txt_cantHambGrande.Text = "0";
            this.txt_cantHambGrande.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.toolTip_infoControles.SetToolTip(this.txt_cantHambGrande, "Cantidad.");
            this.txt_cantHambGrande.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_cant_KeyPress);
            // 
            // txt_cantHambMedia
            // 
            this.txt_cantHambMedia.Location = new System.Drawing.Point(123, 131);
            this.txt_cantHambMedia.Name = "txt_cantHambMedia";
            this.txt_cantHambMedia.Size = new System.Drawing.Size(28, 20);
            this.txt_cantHambMedia.TabIndex = 5;
            this.txt_cantHambMedia.Text = "0";
            this.txt_cantHambMedia.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.toolTip_infoControles.SetToolTip(this.txt_cantHambMedia, "Cantidad.");
            this.txt_cantHambMedia.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_cant_KeyPress);
            // 
            // txt_cantHambChica
            // 
            this.txt_cantHambChica.Location = new System.Drawing.Point(21, 131);
            this.txt_cantHambChica.Name = "txt_cantHambChica";
            this.txt_cantHambChica.Size = new System.Drawing.Size(28, 20);
            this.txt_cantHambChica.TabIndex = 5;
            this.txt_cantHambChica.Text = "0";
            this.txt_cantHambChica.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.toolTip_infoControles.SetToolTip(this.txt_cantHambChica, "Cantidad.");
            this.txt_cantHambChica.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_cant_KeyPress);
            // 
            // label2
            // 
            this.label2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.Control;
            this.label2.Location = new System.Drawing.Point(222, 27);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(96, 17);
            this.label2.TabIndex = 0;
            this.label2.Text = "Grande ($ 950)";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            this.label1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.Control;
            this.label1.Location = new System.Drawing.Point(120, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(96, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Media ($ 450)";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // button1
            // 
            this.button1.BackgroundImage = global::TP_ComidaRapida.Properties.Resources.Hamburguesa_Media;
            this.button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button1.Cursor = System.Windows.Forms.Cursors.Default;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button1.Location = new System.Drawing.Point(18, 48);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(96, 103);
            this.button1.TabIndex = 0;
            this.button1.UseVisualStyleBackColor = true;
            // 
            // button7
            // 
            this.button7.BackgroundImage = global::TP_ComidaRapida.Properties.Resources.Hamburguesa_Grande;
            this.button7.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button7.Cursor = System.Windows.Forms.Cursors.Default;
            this.button7.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button7.Location = new System.Drawing.Point(222, 48);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(96, 103);
            this.button7.TabIndex = 0;
            this.button7.UseVisualStyleBackColor = true;
            // 
            // button4
            // 
            this.button4.BackgroundImage = global::TP_ComidaRapida.Properties.Resources.Hamburguesa_Chica;
            this.button4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button4.Cursor = System.Windows.Forms.Cursors.Default;
            this.button4.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button4.Location = new System.Drawing.Point(120, 48);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(96, 103);
            this.button4.TabIndex = 0;
            this.button4.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.Color.Transparent;
            this.groupBox2.Controls.Add(this.txt_cantPizzaGrande);
            this.groupBox2.Controls.Add(this.txt_cantPizzaMedia);
            this.groupBox2.Controls.Add(this.txt_cantPizzaChica);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.button11);
            this.groupBox2.Controls.Add(this.button9);
            this.groupBox2.Controls.Add(this.button8);
            this.groupBox2.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.ForeColor = System.Drawing.SystemColors.Control;
            this.groupBox2.Location = new System.Drawing.Point(355, 44);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(337, 167);
            this.groupBox2.TabIndex = 0;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Pizzas";
            // 
            // txt_cantPizzaGrande
            // 
            this.txt_cantPizzaGrande.Location = new System.Drawing.Point(225, 131);
            this.txt_cantPizzaGrande.Name = "txt_cantPizzaGrande";
            this.txt_cantPizzaGrande.Size = new System.Drawing.Size(28, 20);
            this.txt_cantPizzaGrande.TabIndex = 5;
            this.txt_cantPizzaGrande.Text = "0";
            this.txt_cantPizzaGrande.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.toolTip_infoControles.SetToolTip(this.txt_cantPizzaGrande, "Cantidad.");
            this.txt_cantPizzaGrande.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_cant_KeyPress);
            // 
            // txt_cantPizzaMedia
            // 
            this.txt_cantPizzaMedia.Location = new System.Drawing.Point(123, 131);
            this.txt_cantPizzaMedia.Name = "txt_cantPizzaMedia";
            this.txt_cantPizzaMedia.Size = new System.Drawing.Size(28, 20);
            this.txt_cantPizzaMedia.TabIndex = 5;
            this.txt_cantPizzaMedia.Text = "0";
            this.txt_cantPizzaMedia.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.toolTip_infoControles.SetToolTip(this.txt_cantPizzaMedia, "Cantidad.");
            this.txt_cantPizzaMedia.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_cant_KeyPress);
            // 
            // txt_cantPizzaChica
            // 
            this.txt_cantPizzaChica.Location = new System.Drawing.Point(21, 131);
            this.txt_cantPizzaChica.Name = "txt_cantPizzaChica";
            this.txt_cantPizzaChica.Size = new System.Drawing.Size(28, 20);
            this.txt_cantPizzaChica.TabIndex = 5;
            this.txt_cantPizzaChica.Text = "0";
            this.txt_cantPizzaChica.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.toolTip_infoControles.SetToolTip(this.txt_cantPizzaChica, "Cantidad.");
            this.txt_cantPizzaChica.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_cant_KeyPress);
            // 
            // label3
            // 
            this.label3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.Control;
            this.label3.Location = new System.Drawing.Point(222, 27);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(96, 17);
            this.label3.TabIndex = 0;
            this.label3.Text = "Grande ($ 950)";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label4
            // 
            this.label4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.SystemColors.Control;
            this.label4.Location = new System.Drawing.Point(120, 27);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(96, 17);
            this.label4.TabIndex = 0;
            this.label4.Text = "Media ($ 450)";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label5
            // 
            this.label5.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.SystemColors.Control;
            this.label5.Location = new System.Drawing.Point(18, 27);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(96, 17);
            this.label5.TabIndex = 0;
            this.label5.Text = "Chica ($ 250)";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // button11
            // 
            this.button11.BackgroundImage = global::TP_ComidaRapida.Properties.Resources.Pizza_Chica;
            this.button11.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button11.Cursor = System.Windows.Forms.Cursors.Default;
            this.button11.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button11.Location = new System.Drawing.Point(18, 48);
            this.button11.Name = "button11";
            this.button11.Size = new System.Drawing.Size(96, 104);
            this.button11.TabIndex = 0;
            this.button11.UseVisualStyleBackColor = true;
            // 
            // button9
            // 
            this.button9.BackgroundImage = global::TP_ComidaRapida.Properties.Resources.Pizza_Media;
            this.button9.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button9.Cursor = System.Windows.Forms.Cursors.Default;
            this.button9.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button9.Location = new System.Drawing.Point(120, 48);
            this.button9.Name = "button9";
            this.button9.Size = new System.Drawing.Size(96, 103);
            this.button9.TabIndex = 0;
            this.button9.UseVisualStyleBackColor = true;
            // 
            // button8
            // 
            this.button8.BackgroundImage = global::TP_ComidaRapida.Properties.Resources.Pizza_Grande;
            this.button8.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button8.Cursor = System.Windows.Forms.Cursors.Default;
            this.button8.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button8.Location = new System.Drawing.Point(222, 48);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(96, 103);
            this.button8.TabIndex = 0;
            this.button8.UseVisualStyleBackColor = true;
            // 
            // groupBox3
            // 
            this.groupBox3.BackColor = System.Drawing.Color.Transparent;
            this.groupBox3.Controls.Add(this.txt_cantGaseosaGrande);
            this.groupBox3.Controls.Add(this.txt_cantGaseosaMedia);
            this.groupBox3.Controls.Add(this.txt_cantGaseosaChica);
            this.groupBox3.Controls.Add(this.label6);
            this.groupBox3.Controls.Add(this.label7);
            this.groupBox3.Controls.Add(this.label8);
            this.groupBox3.Controls.Add(this.button20);
            this.groupBox3.Controls.Add(this.button18);
            this.groupBox3.Controls.Add(this.button16);
            this.groupBox3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox3.ForeColor = System.Drawing.SystemColors.Control;
            this.groupBox3.Location = new System.Drawing.Point(12, 217);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(337, 167);
            this.groupBox3.TabIndex = 0;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Gaseosas";
            // 
            // txt_cantGaseosaGrande
            // 
            this.txt_cantGaseosaGrande.Location = new System.Drawing.Point(225, 131);
            this.txt_cantGaseosaGrande.Name = "txt_cantGaseosaGrande";
            this.txt_cantGaseosaGrande.Size = new System.Drawing.Size(28, 20);
            this.txt_cantGaseosaGrande.TabIndex = 5;
            this.txt_cantGaseosaGrande.Text = "0";
            this.txt_cantGaseosaGrande.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.toolTip_infoControles.SetToolTip(this.txt_cantGaseosaGrande, "Cantidad.");
            this.txt_cantGaseosaGrande.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_cant_KeyPress);
            // 
            // txt_cantGaseosaMedia
            // 
            this.txt_cantGaseosaMedia.Location = new System.Drawing.Point(123, 131);
            this.txt_cantGaseosaMedia.Name = "txt_cantGaseosaMedia";
            this.txt_cantGaseosaMedia.Size = new System.Drawing.Size(28, 20);
            this.txt_cantGaseosaMedia.TabIndex = 5;
            this.txt_cantGaseosaMedia.Text = "0";
            this.txt_cantGaseosaMedia.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.toolTip_infoControles.SetToolTip(this.txt_cantGaseosaMedia, "Cantidad.");
            this.txt_cantGaseosaMedia.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_cant_KeyPress);
            // 
            // txt_cantGaseosaChica
            // 
            this.txt_cantGaseosaChica.Location = new System.Drawing.Point(21, 131);
            this.txt_cantGaseosaChica.Name = "txt_cantGaseosaChica";
            this.txt_cantGaseosaChica.Size = new System.Drawing.Size(28, 20);
            this.txt_cantGaseosaChica.TabIndex = 5;
            this.txt_cantGaseosaChica.Text = "0";
            this.txt_cantGaseosaChica.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.toolTip_infoControles.SetToolTip(this.txt_cantGaseosaChica, "Cantidad.");
            this.txt_cantGaseosaChica.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_cant_KeyPress);
            // 
            // label6
            // 
            this.label6.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.SystemColors.Control;
            this.label6.Location = new System.Drawing.Point(222, 27);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(96, 17);
            this.label6.TabIndex = 0;
            this.label6.Text = "Grande ($ 950)";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label7
            // 
            this.label7.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.SystemColors.Control;
            this.label7.Location = new System.Drawing.Point(120, 27);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(96, 17);
            this.label7.TabIndex = 0;
            this.label7.Text = "Media ($ 450)";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label8
            // 
            this.label8.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.SystemColors.Control;
            this.label8.Location = new System.Drawing.Point(18, 27);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(96, 17);
            this.label8.TabIndex = 0;
            this.label8.Text = "Chica ($ 250)";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // button20
            // 
            this.button20.BackgroundImage = global::TP_ComidaRapida.Properties.Resources.Coca_Chica;
            this.button20.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button20.Cursor = System.Windows.Forms.Cursors.Default;
            this.button20.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button20.Location = new System.Drawing.Point(18, 48);
            this.button20.Name = "button20";
            this.button20.Size = new System.Drawing.Size(96, 103);
            this.button20.TabIndex = 0;
            this.button20.UseVisualStyleBackColor = true;
            // 
            // button18
            // 
            this.button18.BackgroundImage = global::TP_ComidaRapida.Properties.Resources.Coca_Media;
            this.button18.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button18.Cursor = System.Windows.Forms.Cursors.Default;
            this.button18.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button18.Location = new System.Drawing.Point(120, 48);
            this.button18.Name = "button18";
            this.button18.Size = new System.Drawing.Size(96, 103);
            this.button18.TabIndex = 0;
            this.button18.UseVisualStyleBackColor = true;
            // 
            // button16
            // 
            this.button16.BackgroundImage = global::TP_ComidaRapida.Properties.Resources.Coca_Grande;
            this.button16.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button16.Cursor = System.Windows.Forms.Cursors.Default;
            this.button16.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button16.Location = new System.Drawing.Point(222, 48);
            this.button16.Name = "button16";
            this.button16.Size = new System.Drawing.Size(96, 103);
            this.button16.TabIndex = 0;
            this.button16.UseVisualStyleBackColor = true;
            // 
            // groupBox4
            // 
            this.groupBox4.BackColor = System.Drawing.Color.Transparent;
            this.groupBox4.Controls.Add(this.txt_cantCarneGrande);
            this.groupBox4.Controls.Add(this.txt_cantCarneMedia);
            this.groupBox4.Controls.Add(this.txt_cantCarneChica);
            this.groupBox4.Controls.Add(this.label9);
            this.groupBox4.Controls.Add(this.label11);
            this.groupBox4.Controls.Add(this.label12);
            this.groupBox4.Controls.Add(this.button26);
            this.groupBox4.Controls.Add(this.button27);
            this.groupBox4.Controls.Add(this.button29);
            this.groupBox4.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.groupBox4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox4.ForeColor = System.Drawing.SystemColors.Control;
            this.groupBox4.Location = new System.Drawing.Point(355, 217);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(337, 167);
            this.groupBox4.TabIndex = 0;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Carnes";
            // 
            // txt_cantCarneGrande
            // 
            this.txt_cantCarneGrande.Location = new System.Drawing.Point(225, 131);
            this.txt_cantCarneGrande.Name = "txt_cantCarneGrande";
            this.txt_cantCarneGrande.Size = new System.Drawing.Size(28, 20);
            this.txt_cantCarneGrande.TabIndex = 5;
            this.txt_cantCarneGrande.Text = "0";
            this.txt_cantCarneGrande.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.toolTip_infoControles.SetToolTip(this.txt_cantCarneGrande, "Cantidad.");
            this.txt_cantCarneGrande.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_cant_KeyPress);
            // 
            // txt_cantCarneMedia
            // 
            this.txt_cantCarneMedia.Location = new System.Drawing.Point(123, 131);
            this.txt_cantCarneMedia.Name = "txt_cantCarneMedia";
            this.txt_cantCarneMedia.Size = new System.Drawing.Size(28, 20);
            this.txt_cantCarneMedia.TabIndex = 5;
            this.txt_cantCarneMedia.Text = "0";
            this.txt_cantCarneMedia.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.toolTip_infoControles.SetToolTip(this.txt_cantCarneMedia, "Cantidad.");
            this.txt_cantCarneMedia.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_cant_KeyPress);
            // 
            // txt_cantCarneChica
            // 
            this.txt_cantCarneChica.Location = new System.Drawing.Point(21, 131);
            this.txt_cantCarneChica.Name = "txt_cantCarneChica";
            this.txt_cantCarneChica.Size = new System.Drawing.Size(28, 20);
            this.txt_cantCarneChica.TabIndex = 5;
            this.txt_cantCarneChica.Text = "0";
            this.txt_cantCarneChica.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.toolTip_infoControles.SetToolTip(this.txt_cantCarneChica, "Cantidad.");
            this.txt_cantCarneChica.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_cant_KeyPress);
            // 
            // label9
            // 
            this.label9.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.SystemColors.Control;
            this.label9.Location = new System.Drawing.Point(222, 27);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(96, 17);
            this.label9.TabIndex = 0;
            this.label9.Text = "Grande ($ 950)";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label11
            // 
            this.label11.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.SystemColors.Control;
            this.label11.Location = new System.Drawing.Point(120, 27);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(96, 17);
            this.label11.TabIndex = 0;
            this.label11.Text = "Media ($ 450)";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label12
            // 
            this.label12.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.ForeColor = System.Drawing.SystemColors.Control;
            this.label12.Location = new System.Drawing.Point(18, 27);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(96, 17);
            this.label12.TabIndex = 0;
            this.label12.Text = "Chica ($ 250)";
            this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // button26
            // 
            this.button26.BackgroundImage = global::TP_ComidaRapida.Properties.Resources.Carne_Grande;
            this.button26.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button26.Cursor = System.Windows.Forms.Cursors.Default;
            this.button26.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button26.Location = new System.Drawing.Point(222, 48);
            this.button26.Name = "button26";
            this.button26.Size = new System.Drawing.Size(96, 103);
            this.button26.TabIndex = 0;
            this.button26.UseVisualStyleBackColor = true;
            // 
            // button27
            // 
            this.button27.BackgroundImage = global::TP_ComidaRapida.Properties.Resources.Carne_Media;
            this.button27.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button27.Cursor = System.Windows.Forms.Cursors.Default;
            this.button27.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button27.Location = new System.Drawing.Point(120, 48);
            this.button27.Name = "button27";
            this.button27.Size = new System.Drawing.Size(96, 103);
            this.button27.TabIndex = 0;
            this.button27.UseVisualStyleBackColor = true;
            // 
            // button29
            // 
            this.button29.BackgroundImage = global::TP_ComidaRapida.Properties.Resources.Carne_Chica;
            this.button29.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button29.Cursor = System.Windows.Forms.Cursors.Default;
            this.button29.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button29.Location = new System.Drawing.Point(18, 48);
            this.button29.Name = "button29";
            this.button29.Size = new System.Drawing.Size(96, 103);
            this.button29.TabIndex = 0;
            this.button29.UseVisualStyleBackColor = true;
            // 
            // btn_Facturar
            // 
            this.btn_Facturar.Location = new System.Drawing.Point(580, 396);
            this.btn_Facturar.Name = "btn_Facturar";
            this.btn_Facturar.Size = new System.Drawing.Size(93, 37);
            this.btn_Facturar.TabIndex = 11;
            this.btn_Facturar.Text = "Facturar";
            this.toolTip_infoControles.SetToolTip(this.btn_Facturar, "Facturar ticket de compra.");
            this.btn_Facturar.UseVisualStyleBackColor = true;
            this.btn_Facturar.Click += new System.EventHandler(this.btn_Facturar_Click);
            // 
            // btn_Calcular
            // 
            this.btn_Calcular.Location = new System.Drawing.Point(234, 396);
            this.btn_Calcular.Name = "btn_Calcular";
            this.btn_Calcular.Size = new System.Drawing.Size(96, 37);
            this.btn_Calcular.TabIndex = 11;
            this.btn_Calcular.Text = "Calcular";
            this.toolTip_infoControles.SetToolTip(this.btn_Calcular, "Calcular importe.");
            this.btn_Calcular.UseVisualStyleBackColor = true;
            this.btn_Calcular.Click += new System.EventHandler(this.btn_Calcular_Click);
            // 
            // lbl_Venta
            // 
            this.lbl_Venta.BackColor = System.Drawing.Color.Transparent;
            this.lbl_Venta.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.lbl_Venta.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Venta.ForeColor = System.Drawing.SystemColors.Control;
            this.lbl_Venta.Location = new System.Drawing.Point(12, 404);
            this.lbl_Venta.Name = "lbl_Venta";
            this.lbl_Venta.Size = new System.Drawing.Size(216, 20);
            this.lbl_Venta.TabIndex = 0;
            this.lbl_Venta.Text = "$ 0";
            this.lbl_Venta.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btn_CambiarSesion
            // 
            this.btn_CambiarSesion.Location = new System.Drawing.Point(597, 12);
            this.btn_CambiarSesion.Name = "btn_CambiarSesion";
            this.btn_CambiarSesion.Size = new System.Drawing.Size(35, 26);
            this.btn_CambiarSesion.TabIndex = 11;
            this.btn_CambiarSesion.Text = "S";
            this.toolTip_infoControles.SetToolTip(this.btn_CambiarSesion, "Cambiar de sesión.");
            this.btn_CambiarSesion.UseVisualStyleBackColor = true;
            this.btn_CambiarSesion.Click += new System.EventHandler(this.btn_CambiarSesion_Click);
            // 
            // btn_Volver
            // 
            this.btn_Volver.Location = new System.Drawing.Point(15, 12);
            this.btn_Volver.Name = "btn_Volver";
            this.btn_Volver.Size = new System.Drawing.Size(35, 26);
            this.btn_Volver.TabIndex = 11;
            this.btn_Volver.Text = "<-";
            this.toolTip_infoControles.SetToolTip(this.btn_Volver, "Volver a la ventana anterior.");
            this.btn_Volver.UseVisualStyleBackColor = true;
            this.btn_Volver.Visible = false;
            this.btn_Volver.Click += new System.EventHandler(this.btn_Volver_Click);
            // 
            // btn_Configuracion
            // 
            this.btn_Configuracion.Location = new System.Drawing.Point(638, 12);
            this.btn_Configuracion.Name = "btn_Configuracion";
            this.btn_Configuracion.Size = new System.Drawing.Size(35, 26);
            this.btn_Configuracion.TabIndex = 11;
            this.btn_Configuracion.Text = "C";
            this.toolTip_infoControles.SetToolTip(this.btn_Configuracion, "Cambia la configuración del menú.");
            this.btn_Configuracion.UseVisualStyleBackColor = true;
            // 
            // timer_Precio
            // 
            this.timer_Precio.Enabled = true;
            this.timer_Precio.Interval = 2500;
            // 
            // Menu
            // 
            this.AcceptButton = this.btn_Calcular;
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackgroundImage = global::TP_ComidaRapida.Properties.Resources.Fondo;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(706, 445);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.btn_Volver);
            this.Controls.Add(this.btn_Calcular);
            this.Controls.Add(this.btn_Facturar);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.lbl_Venta);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btn_Configuracion);
            this.Controls.Add(this.btn_CambiarSesion);
            this.MaximizeBox = false;
            this.Name = "Menu";
            this.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Menú";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Menu_FormClosing);
            this.Load += new System.EventHandler(this.Menu_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button button8;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button button9;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button button11;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button button16;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button button18;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button button20;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Button button26;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button button27;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Button button29;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Button btn_Facturar;
        private System.Windows.Forms.Button btn_Calcular;
        private System.Windows.Forms.TextBox txt_cantHambChica;
        private System.Windows.Forms.TextBox txt_cantHambGrande;
        private System.Windows.Forms.TextBox txt_cantHambMedia;
        private System.Windows.Forms.TextBox txt_cantPizzaGrande;
        private System.Windows.Forms.TextBox txt_cantPizzaMedia;
        private System.Windows.Forms.TextBox txt_cantPizzaChica;
        private System.Windows.Forms.TextBox txt_cantGaseosaGrande;
        private System.Windows.Forms.TextBox txt_cantGaseosaMedia;
        private System.Windows.Forms.TextBox txt_cantGaseosaChica;
        private System.Windows.Forms.TextBox txt_cantCarneGrande;
        private System.Windows.Forms.TextBox txt_cantCarneMedia;
        private System.Windows.Forms.TextBox txt_cantCarneChica;
        private System.Windows.Forms.Label lbl_Venta;
        private System.Windows.Forms.Button btn_CambiarSesion;
        private System.Windows.Forms.Button btn_Volver;
        private System.Windows.Forms.ToolTip toolTip_infoControles;
        private System.Windows.Forms.Timer timer_Precio;
        private System.Windows.Forms.Button btn_Configuracion;
    }
}