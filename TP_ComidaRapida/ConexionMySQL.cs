using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.Data;

namespace TP_ComidaRapida
{
    public class ConexionSQL
    {
        static string servidor = "Server=localhost;Database=BD_ComidaRapida;Uid=root"; //Ruta al servidor.
        MySqlConnection conexion = new MySqlConnection(servidor); //Instancia un objeto MySQL con la ruta.

        /* Uso de lenguaje de marcado XML para escribir mensajes orientativos sobre los métodos siguientes. */
        /// <summary>
        /// INSERT INTO tabla(columna1,columna2,columna3...) VALUES (valor1,valor2,valor3...)
        /// </summary>
        public void InsertInto(string tabla, string columna, string valor)
        {
            try
            {
                conexion.Open(); //Abre conexión con el servidor.
                //INSERT INTO Usuario (administrador, nombre, apellido, usuario...) 
                //       VALUES (1,'Juan','Centurión','jcenturion630'...)
                string consulta = $"INSERT INTO {tabla} ({columna}) VALUES ({valor})";
                MySqlCommand comando = new MySqlCommand(consulta, conexion); //Conecta la consulta con la BD.
                comando.ExecuteNonQuery(); //Ejecuta la consulta.
                conexion.Close(); //Cierra conexión con el servidor.
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al insertar datos: " + ex.Message);
            }
        }

        /// <summary>
        /// SELECT columna1,columna2,columna3 FROM tabla WHERE condicion.
        /// </summary>
        /// <returns>Devuelve un objeto con los resultados de la consulta.</returns>
        public object Select(string columna, string tabla, string where)
        {
            object fila = null;
            try
            {
                conexion.Open(); //Abre conexión con el servidor.
                string consulta = $"SELECT {columna} FROM {tabla}"; //SELECT usuario FROM Usuario
                if (!string.IsNullOrEmpty(where)) //Si la variable "where" no es un espacio en blanco.
                    consulta += $" WHERE {where}"; //WHERE usuario='jcenturion630'
                MySqlCommand comando = new MySqlCommand(consulta, conexion); //Conecta la consulta con la BD.
                fila = comando.ExecuteScalar(); //Ejecuta la consulta y obtiene una fila como máximo.
                conexion.Close(); //Cierra conexión con el servidor.
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al mostrar datos: " + ex.Message);
            }
            return fila;
        }

        /// <summary>
        /// Realiza un SELECT columna FROM tabla para rellenar un Control.
        /// </summary>
        /// <param name="dgv">El control utilizado. Ej. DataGridView, ComboBox, etc...</param>
        /// <param name="store_procedure">El nombre del STORE PROCEDURE debe ir acompañado de paréntesis. Ej.: Crear_Ticket()</param>
        public void RellenarControl(DataGridView dgv, string store_procedure)
        {
            try
            {
                conexion.Open(); //Abre conexión con el servidor.
                string consulta = $"CALL {store_procedure}";
                MySqlCommand comando = new MySqlCommand(consulta, conexion); //Conecta la consulta con la BD.
                MySqlDataReader datos = comando.ExecuteReader(); //Trae datos de la tabla a la aplicación.

                DataTable tablaVirtual = new DataTable(); //Crea una tabla virtual para darle formato al objeto "datos".
                tablaVirtual.Load(datos); //Carga los datos en la tabla virtual.
                dgv.DataSource = tablaVirtual; //Rellena el DataGridView con el DataTable.

                conexion.Close(); //Cierra conexión con el servidor.
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar el ComboBox: " + ex.Message);
            }
        }

        /// <summary>
        /// Realiza un SELECT columna FROM tabla para rellenar un Control.
        /// </summary>
        /// <param name="ctrl">El control utilizado. Ej. DataGridView, ComboBox, etc...</param>
        public void RellenarControl(Control ctrl, string columna, string tabla, string where)
        {
            try
            {
                conexion.Open(); //Abre conexión con el servidor.
                string consulta = $"SELECT {columna} FROM {tabla}";
                if (!string.IsNullOrEmpty(where)) //Si la variable "where" no es un espacio en blanco.
                    consulta += $" WHERE {where}";
                MySqlCommand comando = new MySqlCommand(consulta, conexion); //Conecta la consulta con la BD.
                MySqlDataReader datos = comando.ExecuteReader(); //Trae datos de la tabla a la aplicación.

                if (ctrl is DataGridView)
                {
                    /* La instancia "ctrl" cambia de la clase Control a la clase ComboBox para acceder 
                     * a sus métodos característicos. */
                    DataGridView dgv = (DataGridView)ctrl;
                    DataTable tablaVirtual = new DataTable(); //Crea una tabla virtual para darle formato al objeto "datos".
                    tablaVirtual.Load(datos); //Carga los datos en la tabla virtual.
                    dgv.DataSource = tablaVirtual; //Rellena el DataGridView con el DataTable.
                }

                if (datos.HasRows) //Verifica si la tabla tiene filas en primer lugar.
                {
                    while (datos.Read()) //Mientras la tabla encuentre una nueva fila, recorrerla.
                    {
                        if (ctrl is ComboBox)
                        {
                            /* La instancia "ctrl" cambia de la clase Control a la clase ComboBox para acceder 
                             * a sus métodos característicos. */
                            ComboBox cmb = (ComboBox)ctrl;
                            //De la fila actual, obtiene el valor de una columna concreta...
                            string texto = datos.GetString("usuario");
                            cmb.Items.Add(texto);
                        }
                    }
                }

                conexion.Close(); //Cierra conexión con el servidor.
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar el ComboBox: " + ex.Message);
            }
        }

        /// <summary>
        /// UPDATE tabla SET columna=nuevoValor WHERE condicion. No se encontró la forma de hacer un UPDATE múltiple.
        /// </summary>
        public void Update(string tabla, string columna, string nuevoValor, string where)
        {
            try
            {
                conexion.Open(); //Abre conexión con el servidor.
                string consulta = $"UPDATE {tabla} SET {columna} = '{nuevoValor}'"; //UPDATE Usuario SET usuario='jvazquez630'
                if (!string.IsNullOrEmpty(where)) //Si la variable "where" no es un espacio en blanco.
                    consulta += $" WHERE {where}"; //WHERE usuario='jcenturion630'
                MySqlCommand comando = new MySqlCommand(consulta, conexion); //Conecta la consulta con la BD.
                comando.ExecuteNonQuery(); //Ejecuta la consulta.
                conexion.Close(); //Cierra conexión con el servidor.
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al actualizar datos: " + ex.Message);
            }
        }

        /// <summary>
        /// UPDATE tabla SET columna=nuevoValor WHERE condicion. Solo toma una columna a la vez.
        /// </summary>
        public void Consulta(string consulta)
        {
            try
            {
                conexion.Open(); //Abre conexión con el servidor.
                MySqlCommand comando = new MySqlCommand(consulta, conexion); //Conecta la consulta con la BD.
                comando.ExecuteNonQuery(); //Ejecuta la consulta.
                conexion.Close(); //Cierra conexión con el servidor.
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al actualizar datos: " + ex.Message);
            }
        }

        /// <summary>
        /// DELETE FROM tabla WHERE condicion.
        /// </summary>
        public void Delete(string tabla, string where)
        {
            try
            {
                conexion.Open(); //Abre conexión con el servidor.
                string consulta = $"DELETE FROM {tabla}"; //Ej.: DELETE FROM Usuario
                if (!string.IsNullOrEmpty(where)) //Si la variable "where" no es un espacio en blanco.
                    consulta += $" WHERE {where}"; //Ej.: WHERE usuario='jcenturion630'
                MySqlCommand comando = new MySqlCommand(consulta, conexion); //Conecta la consulta con la BD.
                comando.ExecuteNonQuery(); //Ejecuta la consulta.
                conexion.Close(); //Cierra conexión con el servidor.
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al borrar datos: " + ex.Message);
            }
        }
    }
}
