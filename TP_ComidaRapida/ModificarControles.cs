﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace TP_ComidaRapida
{
    public class ModificarControles
    {
        public void ActualizarControles(Form formulario)
        {
            //Selecciona una imagen como fondo del Form:
            formulario.BackgroundImage = TP_ComidaRapida.Properties.Resources.Fondo;
            //Cambia las dimensiones de la imagen de fondo para ajustarla al Form:
            formulario.BackgroundImageLayout = ImageLayout.Stretch;
            //Hace que el Form siempre inicie en el centro de la pantalla.
            formulario.StartPosition = FormStartPosition.CenterScreen;
            //Desactiva el botón "maximizar" de los Form.
            formulario.MaximizeBox = false;
            //Desactiva la opción de redimensionar el Form durante la ejecución de la aplicación.
            formulario.FormBorderStyle = FormBorderStyle.FixedSingle;

            //Para cada Control de un Form individual:
            try
            {
                foreach (Control ctrl in formulario.Controls)
                {
                    //Si el Control es un ComboBox...
                    if (ctrl is ComboBox)
                    {
                        /* El Control activo pasa de clase Control a clase ComboBox para acceder 
                         * a sus métodos característicos: */
                        ComboBox cmb = (ComboBox)ctrl;
                        cmb.DropDownStyle = ComboBoxStyle.DropDownList; //Evita que se pueda escribir en el ComboBox.
                        cmb.SelectedIndex = 0;
                    }

                    //Si el Control es un botón...
                    if (ctrl is Button)
                    {
                        /* El Control activo pasa de clase Control a clase Button para acceder 
                         * a sus métodos característicos: */
                        Button btn = (Button)ctrl;
                        btn.FlatStyle = FlatStyle.Flat; //Cambia el grosor de los bordes del botón.
                        /*Cambia el color del botón cuando tiene el mouse encima, 
                        pero el FlatStyle debe ser Flat obligatoriamente. */
                        btn.FlatAppearance.MouseOverBackColor = Color.Red;
                    }

                    //Si el Control es un Label O un RadioButton O un Button...
                    if (ctrl is Label || ctrl is RadioButton || ctrl is Button)
                    {
                        ctrl.ForeColor = Color.White; //Cambia el color de las letras del Control.
                        ctrl.BackColor = Color.Transparent; //Cambia el color del fondo del Control.
                    }

                    //Si el Control es un DataGridView...
                    if (ctrl is DataGridView)
                    {
                        /* El Control activo pasa de clase Control a clase Button para acceder 
                         * a sus métodos característicos: */
                        DataGridView dgv = (DataGridView)ctrl;
                        dgv.AllowUserToAddRows = false; //No permite que el usuario cree filas nuevas.
                        //No permite que el usuario borre filas solo con funciones estéticas.
                        dgv.AllowUserToDeleteRows = false;
                        dgv.AllowUserToOrderColumns = true; //Permite al usuario reordenar las columnas a su gusto.
                        dgv.AllowUserToResizeRows = false; //No permite redimensionar el alto de las filas.
                        //Ajusta automáticamente el tamaño de las columnas en función de sus celdas.
                        dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                        dgv.DefaultCellStyle.SelectionBackColor = Color.Red; //Color al seleccionar una celda.
                        dgv.MultiSelect = false; //No permite seleccionar varias filas a la vez.
                        dgv.ReadOnly = true; //Celdas de solo lectura.
                        dgv.RowHeadersVisible = false; //Oculta la cabecera de las filas.
                        //Al seleccionar una celda, se selecciona toda la fila.
                        dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
