using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Npgsql;

namespace DAL
{
    public class BaseDatos
    {
        protected string cadenaConexion = "Host=127.0.0.1;Port=5432;Database=postgres;Username=postgres;Password=pg123456;";

        public NpgsqlConnection conexion;

        public BaseDatos()
        {
            conexion = new NpgsqlConnection(cadenaConexion);
        }

        public ConnectionState AbrirConexion()
        {
            if (conexion.State == ConnectionState.Open)
            {
                conexion.Close();

            }
            conexion.Open();
            return conexion.State;
        }
        public void CerrarConexion()
        {
            conexion.Close();
        }
    }
}
