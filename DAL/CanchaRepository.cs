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
        public List<Cancha> Consultar()
        {
            string sentencia = "";
            NpgsqlCommand cmd = new NpgsqlCommand(sentencia, conexion);
            AbrirConexion();
            NpgsqlDataReader reader = cmd.ExecuteReader();

            List<Cancha> canchas = new List<Cancha>();
            while (reader.Read())
            {
                canchas.Add
                (
                    new Cancha
                    {
                        Id_cancha = reader.GetInt32(reader.GetOrdinal("id_cancha")),
                        Nombre_Cancha = reader.GetString(reader.GetOrdinal("nombre_cancha")),
                        Estado = reader.GetString(reader.GetOrdinal("estado")),
                        Precio = reader.GetDecimal(reader.GetOrdinal("precio"))
                    }
                );

            }

            return canchas;
        }

        public List<Cancha> ConsultarDisponible()
        {
            string sentencia = "SELECT c.id_cancha , t.nombre_cancha , precio FROM postgres.\"CanchasDB\".tipocancha t " +
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
                    Nombre_Cancha = reader.GetString(reader.GetOrdinal("nombre_cancha")),
                    Precio = reader.GetInt32(reader.GetOrdinal("precio")),
                    Id_cancha = reader.GetInt32(reader.GetOrdinal("id_cancha"))
                    
                });
            }

            CerrarConexion();
            return canchas;
        }

        public string Eliminar(int id)
        {
            throw new NotImplementedException();
        }

        public string Guardar(Cancha entity)
        {
            throw new NotImplementedException();
        }

        public string Modificar(Cancha entity)
        {
            throw new NotImplementedException();
        }
    }
}
