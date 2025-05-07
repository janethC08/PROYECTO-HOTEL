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
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void BtnLogin_Click(object sender, EventArgs e)
        {
            string usuario = TxtUsuario.Text.Trim();
            string contraseña = TxtContraseña.Text.Trim();

            if (ValidarUsuario(usuario, contraseña))
            {
                MessageBox.Show("Inicio de sesión exitoso.");
                MenuPrincipal menu = new MenuPrincipal();
                menu.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Usuario o contraseña incorrectos.");
            }
        }

        private bool ValidarUsuario(string usuario, string contraseña)
        {
            Conexion conn = new Conexion();
            bool valido = false;

            using (MySqlConnection conexion = conn.AbrirConexion())
            {
                string query = "SELECT COUNT(*) FROM Usuarios WHERE NombreUsuario = @usuario AND Contraseña = @contraseña";
                using (MySqlCommand cmd = new MySqlCommand(query, conexion))
                {
                    cmd.Parameters.AddWithValue("@usuario", usuario);
                    cmd.Parameters.AddWithValue("@contraseña", contraseña);

                    int count = Convert.ToInt32(cmd.ExecuteScalar());
                    valido = (count > 0);
                }
            }

            return valido;
        }
    }
}
        
   
