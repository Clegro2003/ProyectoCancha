using ENTITY;
using Npgsql;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class CanchaRepository: BaseDatos
    {

        public List<Cancha> ConsultarDisponible()
        {
            string sentencia = "SELECT c.id_tipocancha, c.id_cancha , t.nombre_cancha , precio FROM postgres.\"CanchasDB\".tipocancha t " +
                                "JOIN postgres.\"CanchasDB\".cancha c ON t.id_tipocancha = c.id_tipocancha " +
                                "WHERE c.estado = 'DISPONIBLE' ";
            NpgsqlCommand cmd = new NpgsqlCommand(sentencia, conexion);
            AbrirConexion();
            NpgsqlDataReader reader = cmd.ExecuteReader();

            List<Cancha> canchas = new List<Cancha>();
            while (reader.Read())
            {
                canchas.Add(new Cancha
                {
                    TipoCanchaId = new TipoCancha
                    {
                        TipoId = reader.GetInt32(reader.GetOrdinal("id_tipocancha"))
                    },
                    Nombre_Cancha = reader.GetString(reader.GetOrdinal("nombre_cancha")),
                    Precio = reader.GetInt32(reader.GetOrdinal("precio")),
                    Id_cancha = reader.GetInt32(reader.GetOrdinal("id_cancha"))

                });
            }

            CerrarConexion();
            return canchas;
        }

    }
}
