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
            //RellenarTextBox();
        }

        int i = 0;
        int[] cantidad = new int[12];
        decimal[] precio = new decimal[12];
        string[] comida = new string[12];
        decimal totalVenta = 0, totalTicket = 0;

        void RellenarTextBox()
        {
            foreach (GroupBox gbox in this.Controls.OfType<GroupBox>())
            {
                foreach (TextBox txt in gbox.Controls.OfType<TextBox>())
                {
                    txt.Text = "99";
                }
            } 
        }

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
                    decimal precioComida = (decimal)bd.Select("precio", "Comida", $"id='{c}'");
                    precio.Text = "$ " + precioComida.ToString("N");
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
                lbl_Venta.Text = "$ " + totalVenta.ToString("N"); //Da formato de número. Ej.: 1.000.457 en vez de 1000457. 
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
            //DateTime.Now devuelve "26/06/2023" que no sirve para la base de datos, así que se voltea para insertar en servidor.
            string fechaTicket = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss");

            //Inserta el cuerpo del ticket y la forma de pago en la base de datos.
            bd.InsertInto("CuerpoTicket", "fechaEmision,total,CUIT_Empresa,idUsuario",
                $"'{fechaTicket}','{totalTicket}','20-42429088-1','{Login.idUsuario}'");
            bd.InsertInto("DetallesFormaPago", "idFormaPago,monto", $"1,'{totalTicket}'"); //SIEMPRE EFECTIVO. DESCARTADO EL RESTO.

            //Inicializa variables para insertar detalles de ticket en la base de datos.
            //Usando subconsultas, obtengo siempre el último ID de CuerpoTicket (el cuerpo de ticket más reciente).
            int idCuerpoTicket = Convert.ToInt32(bd.Select("id", "CuerpoTicket", "id=(SELECT MAX(id) FROM CuerpoTicket)"));
            int idDetallesFormaPago = Convert.ToInt32(bd.Select("id", "DetallesFormaPago", 
                "id=(SELECT MAX(id) FROM DetallesFormaPago)"));
            #endregion

            #region Ticket en documento de texto:

            try
            {
                //GUARDADO: Disco C:->Usuarios->Acceso Público
                string nomArchivo = "GrupoX_ticket_" + DateTime.Now.ToString("yyyyMMdd_HHmmss") + "..txt";
                string rutaArchivo = "C:\\Users\\Public\\" + nomArchivo;

                int version = 1; //Cuenta las versiones de un ticket con el mismo nombre.

                while (File.Exists(rutaArchivo)) //Mientras ya exista el archivo en la ruta...
                {
                    //Crea un versión distinta sin sobreescribir el archivo original.
                    nomArchivo = "GrupoX_ticket_" + DateTime.Now.ToString("yyyyMMdd_HHmmss") + "_" + version + "..txt";
                    rutaArchivo = "C:\\Users\\Public\\" + nomArchivo;
                    version++;
                }

                using (StreamWriter sw = new StreamWriter(rutaArchivo, false))  //Genera texto en el archivo.
                {
                    string guionIzq = new string('-', 20);
                    string guionDer = new string('-', 22);
                    sw.WriteLine(guionIzq + "GRUPO ¿? S.R.L." + guionDer + "\n");
                    sw.WriteLine("".PadRight(6) + "CUIT: 20-42429088-1.");
                    sw.WriteLine("".PadRight(2) + "ING. BR.: 1007936-1.");
                    sw.WriteLine(" DIRECCIÓN: AV. ZAVALETA 204, PARQUE PATRICIOS, CAP. FED.");
                    sw.WriteLine($" Nº TICKET: {idCuerpoTicket}. TIPO B.");
                    sw.WriteLine("".PadRight(4) + $"EMISOR: {Login.usuarioActual.ToUpper()}.");
                    sw.WriteLine("".PadRight(3) + $"EMISIÓN: {fechaTicket}.\n");
                    sw.WriteLine("".PadRight(5) + $"TOTAL: $ {totalTicket.ToString("N")}."); //"N" da formato de número. Ej.: 1.000.457 en vez de 1000457.
                    sw.WriteLine("".PadRight(2) + $"SUBTOTAL: $ {totalTicket.ToString("N")}.");
                    sw.WriteLine("FORM. PAGO: EFECTIVO.\n");
                    guionIzq = new string('-', 23);
                    guionDer = new string('-', 25);
                    sw.WriteLine(guionIzq + "ARTÍCULOS" + guionDer + "\n");
                    sw.WriteLine("Cant.".PadRight(7) + "Precio Unit.".PadRight(14) + "Descripción".PadRight(20) + "Importe\n");

                    for (int i = 0; i < 12; i++)
                    {
                        if (cantidad[i] != 0)
                        {
                            string cant = cantidad[i].ToString(), precioUnit = precio[i].ToString("N"),
                                    importe = (precio[i] * cantidad[i]).ToString("N");

                            if (precioUnit.Length == 6) precioUnit = "".PadLeft(2) + precioUnit;
                            if (importe.Length == 9) importe = "".PadLeft(1) + importe;
                            if (importe.Length == 8) importe = "".PadLeft(2) + importe;
                            if (importe.Length == 6) importe = "".PadLeft(4) + importe;
                            if (cantidad[i] < 10) cant = "0" + cantidad[i];

                            //Escribe en el documento txt.
                            sw.WriteLine($"x{cant}".PadRight(7) + $"$  {precioUnit}".PadRight(14) + $"{comida[i]}".PadRight(20) +
                                         $"$ {importe}");

                            //Escribe en la base de datos.
                            bd.InsertInto("DetallesTicket", "idCuerpoTicket,idDetallesFormaPago,idComida,cant,importe",
                            $"'{idCuerpoTicket}','{idDetallesFormaPago}','{(i + 1)}','{cantidad[i]}','{(precio[i] * cantidad[i])}'");
                        }
                    }

                    sw.WriteLine("\nIVA RESPONSABLE INSCRIPTO A CONSUMIDOR FINAL.");
                    sw.WriteLine("CF ETA 32000023DGI (logotipo fiscal).");
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

        #region Descartado (No convence la estética):

        private void btn_MouseEnter(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            btn.FlatStyle = FlatStyle.Flat;
            btn.FlatAppearance.BorderColor = Color.White;
        }

        private void btn_MouseLeave(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            btn.FlatStyle = FlatStyle.Popup;
        }
        #endregion
    }
}
