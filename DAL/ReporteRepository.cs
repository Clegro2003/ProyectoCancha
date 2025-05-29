using ENTITY;
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


        
        public List<Reserva> ObtenerReservasPorRango(DateTime desde, DateTime hasta)
        {
            var reservas = new List<Reserva>();
            string query = @"
                SELECT r.reserva_id, r.id_cancha, r.usuario_id, r.fecha, r.horainicio, r.horafin, r.estado,
                       t.nombre_cancha
                FROM ""CanchasDB"".reserva r
                JOIN ""CanchasDB"".cancha c ON r.id_cancha = c.id_cancha
                JOIN ""CanchasDB"".tipocancha t ON t.id_tipoCancha = c.id_tipoCancha
                WHERE r.fecha BETWEEN @desde AND @hasta
                ORDER BY r.fecha, r.horainicio;";

            using (var cmd = new NpgsqlCommand(query, conexion))
            {
                cmd.Parameters.AddWithValue("@desde", desde.Date);
                cmd.Parameters.AddWithValue("@hasta", hasta.Date);

                AbrirConexion();
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var cancha = new Cancha
                        {
                            Nombre_Cancha = reader["nombre_cancha"].ToString()
                        };

                        var reserva = new Reserva
                        {
                            IdReserva = Convert.ToInt32(reader["reserva_id"]),
                            IdCancha = Convert.ToInt32(reader["id_cancha"]),
                            IdUsuario = Convert.ToInt32(reader["usuario_id"]),
                            Fecha = Convert.ToDateTime(reader["fecha"]),
                            HoraInicio = (TimeSpan)reader["horainicio"],
                            HoraFin = (TimeSpan)reader["horafin"],
                            Estado = reader["estado"].ToString(),
                            Cancha = cancha
                        };

                        reservas.Add(reserva);
                    }
                }
                CerrarConexion();
            }

            return reservas;
        }

    }
}
