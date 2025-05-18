using ENTITY;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class ReservaRepository:BaseDatos,IRepository<Reserva>
    {
        public string Guardar(Reserva entity)
        {
            if (entity == null)
                return "Reserva inválida";

            string sentencia = @"
                INSERT INTO postgres.""CanchasDB"".reserva
                (id_cancha, id_usuario, fecha, hora_inicio, hora_fin, estado)
                VALUES(@id_cancha, @id_usuario, @fecha, @hora_inicio, @hora_fin, @estado)
                RETURNING id_reserva";

            using (NpgsqlCommand cmd = new NpgsqlCommand(sentencia, conexion))
            {
                cmd.Parameters.AddWithValue("@id_cancha", entity.IdCancha);
                cmd.Parameters.AddWithValue("@id_usuario", entity.IdUsuario);
                cmd.Parameters.AddWithValue("@fecha", entity.Fecha);
                cmd.Parameters.AddWithValue("@hora_inicio", entity.HoraInicio);
                cmd.Parameters.AddWithValue("@hora_fin", entity.HoraFin);
                cmd.Parameters.AddWithValue("@estado", entity.Estado);

                try
                {
                    AbrirConexion();
                    object result = cmd.ExecuteScalar();
                    return result != null ? $"Reserva registrada con ID {result}" : "No se ha insertado la reserva.";
                }
                catch (PostgresException ex)
                {
                    return $"Error de PostgreSQL: {ex.Message}";
                }
                catch (Exception ex)
                {
                    return $"Error general: {ex.Message}";
                }
                finally
                {
                    CerrarConexion();
                }
            }
        }

        public List<Reserva> Consultar()
        {
            string sentencia = "SELECT * FROM postgres.\"CanchasDB\".reserva";
            NpgsqlCommand cmd = new NpgsqlCommand(sentencia, conexion);
            AbrirConexion();
            NpgsqlDataReader reader = cmd.ExecuteReader();

            List<Reserva> reservas = new List<Reserva>();
            while (reader.Read())
            {
                reservas.Add(new Reserva
                {
                    IdReserva = reader.GetInt32(reader.GetOrdinal("id_reserva")),
                    IdCancha = reader.GetInt32(reader.GetOrdinal("id_cancha")),
                    IdUsuario = reader.GetInt32(reader.GetOrdinal("id_usuario")),
                    Fecha = reader.GetDateTime(reader.GetOrdinal("fecha")),
                    HoraInicio = reader.GetTimeSpan(reader.GetOrdinal("hora_inicio")),
                    HoraFin = reader.GetTimeSpan(reader.GetOrdinal("hora_fin")),
                    Estado = reader.GetString(reader.GetOrdinal("estado"))
                });
            }

            CerrarConexion();
            return reservas;
        }

        public string Eliminar(int id)
        {
            throw new NotImplementedException();
        }

        public string Modificar(Reserva entity)
        {
            throw new NotImplementedException();
        }
    }
}
