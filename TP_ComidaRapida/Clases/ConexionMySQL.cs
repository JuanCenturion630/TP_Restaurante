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
                fila = comando.ExecuteScalar(); //Ejecuta la consulta.

                conexion.Close(); //Cierra conexión con el servidor.
            }
            catch(MySqlException ex)
            {
                MessageBox.Show("Error al conectar con la base de datos.\n\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error:\n\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return fila;
        }

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
            catch (MySqlException ex)
            {
                MessageBox.Show("Error al conectar con la base de datos.\n\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error:\n\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            catch (MySqlException ex)
            {
                MessageBox.Show("Error al conectar con la base de datos.\n\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error:\n\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            catch (MySqlException ex)
            {
                MessageBox.Show("Error al conectar con la base de datos.\n\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error:\n\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void RellenarDGV(DataGridView dgv, string store_procedure)
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
            catch (MySqlException ex)
            {
                MessageBox.Show("Error al conectar con la base de datos.\n\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error:\n\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void RellenarDGV(DataGridView dgv, string columna, string tabla, string where)
        {
            try
            {
                conexion.Open(); //Abre conexión con el servidor.

                string consulta = $"SELECT {columna} FROM {tabla}";
                if (!string.IsNullOrEmpty(where)) //Si la variable "where" no es un espacio en blanco.
                    consulta += $" WHERE {where}";

                MySqlCommand comando = new MySqlCommand(consulta, conexion); //Conecta la consulta con la BD.
                MySqlDataReader datos = comando.ExecuteReader(); //Trae datos de la tabla a la aplicación en función de la consulta.
                DataTable tablaVirtual = new DataTable(); //Crea una tabla virtual para darle formato al objeto "datos".

                tablaVirtual.Load(datos); //Carga los datos en la tabla virtual.
                dgv.DataSource = tablaVirtual; //Rellena el DataGridView con el DataTable.

                conexion.Close(); //Cierra conexión con el servidor.
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Error al conectar con la base de datos.\n\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error:\n\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void RellenarComboBox(ComboBox cmb, string columna, string tabla, string where)
        {
            try
            {
                conexion.Open(); //Abre conexión con el servidor.

                string consulta = $"SELECT {columna} FROM {tabla}";
                if (!string.IsNullOrEmpty(where)) //Si la variable "where" no es un espacio en blanco.
                    consulta += $" WHERE {where}";

                MySqlCommand comando = new MySqlCommand(consulta, conexion); //Conecta la consulta con la BD.
                MySqlDataReader datos = comando.ExecuteReader();

                if (datos.HasRows) //Verifica si la tabla tiene filas en primer lugar.
                {
                    while (datos.Read()) //Mientras la tabla encuentre una nueva fila, recorrerla.
                    {
                        //De la fila actual, obtiene el valor de una columna concreta...
                        string texto = datos.GetString("usuario");
                        cmb.Items.Add(texto);
                    }
                }
                else
                    cmb.Items.Add("");

                conexion.Close(); //Cierra conexión con el servidor.
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Error al conectar con la base de datos.\n\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error:\n\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void Consulta(string consulta)
        {
            try
            {
                conexion.Open(); //Abre conexión con el servidor.
                MySqlCommand comando = new MySqlCommand(consulta, conexion); //Conecta la consulta con la BD.
                comando.ExecuteNonQuery(); //Ejecuta la consulta.
                conexion.Close(); //Cierra conexión con el servidor.
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Error al conectar con la base de datos.\n\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error:\n\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
