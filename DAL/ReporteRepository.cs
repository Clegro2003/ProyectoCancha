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

        public DataTable PorcentajeTipoCancha()
        {
            string query = @"
                SELECT tc.nombre_cancha, COUNT(*) AS cantidad
                FROM ""CanchasDB"".reserva r
                JOIN ""CanchasDB"".cancha c ON r.id_cancha = c.id_cancha
                JOIN ""CanchasDB"".tipocancha tc ON c.id_tipocancha = tc.id_tipocancha
                GROUP BY tc.nombre_cancha";

            using (var cmd = new NpgsqlCommand(query, conexion))
            {
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

    }
}
