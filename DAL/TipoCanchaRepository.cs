using ENTITY;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class TipoCanchaRepository : BaseDatos
    {
        public List<TipoCancha> Consultar()
        {
            string sentencia = "SELECT id_tipocancha,nombre_cancha FROM postgres.\"CanchasDB\".tipocancha";
            var lista = new List<TipoCancha>();

            using (var cmd = new NpgsqlCommand(sentencia, conexion))
            {
                AbrirConexion();
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        lista.Add(new TipoCancha
                        {
                            TipoId = reader.GetInt32(reader.GetOrdinal("id_tipocancha")),
                            NombreCancha = reader.GetString(reader.GetOrdinal("nombre_cancha"))
                        });
                    }
                }
                CerrarConexion();
            }

            return lista;
        }
    }
}
