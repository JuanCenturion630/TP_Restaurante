namespace TP_ComidaRapida
{
    partial class Ticket
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
            this.txt_Ticket = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // rtxt_Ticket
            // 
            this.txt_Ticket.Location = new System.Drawing.Point(3, 3);
            this.txt_Ticket.Multiline = true;
            this.txt_Ticket.Name = "rtxt_Ticket";
            this.txt_Ticket.ReadOnly = true;
            this.txt_Ticket.Size = new System.Drawing.Size(355, 338);
            this.txt_Ticket.TabIndex = 0;
            // 
            // Ticket
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(361, 343);
            this.Controls.Add(this.txt_Ticket);
            this.Name = "Ticket";
            this.Text = "Ticket";
            this.Load += new System.EventHandler(this.Ticket_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txt_Ticket;
    }
}