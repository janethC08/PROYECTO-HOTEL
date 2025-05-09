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
    public partial class SalidaHuesped : Form
    {
        public SalidaHuesped()
        {
            InitializeComponent();
        }
        private void CargarReservasActivas()
        {
            cmbReservas.Items.Clear();
            Conexion conn = new Conexion();

            using (MySqlConnection conexion = conn.AbrirConexion())
            {
                string query = @"SELECT r.IdReserva, h.NombreCompleto 
                                 FROM reservas r
                                 JOIN huespedes h ON r.IdHuesped = h.IdHuesped
                                 WHERE r.Estado = 'Activa'";

                using (MySqlCommand cmd = new MySqlCommand(query, conexion))
                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        int idReserva = reader.GetInt32("IdReserva");
                        string nombre = reader.GetString("NombreCompleto");

                        cmbReservas.Items.Add(new ComboItem(nombre, idReserva));
                    }
                }
            }

            if (cmbReservas.Items.Count > 0)
                cmbReservas.SelectedIndex = 0;
        }

       

        private void btnCheckout_Click(object sender, EventArgs e)
        {
            ComboItem reservaSeleccionada = cmbReservas.SelectedItem as ComboItem;
            if (reservaSeleccionada != null)
            {
                int idReserva = reservaSeleccionada.Value;

                Conexion conn = new Conexion();
                using (MySqlConnection conexion = conn.AbrirConexion())
                {
                    // 1. Obtener el IdHabitacion desde la reserva
                    string obtenerHabitacion = "SELECT IdHabitacion FROM reservas WHERE IdReserva = @id";
                    MySqlCommand cmd1 = new MySqlCommand(obtenerHabitacion, conexion);
                    cmd1.Parameters.AddWithValue("@id", idReserva);
                    int idHabitacion = Convert.ToInt32(cmd1.ExecuteScalar());

                    // 2. Cambiar estado de la reserva a "Finalizada"
                    string actualizarReserva = "UPDATE reservas SET Estado = 'Finalizada' WHERE IdReserva = @id";
                    MySqlCommand cmd2 = new MySqlCommand(actualizarReserva, conexion);
                    cmd2.Parameters.AddWithValue("@id", idReserva);
                    cmd2.ExecuteNonQuery();

                    // 3. Cambiar estado de la habitación a "Disponible"
                    string actualizarHabitacion = "UPDATE habitaciones SET Estado = 'Disponible' WHERE IdHabitacion = @id";
                    MySqlCommand cmd3 = new MySqlCommand(actualizarHabitacion, conexion);
                    cmd3.Parameters.AddWithValue("@id", idHabitacion);
                    cmd3.ExecuteNonQuery();

                    MessageBox.Show("Check-out realizado correctamente.");
                    this.Close();
                }
            }
            else
            {
                MessageBox.Show("Seleccione una reserva válida.");
            }
        }
        

        // Clase interna para usar en el ComboBox
        private class ComboItem
        {
            public string Text { get; set; }
            public int Value { get; set; }

            public ComboItem(string text, int value)
            {
                Text = text;
                Value = value;
            }

            public override string ToString()
            {
                return Text;
            }
        }
    

        
    

        private void SalidaHuesped_Load(object sender, EventArgs e)
        {
            CargarReservasActivas();
        }
    }
}
