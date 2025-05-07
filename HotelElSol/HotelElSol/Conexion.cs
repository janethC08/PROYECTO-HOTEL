using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace HotelElSol
{
    class Conexion
    {
        private MySqlConnection conexion;

        public MySqlConnection AbrirConexion()
        {
            string cadena = "server=localhost;user=root;password=;database=HotelElSol;";
            conexion = new MySqlConnection(cadena);
            conexion.Open();
            return conexion;
        }

        public void CerrarConexion()
        {
            if (conexion != null && conexion.State == System.Data.ConnectionState.Open)
            {
                conexion.Close();
            }
        }
    }
}

    

