using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TP_ComidaRapida
{
    public partial class Ticket : Form
    {
        public Ticket()
        {
            InitializeComponent();
            ModificarControles mc = new ModificarControles();
            mc.ActualizarControles(this);
        }

        private void Ticket_Load(object sender, EventArgs e)
        {
            string ruta = "C:\\Users\\Public\\GrupoX_ticket_20230625_031549..txt";

            try
            {
                //Leer el contenido del documento.
                string contenido = File.ReadAllText(ruta);
                txt_Ticket.Text = contenido;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar el ticket: " + ex.Message);
            }
        }
    }
}
