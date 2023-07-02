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

            Eventos ev = new Eventos();
            ev.ActualizarControles(this);
            this.FormClosing += ev.FormClosing_RegistrarCierreSesion;
            AsignarEventoKeyPress();

            RellenarVector();
            RellenarLabel();
            RellenarTextBox(0);
        }

        int i = 0;
        int[] cantidad = new int[12];
        decimal[] precio = new decimal[12];
        string[] comida = new string[12];
        decimal totalCalculado = 0, totalEmitidoEnTicket = 0;

        void AsignarEventoKeyPress()
        {
            Eventos ev = new Eventos();
            foreach (GroupBox gbox in Controls.OfType<GroupBox>())
                foreach (TextBox txt in gbox.Controls.OfType<TextBox>())
                    txt.KeyPress += (sender, e) => ev.KeyPress_SoloNumeros_LimitarCantDeDigitos(sender, e, 1);
        }

        void RellenarTextBox(int cant)
        {
            foreach (GroupBox gbox in this.Controls.OfType<GroupBox>())
                foreach (TextBox txt in gbox.Controls.OfType<TextBox>())
                    txt.Text = cant.ToString();
        }

        void RellenarLabel()
        {
            ConexionSQL bd = new ConexionSQL();
            int c = 0;

            //Para cada GroupBox dentro del Form (4):
            foreach (GroupBox gbox in Controls.OfType<GroupBox>())
            {
                //Para cada TextBox dentro del cada GroupBox (3):
                foreach (Label lbl in gbox.Controls.OfType<Label>())
                {
                    c++;
                    decimal precio = (decimal)bd.Select("precio", "Comida", $"id='{c}'");
                    lbl.Text = "$ " + precio.ToString("N");
                }
            }
        }

        void RellenarVector()
        {
            ConexionSQL bd = new ConexionSQL();
            for(int i = 0; i < 12; i++)
            {
                comida[i] = (string)bd.Select("nombre", "Comida", $"id='{i + 1}'");
                precio[i] = (decimal)bd.Select("precio", "Comida", $"id='{i + 1}'");
            }
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
                            totalCalculado += cantidad[i] * precio[i];
                            totalEmitidoEnTicket = totalCalculado;
                            i++;
                        }
                    }
                }

                i = 0;
                lbl_Venta.Text = "$ " + totalCalculado.ToString("N"); //Da formato de número. Ej.: 1.000.457 en vez de 1000457. 
                totalCalculado = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btn_Facturar_Click(object sender, EventArgs e)
        {
            int ceros = 0;
            for (int i = 0; i < 12; i++)
                if (cantidad[i] == 0)
                    ceros++;
            if (ceros == 12)
            {
                MessageBox.Show("Selecione al menos una opción de compra.");
                return; //Aborta el evento Click.
            }

            #region Ticket en base de datos:

            ConexionSQL bd = new ConexionSQL();
            int idUsuario = Login.GetIdUsuario();
            //DateTime.Now devuelve "26/06/2023" que no sirve para la base de datos, así que se voltea para insertar en servidor.
            string fechaTicket = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss");

            //Inserta el cuerpo del ticket y la forma de pago en la base de datos.
            bd.InsertInto("CuerpoTicket", "fechaEmision,total,CUIT_Empresa,idUsuario",
                $"'{fechaTicket}','{totalEmitidoEnTicket}','20-42429088-1','{idUsuario}'");
            bd.InsertInto("DetallesFormaPago", "idFormaPago,monto", 
                $"1,'{totalEmitidoEnTicket}'"); //SIEMPRE EFECTIVO. DESCARTADO EL RESTO.

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
                string nombreArchivo = "GrupoX_ticket_" + DateTime.Now.ToString("yyyyMMdd_HHmmss") + "..txt";
                string rutaArchivo = "C:\\Users\\Public\\" + nombreArchivo;

                int version = 1; //Cuenta las versiones de un ticket con el mismo nombre.

                while (File.Exists(rutaArchivo)) //Mientras ya exista el archivo en la ruta...
                {
                    //Crea un versión distinta sin sobreescribir el archivo original.
                    nombreArchivo = "GrupoX_ticket_" + DateTime.Now.ToString("yyyyMMdd_HHmmss") + "_" + version + "..txt";
                    rutaArchivo = "C:\\Users\\Public\\" + nombreArchivo;
                    version++;
                }

                using (StreamWriter sw = new StreamWriter(rutaArchivo, false))  //Genera texto en el archivo.
                {
                    string usuarioActual = Login.GetUsuarioActual();
                    string guionIzq = new string('-', 20);
                    string guionDer = new string('-', 22);
                    sw.WriteLine(guionIzq + "GRUPO ¿? S.R.L." + guionDer + "\n");
                    sw.WriteLine("".PadRight(6) + "CUIT: 20-42429088-1.");
                    sw.WriteLine("".PadRight(2) + "ING. BR.: 1007936-1.");
                    sw.WriteLine(" DIRECCIÓN: AV. ZAVALETA 204, PARQUE PATRICIOS, CAP. FED.");
                    sw.WriteLine($" Nº TICKET: {idCuerpoTicket}. TIPO B.");
                    sw.WriteLine("".PadRight(4) + $"EMISOR: {usuarioActual.ToUpper()}.");
                    sw.WriteLine("".PadRight(3) + $"EMISIÓN: {fechaTicket}.\n");
                    sw.WriteLine("".PadRight(5) + $"TOTAL: $ {totalEmitidoEnTicket.ToString("N")}."); //"N" da formato de número. Ej.: 1.000.457 en vez de 1000457.
                    sw.WriteLine("".PadRight(2) + $"SUBTOTAL: $ {totalEmitidoEnTicket.ToString("N")}.");
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
            bool admin = Login.GetAdmin();
            if (admin)
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
                ConexionSQL bd = new ConexionSQL();
                int idUsuario = Login.GetIdUsuario();
                string fechaInvertida = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss");
                bd.Consulta($"CALL Registrar_Cierre_Sesion('{fechaInvertida}','{idUsuario}')");

                this.Hide();
                Login login = new Login();
                login.Show();
            }
        }
    }
}
