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
    public partial class ConsultaHabitaciones : Form
    {
        public ConsultaHabitaciones()
        {
            InitializeComponent();
        }

        private void dgvHabitaciones_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void ConsultaHabitaciones_Load(object sender, EventArgs e)
        {
            CargarHabitaciones();
        }
        private void CargarHabitaciones()
        {
            Conexion conn = new Conexion();
            using (MySqlConnection conexion = conn.AbrirConexion())
            {
                string query = "SELECT Numero, Tipo, Precio, Estado FROM Habitaciones";
                MySqlDataAdapter da = new MySqlDataAdapter(query, conexion);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dgvHabitaciones.DataSource = dt;
            }
        }
    }
}

