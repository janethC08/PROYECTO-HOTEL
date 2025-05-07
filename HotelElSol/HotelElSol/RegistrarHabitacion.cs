using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace HotelElSol
{
    public partial class RegistrarHabitacion : Form
    {
        public RegistrarHabitacion()
        {
            InitializeComponent();
            CargarHabitacionesDisponibles();
        }
        private void CargarHabitacionesDisponibles()
        {
            Conexion conn = new Conexion();
            cmbHabitaciones.Items.Clear();

            using (MySqlConnection conexion = conn.AbrirConexion())
            {
                string query = "SELECT IdHabitacion, Numero FROM Habitaciones WHERE Estado = 'Disponible'";
                using (MySqlCommand cmd = new MySqlCommand(query, conexion))
                {
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            cmbHabitaciones.Items.Add(new ComboBoxItem(
                                reader.GetString("Numero"),
                                reader.GetInt32("IdHabitacion")
                            ));
                        }
                    }
                }
            }
        }

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            try
            {
                string nombre = txtNombre.Text.Trim();
                string documento = txtDocumento.Text.Trim();
                string telefono = txtTelefono.Text.Trim();
                string email = txtEmail.Text.Trim();
                DateTime entrada = dtpEntrada.Value;
                DateTime salida = dtpSalida.Value;

                if (cmbHabitaciones.SelectedItem == null)
                {
                    MessageBox.Show("Selecciona una habitación.");
                    return;
                }

                int habitacionId = ((ComboBoxItem)cmbHabitaciones.SelectedItem).Value;

                Conexion conn = new Conexion();
                using (MySqlConnection conexion = conn.AbrirConexion())
                {
                    // Insertar huésped
                    string insertHuesped = "INSERT INTO huespedes (NombreCompleto, DocumentoIdentidad, Telefono, Email) VALUES (@nombre, @documento, @telefono, @email)";
                    MySqlCommand cmdHuesped = new MySqlCommand(insertHuesped, conexion);
                    cmdHuesped.Parameters.AddWithValue("@nombre", nombre);
                    cmdHuesped.Parameters.AddWithValue("@documento", documento);
                    cmdHuesped.Parameters.AddWithValue("@telefono", telefono);
                    cmdHuesped.Parameters.AddWithValue("@email", email);
                    cmdHuesped.ExecuteNonQuery();

                    long idHuesped = cmdHuesped.LastInsertedId;

                    // Insertar reserva
                    string insertReserva = "INSERT INTO reservas (IdHuesped, IdHabitacion, FechaEntrada, FechaSalida) VALUES (@huesped, @habitacion, @entrada, @salida)";
                    MySqlCommand cmdReserva = new MySqlCommand(insertReserva, conexion);
                    cmdReserva.Parameters.AddWithValue("@huesped", idHuesped);
                    cmdReserva.Parameters.AddWithValue("@habitacion", habitacionId);
                    cmdReserva.Parameters.AddWithValue("@entrada", entrada);
                    cmdReserva.Parameters.AddWithValue("@salida", salida);
                    cmdReserva.Parameters.AddWithValue("@estado", "Activa");
                    cmdReserva.ExecuteNonQuery();

                    // Actualizar estado de habitación a Ocupada
                    string actualizarHabitacion = "UPDATE habitaciones SET Estado = 'Ocupada' WHERE IdHabitacion = @id";
                    MySqlCommand cmdActualizar = new MySqlCommand(actualizarHabitacion, conexion);
                    cmdActualizar.Parameters.AddWithValue("@id", habitacionId);
                    cmdActualizar.ExecuteNonQuery();

                    MessageBox.Show("Check-in realizado correctamente.");
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al registrar: " + ex.Message);
            }
        }



        

        private class ComboBoxItem
        {
            public string Text { get; set; }
            public int Value { get; set; }

            public ComboBoxItem(string text, int value)
            {
                Text = text;
                Value = value;
            }

            public override string ToString()
            {
                return Text;
            }
        }
    }
}


        
    

