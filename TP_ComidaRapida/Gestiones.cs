using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TP_ComidaRapida
{
    public partial class Gestiones : Form
    {
        public Gestiones()
        {
            InitializeComponent();

            Eventos ev = new Eventos();
            ev.ActualizarControles(this);
            this.FormClosing += ev.FormClosing_RegistrarCierreSesion;
            txt_Buscador.TabIndex = 0;
        }

        private void btn_Buscar_Click(object sender, EventArgs e)
        {
            bool encontrado = false;
            try
            {
                foreach (DataGridViewRow fila in dgv_Tablas.Rows)
                {
                    foreach (DataGridViewCell celda in fila.Cells)
                    {
                        // Verificar si el valor de la celda coincide o es similar a la búsqueda
                        if (celda.Value != null && celda.Value.ToString().Contains(txt_Buscador.Text))
                        {
                            int i = celda.RowIndex;
                            dgv_Tablas.Rows[i].Selected = true;
                            encontrado = true;
                            return; //Terminar la búsqueda una vez se encuentre la primera coincidencia.
                        }
                    }
                }
                if (!encontrado)
                    MessageBox.Show($"'{txt_Buscador.Text}' no encontrado.", "Advertencia", MessageBoxButtons.OK, 
                        MessageBoxIcon.Exclamation);
            }
            catch(Exception ex)
            {
                MessageBox.Show("Ocurrió un error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        bool sePresionoEliminar = false;

        private void btn_Agregar_Click(object sender, EventArgs e)
        {
            sePresionoEliminar = false;
            try
            {
                if (dgv_Tablas.SelectedRows.Count == 0)
                    MessageBox.Show("Seleccione una fila.");
                else
                {
                    switch (cmb_tablas.SelectedIndex)
                    {
                        case 0:
                            AgregarModificarUsuario amu = new AgregarModificarUsuario();
                            amu.SetVisibleBtnRegistrarse(false);
                            amu.SetVisibleBtnInicioSesion(false);
                            amu.SetVisibleBtnModificar(false);
                            amu.SetAcceptButtonBtnAgregar();
                            amu.Text = "Agregar Usuario";

                            Registrarse registrarse = new Registrarse();
                            registrarse.SetEsAdmin(true);

                            amu.ShowDialog();
                            break;
                        case 1:
                            AgregarModificarComida amc = new AgregarModificarComida();
                            amc.SetVisibleBtnModificar(false);
                            amc.SetAcceptButtonBtnAgregar();
                            amc.Text = "Agregar Comida";
                            amc.ShowDialog();
                            break;
                        case 2:
                            MessageBox.Show("No puede agregar tickets.", "Advertencia", MessageBoxButtons.OK, 
                                MessageBoxIcon.Information);
                            break;
                        case 3:
                            MessageBox.Show("No puede agregar sesiones.", "Advertencia", MessageBoxButtons.OK, 
                                MessageBoxIcon.Information);
                            break;
                    }
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show("Ocurrió un error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn_Modificar_Click(object sender, EventArgs e)
        {
            sePresionoEliminar = false;
            try
            {
                if (dgv_Tablas.SelectedRows.Count == 0)
                    MessageBox.Show("Seleccione una fila.");
                else
                {
                    switch (cmb_tablas.SelectedIndex)
                    {
                        case 0:
                            //Se reconfiguran los botones utilizando setters.
                            AgregarModificarUsuario amu = new AgregarModificarUsuario();
                            amu.SetVisibleBtnRegistrarse(false);
                            amu.SetVisibleBtnInicioSesion(false);
                            amu.SetVisibleBtnAgregar(false);
                            amu.SetAcceptButtonBtnModificar();
                            amu.Text = "Modificar Usuario";

                            Registrarse registrarse = new Registrarse();
                            registrarse.SetEsAdmin(true);

                            DataGridViewRow filaUsuario = dgv_Tablas.SelectedRows[0];

                            //Se escriben los Controles de AgregarModificarUsuario usando setters.
                            if ((bool)filaUsuario.Cells[0].Value)
                                amu.SetCheckedCheckAdmin(true);
                            else
                                amu.SetCheckedCheckEmpleado(true);

                            amu.SetTextTxtNombre(filaUsuario.Cells[1].Value.ToString());
                            amu.SetTextTxtApellido(filaUsuario.Cells[2].Value.ToString());
                            amu.SetTextTxtUsuario(filaUsuario.Cells[3].Value.ToString());
                            amu.SetUsuarioTruncado(filaUsuario.Cells[3].Value.ToString()); //Usar para los UPDATE.
                            amu.SetTextTxtPassword(filaUsuario.Cells[4].Value.ToString());
                            amu.SetValueDtpFechaNacimiento((DateTime)filaUsuario.Cells[5].Value);

                            if (filaUsuario.Cells[7].Value.ToString() == "08:00:00" 
                                && filaUsuario.Cells[8].Value.ToString() == "16:00:00")
                                amu.SetSelectedIndexCmbTurnos(0);
                            else
                                amu.SetSelectedIndexCmbTurnos(1);

                            amu.ShowDialog();
                            break;
                        case 1:
                            //Se reconfiguran los botones.
                            AgregarModificarComida amc = new AgregarModificarComida();
                            amc.SetVisibleBtnAgregar(false);
                            amc.SetAcceptButtonBtnModificar();
                            amc.Text = "Modificar Comida";

                            //Se escriben los TextBox usando setters.
                            DataGridViewRow filacomida = dgv_Tablas.SelectedRows[0];
                            amc.SetTextTxtComida(filacomida.Cells[0].Value.ToString());
                            amc.SetComidaTruncada(filacomida.Cells[0].Value.ToString());
                            amc.SetTextTxtPrecio(filacomida.Cells[1].Value.ToString());
                            amc.ShowDialog();
                            break;
                        case 2:
                            MessageBox.Show("No puede modificar los tickets.", "Advertencia", MessageBoxButtons.OK, 
                                MessageBoxIcon.Information);
                            break;
                        case 3:
                            MessageBox.Show("No puede modificar el registro de sesiones.", "Advertencia", MessageBoxButtons.OK, 
                                MessageBoxIcon.Information);
                            break;
                    }
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show("Ocurrió un error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn_Eliminar_Click(object sender, EventArgs e)
        {
            try
            {
                ConexionSQL bd = new ConexionSQL();
                if (dgv_Tablas.SelectedCells.Count == 0) //Si las celdas seleccionadas son 0.
                    MessageBox.Show("Seleccione una fila.");
                else
                {
                    //Aunque el borrado lógico de Comida esta programado, no lo ejecutaremos porque la aplicación necesita 
                    //obligatoriamente 12 comidas estáticas.
                    if (cmb_tablas.SelectedIndex >= 1)
                        MessageBox.Show("No se puede eliminar este registro.", "Advertencia", MessageBoxButtons.OK, 
                            MessageBoxIcon.Information);
                    else
                    {
                        sePresionoEliminar = true;
                        if (MessageBox.Show("¿Desea borrar la fila?", "Aviso",
                                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            //De la celda seleccionada, obtiene el índice de la fila de DataGridView.
                            int i = dgv_Tablas.SelectedCells[0].RowIndex;
                            switch (cmb_tablas.SelectedIndex)
                            {
                                case 0:
                                    //Obtiene el valor de la celda 3 de la fila X, es decir, la columna "usuario" de la tabla SQL.
                                    string usuario = dgv_Tablas.Rows[i].Cells[3].Value.ToString();
                                    bd.Update("Usuario", "borradoLogico", "1", $"usuario='{usuario}'");
                                    RefrescarDGV(dgv_Tablas, "usuario");
                                    break;
                                case 1:
                                    //Obtiene el valor de la celda 0 de la fila X, es decir, la columna "comida" de la tabla SQL.
                                    string comida = dgv_Tablas.Rows[i].Cells[0].Value.ToString();
                                    bd.Update("Comida", "borradoLogico", "1", $"nombre='{comida}'");
                                    RefrescarDGV(dgv_Tablas, "comida");
                                    break;
                            }
                        }
                    }
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show("Ocurrió un error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn_Imprimir_Click(object sender, EventArgs e)
        {
            Ticket ticket = new Ticket();
            ticket.ShowDialog();
        }

        private void btn_Menu_Click(object sender, EventArgs e)
        {
            this.Hide();
            Menu menu = new Menu();
            menu.Show();
        }

        private void btn_Login_Click(object sender, EventArgs e)
        {
            this.Hide();
            Login login = new Login();
            login.Show();
        }

        private void cmb_tablas_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                switch (cmb_tablas.SelectedIndex)
                {
                    case 0:
                        btn_Imprimir.Enabled = false;
                        RefrescarDGV(dgv_Tablas, "usuario");
                        this.Text = "Gestionar Usuarios";
                        break;
                    case 1:
                        btn_Imprimir.Enabled = false;
                        RefrescarDGV(dgv_Tablas, "comida");
                        this.Text = "Gestionar Comidas";
                        break;
                    case 2:
                        btn_Imprimir.Enabled = true;
                        toolTip_infoControles.SetToolTip(btn_Imprimir, "Imprimir ticket.");
                        RefrescarDGV(dgv_Tablas, "ticket");
                        this.Text = "Gestionar Tickets";
                        break;
                    case 3:
                        btn_Imprimir.Enabled = false;
                        RefrescarDGV(dgv_Tablas, "sesion");
                        this.Text = "Gestionar Sesiones";
                        break;
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show("Ocurrió un error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void RefrescarDGV(DataGridView dgv, string opcion)
        {
            ConexionSQL bd = new ConexionSQL();
            switch (opcion)
            {
                case "usuario":
                    bd.RellenarDGV(dgv, "Mostrar_Usuarios()");
                    break;
                case "comida":
                    bd.RellenarDGV(dgv, "Mostrar_Comidas()");
                    break;
                case "ticket":
                    bd.RellenarDGV(dgv, "Crear_Ticket()");
                    break;
                case "sesion":
                    bd.RellenarDGV(dgv, "Mostrar_Sesiones()");
                    break;
            }
        }

        private void Gestiones_Activated(object sender, EventArgs e)
        {
            if (!sePresionoEliminar)
            {
                switch (cmb_tablas.SelectedIndex)
                {
                    case 0:
                        RefrescarDGV(dgv_Tablas, "usuario");
                        break;
                    case 1:
                        RefrescarDGV(dgv_Tablas, "comida");
                        break;
                }
            }
        }
    }
}
