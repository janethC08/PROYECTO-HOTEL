using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HotelElSol
{
    public partial class MenuPrincipal : Form
    {
        public MenuPrincipal()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ConsultaHabitaciones consulta = new ConsultaHabitaciones();
            consulta.ShowDialog();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnRegistrarHabitaciones_Click(object sender, EventArgs e)
        {
            RegistrarHabitacion form = new RegistrarHabitacion();
            form.ShowDialog();
        }

        private void btnSalidaHuesped_Click(object sender, EventArgs e)
        {
            SalidaHuesped consulta = new SalidaHuesped();
            consulta.ShowDialog();
                
        }

        private void btnFacturar_Click(object sender, EventArgs e)
        {
            Facturacion form = new Facturacion();
            form.ShowDialog();
        }

        private void btnUsuarios_Click(object sender, EventArgs e)
        {
            
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
