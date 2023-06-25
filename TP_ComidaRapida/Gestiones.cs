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
            ModificarControles mc = new ModificarControles();
            mc.ActualizarControles(this);
            txt_Buscador.TabIndex = 0;
        }

        ConexionSQL bd = new ConexionSQL();

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
                    MessageBox.Show($"'{txt_Buscador.Text}' no encontrado.");
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btn_Agregar_Click(object sender, EventArgs e)
        {
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
                            amu.btn_Registrarse.Visible = false;
                            amu.btn_InicioSesion.Visible = false;
                            amu.btn_Modificar.Visible = false;
                            amu.AcceptButton = amu.btn_Agregar;
                            amu.Text = "Agregar Usuario";
                            amu.YaEsAdmin = true;
                            amu.ShowDialog();
                            break;
                        case 1:
                            AgregarModificarComida amc = new AgregarModificarComida();
                            amc.btn_Modificar.Visible = false;
                            amc.AcceptButton = amc.btn_Agregar;
                            amc.Text = "Agregar Comida";
                            amc.ShowDialog();
                            break;
                        case 2:
                            MessageBox.Show("No puede agregar tickets.");
                            break;
                        case 3:
                            MessageBox.Show("No puede agregar sesiones.");
                            break;
                    }
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btn_Modificar_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgv_Tablas.SelectedRows.Count == 0)
                    MessageBox.Show("Seleccione una fila.");
                else
                {
                    switch (cmb_tablas.SelectedIndex)
                    {
                        case 0:
                            //Se reconfiguran los botones.
                            AgregarModificarUsuario amu = new AgregarModificarUsuario();
                            amu.btn_Registrarse.Visible = false;
                            amu.btn_InicioSesion.Visible = false;
                            amu.btn_Agregar.Visible = false;
                            amu.AcceptButton = amu.btn_Modificar;  //Con solo presionar ENTER se activa el botón.
                            amu.Text = "Modificar Usuario";
                            amu.YaEsAdmin = true;

                            //Se escriben los TextBox.
                            DataGridViewRow filaUsuario = dgv_Tablas.SelectedRows[0];
                            if ((bool)filaUsuario.Cells[0].Value)
                                amu.check_Admin.Checked = true;
                            amu.txt_Nombre.Text = filaUsuario.Cells[1].Value.ToString();
                            amu.txt_Apellido.Text = filaUsuario.Cells[2].Value.ToString();
                            //Escribe el viejo usuario en Form "AgregarModificarUsuario" para modificarlo.
                            amu.txt_Usuario.Text = filaUsuario.Cells[3].Value.ToString();
                            //Guarda el viejo usuario para realizar el UPDATE posterior.
                            amu.usuarioTruncado = filaUsuario.Cells[3].Value.ToString();
                            amu.txt_Password.Text = filaUsuario.Cells[4].Value.ToString();
                            amu.dtp_fechaNacimiento.Value = (DateTime)filaUsuario.Cells[5].Value;
                            if (filaUsuario.Cells[7].Value.ToString() == "08:00:00" && filaUsuario.Cells[8].Value.ToString() == "16:00:00")
                                amu.cmb_Turnos.SelectedIndex = 0;
                            else
                                amu.cmb_Turnos.SelectedIndex = 1;
                            amu.ShowDialog();
                            break;
                        case 1:
                            //Se reconfiguran los botones.
                            AgregarModificarComida amc = new AgregarModificarComida();
                            amc.btn_Agregar.Visible = false;
                            amc.AcceptButton = amc.btn_Modificar;
                            amc.Text = "Modificar Comida";

                            //Se escriben los TextBox.
                            DataGridViewRow filacomida = dgv_Tablas.SelectedRows[0];
                            amc.txt_Comida.Text = filacomida.Cells[0].Value.ToString();
                            amc.comidaTruncada = filacomida.Cells[0].Value.ToString();
                            amc.txt_Precio.Text = filacomida.Cells[1].Value.ToString();
                            amc.ShowDialog();
                            break;
                        case 2:
                            MessageBox.Show("No puede modificar los tickets.");
                            break;
                        case 3:
                            MessageBox.Show("No puede modificar el registro de sesiones.");
                            break;
                    }
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        bool sePresionoEliminar = false;

        private void btn_Eliminar_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgv_Tablas.SelectedCells.Count == 0) //Si las celdas seleccionadas son 0.
                {
                    MessageBox.Show("Seleccione una fila.");
                }
                else
                {
                    //Aunque el borrado lógico de Comida esta programado, no lo ejecutaremos porque la aplicación necesita 
                    //obligatoriamente 12 comidas estáticas.
                    if (cmb_tablas.SelectedIndex >= 1)
                        MessageBox.Show("No se puede aplicar esta acción en este registro.");
                    else
                    {
                        sePresionoEliminar = true;
                        if (MessageBox.Show("¿Desea borrar la fila?", "Aviso",
                                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            //De la celda seleccionada, obtiene el índice de la fila de DataGridView, no de la tabla SQL.
                            int i = dgv_Tablas.SelectedCells[0].RowIndex;
                            switch (cmb_tablas.SelectedIndex)
                            {
                                case 0:
                                    //Obtiene el valor de la celda 3 de la fila X, es decir, la columna "usuario" de la tabla SQL.
                                    string usuario = dgv_Tablas.Rows[i].Cells[3].Value.ToString();
                                    bd.Update("Usuario", "despedido", "1", $"usuario='{usuario}'");
                                    RefrescarDGV(dgv_Tablas, "usuario");
                                    break;
                                case 1:
                                    //Obtiene el valor de la celda 0 de la fila X, es decir, la columna "comida" de la tabla SQL.
                                    string comida = dgv_Tablas.Rows[i].Cells[0].Value.ToString();
                                    bd.Update("Comida", "descartado", "1", $"nombre='{comida}'");
                                    RefrescarDGV(dgv_Tablas, "comida");
                                    break;
                            }
                        }
                    }
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
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

        private void Gestiones_FormClosing(object sender, FormClosingEventArgs e)
        {
            //El evento se produce al intentar cerrar el formulario.
            if (MessageBox.Show("¿Desea cerrar la aplicación?", "Aviso",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                string fechaInvertida = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss");
                bd.Update($"CALL Registrar_Cierre_Sesion('{fechaInvertida}','{Login.idUsuario}')");

                /* e.Cancel = false no cancela el evento, o sea, el formulario sí se cierra, 
                 * pero el mensaje de salida se repite al mezclarse con el mensaje de salida 
                 * del formulario Login, para evitarlo usar ExitThread() para matar todos los 
                 * procesos de la aplicación. */
                Application.ExitThread();
            }
            else
                e.Cancel = true; //Se cancela el evento, el formulario no se cierra.
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
                        this.Text = "Gestionar Comida";
                        break;
                    case 2:
                        btn_Imprimir.Enabled = true;
                        toolTip_infoControles.SetToolTip(btn_Imprimir, "Imprimir ticket.");
                        RefrescarDGV(dgv_Tablas, "ticket");
                        this.Text = "Gestionar Tickets";
                        break;
                    case 3:
                        RefrescarDGV(dgv_Tablas, "sesion");
                        this.Text = "Gestionar Sesiones";
                        break;
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        void RefrescarDGV(DataGridView dgv, string opcion)
        {
            switch (opcion)
            {
                case "usuario":
                    bd.RellenarControl(dgv,
                        "administrador AS Admin,nombre AS Nombre,apellido AS Apellido,usuario AS Usuario,pass AS Password,fechaNacimiento AS Nacimiento,edad AS Edad,horaIngreso AS Ingreso,horaSalida AS Egreso",
                        "Usuario",
                        "despedido=0");
                    break;
                case "comida":
                    bd.RellenarControl(dgv, 
                        "nombre AS Comida,precio AS Precio", 
                        "Comida", 
                        "descartado=0");
                    break;
                case "ticket":
                    bd.RellenarControl(dgv, "Crear_Ticket()");
                    break;
                case "sesion":
                    bd.RellenarControl(dgv, "Mostrar_Sesiones()");
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
                sePresionoEliminar = false;
            }
        }
    }
}
