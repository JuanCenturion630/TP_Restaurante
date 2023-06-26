using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TP_ComidaRapida
{
    public partial class AgregarModificarComida : Form
    {
        public AgregarModificarComida()
        {
            InitializeComponent();
            Controladores cs = new Controladores();
            cs.ActualizarControles(this);
            txt_Comida.KeyPress += (sender, e) => cs.SoloTextoMenorA(sender, e, 39);
            txt_Precio.KeyPress += (sender, e) => cs.SoloNumerosConComa_LimitarCantDeDigitos(sender, e, 7);
        }

        string comidaTruncada;

        public void SetComidaTruncada(string comida)
        {
            comidaTruncada = comida;
        }

        #region Setters para TextBoxs:

        public void SetTextTxtComida(string contenido)
        {
            txt_Comida.Text = contenido;
        }

        public void SetTextTxtPrecio(string contenido)
        {
            txt_Precio.Text = contenido;
        }
        #endregion

        #region Setters para Buttons:

        public void SetVisibleBtnAgregar(bool estado)
        {
            btn_Agregar.Visible = estado;
        }

        public void SetAcceptButtonBtnAgregar()
        {
            AcceptButton = btn_Agregar;
        }

        public void SetVisibleBtnModificar(bool estado)
        {
            btn_Modificar.Visible = estado;
        }

        public void SetAcceptButtonBtnModificar()
        {
            AcceptButton = btn_Modificar;
        }
        #endregion

        private void btn_Agregar_Click(object sender, EventArgs e)
        {
            ConexionSQL bd = new ConexionSQL();
            Controladores cs = new Controladores();

            if (!cs.TextoEnBlanco(this) && !cs.RepetidoEnBaseDeDatos("nombre", "Comida", txt_Comida))
            {
                string plato = cs.DarFormato(txt_Comida, "ToTitleCase");
                bd.InsertInto("Comida", "nombre,precio,borradoLogico", $"'{plato}','{txt_Precio.Text}','0'");
                MessageBox.Show("Plato creado con éxito.");
                this.Hide();
            }
        }

        private void btn_Modificar_Click(object sender, EventArgs e)
        {
            ConexionSQL bd = new ConexionSQL();
            Controladores cs = new Controladores();

            if (!cs.TextoEnBlanco(this) && !cs.RepetidoEnBaseDeDatos("nombre", "Comida", txt_Comida, comidaTruncada))
            {
                string plato = cs.DarFormato(txt_Comida, "ToTitleCase");
                bd.Consulta($"UPDATE Comida SET nombre='{plato}' WHERE nombre='{comidaTruncada}'");
                bd.Consulta($"UPDATE Comida SET precio='{txt_Precio.Text}' WHERE nombre='{comidaTruncada}'");
                MessageBox.Show("Plato actualizado con éxito.");
                this.Hide();
            }
        }
    }
}
