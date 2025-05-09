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
    public partial class Facturacion : Form
    {
        public Facturacion()
        {
            InitializeComponent();
        }

        private void Facturacion_Load(object sender, EventArgs e)
        {
            CargarReservasFinalizadas();
        }
        private void CargarReservasFinalizadas()
        {
            cmbReservas.Items.Clear();

            Conexion conn = new Conexion();
            using (MySqlConnection conexion = conn.AbrirConexion())
            {
                string query = @"SELECT r.IdReserva, h.NombreCompleto
                                 FROM reservas r
                                 JOIN huespedes h ON r.IdHuesped = h.IdHuesped
                                 WHERE r.Estado = 'Finalizada'";

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

        private void btnCalcular_Click(object sender, EventArgs e)
        {
            ComboItem seleccion = cmbReservas.SelectedItem as ComboItem;
            if (seleccion == null)
            {
                MessageBox.Show("Seleccione una reserva finalizada.");
                return;
            }

            int idReserva = seleccion.Value;

            using (MySqlConnection conexion = new Conexion().AbrirConexion())
            {
                string consulta = @"SELECT DATEDIFF(FechaSalida, FechaEntrada) AS Dias, h.Precio
                                    FROM reservas r
                                    JOIN habitaciones h ON r.IdHabitacion = h.IdHabitacion
                                    WHERE r.IdReserva = @id";

                MySqlCommand cmd = new MySqlCommand(consulta, conexion);
                cmd.Parameters.AddWithValue("@id", idReserva);

                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        int dias = reader.GetInt32("Dias");
                        decimal precio = reader.GetDecimal("Precio");
                        decimal total = dias * precio;

                        lblDias.Text = dias + " día(s)";
                        lblPrecio.Text = "$" + precio.ToString("0.00");
                        lblTotal.Text = "$" + total.ToString("0.00");

                        // Guardamos el total en el Tag del label para usarlo al facturar
                        lblTotal.Tag = total;
                    }
                    else
                    {
                        MessageBox.Show("No se pudo calcular.");
                    }
                }
            }
        }
    

        private void btnFacturar_Click(object sender, EventArgs e)
        {
            ComboItem seleccion = cmbReservas.SelectedItem as ComboItem;
            if (seleccion == null || lblTotal.Tag == null)
            {
                MessageBox.Show("Primero seleccione y calcule una reserva.");
                return;
            }

            int idReserva = seleccion.Value;
            decimal total = (decimal)lblTotal.Tag;

            using (MySqlConnection conexion = new Conexion().AbrirConexion())
            {
                string query = @"INSERT INTO facturas (IdReserva, FechaEmision, Total)
                                 VALUES (@reserva, CURDATE(), @total)";

                MySqlCommand cmd = new MySqlCommand(query, conexion);
                cmd.Parameters.AddWithValue("@reserva", idReserva);
                cmd.Parameters.AddWithValue("@total", total);
                cmd.ExecuteNonQuery();
            }

            MessageBox.Show("Factura generada correctamente.");
            this.Close();
        }

        // Clase para manejar el ComboBox con nombre + ID
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
    }
}
        
        