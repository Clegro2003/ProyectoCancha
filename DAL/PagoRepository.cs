using ENTITY;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class PagoRepository : BaseDatos, IRepository<Pago>
    {
        public List<Pago> Consultar()
        {
            throw new NotImplementedException();
        }

        public string Eliminar(int id)
        {
            throw new NotImplementedException();
        }

        public string Guardar(Pago entity)
        {
            string sentencia = @"INSERT INTO ""CanchasDB"".pago (id_pago, reserva_id, fecha, monto)
                                 VALUES(@id_pago, @reserva_id, @fecha, @monto);";

            using (NpgsqlCommand cmd = new NpgsqlCommand(sentencia, conexion))
            {
                cmd.Parameters.AddWithValue("@id_pago", entity.IdPago);
                cmd.Parameters.AddWithValue("@reserva_id", entity.Reserva);
                cmd.Parameters.AddWithValue("@fecha", entity.Fecha);
                cmd.Parameters.AddWithValue("@monto", entity.Monto);

                try
                {
                    AbrirConexion();
                    object result = cmd.ExecuteScalar();
                    return result != null ? $"Okey... Perfecto" : "No se ha insertado el usuario.";
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

        public string Modificar(Pago entity)
        {
            throw new NotImplementedException();
        }
    }
}
