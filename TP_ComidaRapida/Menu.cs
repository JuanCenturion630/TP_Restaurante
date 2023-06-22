using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace TP_ComidaRapida
{
    public partial class Menu : Form
    {
        public Menu()
        {
            InitializeComponent();
            ModificarControles mc = new ModificarControles();
            mc.ActualizarControles(this);
            RellenarVector();
            RellenarLabel();
        }

        int i = 0;
        int[] cantidad = new int[12];
        decimal[] precio = new decimal[12];
        string[] comida = new string[12];
        decimal totalVenta = 0, totalTicket = 0;

        void RellenarLabel()
        {
            int c = 0;
            ConexionSQL bd = new ConexionSQL();
            //Para cada GroupBox dentro del Form (4):
            foreach (GroupBox gbox in Controls.OfType<GroupBox>())
            {
                //Para cada TextBox dentro del cada GroupBox (3):
                foreach (Label precio in gbox.Controls.OfType<Label>())
                {
                    c++;
                    precio.Text = Convert.ToString(bd.Select("precio", "Comida", $"id='{c}'"));
                }
            }
        }

        void RellenarVector()
        {
            ConexionSQL bd = new ConexionSQL();
            for(int i = 0; i < 12; i++)
            {
                precio[i] = (decimal)bd.Select("precio", "Comida", $"id='{i + 1}'");
                comida[i] = (string)bd.Select("nombre", "Comida", $"id='{i + 1}'");
            }
        }

        private void Menu_FormClosing(object sender, FormClosingEventArgs e)
        {
            //El evento se produce al intentar cerrar el formulario.
            if (MessageBox.Show("¿Desea cerrar la aplicación?", "Aviso",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                /* e.Cancel = false no cancela el evento, o sea, el formulario sí se cierra, 
                 * pero el mensaje de salida se repite al mezclarse con el mensaje de salida 
                 * del formulario Login, para evitarlo usar ExitThread() para matar todos los 
                 * procesos de la aplicación. */
                Application.ExitThread();
            }
            else
                e.Cancel = true; //Se cancela el evento, el formulario no se cierra.
        }

        private void txt_cant_KeyPress(object sender, KeyPressEventArgs e)
        {
            /* El objeto sender representa al actual control que disparó el evento
             * El objeto sender pasa a ser de la clase TextBox para usar sus métodos característicos: */
            TextBox txt = (TextBox)sender;

            /* El evento KeyPress cuando se enfoca TextBox y se presiona y suelta una tecla.
             * e.KeyChar es la tecla presionada,
             * Si tecla NO es un número (símbolo o letra) Y NO es backspace '\b' (tecla borrar)
             * entonces...
             * O si longitud es mayor a 2 Y No es backspace entonces...
             * 
             --- Al bloquear todas las teclas distintas de números, también bloque la tecla borrar, 
             --- por ello hay que colocar el !='\b' */

            if (!char.IsNumber(e.KeyChar) && e.KeyChar != '\b' || txt.TextLength > 1 && e.KeyChar != '\b')
                e.Handled = true; //Se cancela la tecla.
        }

        private void btn_Calcular_Click(object sender, EventArgs e)
        {
            try
            {
                //Para cada GroupBox dentro del Form (4):
                foreach (GroupBox gbox in this.Controls.OfType<GroupBox>())
                {
                    //Para cada TextBox dentro del cada GroupBox (3):
                    foreach (TextBox cant in gbox.Controls.OfType<TextBox>())
                    {
                        //Si el índice actual es menor al tamaño del vector "precio":
                        if (i < precio.Length)
                        {
                            //Si el texto del TextBox es nulo o vacío, lo reemplaza por 0.
                            if (string.IsNullOrWhiteSpace(cant.Text))
                                cant.Text = "0";

                            cantidad[i] = Convert.ToInt32(cant.Text);
                            //Se acumula el texto de los TextBox (unidades de comida) * precio:
                            totalVenta += cantidad[i] * precio[i];
                            totalTicket = totalVenta;
                            i++; //Aumenta en +1 para ir a la siguiente posición del vector.
                        }
                    }
                }

                i = 0;
                lbl_Venta.Text = "$ " + totalVenta.ToString();
                totalVenta = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btn_Facturar_Click(object sender, EventArgs e)
        {
            #region Ticket en base de datos:
            
            ConexionSQL bd = new ConexionSQL();
            DateTime fechaTicket = DateTime.Now;
            
            //Inserta el cuerpo del ticket y la forma de pago en la base de datos.
            bd.InsertInto("CuerpoTicket", "fechaEmision,total,CUIT_Empresa", 
                $"'{fechaTicket}','{totalTicket}','20-42429088-1'"); //BUG: NO INSERTA HORA EN BASE DE DATOS.
            bd.InsertInto("DetallesFormaPago", "idFormaPago,monto", $"1,'{totalTicket}'"); //SIEMPRE EFECTIVO. DESCARTADO EL RESTO.

            //Inicializa variables para insertar detalles de ticket en la base de datos.
            int idUsuario = Convert.ToInt32(bd.Select("id", "Usuario", $"usuario='{Login.usuarioActual}'"));

            //Usando subconsultas, obtengo siempre el último ID de CuerpoTicket (el cuerpo de ticket más reciente).
            int idCuerpoTicket = Convert.ToInt32(bd.Select("id", "CuerpoTicket", "id=(SELECT MAX(id) FROM CuerpoTicket)"));
            int idDetFormaPago = Convert.ToInt32(bd.Select("id", "DetallesFormaPago", "id=(SELECT MAX(id) FROM DetallesFormaPago)"));
            #endregion

            #region Ticket en documento de texto:

            try
            {
                string nomArchivo = "ticket_" + DateTime.Now.ToString("yyyyMMdd_HHmmss") + "..txt";
                string rutaArchivo = "C:\\Users\\Public\\" + nomArchivo;

                int version = 1; //Cuenta las versiones de un ticket con el mismo nombre.

                while (File.Exists(rutaArchivo)) //Mientras ya exista el archivo en la ruta...
                {
                    //Crea un versión distinta sin sobreescribir el archivo original.
                    nomArchivo = "ticket_" + DateTime.Now.ToString("yyyyMMdd_HHmmss") + "_" + version + "..txt";
                    rutaArchivo = "C:\\Users\\Public\\" + nomArchivo;
                    version++;
                }

                using (StreamWriter sw = new StreamWriter(rutaArchivo, false))  //Genera texto en el archivo.
                {
                    sw.WriteLine("TICKET:\n");
                    sw.WriteLine("GRUPO X S.R.L.");
                    sw.WriteLine("CUIT: 20-42429088-1.");
                    sw.WriteLine("ING. BR.: 1007936-1.");
                    sw.WriteLine("AV. ZAVALETA 204, PARQUE PATRICIOS, CAP. FED.");
                    sw.WriteLine("Nº TICKET: " + idCuerpoTicket);
                    sw.WriteLine("Emisor: " + bd.Select("usuario", "Usuario", $"id='{idUsuario}'"));
                    sw.WriteLine($"{fechaTicket.ToString("d/M/yy - HH:mm")}\n");
                    sw.WriteLine($"TOTAL: $ {totalTicket.ToString()}");
                    sw.WriteLine("FORMA DE PAGO: EFECTIVO.");
                    sw.WriteLine($"SUBTOTAL: $ {totalTicket.ToString()}\n");
                    sw.WriteLine("ARTÍCULOS:\n");
                    
                    for (int i = 0; i < 12; i++)
                    {
                        if (cantidad[i] != 0)
                        {
                            //Escribe en el documento txt.
                            sw.WriteLine($"x{cantidad[i]} {comida[i]} - $ {(precio[i] * cantidad[i])}.");
                            //Escribe en la base de datos.
                            bd.InsertInto("DetallesTicket", "idUsuario,idCuerpoTicket,idDetallesFormaPago,idComida,cant",
                                $"'{idUsuario}','{idCuerpoTicket}','{idDetFormaPago}','{(i + 1)}','{cantidad[i]}'");
                        }
                    }

                    sw.WriteLine("\nIVA RESPONSABLE INSCRIPTO A CONSUMIDOR FINAL");
                    sw.WriteLine("CF ETA 32000023DGI (logotipo fiscal)");
                }

                MessageBox.Show("Ticket de factura generado correctamente.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al generar el ticket de factura: " + ex.Message);
            }
            #endregion
        }

        private void Menu_Load(object sender, EventArgs e)
        {
            if (Login.admin == true)
                btn_Volver.Visible = true;
        }

        private void btn_Volver_Click(object sender, EventArgs e)
        {
            this.Hide();
            Gestiones gu = new Gestiones();
            gu.Show();
        }

        private void btn_CambiarSesion_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Desea cerrar sesión?", "Aviso",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                this.Hide();
                Login login = new Login();
                login.Show();
            }
        }
    }
}
