using Npgsql;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class ReporteRepository:BaseDatos
    {

        public DataTable ReservasPorDia(DateTime desde, DateTime hasta)
        {
            string query = @"
                SELECT fecha, COUNT(*) AS cantidad
                FROM ""CanchasDB"".reserva
                WHERE fecha BETWEEN @desde AND @hasta
                GROUP BY fecha
                ORDER BY fecha";

            using (var cmd = new NpgsqlCommand(query, conexion))
            {
                cmd.Parameters.AddWithValue("@desde", desde);
                cmd.Parameters.AddWithValue("@hasta", hasta);

                var tabla = new DataTable();
                try
                {
                    AbrirConexion();
                    var adapter = new NpgsqlDataAdapter(cmd);
                    adapter.Fill(tabla);
                    return tabla;
                }
                finally
                {
                    CerrarConexion();
                }
            }
        }

        public DataTable PorcentajeTipoCancha(DateTime desde, DateTime hasta)
        {
            string query = @"
        SELECT tc.nombre_cancha, COUNT(*) AS cantidad
        FROM ""CanchasDB"".reserva r
        JOIN ""CanchasDB"".cancha c ON r.id_cancha = c.id_cancha
        JOIN ""CanchasDB"".tipocancha tc ON c.id_tipocancha = tc.id_tipocancha
        WHERE r.fecha BETWEEN @desde AND @hasta
        GROUP BY tc.nombre_cancha";

            using (var cmd = new NpgsqlCommand(query, conexion))
            {
                cmd.Parameters.AddWithValue("@desde", desde);
                cmd.Parameters.AddWithValue("@hasta", hasta);

                var tabla = new DataTable();
                try
                {
                    AbrirConexion();
                    var adapter = new NpgsqlDataAdapter(cmd);
                    adapter.Fill(tabla);
                    return tabla;
                }
                finally
                {
                    CerrarConexion();
                }
            }
        }


        public DataTable ReservasPorHora(DateTime fecha)
        {
            string query = @"
        SELECT horainicio, COUNT(*) AS cantidad
        FROM ""CanchasDB"".reserva
        WHERE fecha = @fecha
        GROUP BY horainicio
        ORDER BY horainicio";

            using (var cmd = new NpgsqlCommand(query, conexion))
            {
                cmd.Parameters.AddWithValue("@fecha", fecha);

                var tabla = new DataTable();
                try
                {
                    AbrirConexion();
                    var adapter = new NpgsqlDataAdapter(cmd);
                    adapter.Fill(tabla);
                    return tabla;
                }
                finally
                {
                    CerrarConexion();
                }
            }
        }

        public int ObtenerTotalReservas(DateTime desde, DateTime hasta)
        {
            string query = @"SELECT COUNT(*) FROM ""CanchasDB"".reserva WHERE fecha BETWEEN @desde AND @hasta";
            using (var cmd = new NpgsqlCommand(query, conexion))
            {
                cmd.Parameters.AddWithValue("@desde", desde);
                cmd.Parameters.AddWithValue("@hasta", hasta);
                AbrirConexion();
                int total = Convert.ToInt32(cmd.ExecuteScalar());
                CerrarConexion();
                return total;
            }
        }

        public int ObtenerTotalHorasReservadas(DateTime desde, DateTime hasta)
        {
            string query = @"
        SELECT SUM(EXTRACT(EPOCH FROM (horafin - horainicio))/3600)
        FROM ""CanchasDB"".reserva
        WHERE fecha BETWEEN @desde AND @hasta";

            using (var cmd = new NpgsqlCommand(query, conexion))
            {
                cmd.Parameters.AddWithValue("@desde", desde);
                cmd.Parameters.AddWithValue("@hasta", hasta);
                AbrirConexion();
                var result = cmd.ExecuteScalar();
                CerrarConexion();
                return result == DBNull.Value ? 0 : Convert.ToInt32(result);
            }
        }



    }
}
